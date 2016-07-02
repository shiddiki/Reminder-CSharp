using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 2;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.MaxLength = 2;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string[] name = new string[12];
            name[0] = "zero";
            name[1] = "one";
            name[2] = "Three";
            try
            {
                for (int i = 0; i < 3; i++)
                    textBox2.Text = name[i];
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex");
            }
        }
    }
}
