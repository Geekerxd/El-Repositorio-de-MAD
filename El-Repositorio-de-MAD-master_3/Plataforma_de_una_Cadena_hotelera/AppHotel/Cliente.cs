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
        static string usuName;

        public Cliente(string usuName1)
        {
            InitializeComponent();
            usuName = usuName1;
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
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" )
            {

                MessageBox.Show("Una casilla está vacía");
                goto fin;
            }
            EnlaceDB conexion2 = new EnlaceDB();
            try { 


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

            int usuNameInt = 0;
           
            usuNameInt = conexion2.show_UsuarioID(usuNameInt, usuName);


            conexion2.Set_Client(RFC, Nombre, Paterno, Materno, Domicilio, e_mail, telefono, referencia, fecha_naci, usuNameInt);
           

            MessageBox.Show("Se guardó cliente: " + Nombre + " " + Paterno + " " + Materno+ ".");
                textBox1.Text = "";
                textBox2.Text="";
                textBox3.Text="";
                textBox4.Text="";
                textBox5.Text="";
                textBox6.Text="";
                textBox7.Text="";
                textBox8.Text="";
                if (radioButton1.Checked == true)
                    radioButton1.Checked = false;
                else if (radioButton2.Checked == true)
                    radioButton2.Checked = false;
                else if (radioButton3.Checked == true)
                    radioButton3.Checked = false;
                else if (radioButton4.Checked == true)
                    radioButton4.Checked = false;
                else if (radioButton5.Checked == true)
                    radioButton5.Checked = false;
                dateTimePicker1.Value = DateTime.Today;

            }
            catch
            {
                var msg = "";
                msg = "Error de tipo de dato.\nAsegurese de usar los datos correctos.\n";
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


        fin:
            conexion2 = null;


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
