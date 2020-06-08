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
    public partial class Pais : Form
    {
        public Pais()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {//registra pais

            if (textBox1.Text == "" || textBox2.Text == "") { MessageBox.Show("Alguna casilla está vacía."); goto fin; }
            EnlaceDB conexion = new EnlaceDB();
            try
            {

            var nombre = textBox1.Text;
            var descri = textBox2.Text;
            
            conexion.Registra_Pais(nombre, descri);
            
            MessageBox.Show("Se guardó el país: "+ nombre+".");
                textBox1.Text = "";
                textBox2.Text="";
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
