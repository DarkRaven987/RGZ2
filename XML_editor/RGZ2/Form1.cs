﻿using System;
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

        string[] words;
        string[] tags;

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
            words = richTextBox1.Text.Split('<', '>');
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
            //System.IO.File.WriteAllText(filename, richTextBox1.Text);
            System.IO.File.AppendAllText(filename, richTextBox1.Text);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            //int n = 0, min=-1, max=-1;
            tags = richTextBox2.Text.Split('\n');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == textBox2.Text)
                {
                    words[i + 1] = textBox3.Text;
                }
                richTextBox1.Text += words[i];
                /*if ((words[i]==tags[n])&&(tags[n+1]=="")&&(min==-1))
                {
                    min = i;
                }
                else if ((words[i] == '/'+ tags[n]) && (tags[n + 1] == "") && (max == -1))
                {
                    max = i;
                }
                if ((min != -1) && (max != -1))
                {
                    n += 2;
                    break;
                }*/
            }
           
        }
    }
}
