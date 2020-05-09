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
    public partial class VAdmin : Form
    {

        static bool checar;
        public VAdmin()
        {
            InitializeComponent();
            B_Modi.Enabled = false;
            B_AgNuevHote.Enabled = false;
            checar = false;
        }

        private void B_RepSistema_Click(object sender, EventArgs e)
        {
            Form nuevform = new ReportesSistema();
            nuevform.ShowDialog();

        }

        private void B_CancReserv_Click(object sender, EventArgs e)
        {
            Form nuevform = new CancelarReservacion();
            nuevform.ShowDialog();
        }

        private void B_Hote_Click(object sender, EventArgs e)
        {
            checar = !checar;
            B_Modi.Enabled= checar;
            B_AgNuevHote.Enabled = checar;
            
        }

        private void B_AgNuevHote_Click(object sender, EventArgs e)
        {
            Form nuevform = new AgregarHotel();
            nuevform.ShowDialog();

        }

        private void B_Modi_Click(object sender, EventArgs e)
        {

        }

        private void B_regTipoHab_Click(object sender, EventArgs e)
        {

        }

        private void B_RepVent_Click(object sender, EventArgs e)
        {

        }

        private void B_CreaUsuEmp_Click(object sender, EventArgs e)
        {

        }

        private void VAdmin_Load(object sender, EventArgs e)
        {
            
        }
    }
}
