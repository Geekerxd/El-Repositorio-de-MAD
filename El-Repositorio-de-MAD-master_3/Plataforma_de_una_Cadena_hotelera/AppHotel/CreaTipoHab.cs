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


            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == ""
            || textBox5.Text == "" || textBox6.Text == "" ) { MessageBox.Show("Alguna casilla está vacía."); goto fin; }
            EnlaceDB conexion = new EnlaceDB();
            try
            {

                var nombre = textBox1.Text;
            var descrip = textBox2.Text;
            int no_camas = int.Parse(textBox3.Text);
            var tipo_cama = textBox4.Text;
            int cant_pers = int.Parse(textBox5.Text);
            var precio = textBox6.Text;

            
            conexion.Registra_Tipo_Hab(nombre, descrip, no_camas, tipo_cama, cant_pers, precio);
           

            MessageBox.Show("Se guardó tipo de habitación: " + nombre+".");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";



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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
