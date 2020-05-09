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


  


    public partial class AgregarHotel : Form
    {
        TipoHabLista lista = new TipoHabLista();// apar tipo de habitacion
        TipoHabLista L_SA = new TipoHabLista();// para servicions asicionales
        string[] TipoHab = { "Individual", "Doble", "Quad", "Queen", "King", "Master Suite", "Junior Suite" };
        string[] ciudades = { "NewYork", "Monterrey", "CDMX", "Guadalajara", "San Antonio" };
        string[] ZonaTur = { "Playa", "Pueblo mágico", "Montaña", "Ciudad que nunca duerme", "Bosque Lagunas" };
        string[] ServiA = { "Gimnasio", "Wifi", "Servicios de alimentos a cuarto", "Masajes", "Restaurantes" };


        public AgregarHotel()
        {
            InitializeComponent();
        }
        private void AgregarHotel_Load(object sender, EventArgs e)
        {
            timerOFchb.Start();
            
            for (int i = 0; i < ciudades.Length; i++)
            {
                comboBox2.Items.Add(ciudades[i]);
            }
            for (int i = 0; i < TipoHab.Length; i++)//   TipoHab.Count() para la lista
            {

                CheckBox chb = new CheckBox();
                TextBox txb = new TextBox();

                chb.Text = TipoHab[i];
                chb.Location = new Point(10, flowLayoutPanel1.Controls.Count * 20);
                txb.Location = new Point(10, flowLayoutPanel1.Controls.Count * 20);
                flowLayoutPanel1.Controls.Add(chb);
                flowLayoutPanel1.Controls.Add(txb);

                txb.Enabled = false;
                lista.alFinalLista(TipoHab[i],chb, txb);
                          
            }

            for (int i = 0; i < ZonaTur.Length; i++)
            {
                comboBox1.Items.Add(ZonaTur[i]);
            }
            for (int i = 0; i < ServiA.Length; i++)
            {
                CheckBox chb = new CheckBox();

                chb.Text = ServiA[i];
                chb.Location = new Point(10, Flow2.Controls.Count * 20);
                Flow2.Controls.Add(chb);
                L_SA.alFinalLista(ServiA[i], chb);
            }




        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

           


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void flowLayoutPanel1_MouseCaptureChanged(object sender, EventArgs e)
        {
           
        }

        private void timerOFchb_Tick(object sender, EventArgs e)
        {
            lista.getEvery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            L_SA.getEveryText();
        }

        private void Flow2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
          
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}