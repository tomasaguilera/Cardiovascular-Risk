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
    public partial class Diabetico : Form
    {
        public Diabetico()
        {
            InitializeComponent();
        }
        int diab;
        // Si tiene diabetes
        private void button1_Click(object sender, EventArgs e)
        {
            diab = 1;
            Form3 Ventana3 = new Form3(diab, true);
            Ventana3.Show();
        }
        // No tiene diabetes
        private void button2_Click(object sender, EventArgs e)
        {
            diab = 0;
            Form3 Ventana3 = new Form3(diab, true);
            Ventana3.Show();
        }
        // No sabe, la respuesta es pedir un examen de diabetes
        private void button3_Click(object sender, EventArgs e)
        {
            // Sistema de salud
            FonasaIsapre Ventana6 = new FonasaIsapre();
            Ventana6.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
