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
    public partial class TraeExamenes : Form
    {
        public TraeExamenes()
        {
            InitializeComponent();
        }
        //apreto que si
        private void button1_Click(object sender, EventArgs e)
        { 
            Form2 Ventana2 = new Form2(this);
             Ventana2.Show();
            this.Close();
        }
        //apreto que no
        private void button2_Click(object sender, EventArgs e)
        {
            Examenes ex = new Examenes();
            ex.Show();
            //debe ingresar los examenes que se le pidieron
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
    }
}
