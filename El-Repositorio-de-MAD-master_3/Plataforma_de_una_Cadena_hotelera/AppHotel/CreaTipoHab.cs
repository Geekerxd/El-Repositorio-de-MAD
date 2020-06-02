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
    public partial class CreaTipoHab : Form
    {
        public CreaTipoHab()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nombre = textBox1.Text;
            var descrip = textBox2.Text;
            int no_camas = int.Parse(textBox3.Text);
            var tipo_cama = textBox4.Text;
            int cant_pers = int.Parse(textBox5.Text);
            var precio = textBox6.Text;

            EnlaceDB conexion = new EnlaceDB();
            conexion.Registra_Tipo_Hab(nombre, descrip, no_camas, tipo_cama, cant_pers, precio);
            conexion = null;

            MessageBox.Show("Se guardó tipo de habitación: " + nombre+".");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
