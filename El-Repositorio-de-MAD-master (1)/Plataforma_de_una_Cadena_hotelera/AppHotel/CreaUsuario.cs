using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            var contrase = textBox8.Text;
            var Nombre = textBox2.Text;
            var Paterno = textBox3.Text;
            var Materno = textBox4.Text;
            int nNomina = int.Parse(textBox5.Text);
            DateTime nacimi = dateTimePicker1.Value;
            var Domi = textBox1.Text;
            var TelCel = textBox7.Text;
            var msg = "";
            
                EnlaceDB conexion = new EnlaceDB();
            conexion.Set_Users(contrase, Nombre, Paterno, Materno, nNomina, nacimi, Domi, TelCel);
            conexion = null;

            MessageBox.Show("Se guardó usuario: "+ Nombre+ " " + Paterno + " " + Materno + ".");
            



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
