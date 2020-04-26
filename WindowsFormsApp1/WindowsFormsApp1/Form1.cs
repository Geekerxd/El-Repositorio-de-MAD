using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hello button1_Click");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Escribió richTextBox1_TextChanged");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Cambió richTextBox1_TextChanged");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            MessageBox.Show("Bienvenido "+ textBox1.Text +"\nSon las: "+ DateTime.Now.ToString());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            do_check();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            do_check();
        }
        private void do_check()
        {
            button1.Enabled = checkBox1.Checked;
        }
    }
}
