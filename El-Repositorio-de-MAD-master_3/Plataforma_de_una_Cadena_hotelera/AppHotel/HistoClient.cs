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
    public partial class HistoClient : Form
    {
        static bool Avtivatelabel = false;
        static int conta = 0;
        public HistoClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            EnlaceDB conexion = new EnlaceDB();
            string name = textBox1.Text;
            bool caso = false;
            //lena en el combo si RFC y su nombre completo
           caso= conexion.LLenaEnHistorial(comboBox1, name);
            if(caso)Avtivatelabel = true;
            conexion = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            EnlaceDB conexion2 = new EnlaceDB();
            DataTable data = new DataTable();
            int RFC_C=0;
            char[] delimiterChars = { ' ', '.', ':', '\t' };
            string[] words = comboBox1.Text.Split(delimiterChars);
            int C = 1;
            foreach (var c in words)
            {
                if (C == 1)
                {
                    RFC_C = int.Parse($"{c}");
                }
                C++;
            }




            data= conexion2.Set_HistorialTabla(RFC_C);

            dataGridView1.DataSource = data;
            conexion2 = null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Avtivatelabel) {

                label2.Text = "Se llenó comboBox";
                conta++;

                if (conta == 15)
                {
                    label2.Text = "";
                    Avtivatelabel = false;
                    conta = 0;
                }
            }
                       
        }

        private void HistoClient_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
