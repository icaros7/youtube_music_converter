using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youtube_Music_Converter_GUI
{
    public partial class Form1 : Form
    {
        private string buffer = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void LocalizationInit()
        {
            btn_Add.Text = Str.btn_Add;
            btn_New.Text = Str.btn_New;
            btn_Remove.Text = Str.btn_Remove;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LocalizationInit();
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
                    buffer = listBox1.SelectedItem.ToString();
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    this.ActiveControl = textBox1;
                }
                else
                {
                    buffer = listBox1.Items[^1].ToString();
                    listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
                    this.ActiveControl = textBox1;
                }
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

        private void btn_UnRemove_Click(object sender, EventArgs e)
        {
            if (buffer != "")
            {
                listBox1.Items.Add(buffer);
                buffer = "";
                this.ActiveControl = textBox1;
            }
        }
    }
}