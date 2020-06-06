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
    public partial class ReporteOcupacion : Form
    {
        public ReporteOcupacion()
        {
            InitializeComponent();
        }

        private void ReporteOcupacion_Load(object sender, EventArgs e)
        {
            EnlaceDB conexion = new EnlaceDB();


            conexion.set_Pais(comboBox1);

            conexion = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {// boton cargar    

            EnlaceDB conexion2 = new EnlaceDB();

            DataTable data = new DataTable();

            data = conexion2.Set_ReportOcupacionTabla(comboBox1.Text, dateTimePicker1.Value);

            dataGridView2.DataSource = data;
            dataGridView2.Columns[0].ReadOnly = true;
            dataGridView2.Columns[1].ReadOnly = true;
            dataGridView2.Columns[2].ReadOnly = true;
            //dataGridView2.Columns[3].ReadOnly = true;




            conexion2 = null;


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string nombreH = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            if (e.ColumnIndex == 1)
            {

                EnlaceDB conexion2 = new EnlaceDB();

                int idh=0;

                idh = conexion2.show_Hotel(idh, nombreH);
              
               

                

                DataTable data2 = new DataTable();

                data2 = conexion2.Set_ReportOcupacionTabla2(idh, dateTimePicker1.Value);

                dataGridView1.DataSource = data2;

                conexion2 = null;
            }
        }
    }
}
