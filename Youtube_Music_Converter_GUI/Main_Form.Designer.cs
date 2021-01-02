namespace Youtube_Music_Converter_GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_New = new System.Windows.Forms.Button();
            this.btn_Convert = new System.Windows.Forms.Button();
            this.btn_SaveConvert = new System.Windows.Forms.Button();
            this.btn_Paste = new System.Windows.Forms.Button();
            this.btn_UnRemove = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.check_Update = new System.Windows.Forms.CheckBox();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Open = new System.Windows.Forms.Button();
            this.check_OpenatStartup = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openListFromTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addListFromTextFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectGithubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mailToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.한국어ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buffer = new System.Windows.Forms.ListBox();
            this.btn_AddOpen = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 21;
            this.listBox1.Location = new System.Drawing.Point(22, 86);
            this.listBox1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(499, 361);
            this.listBox1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 44);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(499, 32);
            this.textBox1.TabIndex = 0;
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(533, 44);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(143, 54);
            this.btn_Add.TabIndex = 2;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.Location = new System.Drawing.Point(533, 172);
            this.btn_Remove.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(143, 54);
            this.btn_Remove.TabIndex = 3;
            this.btn_Remove.Text = "Remove";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // btn_New
            // 
            this.btn_New.Location = new System.Drawing.Point(533, 300);
            this.btn_New.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(143, 54);
            this.btn_New.TabIndex = 4;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btn_Convert
            // 
            this.btn_Convert.Location = new System.Drawing.Point(297, 496);
            this.btn_Convert.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_Convert.Name = "btn_Convert";
            this.btn_Convert.Size = new System.Drawing.Size(185, 68);
            this.btn_Convert.TabIndex = 5;
            this.btn_Convert.Text = "Convert";
            this.btn_Convert.UseVisualStyleBackColor = true;
            this.btn_Convert.Click += new System.EventHandler(this.btn_Convert_Click);
            // 
            // btn_SaveConvert
            // 
            this.btn_SaveConvert.Location = new System.Drawing.Point(493, 496);
            this.btn_SaveConvert.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_SaveConvert.Name = "btn_SaveConvert";
            this.btn_SaveConvert.Size = new System.Drawing.Size(185, 68);
            this.btn_SaveConvert.TabIndex = 6;
            this.btn_SaveConvert.Text = "Save && Convert";
            this.btn_SaveConvert.UseVisualStyleBackColor = true;
            this.btn_SaveConvert.Click += new System.EventHandler(this.btn_SaveConvert_Click);
            // 
            // btn_Paste
            // 
            this.btn_Paste.Location = new System.Drawing.Point(533, 108);
            this.btn_Paste.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_Paste.Name = "btn_Paste";
            this.btn_Paste.Size = new System.Drawing.Size(143, 54);
            this.btn_Paste.TabIndex = 7;
            this.btn_Paste.Text = "Paste";
            this.btn_Paste.UseVisualStyleBackColor = true;
            this.btn_Paste.Click += new System.EventHandler(this.btn_Paste_Click);
            // 
            // btn_UnRemove
            // 
            this.btn_UnRemove.Location = new System.Drawing.Point(533, 236);
            this.btn_UnRemove.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_UnRemove.Name = "btn_UnRemove";
            this.btn_UnRemove.Size = new System.Drawing.Size(143, 54);
            this.btn_UnRemove.TabIndex = 8;
            this.btn_UnRemove.Text = "UnRemove";
            this.btn_UnRemove.UseVisualStyleBackColor = true;
            this.btn_UnRemove.Click += new System.EventHandler(this.btn_UnRemove_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(22, 496);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(99, 68);
            this.btn_Exit.TabIndex = 10;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // check_Update
            // 
            this.check_Update.Checked = true;
            this.check_Update.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_Update.Location = new System.Drawing.Point(22, 459);
            this.check_Update.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.check_Update.Name = "check_Update";
            this.check_Update.Size = new System.Drawing.Size(264, 27);
            this.check_Update.TabIndex = 11;
            this.check_Update.Text = "Check Update at startup";
            this.check_Update.UseVisualStyleBackColor = true;
            this.check_Update.CheckedChanged += new System.EventHandler(this.check_Update_CheckedChanged);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(132, 496);
            this.btn_Update.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(99, 68);
            this.btn_Update.TabIndex = 12;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(533, 369);
            this.btn_Open.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(143, 34);
            this.btn_Open.TabIndex = 13;
            this.btn_Open.Text = "Open";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // check_OpenatStartup
            // 
            this.check_OpenatStartup.AutoSize = true;
            this.check_OpenatStartup.Location = new System.Drawing.Point(427, 459);
            this.check_OpenatStartup.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.check_OpenatStartup.Name = "check_OpenatStartup";
            this.check_OpenatStartup.Size = new System.Drawing.Size(263, 25);
            this.check_OpenatStartup.TabIndex = 14;
            this.check_OpenatStartup.Text = "Always open file at startup";
            this.check_OpenatStartup.UseVisualStyleBackColor = true;
            this.check_OpenatStartup.CheckedChanged += new System.EventHandler(this.check_OpenatStartup_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.fileToolStripMenuItem, this.helpToolStripMenuItem, this.languageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(700, 40);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.newListToolStripMenuItem, this.openListFromTextFileToolStripMenuItem, this.addListFromTextFileToolStripMenuItem, this.toolStripMenuItem1, this.updateToolStripMenuItem, this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(56, 34);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newListToolStripMenuItem
            // 
            this.newListToolStripMenuItem.Name = "newListToolStripMenuItem";
            this.newListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newListToolStripMenuItem.Size = new System.Drawing.Size(281, 34);
            this.newListToolStripMenuItem.Text = "New";
            this.newListToolStripMenuItem.Click += new System.EventHandler(this.newListToolStripMenuItem_Click);
            // 
            // openListFromTextFileToolStripMenuItem
            // 
            this.openListFromTextFileToolStripMenuItem.Name = "openListFromTextFileToolStripMenuItem";
            this.openListFromTextFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openListFromTextFileToolStripMenuItem.Size = new System.Drawing.Size(281, 34);
            this.openListFromTextFileToolStripMenuItem.Text = "Open";
            this.openListFromTextFileToolStripMenuItem.Click += new System.EventHandler(this.openListFromTextFileToolStripMenuItem_Click);
            // 
            // addListFromTextFileToolStripMenuItem
            // 
            this.addListFromTextFileToolStripMenuItem.Name = "addListFromTextFileToolStripMenuItem";
            this.addListFromTextFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys) (((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) | System.Windows.Forms.Keys.O)));
            this.addListFromTextFileToolStripMenuItem.Size = new System.Drawing.Size(281, 34);
            this.addListFromTextFileToolStripMenuItem.Text = "Add List";
            this.addListFromTextFileToolStripMenuItem.Click += new System.EventHandler(this.addListFromTextFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(278, 6);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(281, 34);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(281, 34);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.tutorialToolStripMenuItem, this.projectGithubToolStripMenuItem, this.mailToToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(69, 34);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // tutorialToolStripMenuItem
            // 
            this.tutorialToolStripMenuItem.Name = "tutorialToolStripMenuItem";
            this.tutorialToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.tutorialToolStripMenuItem.Size = new System.Drawing.Size(222, 34);
            this.tutorialToolStripMenuItem.Text = "Tutorial";
            // 
            // projectGithubToolStripMenuItem
            // 
            this.projectGithubToolStripMenuItem.Name = "projectGithubToolStripMenuItem";
            this.projectGithubToolStripMenuItem.Size = new System.Drawing.Size(222, 34);
            this.projectGithubToolStripMenuItem.Text = "Project Github";
            // 
            // mailToToolStripMenuItem
            // 
            this.mailToToolStripMenuItem.Name = "mailToToolStripMenuItem";
            this.mailToToolStripMenuItem.Size = new System.Drawing.Size(222, 34);
            this.mailToToolStripMenuItem.Text = "Mail to...";
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.englishToolStripMenuItem, this.한국어ToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(118, 34);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(153, 34);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click_1);
            // 
            // 한국어ToolStripMenuItem
            // 
            this.한국어ToolStripMenuItem.Name = "한국어ToolStripMenuItem";
            this.한국어ToolStripMenuItem.Size = new System.Drawing.Size(153, 34);
            this.한국어ToolStripMenuItem.Text = "한국어";
            this.한국어ToolStripMenuItem.Click += new System.EventHandler(this.한국어ToolStripMenuItem_Click);
            // 
            // buffer
            // 
            this.buffer.FormattingEnabled = true;
            this.buffer.ItemHeight = 21;
            this.buffer.Location = new System.Drawing.Point(22, 573);
            this.buffer.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buffer.Name = "buffer";
            this.buffer.Size = new System.Drawing.Size(499, 298);
            this.buffer.TabIndex = 16;
            this.buffer.Visible = false;
            // 
            // btn_AddOpen
            // 
            this.btn_AddOpen.Location = new System.Drawing.Point(533, 413);
            this.btn_AddOpen.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_AddOpen.Name = "btn_AddOpen";
            this.btn_AddOpen.Size = new System.Drawing.Size(143, 34);
            this.btn_AddOpen.TabIndex = 17;
            this.btn_AddOpen.Text = "Load";
            this.btn_AddOpen.UseVisualStyleBackColor = true;
            this.btn_AddOpen.Click += new System.EventHandler(this.btn_AddOpen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 577);
            this.Controls.Add(this.btn_AddOpen);
            this.Controls.Add(this.buffer);
            this.Controls.Add(this.check_OpenatStartup);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.check_Update);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_UnRemove);
            this.Controls.Add(this.btn_Paste);
            this.Controls.Add(this.btn_SaveConvert);
            this.Controls.Add(this.btn_Convert);
            this.Controls.Add(this.btn_New);
            this.Controls.Add(this.btn_Remove);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Youtube Music Converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btn_AddOpen;

        private System.Windows.Forms.ToolStripMenuItem addListFromTextFileToolStripMenuItem;

        private System.Windows.Forms.ListBox buffer;

        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 한국어ToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem mailToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectGithubToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tutorialToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openListFromTextFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;

        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.CheckBox check_OpenatStartup;

        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.CheckBox check_Update;

        private System.Windows.Forms.Button btn_Exit;

        private System.Windows.Forms.Button btn_UnRemove;

        private System.Windows.Forms.Button btn_Paste;

        private System.Windows.Forms.Button btn_SaveConvert;

        private System.Windows.Forms.Button btn_Convert;

        private System.Windows.Forms.Button btn_New;
        private System.Windows.Forms.Button btn_Remove;

        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;

        #endregion
    }
}