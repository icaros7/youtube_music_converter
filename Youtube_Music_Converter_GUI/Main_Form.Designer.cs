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
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 38);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(274, 225);
            this.listBox1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(274, 20);
            this.textBox1.TabIndex = 0;
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(292, 12);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(65, 40);
            this.btn_Add.TabIndex = 2;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Remove
            // 
            this.btn_Remove.Location = new System.Drawing.Point(292, 104);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(65, 40);
            this.btn_Remove.TabIndex = 3;
            this.btn_Remove.Text = "Remove";
            this.btn_Remove.UseVisualStyleBackColor = true;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // btn_New
            // 
            this.btn_New.Location = new System.Drawing.Point(292, 223);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(65, 40);
            this.btn_New.TabIndex = 4;
            this.btn_New.Text = "New";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btn_Convert
            // 
            this.btn_Convert.Location = new System.Drawing.Point(256, 282);
            this.btn_Convert.Name = "btn_Convert";
            this.btn_Convert.Size = new System.Drawing.Size(101, 52);
            this.btn_Convert.TabIndex = 5;
            this.btn_Convert.Text = "Convert";
            this.btn_Convert.UseVisualStyleBackColor = true;
            // 
            // btn_SaveConvert
            // 
            this.btn_SaveConvert.Location = new System.Drawing.Point(149, 282);
            this.btn_SaveConvert.Name = "btn_SaveConvert";
            this.btn_SaveConvert.Size = new System.Drawing.Size(101, 52);
            this.btn_SaveConvert.TabIndex = 6;
            this.btn_SaveConvert.Text = "Save && Convert";
            this.btn_SaveConvert.UseVisualStyleBackColor = true;
            this.btn_SaveConvert.Click += new System.EventHandler(this.btn_SaveConvert_Click);
            // 
            // btn_Paste
            // 
            this.btn_Paste.Location = new System.Drawing.Point(292, 58);
            this.btn_Paste.Name = "btn_Paste";
            this.btn_Paste.Size = new System.Drawing.Size(65, 40);
            this.btn_Paste.TabIndex = 7;
            this.btn_Paste.Text = "Paste";
            this.btn_Paste.UseVisualStyleBackColor = true;
            this.btn_Paste.Click += new System.EventHandler(this.btn_Paste_Click);
            // 
            // btn_UnRemove
            // 
            this.btn_UnRemove.Location = new System.Drawing.Point(292, 150);
            this.btn_UnRemove.Name = "btn_UnRemove";
            this.btn_UnRemove.Size = new System.Drawing.Size(65, 40);
            this.btn_UnRemove.TabIndex = 8;
            this.btn_UnRemove.Text = "UnRemove";
            this.btn_UnRemove.UseVisualStyleBackColor = true;
            this.btn_UnRemove.Click += new System.EventHandler(this.btn_UnRemove_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(12, 292);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(54, 42);
            this.btn_Exit.TabIndex = 10;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            // 
            // check_Update
            // 
            this.check_Update.Checked = true;
            this.check_Update.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_Update.Location = new System.Drawing.Point(12, 269);
            this.check_Update.Name = "check_Update";
            this.check_Update.Size = new System.Drawing.Size(144, 17);
            this.check_Update.TabIndex = 11;
            this.check_Update.Text = "Check Update at startup";
            this.check_Update.UseVisualStyleBackColor = true;
            this.check_Update.CheckedChanged += new System.EventHandler(this.check_Update_CheckedChanged);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(72, 292);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(54, 42);
            this.btn_Update.TabIndex = 12;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 348);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Youtube Music Converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

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