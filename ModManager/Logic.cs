using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ModManager
{
    static partial class Program
    {
        #region string const
        private const string disabled = "disabled";
        private const string root = "files";
        private const string newSubtree = "newFiles";
        private const string replacedSubtree = "replacedFiles";
        private const string pathEntry = "path";
        private const string nameAttr = "name";
        private const string versionAttr = "version";
        private const string version = "1";

        private static readonly string appFolder =
           Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ModManager");
        #endregion

        #region converts
        public static string ResolveXmlPath(string modName, bool isDisabled = false)
        {
            string filename = $"{modName}.xml";
            if (isDisabled)
            {
                return Path.Combine(appFolder, disabled, filename);
            }
            else
            {
                return Path.Combine(appFolder, filename);
            }
        }

        private static string BackupExtension(string modName) => $".backup_{modName}";

        private static string DisabledExtension(string modName) => $".disabled_{modName}";

        #endregion

        #region checks

        public static bool IsValidExt(string ext)
        {
            return !(string.IsNullOrWhiteSpace(ext) || ext.Any(c => Path.GetInvalidFileNameChars().Contains(c)));

        }

        public static bool ModExists(string modName, out bool? isDisabled)
        {
            if (File.Exists(ResolveXmlPath(modName)))
            {
                isDisabled = false;
                return true;
            }
            else if (File.Exists(ResolveXmlPath(modName, isDisabled: true)))
            {
                isDisabled = true;
                return true;
            }
            else
            {
                isDisabled = null;
                return false;
            }
        }

        private static bool HasWriteAccessToFolder(string folderPath)
        {
            try
            {
                DirectorySecurity ds = Directory.GetAccessControl(folderPath);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }

        public static bool IsWritablePath(string path)
        {
            return Directory.Exists(path) && HasWriteAccessToFolder(path);
        }

        #endregion

        #region IO and file operations

        private static void SwapExtensions(List<string> replacedFiles, string currentExt, string newExt)
        {
            foreach (string filename in replacedFiles)
            {
                File.Replace(filename + currentExt, filename, filename + newExt);
            }
        }

        private static void SaveXml(string modName, List<string> newFiles, List<string> replacedFiles)
        {
            Directory.CreateDirectory(appFolder);
            string path = ResolveXmlPath(modName);
            XDocument xdoc = new XDocument();
            XElement docRoot = new XElement(root);
            XElement newRoot = new XElement(newSubtree);
            XElement replacedRoot = new XElement(replacedSubtree);
            docRoot.SetAttributeValue(versionAttr, version);
            docRoot.SetAttributeValue(nameAttr, modName);
            foreach (string f in newFiles)
            {
                newRoot.Add(new XElement(pathEntry)
                {
                    Value = f
                });
            }
            foreach (string f in replacedFiles)
            {
                replacedRoot.Add(new XElement(pathEntry)
                {
                    Value = f
                });
            }
            docRoot.Add(newRoot);
            docRoot.Add(replacedRoot);
            xdoc.Add(docRoot);
            xdoc.Save(path);
        }

        private static void RetrieveXml(string modName, out List<string> newFiles, out List<string> replacedFiles, bool isDisabled = false)
        {
            string path = ResolveXmlPath(modName, isDisabled);
            XDocument xdoc = XDocument.Load(path);
            XElement docRoot = xdoc.Element(root);
            if (docRoot.Attribute(versionAttr).Value != version)
            {
                throw new Exception(
                    $"Этот мод был установлен другой версией программы, удалите его вручную{Environment.NewLine}Пути к заменённым файлам находятся в XML-файле:{Environment.NewLine}{path}");
            }
            newFiles = docRoot.Element(newSubtree).Elements().
            Select(e => e.Value).ToList();
            replacedFiles = docRoot.Element(replacedSubtree).Elements().
            Select(e => e.Value).ToList();
        }

        private static string[] GetModList(bool enabled)
        {
            string disabledFolder = Path.Combine(appFolder, disabled);
            Directory.CreateDirectory(disabledFolder);
            DirectoryInfo dirInfo = new DirectoryInfo(enabled ? appFolder : disabledFolder);
            FileInfo[] allFiles = dirInfo.GetFiles();
            return allFiles.Select(f => Path.GetFileNameWithoutExtension(f.Name)).ToArray();
        }

        #endregion

        #region private sync mod-manage methods

        private static void InstallMod(DirectoryInfo gameDir, DirectoryInfo modDir, string modName)
        {
            List<string> newFiles = new List<string>();
            List<string> replacedFiles = new List<string>();
            FileInfo[] allFiles = modDir.GetFiles("*", SearchOption.AllDirectories);
            int index = modDir.FullName.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).Length + 1;
            string gds = gameDir.FullName;
            string backupExt = BackupExtension(modName);
            foreach (FileInfo modFile in allFiles)
            {
                string origFileName = Path.Combine(gds, modFile.FullName.Substring(index));
                FileInfo origFile = new FileInfo(origFileName);
                if (origFile.Exists)
                {
                    origFile.MoveTo(origFileName + backupExt);
                    replacedFiles.Add(origFileName);
                }
                else
                {
                    origFile.Directory.Create();
                    newFiles.Add(origFileName);
                }
                modFile.CopyTo(origFileName);
            }
            SaveXml(modName, newFiles, replacedFiles);
        }

        private static void DisableMod(string modName)
        {
            RetrieveXml(modName, out List<string> newFiles, out List<string> replacedFiles);
            string currentExt = BackupExtension(modName);
            string newExt = DisabledExtension(modName);
            SwapExtensions(replacedFiles, currentExt, newExt);
            foreach (string f in newFiles)
            {
                File.Move(f, f + newExt);
            }
            File.Move(ResolveXmlPath(modName),
            ResolveXmlPath(modName, isDisabled: true));
        }

        private static void EnableMod(string modName)
        {
            File.Move(ResolveXmlPath(modName, isDisabled: true),
            ResolveXmlPath(modName));
            RetrieveXml(modName, out List<string> newFiles, out List<string> replacedFiles);
            string currentExt = DisabledExtension(modName);
            string newExt = BackupExtension(modName);
            SwapExtensions(replacedFiles, currentExt, newExt);

            foreach (string f in newFiles)
            {
                File.Move(f + currentExt, f);
            }
        }

        private static void DeleteMod(string modName, bool isDisabled)
        {
            if (!isDisabled)
            {
                DisableMod(modName);
            }
            RetrieveXml(modName, out List<string> newFiles, out List<string> replacedFiles, true);
            File.Delete(ResolveXmlPath(modName, true));
            string disabledExt = DisabledExtension(modName);
            foreach (string f in newFiles.Concat(replacedFiles))
            {
                File.Delete(f + disabledExt);
            }
        }

        #endregion

        #region public async wrappers

        public static Task InstallModAsync(string modName, string gameDirPath, string modDirPath)
        {
            DirectoryInfo gameDir = new DirectoryInfo(gameDirPath);
            DirectoryInfo modDir = new DirectoryInfo(modDirPath);
            if (ModExists(modName, out _))
            {
                throw new Exception("Такое имя мода уже используется");
            }
            InstallMod(gameDir, modDir, modName);
            return Task.CompletedTask;
        }

        public static Task DisableModAsync(string modName)
        {
            if (ModExists(modName, out bool? isDisabled))
            {
                if (!isDisabled.Value)
                {
                    DisableMod(modName);
                }
            }
            else
            {
                throw new Exception("Мода с таким именем не существует");
            }
            return Task.CompletedTask;
        }

        public static Task EnableModAsync(string modName)
        {
            if (ModExists(modName, out bool? isDisabled))
            {
                if (isDisabled.Value)
                {
                    EnableMod(modName);
                }
            }
            else
            {
                throw new Exception("Мода с таким именем не существует");
            }
            return Task.CompletedTask;
        }

        public static Task DeleteModAsync(string modName)
        {
            if (ModExists(modName, out bool? isDisabled))
            {
                DeleteMod(modName, isDisabled.Value);
            }
            else
            {
                throw new Exception("Мода с таким именем не существует");
            }
            return Task.CompletedTask;
        }

        public static Task<string[]> GetModListAsync(bool enabled = true)
        {
            return Task.FromResult(GetModList(enabled));
        }

        #endregion
    }
}