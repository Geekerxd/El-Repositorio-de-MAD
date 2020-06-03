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
    public partial class CancelarReservacion : Form
    {
        static int clave;
        public CancelarReservacion()
        {
            InitializeComponent();
        }

        private void CancelarReservacion_Load(object sender, EventArgs e)
        {
            clave = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "a")
            {

                //funcion que le mande Clave y se borre la reservacion
                EnlaceDB conexion2 = new EnlaceDB();
                conexion2.Borra_ServiReservation(clave);

                conexion2.Borra_reservation(clave);
                

                conexion2 = null;

                MessageBox.Show("La reservacion de: " + clave + " ha sido cancelada");

            }
            else MessageBox.Show("Contraseña incorrecta");


            listBox1.Items.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            clave = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {//VER DATOS
            listBox1.Items.Clear();
            int cve= int.Parse(textBox1.Text);
            //funcion que busca la reselvacion y muestra datos  
            EnlaceDB conexion = new EnlaceDB();
            conexion.Mostrar_EnText_Reservation(listBox1, cve);
            conexion = null;
            clave = cve;
        }
    }
}
