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
        static string usuName;
        static bool activateDateChange=false;
        string[] metodos_pago = { "Tarjeta de credito", "Transferencia bancaria", "Cash", "PayPal", "Sofort" };
        static int value=0;

        public HacerReservacion(string usuName1)
        {
            usuName = usuName1;
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            

            //var conexion = new EnlaceDB();
            //DataTable data = new DataTable();

            //data = conexion.get_Users();

            //dataGridView1.DataSource = data;
            //conexion = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {   //  BOTÓN DE RESERVACIÓN

            #region NumDeHabitacion
            int NumHab = 0;
            char[] delimiterChars = { ',', '.', ':', '\t' };

            string[] words = comboBox5.Text.Split(delimiterChars);
            int C = 1;
            foreach (var c in words)
            {
                if (C==3) {
                    NumHab = int.Parse($"{c}");
                }
                C++;
            }
            #endregion

            //MessageBox.Show("el numero de habitación es: "+ NumHab);  //Numero de habitacón
            int  tamanoL = ServiciosEle.Items.Count;                       //tamaño de una lista



            //foreach (var item in ServiciosEle.Items)//cada item de la lista
            //{
            //    MessageBox.Show("Item: " + item.ToString());
            //}


            var anticipo = textBox3.Text;
            var medio_pago_res = comboBox4.Text;
            DateTime fecha_e = dateTimePicker1.Value;
            DateTime fecha_s = dateTimePicker2.Value;
            int Personas = int.Parse(textBox2.Text);

            EnlaceDB conexion12 = new EnlaceDB();
            int ID = int.Parse(textBox4.Text);
           
            conexion12 = null;
            EnlaceDB conexion13 = new EnlaceDB();
            int id_Hab = conexion13.show_id_TipoHab(comboBox2.Text,comboBox3.Text);
            conexion13 = null;
            
            float TotalMoney=int.Parse(label5.Text);

            EnlaceDB conexion11 = new EnlaceDB();
            conexion11.Set_Reservations(anticipo, medio_pago_res, fecha_e, fecha_s, Personas, ID, id_Hab, TotalMoney);
            int clReserv= conexion11.show_id_MAXReservation();

            foreach (var item in ServiciosEle.Items)
             {
                int idS = conexion11.show_idServicio(0, item.ToString());

                conexion11.Registro_serv_in_reserv(clReserv,  idS);
            }
                //conexion11.Registro_serv_in_reserv(int cve_reserv, int id_serv);

            conexion11 = null;
            //show_id_MAXReservation

            //EnlaceDB conexion15 = new EnlaceDB();
            //int id_Hab = conexion15.show_id_TipoHab(comboBox2.Text, comboBox3.Text);
            //conexion15 = null;

            MessageBox.Show("Tu clave de reservación es: "+ clReserv+".\nUtilize esta clave para hacer \"Check In\"");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void HacerReservacion_Load(object sender, EventArgs e)
        {
            timer1.Start();//este es un reloj y va con un funcion de abajo
            label17.Text = "";
            label5.Text = "";
            activateDateChange = false;
            for (int i = 0; i < metodos_pago.Length; i++)
            {
                comboBox4.Items.Add(metodos_pago[i]);
            }

            int usuNameInt = 0;
            EnlaceDB conexion2 = new EnlaceDB();
            usuNameInt = conexion2.show_UsuarioID(usuNameInt, usuName);
            conexion2 = null;

            EnlaceDB conexion = new EnlaceDB();
            conexion.set_CiudadUsu(comboBox1, usuNameInt);
            conexion = null;
            
            //EnlaceDB conexion3 = new EnlaceDB();
            //conexion3.set_Hotels(comboBox2);
            //conexion3 = null;

            


        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            //
            //EnlaceDB conexion4 = new EnlaceDB();
            //conexion4.set_Habs(comboBox3);
            //conexion4 = null;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Text="";
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            comboBox5.Items.Clear();
            comboBox5.Text = "";
            listBox1.Items.Clear();
            ServicionOp.Items.Clear();
            ServiciosEle.Items.Clear();

            var ciudad = comboBox1.Text;
            //MessageBox.Show("La ciudad es:"+ ciudad);
            int usuNameInt = 0;
            EnlaceDB conexion2 = new EnlaceDB();
            usuNameInt = conexion2.show_UsuarioID(usuNameInt, usuName);
            conexion2 = null;

            EnlaceDB conexion4 = new EnlaceDB();
            conexion4.set_Hotels(comboBox2, ciudad, usuNameInt);
            conexion4 = null;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            comboBox5.Items.Clear();
            comboBox5.Text = "";
            ServicionOp.Items.Clear();
            ServiciosEle.Items.Clear();


            string hote = comboBox2.Text;

            EnlaceDB conexion5 = new EnlaceDB();
            conexion5.Mostrar_EnText_hotel(listBox1, hote);
          

          
            int[] IDS = new int[100];
            IDS = conexion5.MostrarTiposHab(hote);
          

            for (int i=0;i< IDS.Length;i++) {


                conexion5.MostrarTiposHab2(comboBox3, IDS[i]);
               

                if (IDS[i]==0) { break; }
            }

           
            int[] serv = new int[50];
            serv = conexion5.MostrarServ(hote);
           



            for (int i = 0; i < serv.Length; i++)
            {




                conexion5.MostrarServicios(ServicionOp, serv[i]);
               



                if (serv[i] == 0) { break; }
            }



            conexion5 = null;

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            comboBox5.Items.Clear();
            comboBox5.Text = "";

            string hote1 = comboBox2.Text;
            string tipo = comboBox3.Text;
            EnlaceDB conexion7 = new EnlaceDB();
            conexion7.MostrarHabitaciones(comboBox5, hote1, tipo);
            conexion7 = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string temp1 = ServicionOp.SelectedItem.ToString();
            ServiciosEle.Items.Add(temp1);
            ServicionOp.Items.Remove(temp1);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string temp2 = ServiciosEle.SelectedItem.ToString();
            ServicionOp.Items.Add(temp2);
            ServiciosEle.Items.Remove(temp2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ///
            String diff2="";
            if (activateDateChange) {
                System.DateTime firstDate = dateTimePicker1.Value;
                System.DateTime secondDate = dateTimePicker2.Value;

                System.TimeSpan diff = secondDate.Subtract(firstDate);
                System.TimeSpan diff1 = secondDate - firstDate;

                diff2 = (secondDate - firstDate).TotalDays.ToString();
            }
            

           
            //value += 1;
            label17.Text = diff2;

           
            //si no estan vacios los siguientes controlles...
            if(comboBox3.Text!="" && textBox2.Text != "" && label17.Text!="") {
                float costo = 0;
                EnlaceDB conexion10 = new EnlaceDB();
                costo= conexion10.CostoHab(costo,comboBox3.Text);
                conexion10 = null;

                float ff = float.Parse(label17.Text);
                float pp = float.Parse(textBox2.Text);
                costo = costo * ff * pp;


                label5.Text = costo.ToString();
            } else {
                label5.Text = "...";
            }

           


            //
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            activateDateChange = true;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            activateDateChange = true;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
            if (textBox1.Text != "") {
                EnlaceDB conexion6 = new EnlaceDB();
                DataTable data = new DataTable();
                data=conexion6.Consulta_Clientes(textBox1.Text);
                dataGridView1.DataSource = data;
                conexion6 = null;

                dataGridView1.Columns[0].ReadOnly =true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].ReadOnly = true;

            }
            else MessageBox.Show("No se ingreso ningun nombre");


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // textBox4.Text = dataGridView1.CurrentCell.Value.ToString();

                string ID= dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if(e.ColumnIndex == 3)textBox4.Text = ID;

        }
    }
}
