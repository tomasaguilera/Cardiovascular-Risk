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
    public partial class FonasaIsapre : Form
    {
        public FonasaIsapre()
        {
            InitializeComponent();
        }
        // ES FONASA
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se debe realizar el exámen de Glicemia cuyo costo en Fonasa es de $1650");
        }
        //es isapre
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se debe realizar el exámen de Glicemia cuyo costo en Isapre es de $1779");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
