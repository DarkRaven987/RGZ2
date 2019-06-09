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
            richTextBox1.Text = fileText;
            int start = richTextBox1.Find("<");
            int finish = richTextBox1.Find(">");
            //выделяем до конца текста
            richTextBox1.Select(start, finish+1 - start);
            //в выделенный фрагмент устанавливаем шрифт, созданный из имеющегося, 
            //но со стилем Bold - жирный
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Bold);
            //сбрасываем выделение, тут в начало текста
            richTextBox1.Select(0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, richTextBox1.Text);
        }
    }
}
