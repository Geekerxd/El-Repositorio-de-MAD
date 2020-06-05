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
    public partial class CheckIn : Form
    {
        static int _IDC;
        public CheckIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            EnlaceDB conexion = new EnlaceDB();

            if (conexion.MostrarReservacion(listBox1, int.Parse(textBox1.Text)))
            {
                _IDC = int.Parse(conexion.GetIDCliente());
                int IDH = int.Parse(conexion.GetIDHotel());

                listBox1.Items.Add("Nombre del cliente:\t\t" + conexion.IDGetCliente(_IDC));
                listBox1.Items.Add("Tipo de habitacion:\t\t" + conexion.IDGetHabitacion(IDH));

               
                conexion.SetIDCliente("");
                conexion.SetIDHotel("");
               
            }
            else MessageBox.Show("No se escontro esta clave de reservacion");

            conexion = null;
           
        }

        private void button3_Click(object sender, EventArgs e)
        {   // BOTON DE CHECK IN

            EnlaceDB conexion2 = new EnlaceDB();
            conexion2.CHECK_IN(int.Parse(textBox1.Text));

            

            MessageBox.Show("se hizo check in de: "+ conexion2.IDGetCliente(_IDC)+" \n\nCon clave: "+ textBox1.Text);

            conexion2 = null;
        }
    }
}
