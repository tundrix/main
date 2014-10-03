using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Collections;

namespace tundrica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private string ReadFileAsString(string fileName)
        {
            // create reader & open file
            TextReader tr = new StreamReader(fileName);

            // read a line of text
            string res = tr.ReadToEnd();

            // close the stream
            tr.Close();

            return res;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Load Help Reference Text
            textBox12.Text = ReadFileAsString("Help_Reference.txt");
            textBox14.Text = "Sorted: ";

            SortedList sl = new SortedList();
            for (int i = 0; i < textBox12.Lines.Length; i++)
            {
                if (textBox12.Lines[i].Contains("="))
                {
                    if (!sl.ContainsKey(textBox12.Lines[i]))
                    {
                        sl.Add(textBox12.Lines[i], ""/*textBox12.Lines[i]*/);
                    }
                }
            }
            for (int i = 0; i < sl.Count; i++)
            {
                textBox14.Text += "\r\n"+sl.GetKey(i)  ;
                //textBox14.Text += sl.GetByIndex(i) + "\r\n";
            }
            #endregion
            #region Load Help Reference Details Text
            textBox15.Text = ReadFileAsString("Help_Reference_Details.txt");
            #endregion
        }
    }
}
