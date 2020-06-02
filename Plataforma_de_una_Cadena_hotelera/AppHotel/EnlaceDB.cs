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
        string[] usuarios;

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





        public void set_Pais(ComboBox combo)
        {//llenar combo
            var msg = "";

            try {

                conectar();

                dr = null;
                string qry = "sp_BuscaPais";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;


                dr = _comandosql.ExecuteReader();

                while (dr.Read())
                {
                    combo.Items.Add(dr["P_Nombre"].ToString());


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



        public void set_StringUsers()
        {//llenar combo
            var msg = "";

            try
            {

                conectar();

                dr = null;
                string qry = "sp_StringUsu";
                _comandosql = new SqlCommand(qry, _conexion);
                _conexion.Open();
                _comandosql.CommandType = CommandType.StoredProcedure;
                _comandosql.CommandTimeout = 1200;


                dr = _comandosql.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    usuarios[i]= dr["Nombre_Comp"].ToString();
                    //.Add(dr["P_Nombre"].ToString());

                    i++;
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

        public string[] getStringUser() {
            string[] a= usuarios;
            return a;   
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

    }
}
