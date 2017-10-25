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
    public partial class Form3 : Form
    {
        int P=0;
        int cigarros;
        int DRF1 = 0;
        int DRF2 = 0;
        int DRF3 = 0;
        int DRF4 = 0;
        int rangodiastolica=0;
        int rangosistolica=0;
        int DRP1 = 0;
        int DRP2 = 0;
        int DRP3 = 0;
        int DRP4 = 0;
        int DRE1=0;
        int DRE2=0;
        int DRE3=0;
        int DRE4=0;
        String sexo;
        int edad;
        String sistemasalud;
        public Boolean Diabetesingresado;
        public int diabetes { get; set; }
        // int diabetes; // 1 tiene, 0 no tiene
        int presionsistolica;
        int presiondiastolica;
        int pulsocardiaco;

        public Form3(int diab, Boolean ingresadiabetes)
        {
            this.diabetes = diab;
            this.Diabetesingresado = ingresadiabetes;
            InitializeComponent();
            verificaDiabetesIngresado();
            textBox1.MaxLength = 3;
            textBox2.MaxLength = 3;
            textBox3.MaxLength = 3;
            textBox4.MaxLength = 3;
            textBox5.MaxLength = 3;
        }
        private void verificaDiabetesIngresado()
        {
            if (Diabetesingresado)
            {
                if (diabetes == 1)
                {
                    comboBox3.SelectedIndex = 0;
                    comboBox3.Enabled = false;
                }
                else
                {
                    comboBox3.SelectedIndex = 1;
                    comboBox3.Enabled = false;
                }
            }
        }

        private void leerVariables()
        {
            verificaDiabetesIngresado();
            sexo = comboBox1.Text;
            if (Int32.TryParse(textBox1.Text, out edad)) { }
            else {
                MessageBox.Show("Error en Edad");
            }
            sistemasalud = comboBox2.Text;
            if (!Diabetesingresado)
            {
                    if (comboBox3.Text.Equals("Si"))
                    {
                        diabetes = 1;
                    }
                    else if (comboBox3.Text.Equals("No"))
                    {
                        diabetes = 0;
                    }
            }
            if (Int32.TryParse(textBox2.Text, out presionsistolica)) { }
            else
            {
                MessageBox.Show("Error en Presion Sistolica");
            }
            if (Int32.TryParse(textBox3.Text, out presiondiastolica)) { }
            else
            {
                MessageBox.Show("Error en Presion Diastolica");
            }
            if (Int32.TryParse(textBox4.Text, out pulsocardiaco)) { }
            else
            {
                MessageBox.Show("Error en Pulso Cardiaco");
            }
            if (Int32.TryParse(textBox5.Text, out cigarros)) { }
            else
            {
                MessageBox.Show("Error en cigarros por dia");
            }
            if (edad < 55) DRE1 = 1;
            else if (edad >= 55 && edad < 60) DRE2 = 1;
            else if (edad >= 60 && edad < 65) DRE3 = 1;
            else if (edad >= 65 ) DRE4 = 1;
            if (presionsistolica < 120) rangosistolica = 1;
            else if (presionsistolica >= 120 && presionsistolica < 140) rangosistolica = 2;
            else if (presionsistolica >= 140 && presionsistolica < 160) rangosistolica = 3;
            else if (presionsistolica >= 160) rangosistolica = 4;
            if (presiondiastolica < 80) rangodiastolica = 1;
            else if (presiondiastolica >= 80 && presiondiastolica < 90) rangodiastolica = 2;
            else if (presiondiastolica >= 90 && presiondiastolica < 100) rangodiastolica = 3;
            else if (presiondiastolica >= 100) rangodiastolica = 4;
            P = Math.Max(rangodiastolica, rangosistolica);
            if (P == 1) DRP1 = 1;
            else if (P == 2) DRP2 = 1;
            else if (P == 3) DRP3 = 1;
            else if (P == 4) DRP4 = 1;
            if (sexo.Equals("Masculino"))
            {
                if (cigarros == 0) DRF1 = 1;
                else if (cigarros > 0 && cigarros < 20) DRF2 = 1;
                else if (cigarros >= 20 && cigarros < 25) DRF3 = 1;
                else if (cigarros >= 25) DRF4 = 1;
            }
            else if (sexo.Equals("Femenino"))
            {
                if (cigarros == 0) DRF1 = 1;
                else if (cigarros > 0 && cigarros < 20) DRF2 = 1;
                else if (cigarros >= 20) DRF3 = 1;
            }
            Console.WriteLine("diabetes " + diabetes);
        }
        private void resetVariables()
        {
            P = 0;
            cigarros=0;
             DRF1 = 0;
             DRF2 = 0;
             DRF3 = 0;
             DRF4 = 0;
             rangodiastolica = 0;
             rangosistolica = 0;
             DRP1 = 0;
             DRP2 = 0;
             DRP3 = 0;
             DRP4 = 0;
             DRE1 = 0;
             DRE2 = 0;
             DRE3 = 0;
             DRE4 = 0;
            String sexo = "";
             edad =0 ;
            String sistemasalud= "";
             //diabetes=-1; // lo cambie
             presionsistolica=0;
             presiondiastolica=0;
             pulsocardiaco=0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            resetVariables();
            Double riesgo=-1;
            leerVariables();
            if (sexo.Equals("Masculino"))
            {
                riesgo = modeloHombres();
            }
            else if (sexo.Equals("Femenino"))
            {
               riesgo = modeloMujeres();
            }
            if (diabetes == 1)
            {
                riesgo = Math.Round(riesgo, 4);
                MessageBox.Show("Su riesgo es de: " + riesgo*100 + "%\nComo usted es diabetico, debe volver cada 3 meses.");
            }
            else if (diabetes == 0)
            {
                if (riesgo < 0.05)
                {
                    riesgo = Math.Round(riesgo, 4);
                    MessageBox.Show("Su riesgo es de: " + riesgo * 100 + "%\nDebe volver a realizarse un chequeo en 12 meses.");
                }
                else if (riesgo >= 0.05 && riesgo < 0.1)
                {
                    riesgo = Math.Round(riesgo, 4);
                    MessageBox.Show("Su riesgo es de: " + riesgo * 100 + "%\nDebe volver a realizarse un chequeo en 6 meses.");
                }
                else if (riesgo >= 0.1)
                {
                    riesgo = Math.Round(riesgo, 4);
                    MessageBox.Show("Su riesgo es de: " + riesgo * 100 + "%\nDebe volver a realizarse un chequeo en 3 meses.");
                }
            }
        }
        private Double modeloHombres()
        {
            Double betaDiabetes=Math.Log(1.157);
            Double betaDRE2=Math.Log(1.557418);
            Double betaDRE3=Math.Log(1.853806);
            Double betaDRE4=Math.Log(3.837307);
            Double betaDRP3=Math.Log(1.175432);
            Double betaDRP4=Math.Log(1.359436);
            Double betaDRF1=Math.Log(0.798479);
            Double betaHR=Math.Log(1.006695);
            Double Scero = 0.90015;
            Double G = 1.6;
            Double L = betaDiabetes * diabetes + betaDRE2 * DRE2 + betaDRE3 * DRE3 + betaDRE4 * DRE4 + betaDRP3 * DRP3 + betaDRP4 * DRP4+betaDRF1*DRF1+betaHR*pulsocardiaco;
            Double Riesgo = 1-Math.Pow(Scero,Math.Exp(L-G));
            return Riesgo;
        }
        private Double modeloMujeres()
        {
            Double betaDiabetes = Math.Log(1.153137);
            Double betaDRE2 = Math.Log(1.587308);
            Double betaDRE3 = Math.Log(1.884674);
            Double betaDRE4 = Math.Log(3.926576);
            Double betaDRP4 = Math.Log(1.268077);
            Double betaDRF1 = Math.Log(0.8053327);
            Double betaHR = Math.Log(1.007366);
            Double Scero = 0.96246;
            Double G = 1.1;
            Double L = betaDiabetes * diabetes + betaDRE2 * DRE2 + betaDRE3 * DRE3 + betaDRE4 * DRE4 + betaDRP4 * DRP4 + betaDRF1 * DRF1 + betaHR * pulsocardiaco;
            Double Riesgo = 1 - Math.Pow(Scero, Math.Exp(L - G));
            return Riesgo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                if (Int32.Parse(textBox1.Text) > 115) MessageBox.Show("Ingreso un valor excedido de edad. Vuelva a intentarlo.");
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (!textBox2.Text.Equals(""))
            {
                if (Int32.Parse(textBox2.Text) > 250) MessageBox.Show("Ingreso un valor excedido de presion sistolica. Vuelva a intentarlo.");
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (!textBox3.Text.Equals(""))
            {
                if (Int32.Parse(textBox3.Text) > 150) MessageBox.Show("Ingreso un valor excedido de presion diastolica. Vuelva a intentarlo.");
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (!textBox4.Text.Equals(""))
            {
                if (Int32.Parse(textBox4.Text) > 250) MessageBox.Show("Ingreso un valor excedido de pulso cardiaco. Vuelva a intentarlo.");
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (!textBox5.Text.Equals(""))
            {
                if (Int32.Parse(textBox5.Text) > 100) MessageBox.Show("Ingreso un valor excedido de cigarros fumados al dia. Vuelva a intentarlo.");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
