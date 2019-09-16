using System;
using System.IO;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadModList().Wait();
        }

        private void PickModFolderBtn_Click(object sender, EventArgs e)
        {
            if (modDirDialog.ShowDialog() == DialogResult.OK)
            {
                modPathBox.Text = modDirDialog.SelectedPath;
            }
        }

        private void PickGameFolderBtn_Click(object sender, EventArgs e)
        {
            if (gameDirDialog.ShowDialog() == DialogResult.OK)
            {
                gamePathBox.Text = gameDirDialog.SelectedPath;
            }
        }

        private void GamePathBox_Validating(object sender, CancelEventArgs e)
        {
            if (Program.IsWritablePath(gamePathBox.Text))
            {
                gameDirDialog.SelectedPath = gamePathBox.Text;
            }
        }

        private void ModPathBox_Validating(object sender, CancelEventArgs e)
        {
            if (Directory.Exists(modPathBox.Text))
            {
                modDirDialog.SelectedPath = modPathBox.Text;
            }
        }

        private void NameBox_Validating(object sender, CancelEventArgs e)
        {
            nameBox.Text = Regex.Replace(nameBox.Text, @"[\.\s/<:>\\\|\?\*""]", string.Empty);
        }

        private bool ControlsEnabled
        {
            set
            {
                installGroupBox.Enabled =
                    manageGroupBox.Enabled = value;
            }
        }

        private async Task LoadModList()
        {
            ControlsEnabled = false;

            activeModsList.Items.Clear();
            activeModsList.Items.AddRange(await Program.GetModListAsync());

            disabledModsList.Items.Clear();
            disabledModsList.Items.AddRange(await Program.GetModListAsync(false));

            ControlsEnabled = true;
        }

        private async Task PerformOperation(Func<string, Task> operation, string modName)
        {
            if (modName != null)
            {
                try
                {
                    ControlsEnabled = false;
                    await operation(modName);
                    await LoadModList();
                }
                catch (Exception ex)
                {
                    ControlsEnabled = true;
                    DisplayException(ex);
                }
            }
        }

        private void DisplayException(Exception ex)
        {
            MessageBox.Show($"{ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void Install_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(modPathBox.Text) &&
                Program.IsWritablePath(gamePathBox.Text) &&
                Program.IsValidExt(nameBox.Text))
            {
                try
                {
                    ControlsEnabled = false;
                    await Program.InstallModAsync(nameBox.Text, gamePathBox.Text, modPathBox.Text);
                    await LoadModList();
                }
                catch (Exception ex)
                {
                    ControlsEnabled = true;
                    DisplayException(ex);
                }
            }
            else
            {
                MessageBox.Show("Путь и/или расширения заданы некорректно", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActiveModsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            disabledModsList.SelectedIndexChanged -= DisabledModsList_SelectedIndexChanged;
            disabledModsList.ClearSelected();
            disabledModsList.SelectedIndexChanged += DisabledModsList_SelectedIndexChanged;
            enableBtn.Enabled = false;
            delBtn.Enabled = disableBtn.Enabled =
                activeModsList.SelectedItem != null;
        }

        private void DisabledModsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            activeModsList.SelectedIndexChanged -= ActiveModsList_SelectedIndexChanged;
            activeModsList.ClearSelected();
            activeModsList.SelectedIndexChanged += ActiveModsList_SelectedIndexChanged;
            disableBtn.Enabled = false;
            delBtn.Enabled = enableBtn.Enabled =
                disabledModsList.SelectedItem != null;
        }

        private async void DisableBtn_Click(object sender, EventArgs e)
        {
            string modName = activeModsList.SelectedItem?.ToString();
            await PerformOperation(Program.DisableModAsync, modName);
            object itemToSelect;
            if ((itemToSelect = disabledModsList.Items.OfType<string>().
                FirstOrDefault(s => s == modName)) != null)
            {
                disabledModsList.SelectedItem = itemToSelect;
            }
        }

        private async void EnableBtn_Click(object sender, EventArgs e)
        {
            string modName = disabledModsList.SelectedItem?.ToString();
            await PerformOperation(Program.EnableModAsync, modName);
            object itemToSelect;
            if ((itemToSelect = activeModsList.Items.OfType<string>().
                FirstOrDefault(s => s == modName)) != null)
            {
                activeModsList.SelectedItem = itemToSelect;
            }
        }

        private async void DelBtn_Click(object sender, EventArgs e)
        {
            string modName =
                disabledModsList.SelectedItem?.ToString() ??
                activeModsList.SelectedItem?.ToString();
            await PerformOperation(Program.DeleteModAsync, modName);
        }
    }
}
