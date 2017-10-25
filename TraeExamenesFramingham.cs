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
    public partial class TraeExamenesFramingham : Form
    {
        public TraeExamenesFramingham()
        {
            InitializeComponent();
        }
        //apreto que si
        private void button1_Click(object sender, EventArgs e)
        {
            //es diabetico
            Diabetico diab = new Diabetico();
            diab.Show();

        }
        // no viene por primera vez, se deberia haber hecho el examen de diabetes
        //se le debe mostrar el combobox de diabetes
        private void button2_Click(object sender, EventArgs e)
        {
            int diab = -1;
            Form3 Ventana3 = new Form3(diab, false);
            Ventana3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
