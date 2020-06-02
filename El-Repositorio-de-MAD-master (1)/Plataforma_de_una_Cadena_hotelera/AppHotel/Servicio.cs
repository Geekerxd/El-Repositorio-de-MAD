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
    public partial class Servicio : Form
    {
        public Servicio()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var Nombre = textBox1.Text;
            var Precio = textBox2.Text;
            var Caract = textBox3.Text;
            EnlaceDB conexion = new EnlaceDB();
            conexion.Registra_Servicio(Nombre, Precio, Caract);
            conexion = null;

            MessageBox.Show("Se guardó servicio: " + Nombre + ".");
        }
    }
}
