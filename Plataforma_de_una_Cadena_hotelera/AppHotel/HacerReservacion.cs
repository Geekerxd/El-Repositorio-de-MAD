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
    public partial class HacerReservacion : Form
    {
        public HacerReservacion()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            var conexion = new EnlaceDB();
            DataTable data = new DataTable();

            data = conexion.get_Users();

            dataGridView1.DataSource = data;
            conexion = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {//reservación

            String Nombre = textBox1.Text;


            var conexion = new EnlaceDB();

            conexion.SET_Users(Nombre); 
 
            
            conexion = null;
            



        }
    }
}
