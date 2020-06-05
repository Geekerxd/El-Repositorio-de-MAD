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
        public HistoClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            EnlaceDB conexion = new EnlaceDB();
            string name = textBox1.Text;

            //lena en el combo si RFC y su nombre completo
            conexion.LLenaEnHistorial(comboBox1, name);

            conexion = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
    }
}
