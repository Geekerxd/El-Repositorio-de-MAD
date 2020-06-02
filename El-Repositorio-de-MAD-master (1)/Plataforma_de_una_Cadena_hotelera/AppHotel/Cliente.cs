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
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
        }

        //private void Cliente_Load(object sender, EventArgs e)
        //{
        //    radioButton1.Checked = true;
        //}

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int RFC = int.Parse(textBox1.Text);
            var Nombre = textBox2.Text;
            var Paterno = textBox3.Text;
            var Materno = textBox4.Text;
            var Domicilio = textBox6.Text;
            var e_mail = textBox5.Text;
            var telefono = textBox7.Text;

            var referencia = Convert.ToString(0);
            

            if (radioButton1.Checked == true)
            {
                referencia = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                referencia = radioButton2.Text;
            }
            else if(radioButton3.Checked == true)
            {
                referencia = radioButton3.Text;
            }
            else if (radioButton4.Checked == true)
            {
                referencia = radioButton4.Text;
            }
            else if (radioButton5.Checked == true)
            {
                referencia = radioButton5.Text;
            }
            else
            {
                referencia = textBox8.Text;
            }

            //var referencia = textBox2.Text;
            DateTime fecha_naci = dateTimePicker1.Value;

            EnlaceDB conexion = new EnlaceDB();
            conexion.Set_Client(RFC, Nombre, Paterno, Materno, Domicilio, e_mail, telefono, referencia, fecha_naci);
            conexion = null;

            MessageBox.Show("Se guardó cliente: " + Nombre + " " + Paterno + " " + Materno+ ".");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
