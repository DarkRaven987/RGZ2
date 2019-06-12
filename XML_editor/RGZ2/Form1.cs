using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RGZ2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            richTextBox1.Text = "";
            richTextBox1.Text = fileText;

            int start = -1, finish = -1;

            for (int i = 0; i < fileText.Length; i++)
            {
                if (fileText[i] == '<')
                {
                    start = i;
                }
                if (fileText[i] == '>')
                {
                    finish = i + 1;
                }
                if ((start != -1) && (finish != -1))
                {
                    richTextBox1.Select(start, finish - start);
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Bold);
                    richTextBox1.Select(0, 0);
                    start = -1; finish = -1;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            foreach (char s in richTextBox1.Text)
            {
                //MessageBox.Show(" " + s);
            }
            System.IO.File.WriteAllText(filename, richTextBox1.Text);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s1 = textBox2.Text;
            string s2 = textBox1.Text;
            richTextBox1.Text = richTextBox1.Text.Replace(s1, s2);
            int start = -1, finish = -1;

            richTextBox1.Font = new Font(richTextBox1.Font, richTextBox1.Font.Style | FontStyle.Regular);
            for (int i = 0; i < richTextBox1.Text.Length; i++)
            {
                if (richTextBox1.Text[i] == '<')
                {
                    start = i;
                }
                if (richTextBox1.Text[i] == '>')
                {
                    finish = i + 1;
                }
                if ((start != -1) && (finish != -1))
                {
                    richTextBox1.Select(start, finish - start);
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Bold);
                    richTextBox1.Select(0, 0);
                    start = -1; finish = -1;
                }
            }
        }
           
        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
