using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Configuration;

namespace AppHotel
{
    public partial class CreaUsuario : Form
    {
        public CreaUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == ""
                || textBox5.Text == "" || textBox7.Text == "" || textBox8.Text == "") { MessageBox.Show("Alguna casilla está vacía."); goto fin; }
            EnlaceDB conexion = new EnlaceDB();
            try
            {
                var contrase = textBox8.Text;
                var Nombre = textBox2.Text;
                var Paterno = textBox3.Text;
                var Materno = textBox4.Text;
                int nNomina = int.Parse(textBox5.Text);
                DateTime nacimi = dateTimePicker1.Value;
                var Domi = textBox1.Text;
                var TelCel = textBox7.Text;


               
                conexion.Set_Users(contrase, Nombre, Paterno, Materno, nNomina, nacimi, Domi, TelCel);

                MessageBox.Show("Se guardó usuario: " + Nombre + " " + Paterno + " " + Materno + ".");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                dateTimePicker1.Value = DateTime.Today;
                textBox7.Text = "";
                textBox8.Text = "";
            }
            catch 
            {
                var msg = "";
                msg = "Error de tipo de dato.\nAsegurese de usar los datos correctos.\n";
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        fin:
            conexion = null;

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void CreaUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
