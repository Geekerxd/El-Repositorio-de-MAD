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
    public partial class UsuEmp : Form
    {
        public UsuEmp()
        {
            InitializeComponent();
        }

        private void B_HacReservación_Click(object sender, EventArgs e)
        {
            Form nuevform = new HacerReservacion();
            nuevform.ShowDialog();


        }

        private void reportesDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reporteDeOcupaciónPorHotelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //ventana re reportes de ocupacion por hotel
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //alta del cliente
        }
    }
}
