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
    public partial class UsuEmp : Form
    {
        static string usuName;
        static int timer=0;
        public UsuEmp(string usuName1)
        {
            InitializeComponent();
            usuName = usuName1;
        }

        private void B_HacReservación_Click(object sender, EventArgs e)
        {
            Form nuevform = new HacerReservacion(usuName);
            nuevform.ShowDialog();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form nuevform = new Cliente(usuName);
            nuevform.ShowDialog();
        }

        private void UsuEmp_Load(object sender, EventArgs e)
        {
            label2.Text = usuName;
            timer1.Start();
        }

        private void B_CheckOut_Click(object sender, EventArgs e)
        {
            
            Form nuevform = new CheckOut();
            nuevform.ShowDialog();
        }

        private void B_CheckIn_Click(object sender, EventArgs e)
        {
            
            Form nuevform = new CheckIn();
            nuevform.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //TIMER
            if (timer % 100 == 0)
            {

                EnlaceDB conexion2 = new EnlaceDB();
                conexion2.ACTUALIZA_RESERV();
                conexion2 = null;
            }

            timer += 1;

        }
    }
}
