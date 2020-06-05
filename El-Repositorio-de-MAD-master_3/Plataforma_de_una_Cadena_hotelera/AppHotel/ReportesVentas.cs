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
   
    public partial class ReportesVentas : Form
    {
        string[] meses = { "Enero","Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviebre", "Diciembre" };
        public ReportesVentas()
        {
            InitializeComponent();
        }
        public int F_meses(string mes)
        {
            switch(mes) {
                case "Enero":
                        return 1;
                       
                    
                   
                case "Febrero":
                    return 2;
                  
                case "Marzo":
                    return 3;
                  
                case "Abril":
                    return 4;
                    
                case "Mayo":
                    return 5;
                   
                case "Junio":
                    return 6;
                   
                case "Julio":
                    return 7;
                   
                case "Agosto":
                    return 8;
                    
                case "Septiembre":
                    return 9;
                   
                case "Octubre":
                    return 10;
                    

                case "Noviebre":
                    return 11;
                   

                case "Diciembre":
                    return 12;

                default: return 0;


            }
            

          
        }


        private void button1_Click(object sender, EventArgs e)
        {
            EnlaceDB conexion = new EnlaceDB();

            string pais = comboBox1.Text;
            string mes = comboBox2.Text;
            DataTable data = new DataTable();

            data= conexion.Set_ReportVentasTabla(pais, F_meses(mes));


            dataGridView1.DataSource = data;



            conexion = null;
        }

        private void ReportesVentas_Load(object sender, EventArgs e)
        {

            EnlaceDB conexion1 = new EnlaceDB();
            conexion1.set_Pais(comboBox1);
            //pais mes ciudad
            for (int i = 0; i < meses.Length; i++)comboBox2.Items.Add(meses[i]);
            comboBox3.Text = "Todas";
            comboBox3.Items.Add("Todas");
            conexion1.set_Ciudad(comboBox3);


            conexion1 = null;
        }
    }
}
