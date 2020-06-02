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
    
    public partial class Form1 : Form
    {
        static bool Accede;
        string NombreAdmin = "a";
        string ContraAdmin = "a";

        #region principio
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Administrador");
            comboBox1.Items.Add("Usuario empleado");
        }
        /// <summary>
        /// Permite la entrada de Usuarios segun la contraseña y tipo de usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text == "Administrador")
            {
                string adminNmae = textBox1.Text;
                string adminContra = textBox2.Text;

                if (adminNmae == NombreAdmin && adminContra == ContraAdmin)
                {
                    Form nuevform = new VAdmin(NombreAdmin);
                    nuevform.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nombre de usuario o cantraseña incorrectos");
                }
            }
            else if (comboBox1.Text == "Usuario empleado")
            {
               
                string usuNmae= textBox1.Text;
                string usuContra = textBox2.Text;

                EnlaceDB conexion = new EnlaceDB();
                Accede= conexion.AccesoUsu(usuNmae, usuContra);
                conexion = null;

                if (Accede) {

                    Form nuevform = new UsuEmp(usuNmae);
                    nuevform.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nombre de usuario o cantraseña incorrectos");
                }

                Accede = false;
            }
        }


        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
