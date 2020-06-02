using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

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
        static private SqlDataReader dr;


        public DataTable obtenertabla
        {
            get
            {
                return _tabla;
            }
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

        public void set_Pais(ComboBox combo)
        {//llenar combo
            var msg = "";

            try {

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


        public DataTable Registra_Ciudad(string nombre, string descrip, string pais)
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

                var parametro3 = _comandosql.Parameters.Add("@p_nombre", SqlDbType.VarChar, 50);
                parametro3.Value = pais;


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


        public DataTable Set_Client(int RFC, string Nombre, string Paterno, string Materno, 
            string domicilio, string e_mail, string telcel, string referencia, DateTime fecha_naci)
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
            string zona_tur, string domicilio, int usu_atiende, string ciudad)
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
                parametro2.Value = "juanito";

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
                var parametro9 = _comandosql.Parameters.Add("@usuario_atiende", SqlDbType.Int);
                parametro9.Value = usu_atiende;
                var parametro10 = _comandosql.Parameters.Add("@Ciudad", SqlDbType.VarChar, 50);
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

        public DataTable Set_Habitaciones(int nivel, int no_hab, int id_hotel, string tipo)
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

                var parametro1 = _comandosql.Parameters.Add("@nivel", SqlDbType.TinyInt);
                parametro1.Value = nivel;

                var parametro3 = _comandosql.Parameters.Add("@no_hab", SqlDbType.Int);
                parametro3.Value = no_hab;
                var parametro4 = _comandosql.Parameters.Add("@id_hotel", SqlDbType.Int);
                parametro4.Value = id_hotel;
                var parametro5 = _comandosql.Parameters.Add("@tipo", SqlDbType.VarChar, 50);
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

        public DataTable Set_Servicios_en_Hotel(int id_hotel, string nombre, DateTime horarioE, 
            DateTime horarioS)
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

                var parametro1 = _comandosql.Parameters.Add("@caract", SqlDbType.Int);
                parametro1.Value = id_hotel;

                var parametro2 = _comandosql.Parameters.Add("@usuario_registro", SqlDbType.VarChar, 50);
                parametro2.Value = nombre;

                var parametro3 = _comandosql.Parameters.Add("@no_pisos", SqlDbType.Date);
                parametro3.Value = horarioE;
                var parametro4 = _comandosql.Parameters.Add("@nombre", SqlDbType.Date);
                parametro4.Value = horarioS;

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
