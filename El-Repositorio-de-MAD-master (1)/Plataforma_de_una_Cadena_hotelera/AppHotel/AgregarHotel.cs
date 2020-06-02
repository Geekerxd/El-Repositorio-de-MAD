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


  


    public partial class AgregarHotel : Form
    {
        TipoHabLista lista = new TipoHabLista();// apar tipo de habitacion
        TipoHabLista L_SA = new TipoHabLista();// para servicions asicionales
        string[] TipoHab = { "Individual", "Doble", "Quad", "Queen", "King", "Master Suite", "Junior Suite" };
        //string[] ciudades = { "NewYork", "Monterrey", "CDMX", "Guadalajara", "San Antonio" };
        string[] ZonaTur = { "Playa", "Pueblo mágico", "Montaña", "Ciudad que nunca duerme", "Bosque Lagunas" };
        string[] ServiA = { "Gimnasio", "Wifi", "Servicios de alimentos a cuarto", "Masajes", "Restaurantes" };

        List<String> Tipos = new List<String>();
        string[] tipos;

        public AgregarHotel()
        {
            InitializeComponent();
        }
        private void AgregarHotel_Load(object sender, EventArgs e)
        {
            timerOFchb.Start();

            EnlaceDB conexion = new EnlaceDB();
            conexion.set_Ciudad(comboBox2);
            conexion = null;

            EnlaceDB conexion2 = new EnlaceDB();
            conexion2.set_Usuario(comboBox3);
            conexion2 = null; 

            //List<String> Tipos = new List<String>();

            EnlaceDB conexion3 = new EnlaceDB();
            conexion3.set_Tipo_Hab(Tipos);
            conexion3 = null;

            tipos = Tipos.ToArray();

            for (int i = 0; i < tipos.Length; i++)//   TipoHab.Count() para la lista
            {

                CheckBox chb = new CheckBox();
                TextBox txb = new TextBox();

                chb.Text = tipos[i];
                chb.Location = new Point(10, flowLayoutPanel1.Controls.Count * 20);
                txb.Location = new Point(10, flowLayoutPanel1.Controls.Count * 20);
                flowLayoutPanel1.Controls.Add(chb);
                flowLayoutPanel1.Controls.Add(txb);

                txb.Enabled = false;
                lista.alFinalLista(tipos[i], chb, txb);

            }

            for (int i = 0; i < ZonaTur.Length; i++)
            {
                comboBox1.Items.Add(ZonaTur[i]);
            }

            List<String> Services = new List<String>();

            EnlaceDB conexion4 = new EnlaceDB();
            conexion4.set_Services(Services);
            conexion4 = null;

            string[] services = Services.ToArray();

            for (int i = 0; i < services.Length; i++)
            {
                CheckBox chb = new CheckBox();

                chb.Text = services[i];
                chb.Location = new Point(10, Flow2.Controls.Count * 20);
                Flow2.Controls.Add(chb);
                L_SA.alFinalLista(services[i], chb);
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
            
            int totalHab = lista.ShowTextEveryNumber();

            var caract = textBox3.Text;
            //var usu_reg = textBox2.Text;
            int no_pisos;
            if (textBox4.Text != "")
            {
                 no_pisos = int.Parse(textBox4.Text);
            }
            else { 
                 no_pisos = 0; }

            var nombreH = textBox1.Text;
            int cant_hab = totalHab;
            var zona_tur = comboBox1.Text;
            var domicilio = textBox2.Text;
            var ciudad = comboBox2.Text;
            int usu_atiende = Int32.Parse(comboBox3.Text);// aaqui tiene que buscar el nombre en los registros y devolver su clave

            EnlaceDB conexion = new EnlaceDB();
            conexion.Set_Hotel(caract, no_pisos, nombreH, cant_hab, zona_tur, domicilio, usu_atiende, ciudad);
            conexion = null;


            //int nivel = ;
            //int no_hab = ;
            //int id_hotel = ;
            //var tipo = checkBox1.Text;

            //EnlaceDB conexion2 = new EnlaceDB();
            //conexion2.Set_Habitaciones(nivel, no_hab, id_hotel, tipo);
            //conexion2 = null;

            MessageBox.Show("Se guardó hotel: " + nombreH +".");
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
