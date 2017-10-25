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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Cleveland
            TraeExamenes ventana4 = new TraeExamenes();
            ventana4.Show();
          //  Form2 Ventana2 = new Form2(this);
         //   Ventana2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Framingham
            TraeExamenesFramingham ventana5 = new TraeExamenesFramingham();
            ventana5.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
