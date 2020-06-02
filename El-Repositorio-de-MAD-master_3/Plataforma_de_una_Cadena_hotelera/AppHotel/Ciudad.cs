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

            EnlaceDB conexion = new EnlaceDB();
            conexion.set_Pais(comboBox1);
            conexion = null;


            EnlaceDB conexion2 = new EnlaceDB();
            conexion2.set_Usuario(comboBox2);
            conexion2 = null;

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
            string Pais = comboBox1.Text;
            string cve_usu = comboBox2.Text;

            //usuario
            int usu_atiende = 0;
            EnlaceDB conexion4 = new EnlaceDB();
            usu_atiende = conexion4.show_UsuarioID(usu_atiende, cve_usu);
            conexion4 = null;

            //pais
            int pais = 0;
            EnlaceDB conexion5 = new EnlaceDB();
            pais = conexion5.show_idPais(pais, Pais);
            conexion5 = null;

            //registra l aciudad
            EnlaceDB conexion = new EnlaceDB();
            conexion.Registra_Ciudad(nombre, descri,pais, usu_atiende);
            conexion = null;

            MessageBox.Show("Se guardó la ciudad: " + nombre + ".");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
