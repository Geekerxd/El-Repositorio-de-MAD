﻿using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

                Form nuevform = new VAdmin();
                nuevform.ShowDialog();
            }
            else if (comboBox1.Text == "Usuario empleado") {
                Form nuevform = new UsuEmp();
                nuevform.ShowDialog();
            }
        }

       
    }
}