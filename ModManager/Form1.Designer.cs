namespace ModManager
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.modPathBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.pickModFolderBtn = new System.Windows.Forms.Button();
            this.installBtn = new System.Windows.Forms.Button();
            this.modDirDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.installGroupBox = new System.Windows.Forms.GroupBox();
            this.pickGameFolderBtn = new System.Windows.Forms.Button();
            this.gamePathBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.manageGroupBox = new System.Windows.Forms.GroupBox();
            this.delBtn = new System.Windows.Forms.Button();
            this.disableBtn = new System.Windows.Forms.Button();
            this.enableBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.disabledModsList = new System.Windows.Forms.ListBox();
            this.activeModsList = new System.Windows.Forms.ListBox();
            this.gameDirDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.installGroupBox.SuspendLayout();
            this.manageGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "(папки должны соответствовать)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Название для мода ";
            // 
            // modPathBox
            // 
            this.modPathBox.Location = new System.Drawing.Point(12, 32);
            this.modPathBox.Name = "modPathBox";
            this.modPathBox.Size = new System.Drawing.Size(174, 20);
            this.modPathBox.TabIndex = 1;
            this.modPathBox.Validating += new System.ComponentModel.CancelEventHandler(this.ModPathBox_Validating);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(119, 116);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(139, 20);
            this.nameBox.TabIndex = 5;
            this.nameBox.Validating += new System.ComponentModel.CancelEventHandler(this.NameBox_Validating);
            // 
            // pickModFolderBtn
            // 
            this.pickModFolderBtn.Location = new System.Drawing.Point(192, 29);
            this.pickModFolderBtn.Name = "pickModFolderBtn";
            this.pickModFolderBtn.Size = new System.Drawing.Size(66, 25);
            this.pickModFolderBtn.TabIndex = 2;
            this.pickModFolderBtn.Text = "Обзор...";
            this.pickModFolderBtn.UseVisualStyleBackColor = true;
            this.pickModFolderBtn.Click += new System.EventHandler(this.PickModFolderBtn_Click);
            // 
            // installBtn
            // 
            this.installBtn.Location = new System.Drawing.Point(264, 29);
            this.installBtn.Name = "installBtn";
            this.installBtn.Size = new System.Drawing.Size(66, 107);
            this.installBtn.TabIndex = 6;
            this.installBtn.Text = "Начать";
            this.installBtn.UseVisualStyleBackColor = true;
            this.installBtn.Click += new System.EventHandler(this.Install_Click);
            // 
            // modDirDialog
            // 
            this.modDirDialog.ShowNewFolderButton = false;
            // 
            // installGroupBox
            // 
            this.installGroupBox.Controls.Add(this.pickGameFolderBtn);
            this.installGroupBox.Controls.Add(this.installBtn);
            this.installGroupBox.Controls.Add(this.gamePathBox);
            this.installGroupBox.Controls.Add(this.nameBox);
            this.installGroupBox.Controls.Add(this.label4);
            this.installGroupBox.Controls.Add(this.label2);
            this.installGroupBox.Controls.Add(this.pickModFolderBtn);
            this.installGroupBox.Controls.Add(this.label1);
            this.installGroupBox.Controls.Add(this.label3);
            this.installGroupBox.Controls.Add(this.modPathBox);
            this.installGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.installGroupBox.Location = new System.Drawing.Point(0, 0);
            this.installGroupBox.Name = "installGroupBox";
            this.installGroupBox.Size = new System.Drawing.Size(343, 142);
            this.installGroupBox.TabIndex = 8;
            this.installGroupBox.TabStop = false;
            this.installGroupBox.Text = "Установка";
            // 
            // pickGameFolderBtn
            // 
            this.pickGameFolderBtn.Location = new System.Drawing.Point(192, 68);
            this.pickGameFolderBtn.Name = "pickGameFolderBtn";
            this.pickGameFolderBtn.Size = new System.Drawing.Size(66, 25);
            this.pickGameFolderBtn.TabIndex = 4;
            this.pickGameFolderBtn.Text = "Обзор...";
            this.pickGameFolderBtn.UseVisualStyleBackColor = true;
            this.pickGameFolderBtn.Click += new System.EventHandler(this.PickGameFolderBtn_Click);
            // 
            // gamePathBox
            // 
            this.gamePathBox.Location = new System.Drawing.Point(12, 71);
            this.gamePathBox.Name = "gamePathBox";
            this.gamePathBox.Size = new System.Drawing.Size(174, 20);
            this.gamePathBox.TabIndex = 3;
            this.gamePathBox.Validating += new System.ComponentModel.CancelEventHandler(this.GamePathBox_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Папка с файлами игры";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Папка с файлами мода";
            // 
            // manageGroupBox
            // 
            this.manageGroupBox.Controls.Add(this.delBtn);
            this.manageGroupBox.Controls.Add(this.disableBtn);
            this.manageGroupBox.Controls.Add(this.enableBtn);
            this.manageGroupBox.Controls.Add(this.label6);
            this.manageGroupBox.Controls.Add(this.label5);
            this.manageGroupBox.Controls.Add(this.disabledModsList);
            this.manageGroupBox.Controls.Add(this.activeModsList);
            this.manageGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manageGroupBox.Location = new System.Drawing.Point(0, 142);
            this.manageGroupBox.Name = "manageGroupBox";
            this.manageGroupBox.Size = new System.Drawing.Size(343, 217);
            this.manageGroupBox.TabIndex = 9;
            this.manageGroupBox.TabStop = false;
            this.manageGroupBox.Text = "Управление установленными";
            // 
            // delBtn
            // 
            this.delBtn.Enabled = false;
            this.delBtn.Location = new System.Drawing.Point(138, 136);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(66, 26);
            this.delBtn.TabIndex = 11;
            this.delBtn.Text = "Удалить";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.DelBtn_Click);
            // 
            // disableBtn
            // 
            this.disableBtn.Enabled = false;
            this.disableBtn.Location = new System.Drawing.Point(138, 72);
            this.disableBtn.Name = "disableBtn";
            this.disableBtn.Size = new System.Drawing.Size(66, 26);
            this.disableBtn.TabIndex = 9;
            this.disableBtn.Text = ">>";
            this.disableBtn.UseVisualStyleBackColor = true;
            this.disableBtn.Click += new System.EventHandler(this.DisableBtn_Click);
            // 
            // enableBtn
            // 
            this.enableBtn.Enabled = false;
            this.enableBtn.Location = new System.Drawing.Point(138, 104);
            this.enableBtn.Name = "enableBtn";
            this.enableBtn.Size = new System.Drawing.Size(66, 26);
            this.enableBtn.TabIndex = 10;
            this.enableBtn.Text = "<<";
            this.enableBtn.UseVisualStyleBackColor = true;
            this.enableBtn.Click += new System.EventHandler(this.EnableBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(207, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Отключенные";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Активные";
            // 
            // disabledModsList
            // 
            this.disabledModsList.FormattingEnabled = true;
            this.disabledModsList.Location = new System.Drawing.Point(210, 32);
            this.disabledModsList.Name = "disabledModsList";
            this.disabledModsList.Size = new System.Drawing.Size(120, 173);
            this.disabledModsList.TabIndex = 8;
            this.disabledModsList.SelectedIndexChanged += new System.EventHandler(this.DisabledModsList_SelectedIndexChanged);
            // 
            // activeModsList
            // 
            this.activeModsList.FormattingEnabled = true;
            this.activeModsList.Location = new System.Drawing.Point(12, 32);
            this.activeModsList.Name = "activeModsList";
            this.activeModsList.Size = new System.Drawing.Size(120, 173);
            this.activeModsList.TabIndex = 7;
            this.activeModsList.SelectedIndexChanged += new System.EventHandler(this.ActiveModsList_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 359);
            this.Controls.Add(this.manageGroupBox);
            this.Controls.Add(this.installGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Менеджер модов";
            this.installGroupBox.ResumeLayout(false);
            this.installGroupBox.PerformLayout();
            this.manageGroupBox.ResumeLayout(false);
            this.manageGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox modPathBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Button pickModFolderBtn;
        private System.Windows.Forms.Button installBtn;
        private System.Windows.Forms.FolderBrowserDialog modDirDialog;
        private System.Windows.Forms.GroupBox installGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button pickGameFolderBtn;
        private System.Windows.Forms.TextBox gamePathBox;
        private System.Windows.Forms.GroupBox manageGroupBox;
        private System.Windows.Forms.Button disableBtn;
        private System.Windows.Forms.Button enableBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox disabledModsList;
        private System.Windows.Forms.ListBox activeModsList;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.FolderBrowserDialog gameDirDialog;
    }
}

