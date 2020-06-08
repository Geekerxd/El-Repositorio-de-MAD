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
        string adminName;
        TipoHabLista lista = new TipoHabLista();// para tipo de habitacion
        TipoHabLista L_SA = new TipoHabLista();// para servicions asicionales
        string[] TipoHab = { "Individual", "Doble", "Quad", "Queen", "King", "Master Suite", "Junior Suite" };
        //string[] ciudades = { "NewYork", "Monterrey", "CDMX", "Guadalajara", "San Antonio" };
        string[] ZonaTur = { "Playa", "Pueblo mágico", "Montaña", "Ciudad que nunca duerme", "Bosque Lagunas" };
        string[] ServiA = { "Gimnasio", "Wifi", "Servicios de alimentos a cuarto", "Masajes", "Restaurantes" };

        List<String> Tipos = new List<String>();
        string[] tipos;

        public AgregarHotel(string AdminNmae)
        {
            adminName = AdminNmae;

            InitializeComponent();

        }
        private void AgregarHotel_Load(object sender, EventArgs e)
        {
            timerOFchb.Start();//este es un reloj y va con un funcion de abajo



            label12.Text= adminName;

            EnlaceDB conexion = new EnlaceDB();
            conexion.set_Ciudad(comboBox2);
            conexion = null;

            //EnlaceDB conexion2 = new EnlaceDB();
            //conexion2.set_Usuario(comboBox3);
            //conexion2 = null; 

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
            EnlaceDB conexion5 = new EnlaceDB();
            //funcion que cheque si ya existe el hotel
            
            if (conexion5.show_Hotel(0, textBox1.Text) != 0) {
                MessageBox.Show("Hotel \""+ textBox1.Text + "\" Ya existe"); goto END; }

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
            string ciudad1 = comboBox2.Text;

            int ciudad = 0;
           
            ciudad = conexion5.show_idCiudad(ciudad, ciudad1);
           
            // var usu_atiendeTemp = comboBox3.Text;

            //int usu_atiende = 0;
            //EnlaceDB conexion4 = new EnlaceDB();
            //usu_atiende = conexion4.show_UsuarioID(usu_atiende, usu_atiendeTemp);
            //conexion4 = null;

            //int usu_atiende = Int32.Parse(comboBox3.Text);

           
            conexion5.Set_Hotel(caract, no_pisos, nombreH, cant_hab, zona_tur, domicilio, ciudad, adminName);
           

            int id_hotel = 0;
           
            id_hotel= conexion5.show_Hotel(id_hotel, nombreH);
           

            //var random = new Random();
            int no_hab = 0;

            //funcion que regresa la cantidad de tipos de hab con palomita
            int canthabcheck= lista.ShowTextEveryNumber2();
            for (int i = 0; i < canthabcheck; i++)// cant tipos de hab
            {
                //funcion que trae el numero de habitaciones de este tipo
                int canth = lista.ShowTextEveryNumber3(i);
                //funciones que trae el texto del tipo de hab
                string Tipotemp = lista.ShowTextEveryNumber4(i);

                for (int j = 0; j < canth; j++)// canti hab de es tipo
                {

                    //var value = random.Next(1, int.Parse(textBox4.Text));
                    //
                    //var nivel = value;
                    no_hab = no_hab +1;

                    int tipo1 = 0;
                   
                    tipo1 = conexion5.show_TipoHabID(tipo1, Tipotemp);
                    

                    var tipo = tipo1;
                    //
                   
                    conexion5.Set_Habitaciones(no_hab, id_hotel, tipo);
                    
                }
            }

            lista.limpieza();

            int cantServicheck = L_SA.ShowTextEveryNumber6();//especial para los checkbox

            for (int i=0;i<cantServicheck;i++) {

                var TipoServi = L_SA.ShowTextEveryNumber4(i);
                //var TipoServi = L_SA.ShowTextEveryNumber4(i);

                int tipo1 = 0;
               
                tipo1 = conexion5.show_idServicio(tipo1, TipoServi);
                

               
                conexion5.Set_Servicios_en_Hotel(id_hotel, tipo1);
                
            }

            lista.limpieza2();


            MessageBox.Show("Se guardó hotel: " + nombreH +".");



            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            lista.ressetTipoHab();
            L_SA.ressetServi();





        END:
            conexion5 = null;
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

        private void label12_Click(object sender, EventArgs e)
        {



        }
    }
}
