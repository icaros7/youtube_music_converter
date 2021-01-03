using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
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
            FormClosing += new FormClosingEventHandler(Close); // FormClosingEventHandler를 통한 폼 클로징 이벤트 제어 문
        }

        private void Close(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(Str.str_Exit_Sure, Str.str_AppName, MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);
            if (result != DialogResult.OK)
            {
                e.Cancel = true; // Cancel FormClosingEvent
            }
        }

        private void LocalizationInit()
        {
            Text = Str.str_AppName;
            
            // Main_Form 버튼
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
            
            // Main_Form 체크박스
            check_Update.Text = Str.str_CheckUpdate;
            check_OpenatStartup.Text = Str.str_OpenAtStartup;
            
            // Main_Form ToolStripMenuItem
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

            // 언어 변경 혹은 폼 첫 Init 시 Main_Form 언어 변경 ToolStripMenuItem 체크
            if (Equals(Thread.CurrentThread.CurrentUICulture, CultureInfo.GetCultureInfo("ko-KR")))
            {
                englishToolStripMenuItem.Checked = false;
                한국어ToolStripMenuItem.Checked = true;
            }
            else
            {
                englishToolStripMenuItem.Checked = true;
                한국어ToolStripMenuItem.Checked = false;
            }

        }

        private void IniLoad()
        {
            if (!File.Exists("Youtube_Music_Converter_GUI.ini")) return;
            ini.Load("Youtube_Music_Converter_GUI.ini");
            
            
            // 정해진 값이 없는 경우를 위한 예외 처리
            try
            {
                check_OpenatStartup.Checked = ini["Settings"]["OpenAtStartup"].ToBool();
                check_Update.Checked = ini["Settings"]["CheckUpdateAtStartup"].ToBool();
                Thread.CurrentThread.CurrentUICulture =
                    CultureInfo.GetCultureInfo(ini["Settings"]["Language"].ToString());
            }
            catch (ArgumentNullException){}
        }

        private void ChangeLanguage(string culture) // 언어 변경 메서드
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
            ActiveControl = textBox1;
        }

        private string Save(int status)
        {
            if (status == 0) // Save & Convert
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = Str.str_TextFilter;
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;

                    while (true)
                    {
                        if (saveFileDialog.ShowDialog() != DialogResult.OK) continue;
                        using var streamWriter = new StreamWriter(saveFileDialog.FileName, false);
                        foreach (var item in listBox1.Items)
                        {
                            streamWriter.WriteLine(item.ToString());
                        }
                        break;
                    }

                    return saveFileDialog.FileNames.ToString();
                }
            }
            else // Convert via temp text file
            {
                using var streamWriter = new StreamWriter(@"Youtube_Music_Converter_tmp.txt", false);
                foreach (var item in listBox1.Items)
                {
                    streamWriter.WriteLine(item.ToString());
                }

                return @"Youtube_Music_Converter_tmp.txt";
            }
        }
        
        private void OpenDialog()
        {
            var path = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = Str.str_TextFilter;
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                 
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                }
                else
                {
                    ActiveControl = textBox1;
                }
            }
                 
            if (path != "")
            {
                Open(path);
            }
        }

        private bool CheckEmpty()
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show(Str.str_no_list, Str.str_AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        
        public static void OpenBrowser(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IniLoad();
            LocalizationInit();

            if (check_Update.Checked){ btn_Update.PerformClick(); }

            if (args.Length < 2)
            {
                if (check_OpenatStartup.Checked){ btn_Open.PerformClick(); }
            }
            else { Open(args[1]); }
        }

        private void btn_Add_Click(object sender, EventArgs e) // textBox1 로 부터 1행 씩 추가
        {
            if (textBox1.TextLength != 0)
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
                ActiveControl = textBox1;
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e) // listBox1 마지막 행 혹은 선택 행 제거
        {
            if (listBox1.Items.Count != 0)
            {
                if (listBox1.SelectedItem != null)
                {
                    buffer.Items.Add(listBox1.Items[listBox1.SelectedIndex]);
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    ActiveControl = textBox1;
                }
                else
                {
                    buffer.Items.Add(listBox1.Items[^1]!);
                    listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
                    ActiveControl = textBox1;
                }
            }
        }

        private void btn_UnRemove_Click(object sender, EventArgs e) // 제거 시 buffer list를 통한 복구
        {
            if (buffer.Items.Count != 0)
            {
                listBox1.Items.Add(buffer.Items[^1]);
                buffer.Items.RemoveAt(buffer.Items.Count - 1);
                ActiveControl = textBox1;
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            DialogResult clear = MessageBox.Show(Str.str_Clear, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (clear == DialogResult.Yes)
            {
                listBox1.Items.Clear();
                buffer.Items.Clear();
                ActiveControl = textBox1;
            }
        }

        private void btn_Paste_Click(object sender, EventArgs e) // 클립보드로 부터 Text 읽기
        {
            textBox1.Text = Clipboard.GetText(); //TODO: URL 형식 값만 가져 올 수 있도록 수정
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

        private void btn_Convert_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
            {
                Convert_Form convertForm = new Convert_Form(Save(1));
                convertForm.ShowDialog();
            }
        }

        private void btn_SaveConvert_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
            {
                Convert_Form convertForm = new Convert_Form(Save(0));
                convertForm.ShowDialog();
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            //TODO: Update
        }

        private void check_Update_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ini["Settings"]["CheckUpdateAtStartup"] = check_Update.Checked;
                ini.Save("Youtube_Music_Converter_GUI.ini");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), Str.str_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void check_OpenatStartup_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ini["Settings"]["OpenAtStartup"] = check_OpenatStartup.Checked;
                ini.Save("Youtube_Music_Converter_GUI.ini");
            }
            catch (Exception exception)
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

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_Exit.PerformClick();
        }
    }
}