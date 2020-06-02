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
    public partial class Ciudad : Form
    {
        private void Ciudad_Load(object sender, EventArgs e)
        {
           // MessageBox.Show("aqui se llena el combo");


            EnlaceDB conexion = new EnlaceDB();
            conexion.set_Pais(comboBox1);
            conexion = null;

            //comboBox1

        }
        public Ciudad()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //boton crear

            var nombre = textBox1.Text;
            var descri = textBox2.Text;
            var pais = comboBox1.Text;
            EnlaceDB conexion = new EnlaceDB();
            conexion.Registra_Ciudad(nombre, descri,pais);
            conexion = null;

            MessageBox.Show("se guadró: " + nombre + " con éxito");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
