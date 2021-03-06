﻿using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youtube_Music_Converter_GUI
{
    public partial class Convert_Form : Form
    {
        private string output;
        private string path;
        private int Task_Num = 0;
        private int cur_pos = 100;
        private int cur_end = -1;

        public Convert_Form(string output)
        {
            this.output = output;
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(Close); // FormClosingEventHandler를 통한 폼 클로징 이벤트 제어 문
            Localization();
            Convert();
        }

        private void Close(object sender, FormClosingEventArgs e) // 변환 도중 FormClosing 시도 시 확인
        {
            if (btn_Close.Enabled == false)
            {
                DialogResult result = MessageBox.Show(Str.str_Converting_exit, Str.str_AppName,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (result != DialogResult.OK)
                {
                    e.Cancel = true;
                }
            }
        }

        private void ProgressView(string line, int i)
        {
            if (Regex.IsMatch(line, @".\d") && line.IndexOf(@":", StringComparison.Ordinal) == 8)
            {
                Task_Num = Int32.Parse(Regex.Replace(line, @"[^0-9]", ""));
                cur_pos = i + 3;
                cur_end = cur_pos + Task_Num;
                if (progressBar1.Value > 1)
                {
                    progressSet(50);
                    linkLabel1.Visible = true;
                }
            }

            if (i < cur_end && i >= cur_pos)
            {
                progressAdd(50/Task_Num);
            }
        }

        private void progressAdd(int prog)
        {
            progressBar1.Value += prog;
            ProgressPercent.Text = progressBar1.Value.ToString();
        }

        private void progressSet(int prog)
        {
            progressBar1.Value = prog;
            ProgressPercent.Text = prog.ToString();
        }

        private void Localization()
        {
            Text = Str.str_AppName;
            label_output.Text = Str.str_Output;
            btn_Close.Text = Str.btn_Close;
            btn_OpenFolder.Text = Str.btn_OpenFolder;
            linkLabel1.Text = Str.str_wrong_task;
        }

        private void NoApp() // Youtube_Music_Converter 앱이 없는 경우 종료 메서드
        {
            MessageBox.Show(Str.str_ExitApp, Str.str_AppName, MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            Application.Exit();
        }

        private async void Convert()
        {
            int i = 1;
            if (File.Exists("Youtube_Music_Converter.exe"))
            {
                path = Environment.CurrentDirectory;
            }
            else
            {
        #if DEBUG // 디버그 모드 시 (솔루션 빌드 환경 시 ) Youtube_Music_Converter 프로젝트 Debug 앱 실행 하도록 설정
                if (File.Exists(
                    "..\\..\\..\\..\\Youtube_Music_Converter\\bin\\Debug\\netcoreapp3.1\\Youtube_Music_Converter.exe"))
                {
                    path =
                        @"..\\..\\..\\..\\Youtube_Music_Converter\\bin\\Debug\\netcoreapp3.1\\";
                    Text = @"[DEBUG MODE] " + Str.str_AppName;
                }
                else
                {
        #endif
                    // Youtube_Music_Converter.exe 를 찾을 수 없는 경우 수동 설정
                    DialogResult result = MessageBox.Show(Str.str_FindApp, Str.str_AppName, MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Yes)
                    {
                        using OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Filter = Str.str_AppName + @"|Youtube_Music_Converter.exe";
                        openFileDialog.FilterIndex = 1;
                        openFileDialog.RestoreDirectory = true;
                 
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            path = openFileDialog.FileName.Replace(@"Youtube_Music_Converter.exe",@"");
                        }
                        else
                        {
                            NoApp();
                        }
                    }
                    else
                    {
                        NoApp();
                    }
        #if DEBUG // 디버그 모드 시 (솔루션 빌드 환경 시 ) Youtube_Music_Converter 프로젝트 Debug 앱 실행 하도록 설정
                }
        #endif
            }

            var ymc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Path.Combine(path, @"Youtube_Music_Converter.exe"),
                    Arguments = output + @" GUI",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            await Task.Run(() => // UI 동작을 위한 Async 흐름
            {
                ymc.Start();
                while (!ymc.StandardOutput.EndOfStream)
                {
                    string line = ymc.StandardOutput.ReadLine();

                    ProgressView(line, i);
                    if (line == @"End of Program")
                    {
                        if (output == @"Youtube_Music_Converter_tmp.txt")
                        {
                            File.Delete(@"Youtube_Music_Converter_tmp.txt");
                        }
                        btn_Close.Enabled = true;
                        btn_OpenFolder.Enabled = true;
                        linkLabel1.Visible = false;
                        progressSet(100);
                        break;
                    }
                    
                    listBox1.Items.Add(line);
                    listBox1.TopIndex = listBox1.Items.Count -1;
                    i++;
                }
            });

        }

        private void Convert_Form_Load_1(object sender, EventArgs e)
        {
            ProgressPercent.Text = 0.ToString();
            btn_Close.Enabled = false;
            btn_OpenFolder.Enabled = false;
            linkLabel1.Visible = false;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_OpenFolder_Click(object sender, EventArgs e)
        {
#if DEBUG // 디버그 모드 시 (솔루션 빌드 환경 시 ) Youtube_Music_Converter 프로젝트 Debug 앱 실행 하도록 설정
            path = Environment.CurrentDirectory;
#endif
            Process.Start(@"explorer.exe", Path.Combine(path, output.Replace(@".txt", @"")));
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e) // 출력 리스트 더블 클릭 시 해당 행 복사
        {
            if (listBox1.SelectedItem != null)
            {
                Clipboard.SetText(listBox1.SelectedItem.ToString());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // ffmpeg 작업 중단
        {
            if (progressBar1.Value == 100) return;
            Process.Start(@"taskkill.exe", @"-f -im ffmpeg.exe");
            MessageBox.Show(Str.str_killed, Str.str_AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}