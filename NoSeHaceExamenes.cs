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
    public partial class NoSeHaceExamenes : Form
    {
        public NoSeHaceExamenes()
        {
            InitializeComponent();
        }
        int dummysexo;
        int dummyDolorPecho;
        int presiondiastolica;
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedIndex == 0) //hombre
            {
                dummysexo = 1;
            }
            if (comboBox1.SelectedIndex == 1) //mujer
            {
                dummysexo = 0;
            }
            if (comboBox1.SelectedIndex == -1) //no eligio
            {
                MessageBox.Show("Debe ingresar sexo");
            }
            //DOLOR DE PECHO
            if (comboBox5.SelectedIndex == 0) //SI
            {
                dummyDolorPecho = 1;
            }
            if (comboBox5.SelectedIndex == 1) //NO
            {
                dummyDolorPecho = 0;
            }
            if (comboBox5.SelectedIndex == -1) //no eligio
            {
                MessageBox.Show("Debe indicar si le duele el pecho");
            }
            //PRESION
            if (Int32.TryParse(textBox2.Text, out presiondiastolica)) { }
            else
            {
                MessageBox.Show("Error en Presion Diastolica");
            }

            double exponente = 1.405716 * dummysexo + 1.488324 * dummyDolorPecho + 0.0217362 * presiondiastolica + -5.129445;

            double riesgo = Math.Round(1 / (1 + Math.Exp(-exponente)), 3);
            double proximaVisita = Math.Round((1 - riesgo) * 68.12 * 24 / 100);
            MessageBox.Show("Usted tiene una probabilidad de tener una enfermedad cardiaca de " + riesgo + ". " + "Debe volver en " + proximaVisita + " meses");

        }
    }
}
