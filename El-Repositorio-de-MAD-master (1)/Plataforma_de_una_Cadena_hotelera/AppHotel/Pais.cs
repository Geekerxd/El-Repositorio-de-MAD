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
            var nombre = textBox1.Text;
            var descri = textBox2.Text;
            EnlaceDB conexion = new EnlaceDB();
            conexion.Registra_Pais(nombre, descri);
            conexion = null;
            MessageBox.Show("Se guardó el país: "+ nombre+".");
        }
    }
}
