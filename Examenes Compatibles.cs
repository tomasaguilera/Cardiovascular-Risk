using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Capstone
{
    public partial class Examenes_Compatibles : Form
    {
        public Examenes_Compatibles()
        {
            InitializeComponent();
            DataTable tabla = crearTabla();
            dataGridView1.DataSource = tabla;
        }
        public DataTable crearTabla()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Combinacion", typeof(int));
            table.Columns.Add("Sexo, DolorPecho, Presion", typeof(int));
            table.Columns.Add("Hemograma", typeof(int));
            table.Columns.Add("Colesterol", typeof(int));
            table.Columns.Add("Electrocardiograma", typeof(int));
            table.Columns.Add("Angiotomografia", typeof(int));
            table.Columns.Add("Angina", typeof(int));
            table.Columns.Add("PulsoMAX", typeof(int));
            table.Columns.Add("Segmento ST", typeof(int));
            table.Rows.Add(1, 1, 0, 0, 0, 0, 0, 0, 0);
            table.Rows.Add(2, 1, 1, 0, 0, 0, 0, 0, 0);
            table.Rows.Add(3, 1, 0, 0, 1, 0, 0, 0, 0);
            table.Rows.Add(4, 1, 1, 0, 0, 1, 0, 0, 0);
            table.Rows.Add(5, 1, 0, 0, 0, 0, 0, 0, 0);
            table.Rows.Add(6, 1, 0, 0, 0, 0, 1, 1, 1);
            table.Rows.Add(7, 1, 1, 0, 0, 0, 1, 1, 1);
            table.Rows.Add(8, 1, 0, 0, 1, 0, 1, 1, 1);
            table.Rows.Add(9, 1, 1, 0, 1, 0, 0, 0, 0);
            table.Rows.Add(10, 1, 0, 0, 0, 1, 0, 0, 0);
            table.Rows.Add(11, 1, 1, 0, 0, 1, 0, 0, 0);
            table.Rows.Add(12, 1, 1, 1, 1, 1, 0, 0, 0);
            table.Rows.Add(13, 1, 0, 0, 0, 1, 1, 1, 1);
            table.Rows.Add(14, 1, 1, 0, 0, 1, 1, 1, 1);
            table.Rows.Add(15, 1, 1, 1, 1, 1, 1, 1, 1);
            return table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
