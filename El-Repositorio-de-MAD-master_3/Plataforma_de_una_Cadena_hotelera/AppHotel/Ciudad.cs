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
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "") { MessageBox.Show("Alguna casilla está vacía."); goto fin; }
            EnlaceDB conexion4 = new EnlaceDB();
            try
            {

            var nombre =     textBox1.Text;
            var descri =     textBox2.Text;
            string Pais =    comboBox1.Text;
            string cve_usu = comboBox2.Text;

            //usuario
            int usu_atiende = 0;
            
            usu_atiende = conexion4.show_UsuarioID(usu_atiende, cve_usu);
            

            //pais
            int pais = 0;
           
            pais = conexion4.show_idPais(pais, Pais);
            

            //registra l aciudad
           
                conexion4.Registra_Ciudad(nombre, descri,pais, usu_atiende);
            

            MessageBox.Show("Se guardó la ciudad: " + nombre + ".");
                textBox1.Text="";
                textBox2.Text = "";
                comboBox1.Text="";
                comboBox2.Text = "";
            }
            catch
            {
                var msg = "";
                msg = "Error de tipo de dato.\nAsegurese de usar los datos correctos.\n";
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        fin:
            conexion4 = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
