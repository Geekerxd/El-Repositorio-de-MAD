using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace AppHotel
{
    public partial class CheckOut : Form
    {
        static int _IDC;
        public CheckOut()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            EnlaceDB conexion = new EnlaceDB();
            bool validacion=true;

            if (textBox1.Text == "") { MessageBox.Show("Casilla de clave de reservacion está vacia."); validacion = false; }
            else if (!conexion.MostrarReservacion(listBox1, int.Parse(textBox1.Text)))
            { MessageBox.Show("No existe registros de clave ingresada."); validacion = false; }

            if (validacion)
            {
                _IDC = int.Parse(conexion.GetIDCliente());
                int IDH = int.Parse(conexion.GetIDHotel());
                listBox1.Items.Add("Nombre del cliente:\t\t" + conexion.IDGetCliente(_IDC));
                listBox1.Items.Add("Tipo de habitacion:\t\t" + conexion.IDGetHabitacion(IDH));
                if (textBox2.Text != "")
                    listBox1.Items.Add("Costo Total:\t" + conexion.Precio_Total(int.Parse(textBox1.Text), float.Parse(textBox2.Text)).ToString());

                conexion.MostrarServiciosCheckOut(listBox2 ,int.Parse(textBox1.Text));
                conexion.SetIDCliente("");
                conexion.SetIDHotel("");
            }


            conexion = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {   /////////////////////////////////////////
            //   CHECK OUT — CREAR FACTURA         //
            /////////////////////////////////////////
            ///
           
       

            EnlaceDB conexion2 = new EnlaceDB();


            conexion2.Ingresafactura(int.Parse(textBox1.Text));
            int NuFactura = conexion2.show_id_MAXFACTURA();

            string extencion = "Factura " + NuFactura.ToString() ;
            //string fileName = @"C:\Users\Dell 66895\Desktop\Repositorio_MAD\El-Repositorio-de-MAD-master_3\Plataforma_de_una_Cadena_hotelera\AppHotel\Facturas\"+ extencion+ ".txt";
            string fileName6 = Environment.CurrentDirectory +"\\"+ extencion + ".txt";
            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName6))
                {
                    File.Delete(fileName6);
                }

                // Create a new file     
                using (StreamWriter sw = File.CreateText(fileName6))
                {

                    sw.WriteLine("Número de factura: \t{0}", NuFactura);


                    conexion2.MostrarReservacion2(sw, int.Parse(textBox1.Text));
                    _IDC = int.Parse(conexion2.GetIDCliente());
                    int IDH = int.Parse(conexion2.GetIDHotel());

                    sw.WriteLine("Nombre del cliente:\t" + conexion2.IDGetCliente(_IDC));
                    sw.WriteLine("Tipo de habitacion:\t" + conexion2.IDGetHabitacion(IDH));
                    if (textBox2.Text != "")
                        sw.WriteLine("Costo Total:\t\t" + conexion2.Precio_Total(int.Parse(textBox1.Text), float.Parse(textBox2.Text)).ToString());






                   
                    //sw.WriteLine("Author: Gonzalo Aguilar Galeana");
                    //sw.WriteLine("☼☼♫◄►♀☼☼♫◄►♀☼☼♫◄►♀☼☼♫◄►♀☼☼♫◄►♀☼☼♫◄►♀☼☼♫◄►♀");
                    //sw.WriteLine("Add one more line ");
                    //sw.WriteLine("Done! ");
                }

                conexion2.CheckOut(int.Parse(textBox1.Text));



                MessageBox.Show("Se creo factura con el número "+ NuFactura + " como documento de texto \n"+@"En: AppHotel\Facturas");
                textBox1.Text = "";
                textBox2.Text="";
                listBox1.Items.Clear();
                listBox2.Items.Clear();

                #region leer_txt
                // Write file contents on console.    
                /* using (StreamReader sr = File.OpenText(fileName6))
                 {
                     string s = "";
                     while ((s = sr.ReadLine()) != null)
                     {
                         Console.WriteLine(s);
                     }
                 }*/
                #endregion
            }
            catch (Exception Ex)
            {
               
                MessageBox.Show(Ex.ToString());
            }



            conexion2 = null;
        }

        private void CheckOut_Load(object sender, EventArgs e)
        {

        }
    }
}
