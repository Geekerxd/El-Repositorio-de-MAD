using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
namespace AppHotel
{
    public class EnlaceDB
    {
        static private string _aux { set; get; }
        static private SqlConnection _conexion;
        static private DataTable _tabla = new DataTable();
        static private DataSet _DS = new DataSet();
        static private SqlDataAdapter _adaptador = new SqlDataAdapter();
        static private SqlCommand _comandosql = new SqlCommand();
        static private SqlCommand _comandosql2 = new SqlCommand();
        static private SqlDataReader dr;
        static private int IDClienteTemp=0;
        static private string  idc= "";
        static private string  idH= "";
        public DataTable obtenertabla
        {
            get
            {
                return _tabla;
            }
        }

        public int obtenerIDClienteTemp()
        {
            return IDClienteTemp;
        }

        private static void conectar()
        {
            //string cnn = ConfigurationManager.AppSettings["desarrollo1"];
            string cnn = ConfigurationManager.ConnectionStrings["desarrollo1"].ToString();
            _conexion = new SqlConnection(cnn);
        }
        private static void desconectar()
        {
            _conexion.Close();
        }

        public  string GetIDCliente()
        {
            return idc;
        }
        public  string GetIDHotel()
        {
            return idH;
        }
        public string SetIDCliente(string id)
        {
            return idc;
        }
        public string SetIDHotel(string id)
        {
            return idH;
        }

        public bool Autentificar(string us, string ps)
        {
            bool isValid = false;
            try
            {
                conectar();
                string qry = "SP_ValidaUser";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.Text;
                _comandosql.CommandTimeout = 9000;

                var parametro1 = _comandosql.Parameters.Add("@u", SqlDbType.Char, 20);
                parametro1.Value = us;
                var parametro2 = _comandosql.Parameters.Add("@p", SqlDbType.Char, 20);
                parametro2.Value = ps;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(_tabla);

                if (_tabla.Rows.Count > 0)
                {
                    isValid = true;
                }

            }
            catch (SqlException e)
            {
                isValid = false;
            }
            finally
            {
                desconectar();
            }

            return isValid;
        }

        //EJEMPLO////////////////////////////////////////////////////////
        public DataTable get_Users()
        {
            var msg = "";
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                string qry = "Select Nombre_Comp, No_nomina, Fecha_nacimiento from Usuario";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.Text;
                _comandosql.CommandTimeout = 1200;



                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }
        
        //PRUEBA/////////////////////////////////////////////////////////
        public void SET_Users(string name)
        {
            var msg = "";
           // DataTable tabla = new DataTable();
            try
            {
                conectar();
               // string qry = "exec sp_Insert_User 'aww','"+  name + "','45','19950118','calleee 15','12345678',NULL";



                string cmd = string.Format("EXEC sp_Insert_User1 '{0}' ", name);


                //insert into Usuario values('dsa','dsa perez','79','19980501','super calle 15','12345678',NULL)
                _comandosql = new SqlCommand(cmd, _conexion);
                _comandosql.CommandType = CommandType.Text;
                _comandosql.CommandTimeout = 1200;



                _adaptador.SelectCommand = _comandosql;
                //_adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
            
        }


        public DataTable Registra_Pais(string nombre, string descrip)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Insert_Pais";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                parametro1.Value = nombre;

                var parametro2 = _comandosql.Parameters.Add("@descrip", SqlDbType.VarChar, 300);
                parametro2.Value = descrip;

                
                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        //LLena tablas
        public DataTable Consulta_Clientes(string name)
        {
            var msg = "";
            DataTable tabla = new DataTable();

            try
            {
                conectar();
                string qry = "SP_Consulta_cliente";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@nombreCliente", SqlDbType.VarChar, 80);
                parametro1.Value = name;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }



        public DataTable Registra_Ciudad(string nombre, string descrip, int pais, int cve_usu)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Insert_City";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                parametro1.Value = nombre;

                var parametro2 = _comandosql.Parameters.Add("@descrip", SqlDbType.VarChar, 300);
                parametro2.Value = descrip;

                var parametro3 = _comandosql.Parameters.Add("@id_pais", SqlDbType.Int);
                parametro3.Value = pais;
                var parametro4 = _comandosql.Parameters.Add("@cve_usu", SqlDbType.Int);
                parametro4.Value = cve_usu;



                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }


        public DataTable Set_Users(string contrase, string Nombre, string Paterno, 
            string Materno, int nNomina, DateTime nacimi, string domici,  string telCel)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Insert_User";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@Contrasena", SqlDbType.Char, 8);
                parametro1.Value = contrase;

                var parametro2 = _comandosql.Parameters.Add("@nombreC", SqlDbType.VarChar, 80);
                parametro2.Value = Nombre;
                
                var parametro3 = _comandosql.Parameters.Add("@paterno", SqlDbType.VarChar, 20);
                parametro3.Value = Paterno;
                var parametro4 = _comandosql.Parameters.Add("@materno", SqlDbType.VarChar, 20);
                parametro4.Value = Materno;
                var parametro5 = _comandosql.Parameters.Add("@No_nomina", SqlDbType.Int);
                parametro5.Value = nNomina;
                var parametro6 = _comandosql.Parameters.Add("@Fecha_nacimiento", SqlDbType.Date);
                parametro6.Value = nacimi;
                var parametro7 = _comandosql.Parameters.Add("@Domicilio", SqlDbType.VarChar, 100);
                parametro7.Value = domici;
                var parametro8 = _comandosql.Parameters.Add("@Telefono", SqlDbType.Char, 10);
                parametro8.Value = telCel;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Registra_Tipo_Hab(string nombre, string descrip, int no_camas, string tipo_cama, 
            int cant_pers, string precio)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Insertar_Tipo_Hab";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                parametro1.Value = nombre;

                var parametro2 = _comandosql.Parameters.Add("@descrip", SqlDbType.VarChar, 300);
                parametro2.Value = descrip;

                var parametro3 = _comandosql.Parameters.Add("@no_camas", SqlDbType.TinyInt);
                parametro3.Value = no_camas;

                var parametro4 = _comandosql.Parameters.Add("@tipo_cama", SqlDbType.VarChar, 30);
                parametro4.Value = tipo_cama;

                var parametro5 = _comandosql.Parameters.Add("@cant_pers", SqlDbType.TinyInt);
                parametro5.Value = cant_pers;

                var parametro6 = _comandosql.Parameters.Add("@precio", SqlDbType.Money);
                parametro6.Value = precio;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Registra_Servicio(string nombre, string precio, string caract)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Insert_Service";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                parametro1.Value = nombre;

                var parametro2 = _comandosql.Parameters.Add("@precio", SqlDbType.Money);
                parametro2.Value = precio;

                var parametro3 = _comandosql.Parameters.Add("@caract", SqlDbType.VarChar, 300);
                parametro3.Value = caract;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Registro_serv_in_reserv(int cve_reserv, int idS)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Insert_Serv_in_Reserv";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@cve_reserv", SqlDbType.BigInt);
                parametro1.Value = cve_reserv;

                var parametro2 = _comandosql.Parameters.Add("@id_serv", SqlDbType.Int);
                parametro2.Value = idS;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Set_Client(int RFC, string Nombre, string Paterno, string Materno, 
            string domicilio, string e_mail, string telcel, string referencia, DateTime fecha_naci, int usuName)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Insert_Client";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@RFC", SqlDbType.Int);
                parametro1.Value = RFC;

                var parametro2 = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 80);
                parametro2.Value = Nombre;

                var parametro3 = _comandosql.Parameters.Add("@paterno", SqlDbType.VarChar, 20);
                parametro3.Value = Paterno;
                var parametro4 = _comandosql.Parameters.Add("@materno", SqlDbType.VarChar, 20);
                parametro4.Value = Materno;
                var parametro5 = _comandosql.Parameters.Add("@domicilio", SqlDbType.VarChar, 100);
                parametro5.Value = domicilio;
                var parametro6 = _comandosql.Parameters.Add("@e_mail", SqlDbType.VarChar, 50);
                parametro6.Value = e_mail;
                var parametro7 = _comandosql.Parameters.Add("@telefono", SqlDbType.Char, 10);
                parametro7.Value = telcel;
                var parametro8 = _comandosql.Parameters.Add("@referencia", SqlDbType.VarChar, 50);
                parametro8.Value = referencia;
                var parametro9 = _comandosql.Parameters.Add("@fecha_naci", SqlDbType.Date);
                parametro9.Value = fecha_naci;
                var parametro10 = _comandosql.Parameters.Add("@usuRegistro", SqlDbType.Int);
                parametro10.Value = usuName;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }


        #region LLENAR_COMBOS
        public void set_Pais(ComboBox combo)
        {//llenar combo
            var msg = "";

            try
            {

                conectar();

                dr = null;
                string qry = "sp_Busca_Pais";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                dr = _comandosql.ExecuteReader();

                while (dr.Read())
                {
                    combo.Items.Add(dr["nombre"].ToString());
                }

                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        }
        public void set_Ciudad(ComboBox combo)
        {//llenar combo
            var msg = "";

            try
            {

                conectar();

                dr = null;
                string qry = "sp_Busca_Ciudad";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                dr = _comandosql.ExecuteReader();

                while (dr.Read())
                {
                    combo.Items.Add(dr["nombre"].ToString());
                }

                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        }
        public void set_CiudadUsu(ComboBox combo, int idUsu)
        {//llenar combo
            var msg = "";

            try
            {

                conectar();

                dr = null;
                string qry = "sp_Busca_CiudadUsu";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@idUsu", SqlDbType.Int);
                parametro1.Value = idUsu;


                dr = _comandosql.ExecuteReader();

                while (dr.Read())
                {
                    combo.Items.Add(dr["nombre"].ToString());
                }

                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        }
        public void set_Cliente(ComboBox combo)
        {//llenar combo
            var msg = "";

            try
            {

                conectar();

                dr = null;
                string qry = "sp_Busca_Cliente";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                dr = _comandosql.ExecuteReader();

                while (dr.Read())
                {
                    combo.Items.Add(dr["nombre"].ToString());
                }

                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        }
        public void set_Hotels(ComboBox combo, string ciudad, int usuName)
        {//llenar combo
            var msg = "";

            try
            {

                conectar();

                dr = null;
                string qry = "sp_Busca_Hotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@nombre_ciudad", SqlDbType.VarChar, 50);
                parametro1.Value = ciudad;

                var parametro2 = _comandosql.Parameters.Add("@id_usu", SqlDbType.Int);
                parametro2.Value = usuName;

                dr = _comandosql.ExecuteReader();

                while (dr.Read())
                {
                    combo.Items.Add(dr["nombre"].ToString());
                }
                

                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        }
        public void MostrarTiposHab2(ComboBox combo, int IDS)
        {//llenar combo
            var msg = "";

            try
            {

                conectar();

                dr = null;
                string qry = "sp_MuestraTipoHab2";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@id", SqlDbType.Int);
                parametro1.Value = IDS;

                dr = _comandosql.ExecuteReader();



                while (dr.Read())
                {
                    combo.Items.Add(dr["nombre"].ToString());
                }


                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        }
        public void MostrarHabitaciones(ComboBox combo, string NameH, string NameTH)
        {//llenar combo
            var msg = "";

            try
            {

                conectar();

                dr = null;
                string qry = "sp_MuestraHabitacion";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@nombre_hotel", SqlDbType.VarChar, 50);
                parametro1.Value = NameH;
                var parametro2 = _comandosql.Parameters.Add("@tipo_hab", SqlDbType.VarChar, 50);
                parametro2.Value = NameTH;

                dr = _comandosql.ExecuteReader();



                while (dr.Read())
                {
                    combo.Items.Add("Hab. Num: "+ dr["num"].ToString());
                }


                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        }
        public void set_Usuario(ComboBox combo)
        {//llenar combo
            var msg = "";

            try
            {

                conectar();

                dr = null;
                string qry = "sp_Busca_Usuario";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                dr = _comandosql.ExecuteReader();

                while (dr.Read())
                {
                    combo.Items.Add(dr["nombre"].ToString());
                }

                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        }

        public int[] MostrarTiposHab( string hotel)
        {//llenar combo
            var msg = "";
        int[] IDS = new int[100];
            try
            {

                conectar();

                dr = null;
                string qry = "sp_MuestraTipoHab";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@nombre_hotel", SqlDbType.VarChar, 50);
                parametro1.Value = hotel;

                dr = _comandosql.ExecuteReader();
                int cont = 0;
                int[] Ids = new int[100];
                int id;
                while (dr.Read())
                {
                     id = Int32.Parse(dr["ID"].ToString());
                    Ids[cont] = id;
                    cont++;
                }
               
                IDS=Ids;

                //for (int i=0;i< cont;i++) {//       FOR

                //    //Ids[i];
                //    //combo.Items.Add(dr["nombre"].ToString());
                //    MostrarTiposHab2(combo,Ids[i]);
                //}


        

                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        return IDS;
        }

        public bool LLenaEnHistorial(ComboBox combo,string name)
        {//llenar combo
            var msg = "";
            bool caso=false;
            try
            {

                conectar();

                dr = null;
                string qry = "sp_BuscaClientRFC";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 80);
                parametro1.Value = name;




                dr = _comandosql.ExecuteReader();

                while (dr.Read())
                {
                    combo.Items.Add(dr["RFC"].ToString() + " " + dr["Nombre"].ToString() + " " + dr["Paterno"].ToString() + " " + dr["Materno"].ToString());
                }
                if (dr.Read())  caso = true;  else caso = false;
                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
            return caso;
        }



        #endregion


        //CASO ESPECIAL ARREGLO
        public int[] MostrarServ(string hotel)
        {//llenar combo
            var msg = "";
            int[] serv = new int[50];
            try
            {


                conectar();


                dr = null;
                string qry = "sp_MuestraServ";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;


                var parametro1 = _comandosql.Parameters.Add("@id_hotel", SqlDbType.VarChar, 50);
                parametro1.Value = hotel;


                dr = _comandosql.ExecuteReader();
                int cont = 0;
                int[] Ids = new int[50];
                int id;
                while (dr.Read())
                {
                    id = Int32.Parse(dr["ID"].ToString());
                    Ids[cont] = id;
                    cont++;
                }


                serv = Ids;


                _conexion.Close();


            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
            return serv;
        }
        public void MostrarServicios(ListBox list, int serv)
        {//llenar combo
            var msg = "";



            try
            {



                conectar();



                dr = null;
                string qry = "sp_MuestraServicios";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;



                var parametro1 = _comandosql.Parameters.Add("@id", SqlDbType.Int);
                parametro1.Value = serv;



                dr = _comandosql.ExecuteReader();





                while (dr.Read())
                {
                    list.Items.Add(dr["nombre"].ToString());
                }




                _conexion.Close();



            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        }
        public float CostoHab(float ElCosto, string tipohab)
        {//llenar combo
            var msg = "";

            string ss="";

            try
            {



                conectar();



                dr = null;
                string qry = "sp_TraeCosto";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;



                var parametro1 = _comandosql.Parameters.Add("@tipo_hab", SqlDbType.VarChar,50);
                parametro1.Value = tipohab;



                dr = _comandosql.ExecuteReader();





                if (dr.Read())
                {
                    ss = dr["Price"].ToString();
                    //100.0
                    ElCosto = float.Parse(ss);
                }




                _conexion.Close();



            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
            return ElCosto;
        }
        public bool MostrarReservacion(ListBox list, int CveRes)
        {//llenar combo
            var msg = "";

            bool encontrado = false;

            try
            {



                conectar();



                dr = null;
                string qry = "sp_MostrarDatosReservacion";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;



                var parametro1 = _comandosql.Parameters.Add("@id", SqlDbType.Int);
                parametro1.Value = CveRes;



                dr = _comandosql.ExecuteReader();





                if (dr.Read())
                {
                    encontrado = true;
                    list.Items.Add("RFC del cliente:\t\t" + dr["idc"].ToString());
                    idc = dr["idc"].ToString();
                   // list.Items.Add("Id de la habitacion:\t\t" + dr["idh"].ToString());
                    idH = dr["idh"].ToString();
                    list.Items.Add("Numero de personas:\t" + dr["personas"].ToString());
                    list.Items.Add("Anticipo:\t\t\t" + dr["anticipo"].ToString());
                    list.Items.Add("Metodo de pago elegido:\t" + dr["MPR"].ToString());
                    list.Items.Add("Fecha de entrada:\t\t" + dr["FE"].ToString());
                    list.Items.Add("Fecha de salida:\t\t" + dr["FS"].ToString());
                  
                    if (dr["CheckIN"].ToString() == "True") list.Items.Add("Ckeck In:\t\tSí." );
                    else list.Items.Add("Ckeck In:\t\tNo.");

                    if (dr["CheckOUT"].ToString() == "True") list.Items.Add("Ckeck Out:\t\tSí.");
                    else list.Items.Add("Ckeck Out:\t\tNo.");




                }




                _conexion.Close();



            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                encontrado = false;
            }
            finally
            {
                desconectar();
            }
            return encontrado;
        }

        public void MostrarReservacion2(StreamWriter sw, int CveRes)
        {//llenar combo
            var msg = "";



            try
            {



                conectar();



                dr = null;
                string qry = "sp_MostrarDatosReservacion";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;



                var parametro1 = _comandosql.Parameters.Add("@id", SqlDbType.Int);
                parametro1.Value = CveRes;



                dr = _comandosql.ExecuteReader();





                if (dr.Read())
                {
                    sw.WriteLine("Id del cliente: \t\t" + dr["idc"].ToString());
                    sw.WriteLine("Id de la habitacion: \t" + dr["idh"].ToString());
                    sw.WriteLine("Numero de personas: \t" + dr["personas"].ToString());
                    sw.WriteLine("Anticipo: \t\t\t" + dr["anticipo"].ToString());
                    sw.WriteLine("Metodo de pago: \t\t" + dr["MPR"].ToString());
                    sw.WriteLine("Fecha de entrada: \t" + dr["FE"].ToString());
                    sw.WriteLine("Fecha de salida: \t\t" + dr["FS"].ToString());

                   
                     idc = dr["idc"].ToString();
                   
                     idH = dr["idh"].ToString();
                    
                }




                _conexion.Close();



            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        }




        public void set_InfoHotel(ListBox List)
        {//llenar combo
            var msg = "";

            try
            {

                conectar();

                dr = null;
                string qry = "sp_Busca_Cliente";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                dr = _comandosql.ExecuteReader();

                while (dr.Read())
                {
                    List.Items.Add("Nombre del Hotel: " + dr["nombre"].ToString());
                    List.Items.Add("Nùmero de pisos: " + dr["No_pisos"].ToString());




                }

                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        }
        //AccesoUsu
        public bool AccesoUsu(string usuName,string usuContra)
        {//llenar combo
            var msg = "";
            bool isValid = false;
             DataTable _tablaTemp = new DataTable();
            try
            {

                conectar();

                dr = null;
                string qry = "sp_BuscaUsu";
                _comandosql = new SqlCommand(qry, _conexion);
               // _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 9000;

                var parametro1 = _comandosql.Parameters.Add("@usuName", SqlDbType.VarChar,80);
                parametro1.Value = usuName;

                var parametro2 = _comandosql.Parameters.Add("@usuContra", SqlDbType.Char, 8);
                parametro2.Value = usuContra;



                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(_tablaTemp);


                // int Scondicion= int.Parse(dr["Bool"].ToString());
                //id_hotel = int.Parse(dr["ID"].ToString());
                if (_tablaTemp.Rows.Count > 0)
                {
                    isValid = true;
                }
               // _conexion.Close();

            }
            catch (SqlException e)
            {

                isValid = false;

            }
            finally
            {
                desconectar();
            }
            return isValid;
        }


        public void set_Tipo_Hab(List<String> Tipos)
        {//llenar combo
            var msg = "";

            try
            {

                conectar();

                dr = null;
                string qry = "sp_Busca_Tipo_Hab";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                dr = _comandosql.ExecuteReader();

                while (dr.Read())
                {
                    Tipos.Add(dr["nombre"].ToString());
                }

                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        }

        public void set_Services(List<String> Services)
        {//llenar combo
            var msg = "";

            try
            {

                conectar();

                dr = null;
                string qry = "sp_Busca_Servicio";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                dr = _comandosql.ExecuteReader();

                while (dr.Read())
                {
                    Services.Add(dr["nombre"].ToString());
                }

                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        }

        public DataTable Set_Hotel(string caract, int no_pisos, string nombre, int cant_hab, 
            string zona_tur, string domicilio, int ciudad, string adminName)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Insert_Hotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@caract", SqlDbType.VarChar, 300);
                parametro1.Value = caract;

                var parametro2 = _comandosql.Parameters.Add("@usuario_registro", SqlDbType.VarChar, 80);
                parametro2.Value = adminName;

                var parametro3 = _comandosql.Parameters.Add("@no_pisos", SqlDbType.TinyInt);
                parametro3.Value = no_pisos;
                var parametro4 = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                parametro4.Value = nombre;
                var parametro5 = _comandosql.Parameters.Add("@cant_hab", SqlDbType.Int);
                parametro5.Value = cant_hab;
                var parametro6 = _comandosql.Parameters.Add("@zona_tur", SqlDbType.VarChar, 50);
                parametro6.Value = zona_tur;
                var parametro8 = _comandosql.Parameters.Add("@domicilio", SqlDbType.VarChar, 100);
                parametro8.Value = domicilio;
                
                var parametro10 = _comandosql.Parameters.Add("@Ciudad", SqlDbType.Int);
                parametro10.Value = ciudad;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public string IDGetCliente(int IDCli)
        {
            var msg = "";
            string NombreCliente="";
            try
            {

                conectar();

                dr = null;
                string qry = "sp_MostrarNombreCliente";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;


                var parametro1 = _comandosql.Parameters.Add("@id", SqlDbType.Int);
                parametro1.Value = IDCli;


                dr = _comandosql.ExecuteReader();



                if (dr.Read())
                {
                    // Tipos.Add(dr["nombre"].ToString());
                    NombreCliente = dr["name"].ToString()+" "+ dr["p"].ToString() + " " + dr["m"].ToString();
                }

                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
            return NombreCliente;
        }

        public string IDGetHabitacion(int IDHabi)
        {//llenar combo
            var msg = "";
            string Nombrehabi = "";
            try
            {

                conectar();

                dr = null;
                string qry = "sp_MostrarNombreHabitac";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;


                var parametro1 = _comandosql.Parameters.Add("@id", SqlDbType.Int);
                parametro1.Value = IDHabi;


                dr = _comandosql.ExecuteReader();



                if (dr.Read())
                {
                    // Tipos.Add(dr["nombre"].ToString());
                    Nombrehabi = dr["nom"].ToString();
                }

                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
            return Nombrehabi;
        }
        /// <summary>
        /// CHECK IN
        /// </summary> 
        /// <param name="idReserv">CON CLAVE DE RESERVACION</param>
        public void CHECK_IN(int idReserv)
        {//llenar combo
            var msg = "";

            try
            {

                conectar();

                dr = null;
                string qry = "sp_CheckIn";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@id", SqlDbType.Int);
                parametro1.Value = idReserv;

                dr = _comandosql.ExecuteReader();

                //if (dr.Read())
                //{
                //    Tipos.Add(dr["nombre"].ToString());
                //}

                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        }
        public void ACTUALIZA_RESERV()
        {//llenar combo
            var msg = "";

            try
            {

                conectar();

               // dr = null;
                string qry = "sp_checkinpasado";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;
                
               // dr = _comandosql.ExecuteReader();

                //if (dr.Read())
                //{
                //    Tipos.Add(dr["nombre"].ToString());
                //}

                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        }
        public float Precio_Total(int clve,float desc)
        {
            var msg = "";
            float TotalMoney = 0;
            try
            {

                conectar();

                 dr = null;
                string qry = "sp_descuento";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;



                var parametro1 = _comandosql.Parameters.Add("@cve", SqlDbType.BigInt);
                parametro1.Value = clve;
                var parametro2 = _comandosql.Parameters.Add("@desc", SqlDbType.Money);
                parametro2.Value = desc;
                
                 dr = _comandosql.ExecuteReader();

                if (dr.Read())
                {
                    TotalMoney=float.Parse(dr["final"].ToString());
                }

                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
            return TotalMoney;
        }
        public void Ingresafactura(int clvReserv)
        {//llenar combo
            var msg = "";

            try
            {

                conectar();

                // dr = null;
                string qry = "sp_Nuevafactura";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;


                var parametro1 = _comandosql.Parameters.Add("@cve_reserv", SqlDbType.BigInt);
                parametro1.Value = clvReserv;

                //  dr = _comandosql.ExecuteReader();
                //
                // if (dr.Read())
                // {
                //     Tipos.Add(dr["nombre"].ToString());
                // }
                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(_tabla);
                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        }
        public int show_id_MAXFACTURA()
        {//llenar combo
            var msg = "";
            int Id = 0;
            try
            {

                conectar();

                dr = null;
                string qry = "sp_MaximoFACTURA";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;
               

                dr = _comandosql.ExecuteReader();

                if (dr.Read())
                {
                    Id = int.Parse(dr["ID"].ToString());
                }




                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return Id;
        }

        public void CheckOut(int clvReserv)
        {//llenar combo
            var msg = "";

            try
            {

                conectar();

                // dr = null;
                string qry = "sp_deleteReserv";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;


                var parametro1 = _comandosql.Parameters.Add("@clave", SqlDbType.BigInt);
                parametro1.Value = clvReserv;
                
                _adaptador.SelectCommand = _comandosql;


                _adaptador.Fill(_tabla);
                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        }

        #region RETURNS_INTEGERS

        public int show_Hotel(int id_hotel, string nombreH)
        {//llenar combo
            var msg = "";

            try
            {

                conectar();

                dr = null;
                string qry = "sp_Busca_idHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@nombreH", SqlDbType.VarChar, 50);
                parametro1.Value = nombreH;

                dr = _comandosql.ExecuteReader();

                if (dr.Read())
                {
                    id_hotel = int.Parse(dr["ID"].ToString());
                }

                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return id_hotel;
        }

        public int show_UsuarioID(int id_usu, string nombre)
        {//llenar combo
            var msg = "";

            try
            {

                conectar();

                dr = null;
                string qry = "sp_Busca_idUsu";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@nombreU", SqlDbType.VarChar, 80);
                parametro1.Value = nombre;

                dr = _comandosql.ExecuteReader();

                if (dr.Read())
                {
                    id_usu = int.Parse(dr["ID"].ToString());
                }

                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return id_usu;
        }

        public int show_idPais(int id_pais, string nombre)
        {//llenar combo
            var msg = "";
            int Id=0;
            try
            {

                conectar();

                dr = null;
                string qry = "sp_Busca_idPais";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@nombreP", SqlDbType.VarChar, 50);
                parametro1.Value = nombre;

                dr = _comandosql.ExecuteReader();

                if (dr.Read())
                {
                    Id = int.Parse(dr["ID"].ToString());
                }
                //_adaptador.SelectCommand = _comandosql;
                //_adaptador.Fill(_tabla);
                


                //if (_tabla.Rows.Count > 0)
                //{
                //    Id = int.Parse(dr["ID"].ToString());
                //}
                //




                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return Id;
        }

        public int show_TipoHabID(int id_tipo, string nombre)
        {//llenar combo
            var msg = "";

            try
            {

                conectar();

                dr = null;
                string qry = "sp_Busca_idTipoHab";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@nombreTipo", SqlDbType.VarChar, 80);
                parametro1.Value = nombre;

                dr = _comandosql.ExecuteReader();

                if (dr.Read())
                {
                    id_tipo = int.Parse(dr["ID"].ToString());
                }

                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return id_tipo;
        }

        public int show_idCiudad(int id_ciudad, string nombre)
        {//llenar combo
            var msg = "";

            try
            {

                conectar();

                dr = null;
                string qry = "sp_Busca_idCiudad";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@nombreC", SqlDbType.VarChar, 80);
                parametro1.Value = nombre;

                dr = _comandosql.ExecuteReader();

                if (dr.Read())
                {
                    id_ciudad = int.Parse(dr["ID"].ToString());
                }

                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return id_ciudad;
        }
        
        public int show_idServicio(int id_Serv, string nombre)
        {//llenar combo
            var msg = "";

            try
            {

                conectar();

                dr = null;
                string qry = "sp_Busca_idTipoServ";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@nombreTipo", SqlDbType.VarChar, 80);
                parametro1.Value = nombre;

                dr = _comandosql.ExecuteReader();

                if (dr.Read())
                {
                    id_Serv = int.Parse(dr["ID"].ToString());
                }

                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return id_Serv;
        }

        public int show_id_RFC_cliente(string nombre)
        {//llenar combo
            var msg = "";
            int Id = 0;
            try
            {

                conectar();

                dr = null;
                string qry = "sp_Busca_idCliente";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@nombreC", SqlDbType.VarChar, 50);
                parametro1.Value = nombre;

                dr = _comandosql.ExecuteReader();

                if (dr.Read())
                {
                    Id = int.Parse(dr["ID"].ToString());
                }
                



                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return Id;
        }
        public int show_id_TipoHab(string hotelNmae, string tipoName)
        {//llenar combo
            var msg = "";
            int Id = 0;
            try
            {

                conectar();

                dr = null;
                string qry = "sp_Busca_idHabitation";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@hotel", SqlDbType.VarChar, 50);
                parametro1.Value = hotelNmae;
                var parametro2 = _comandosql.Parameters.Add("@tipo ", SqlDbType.VarChar, 50);
                parametro2.Value = tipoName;


                dr = _comandosql.ExecuteReader();

                if (dr.Read())
                {
                    Id = int.Parse(dr["ID"].ToString());
                }




                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return Id;
        }
        public int show_id_MAXReservation()
        {//llenar combo
            var msg = "";
            int Id = 0;
            try
            {

                conectar();

                dr = null;
                string qry = "sp_Maximo";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;
                

                dr = _comandosql.ExecuteReader();

                if (dr.Read())
                {
                    Id = int.Parse(dr["ID"].ToString());
                }




                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return Id;
        }




        #endregion


        public DataTable Borra_reservation(int cve_reserv)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "BorraReservacion";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@IDR", SqlDbType.BigInt);
                parametro1.Value = cve_reserv;
                

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }
        public DataTable Borra_ServiReservation(int cve_reserv)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "BorraServiReservacion";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@IDR", SqlDbType.BigInt);
                parametro1.Value = cve_reserv;


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public void Mostrar_EnText_hotel(ListBox txt, string nombre)
        {//llenar combo
            var msg = "";
            
            try
            {

                conectar();

                dr = null;
                string qry = "sp_MostrarDatosHotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@nombre", SqlDbType.VarChar, 80);
                parametro1.Value = nombre;

                dr = _comandosql.ExecuteReader();

                if (dr.Read())
                {
                    txt.Items.Add("Nombre: "+dr["nombre"].ToString());
                    txt.Items.Add("Z.Turi: "+dr["ZT"].ToString());
                    txt.Items.Add("Domicilio: "+dr["domi"].ToString());
                    txt.Items.Add("No. Pisos: "+dr["pisos"].ToString());
                    txt.Items.Add("No. Habi: "+dr["habs"].ToString());
                    txt.Items.Add("Caracteristicas: "+dr["carac"].ToString());
                    txt.Items.Add("Fecha de Creacion: "+dr["ini"].ToString());
                    txt.Items.Add("Registrado por: " + dr["usu"].ToString());
                  
                }
                
                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

           
        }
        public void Mostrar_EnText_Reservation(ListBox txt, int idReserv)
        {//llenar combo
            var msg = "";

            try
            {

                conectar();

                dr = null;
                string qry = "Busca_resreva";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@IDR", SqlDbType.BigInt);
                parametro1.Value = idReserv;

                dr = _comandosql.ExecuteReader();

                if (dr.Read())
                {
                    txt.Items.Add("Fecha de Entrada: " +           dr["Fecha_Entrada"].ToString());
                    txt.Items.Add("Fecha de Salida: " +           dr["Fecha_Salida"].ToString());
                    txt.Items.Add("No. Personas " +        dr["Personas"].ToString());
                    txt.Items.Add("RFC del cliente: " +        dr["RFC"].ToString());
                    txt.Items.Add("No. Habi: " +         dr["ID_Habitacion"].ToString());
                    txt.Items.Add("Medio de pago reservacion: " +  dr["Medio_Pago_Res"].ToString());
                    txt.Items.Add("Anticipo: " +dr["Anticipo"].ToString());
                    txt.Items.Add("Costo Total: " +   dr["Costo_Total"].ToString());

                }

                _conexion.Close();

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }


        }

        public DataTable Set_Habitaciones(int no_hab, int id_hotel, int tipo)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Insert_Habitacion";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro3 = _comandosql.Parameters.Add("@no_hab", SqlDbType.Int);
                parametro3.Value = no_hab;
                var parametro4 = _comandosql.Parameters.Add("@id_hotel", SqlDbType.Int);
                parametro4.Value = id_hotel;
                var parametro5 = _comandosql.Parameters.Add("@tipo", SqlDbType.Int);
                parametro5.Value = tipo;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Set_Servicios_en_Hotel(int id_hotel, int nombre)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                conectar();
                string qry = "sp_Insert_Servicios_en_Hotel";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@id_hotel", SqlDbType.Int);
                parametro1.Value = id_hotel;

                var parametro2 = _comandosql.Parameters.Add("@id_serv", SqlDbType.Int);
                parametro2.Value = nombre;

                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }

        public DataTable Set_Reservations(string anticipo, string medio_pago_res, DateTime fecha_e, 
            DateTime fecha_s, int Personas, int RFC, int id_Hab, float money)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {
                
                conectar();
                string qry = "sp_Insert_Resevation";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@anticipo", SqlDbType.Money);
                parametro1.Value = anticipo;

                var parametro2 = _comandosql.Parameters.Add("@medio_pago_res", SqlDbType.VarChar, 50);
                parametro2.Value = medio_pago_res;

                var parametro3 = _comandosql.Parameters.Add("@fecha_E", SqlDbType.Date);
                parametro3.Value = fecha_e;

                var parametro4 = _comandosql.Parameters.Add("@fecha_S", SqlDbType.Date);
                parametro4.Value = fecha_s;

                var parametro5 = _comandosql.Parameters.Add("@Personas", SqlDbType.TinyInt);
                parametro5.Value = Personas;

                var parametro6 = _comandosql.Parameters.Add("@ID_client", SqlDbType.Int);
                parametro6.Value = RFC;

                var parametro7 = _comandosql.Parameters.Add("@id_Habitacion", SqlDbType.BigInt);
                parametro7.Value = id_Hab;

                var parametro8 = _comandosql.Parameters.Add("@total", SqlDbType.Money);
                parametro8.Value = money;

                




                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }



        public DataTable Set_HistorialTabla(int RFC)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {

                conectar();
                string qry = "sp_HistorialClient";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@RFC", SqlDbType.Int);
                parametro1.Value = RFC;
                


                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }



        public DataTable Set_ReportVentasTabla(string pais, int mes)
        {
            var msg = "";
            DataTable tabla = new DataTable();
            try
            {

                conectar();
                string qry = "sp_RegistroVentas";
                _comandosql = new SqlCommand(qry, _conexion);
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;

                var parametro1 = _comandosql.Parameters.Add("@pais", SqlDbType.VarChar, 50);
                parametro1.Value = pais;


                var parametro2 = _comandosql.Parameters.Add("@mes", SqlDbType.Int);
                parametro2.Value = mes;



                _adaptador.SelectCommand = _comandosql;
                _adaptador.Fill(tabla);

            }
            catch (SqlException e)
            {
                msg = "Excepción de base de datos: \n";
                msg += e.Message;
                MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

            return tabla;
        }


    }
}
