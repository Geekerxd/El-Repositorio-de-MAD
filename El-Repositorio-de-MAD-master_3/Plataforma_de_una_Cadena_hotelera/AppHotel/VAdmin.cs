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
        static string AdminNmae;
        public VAdmin(string NombreAdmin)
        {
            InitializeComponent();
            B_Modi.Enabled = false;
            B_AgNuevHote.Enabled = false;
            checar = false;

            AdminNmae = NombreAdmin;
        }

        private void B_RepSistema_Click(object sender, EventArgs e)
        {

            Form nuevform = new ReporteOcupacion();
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
            Form nuevform = new AgregarHotel(AdminNmae);
            nuevform.ShowDialog();

        }

        private void B_Modi_Click(object sender, EventArgs e)
        {
            Form nuevform = new ConfiHote();
            nuevform.ShowDialog();
        }

        private void B_regTipoHab_Click(object sender, EventArgs e)
        {
            Form nuevform = new CreaTipoHab();
            nuevform.ShowDialog();
        }

        private void B_RepVent_Click(object sender, EventArgs e)
        {
            Form nuevform = new ReportesVentas();
            nuevform.ShowDialog();
        }

        private void B_CreaUsuEmp_Click(object sender, EventArgs e)
        {
            Form nuevform = new CreaUsuario();
            nuevform.ShowDialog();
        }

        private void VAdmin_Load(object sender, EventArgs e)
        {
            
        }

        private void historialDelClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        

        private void reporteDeOcupacionPorHotelToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void historialDelClienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form nuevform = new HistoClient();
            nuevform.ShowDialog();
        }

        private void paisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form nuevform = new Pais();
            nuevform.ShowDialog();


        }

        private void ciudadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form nuevform = new Ciudad();
            nuevform.ShowDialog();
        }

        private void servicioAdicionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form nuevform = new Servicio();
            nuevform.ShowDialog();
        }
    }
}
