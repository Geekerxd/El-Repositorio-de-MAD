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

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" ) { MessageBox.Show("Alguna casilla está vacía."); goto fin; }
            EnlaceDB conexion = new EnlaceDB();
            try
            {

                var Nombre = textBox1.Text;
            var Precio = textBox2.Text;
            var Caract = textBox3.Text;
           
            conexion.Registra_Servicio(Nombre, Precio, Caract);
          

            MessageBox.Show("Se guardó servicio: " + Nombre + ".");
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
    }
}
