using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Youtube_Music_Converter_GUI
{
    public partial class Form1 : Form
    {
        private string[] args;
        IniFile ini = new IniFile();

        public Form1(string[] args)
        {
            InitializeComponent();
            this.args = args;
        }

        private void LocalizationInit()
        {
            btn_Add.Text = Str.btn_Add;
            btn_New.Text = Str.btn_Clear;
            btn_Remove.Text = Str.btn_Remove;
            btn_SaveConvert.Text = Str.btn_SaveConvert;
            btn_Exit.Text = Str.btn_Exit;
            btn_Open.Text = Str.btn_Open;
            btn_AddOpen.Text = Str.btn_AddOpen;
            btn_Paste.Text = Str.btn_Paste;
            btn_Convert.Text = Str.btn_Convert;
            btn_UnRemove.Text = Str.btn_UnRemove;
            btn_Update.Text = Str.btn_Update;
            check_Update.Text = Str.str_CheckUpdate;
            check_OpenatStartup.Text = Str.str_OpenAtStartup;
            exitToolStripMenuItem.Text = Str.btn_Exit;
            updateToolStripMenuItem.Text = Str.btn_Update;
            newListToolStripMenuItem.Text = Str.btn_Clear;
            openListFromTextFileToolStripMenuItem.Text = Str.btn_Open;
            fileToolStripMenuItem.Text = Str.strip_File;
            helpToolStripMenuItem.Text = Str.strip_Help;
            mailToToolStripMenuItem.Text = Str.strip_Feedback;
            tutorialToolStripMenuItem.Text = Str.strip_Tutorial;
            projectGithubToolStripMenuItem.Text = Str.strip_ProjectGit;
            addListFromTextFileToolStripMenuItem.Text = Str.btn_AddOpen;

        }

        private void IniLoad()
        {
            if (!File.Exists("Youtube_Music_Converter_GUI.ini")) return;
            ini.Load("Youtube_Music_Converter_GUI.ini");
            
            check_Update.Checked = ini["Settings"]["CheckUpdateAtStartup"].ToBool();
            check_OpenatStartup.Checked = ini["Settings"]["OpenAtStartup"].ToBool();
            try
            {
                Thread.CurrentThread.CurrentUICulture =
                    CultureInfo.GetCultureInfo(ini["Settings"]["Language"].ToString());
            }
            catch (ArgumentNullException){}
        }

        private void ChangeLanguage(string culture)
        {
            try
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);
                ini["Settings"]["Language"] = culture;
                ini.Save("Youtube_Music_Converter_GUI.ini");
                LocalizationInit();
                MessageBox.Show(Str.str_ChangedLanguage + "\r" + Str.str_ChangedLanguage_Next, Str.str_AppName, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), Str.str_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void Open(string path)
        {
            object[] lines = File.ReadAllLines(path);
            listBox1.Items.AddRange(lines);
            buffer.Items.Clear();
            this.ActiveControl = textBox1;
        }

        private void OpenDialog()
        {
            string path = "";
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = Str.str_TextFilter;
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;
                     
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        path = openFileDialog.FileName;
                    }
                    else
                    {
                        this.ActiveControl = textBox1;
                    }
                }
                     
                if (path != "")
                {
                    Open(path);
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IniLoad();
            LocalizationInit();

            if (check_Update.Checked){ btn_Update.PerformClick(); }

            if (args.Length < 2)
            {
                if (check_OpenatStartup.Checked)
                {
                    btn_Open.PerformClick();
                }
            }
            else
            {
                Open(args[1]);
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0)
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
                this.ActiveControl = textBox1;
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                if (listBox1.SelectedItem != null)
                {
                    buffer.Items.Add(listBox1.Items[listBox1.SelectedIndex]);
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    this.ActiveControl = textBox1;
                }
                else
                {
                    buffer.Items.Add(listBox1.Items[^1]!);
                    listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
                    this.ActiveControl = textBox1;
                }
            }
        }

        private void btn_UnRemove_Click(object sender, EventArgs e)
        {
            if (buffer.Items.Count != 0)
            {
                listBox1.Items.Add(buffer.Items[^1]);
                buffer.Items.RemoveAt(buffer.Items.Count - 1);
                this.ActiveControl = textBox1;
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            DialogResult clear = MessageBox.Show(Str.str_Clear, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (clear == DialogResult.Yes)
            {
                listBox1.Items.Clear();
                this.ActiveControl = textBox1;
            }
        }

        private void btn_SaveConvert_Click(object sender, EventArgs e)
        {
        }

        private void btn_Paste_Click(object sender, EventArgs e)
        {
            textBox1.Text = Clipboard.GetText();
            btn_Add.PerformClick();
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                DialogResult result = MessageBox.Show(Str.str_SureOpen, @"Youtube Music Converter",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result != DialogResult.OK) return;
            }
            listBox1.Items.Clear();
            OpenDialog();
        }

        private void btn_AddOpen_Click(object sender, EventArgs e)
        {
            OpenDialog();
        }

        private void check_Update_CheckedChanged(object sender, EventArgs e)
        {
            if (buffer != "")
            {
                MessageBox.Show(exception.ToString(), Str.str_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openListFromTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_Open.PerformClick();
        }

        private void addListFromTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_AddOpen.PerformClick();
        }

        private void newListToolStripMenuItem_Click(object sender, EventArgs e)
        {
           btn_New.PerformClick(); 
        }

        private void englishToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ChangeLanguage("en-US");
        }

        private void 한국어ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ChangeLanguage("ko-KR"); 
        }
    }
}