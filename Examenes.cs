using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;

namespace Capstone
{
    public partial class Examenes : Form
    {
        public Examenes()
        {
            InitializeComponent();
            textBox1.MaxLength = 3;
            textBox2.MaxLength = 3;
            textBox3.MaxLength = 3;
            //que parta todo desactivado
         /*   comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;
            comboBox7.Enabled = false;*/
            desabilitarCampos();
        }
        int dummysexo;
        int dummyDolorPecho;
        int presiondiastolica;
        int dummyhemograma;
        int colesterol;
        int dummyelectro;
        int rca2;
        int rca3;
        int rca4;
        int dummyExIndAngina;
        int heartrate;
        int dummystexcercise;
        int modelo=0;

        private void desabilitarCampos()
        {
            button1.Enabled = false;
            comboBox2.Enabled = false;
            textBox1.Enabled = false;
            textBox3.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox6.Enabled = false;
            comboBox7.Enabled = false;
        }

        private void verificarTodosCampos()
        {
            Boolean CB1 = false; Boolean CB2 = false; Boolean CB3 = false; Boolean CB4 = false; Boolean CB5 = false; Boolean CB6 = false; Boolean CB7 = false;
            Boolean TB1 = false; Boolean TB2 = false; Boolean TB3 = false;
            if (comboBox1.Enabled) { if (comboBox1.SelectedIndex != -1) CB1 = true; }
            else CB1 = true;
            if (comboBox2.Enabled) { if (comboBox2.SelectedIndex != -1) CB2 = true; }
            else CB2 = true;
            if (comboBox3.Enabled) { if (comboBox3.SelectedIndex != -1) CB3 = true; }
            else CB3 = true;
            if (comboBox4.Enabled) { if (comboBox4.SelectedIndex != -1) CB4 = true; }
            else CB4 = true;
            if (comboBox5.Enabled) { if (comboBox5.SelectedIndex != -1) CB5 = true; }
            else CB5 = true;
            if (comboBox6.Enabled) { if (comboBox6.SelectedIndex != -1) CB6 = true; }
            else CB6 = true;
            if (comboBox7.Enabled) { if (comboBox7.SelectedIndex != -1) CB7 = true; }
            else CB7 = true;
            if (textBox1.Enabled) { if (!textBox1.Text.Equals("")) TB1 = true; }
            else TB1 = true;
            if (textBox2.Enabled) { if (!textBox2.Text.Equals("")) TB2 = true; }
            else TB2 = true;
            if (textBox3.Enabled) { if (!textBox3.Text.Equals("")) TB3 = true; }
            else TB3 = true;
            if (CB1 && CB2 && CB3 && CB4 && CB5 && CB6 && CB7 && TB1 && TB2 && TB3) button1.Enabled=true;
            else button1.Enabled = false;
            //if (comboBox1.Enabled && comboBox1.SelectedIndex != -1 && comboBox2.Enabled && comboBox2.SelectedIndex != -1 && comboBox3.Enabled && comboBox3.SelectedIndex != -1 && comboBox4.Enabled && comboBox4.SelectedIndex != -1 && comboBox5.Enabled && comboBox5.SelectedIndex != -1 && comboBox6.Enabled && comboBox6.SelectedIndex != -1 && comboBox7.Enabled && comboBox7.SelectedIndex != -1 && textBox1.Enabled && !textBox1.Text.Equals("") && textBox2.Enabled && !textBox2.Text.Equals("") && textBox3.Enabled && !textBox3.Text.Equals(""))
            //{
            //    button1.Enabled = true;
            //}
            //else button1.Enabled = false;
        }
        //se deben habilitar los combobox a partir de lo que la persona checkea
        /*   public void checkBox1_Unchecked(object sender, RoutedEventArgs e)
           {
               comboBox1.Enabled = true;
           }

           private void checkbox_otherflag_Checked(object sender, RoutedEventArgs e)
           {
               this.textbox_otherflagtext.IsEnabled = true;
           }

       */
        //click en aceptar

         private void button1_Click(object sender, EventArgs e)
        { //SEXO
            //hay que guardar los datos que puso
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
            //HEMOGRAMA
            if (checkBox1.Checked)
            {
                if (comboBox2.SelectedIndex == 0) { dummyhemograma = 0; }
                if (comboBox2.SelectedIndex == 1) { dummyhemograma = 1; }
                if (comboBox2.SelectedIndex == 2) { dummyhemograma = 1; }
            }
            //PERFIL LIPIDICO
            if (checkBox2.Checked)
            {
                if (Int32.TryParse(textBox1.Text, out colesterol)) { }
                else
                {
                    MessageBox.Show("Error en Colesterol");
                }
            }
            //ELECTROCARDIOGRAMA
            if (checkBox3.Checked)
            {
                if (comboBox3.SelectedIndex == 0) { dummyelectro = 0; }
                if (comboBox3.SelectedIndex == 1) { dummyelectro = 1; }
                if (comboBox3.SelectedIndex == 2) { dummyelectro = 1; }
            }
            //ANGIOTOMOGRAFIA -CA
            if (checkBox4.Checked)
            {
                //rca2 = 1 cuando ca= 1
                if (comboBox4.SelectedIndex == 1) { rca2 = 1; }
                else { rca2 = 0; }
                //rca3 = 1 cuando ca= 2
                if (comboBox4.SelectedIndex == 2) { rca3 = 1; }
                else { rca3 = 0; }
                //rca4 = 1 cuando ca= 3
                if (comboBox4.SelectedIndex == 3) { rca4 = 1; }
                else { rca4 = 0; }
            }
            //TEST DE ESFUERZO
            if (checkBox5.Checked)
            {
                if (comboBox6.SelectedIndex == 0) { dummyExIndAngina = 1; }
                if (comboBox6.SelectedIndex == 1) { dummyExIndAngina = 0; }

                if (Int32.TryParse(textBox3.Text, out heartrate)) { }
                else
                {
                    MessageBox.Show("Error en Pulso máximo");
                }

                if (comboBox7.SelectedIndex == 0 | comboBox7.SelectedIndex == 1) { dummystexcercise = 0; }
                if (comboBox7.SelectedIndex == 2 | comboBox7.SelectedIndex == 3) { dummystexcercise = 1; }
            }

            //encontrar el modelo correspondiente
            //modelo 1, ninguna debe haber estado chequeada
            if (checkBox1.Checked== false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false)
            {
                modelo = 1;
                Console.WriteLine("no se hizo nada " + modelo);
            }
            else if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false)
            {
                modelo = 2; // se hizo solo hemograma
                Console.WriteLine("solo hemograma " + modelo);

            }
            else if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false)
            {
                modelo = 3; // se hizo solo perf lipidico
                Console.WriteLine("solo perfil lipidico" + modelo);
            }
            else if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == true && checkBox4.Checked == false && checkBox5.Checked == false)
            {
                modelo = 4; // se hizo solo ELECTROCARDIAGRAMA
                Console.WriteLine("solo electrocardiogrma " + modelo);
            }
            else if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == true && checkBox4.Checked == false && checkBox5.Checked == false)
            {
                modelo = 5; // se hizo hemograma y electrocardiograma
                Console.WriteLine("solo hemograma y electrocardiograma " + modelo);
            }
            else if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == true)
            {
                modelo = 6; // se hizo test de esfuerzo
                Console.WriteLine("solo test de esfuerzo " + modelo);
            }
            else if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == true)
            {
                modelo = 7; // se hizo hemograma y test de esfuerzo
                Console.WriteLine("se hizo hemograma y test de esfuerzo" + modelo);
            }
            else if (checkBox1.Checked == false && checkBox2.Checked == true && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == true)
            {
                modelo = 8; // se hizo perf lip y test de esfuerzo
                Console.WriteLine("se hizo perf lip y test de esfuerzo" + modelo);
            }
            else if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == true)
            {
                modelo = 9; // se hizo hemograma, perf lip y test de esfuerzo
                Console.WriteLine("se hizo hemograma, perf lip y test de esfuerzo" + modelo);
            }
            else if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == true && checkBox5.Checked == false)
            {
                modelo = 10; // se hizo solo angiotomografia
                Console.WriteLine("se hizo solo angiotomografia" + modelo);
            }
            else if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == true && checkBox5.Checked == false)
            {
                modelo = 11; // se hizo hemograma y angiotomografia
                Console.WriteLine("se hizo hemograma y angiotomografia" + modelo);
            }
            else if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked == true && checkBox5.Checked == false)
            {
                modelo = 12; // se hizo todo menos test de esfuerzo
                Console.WriteLine("se hizo todo menos test de esfuerzo" + modelo);
            }
            else if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == true && checkBox5.Checked == true)
            {
                modelo = 13; // se hizo angiotomografia y test de esfuerzo
                Console.WriteLine("se hizo angiotomografia y test de esfuerzo" + modelo);
            }
            else if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == true && checkBox5.Checked == true)
            {
                modelo = 14; // se hizo hemograma, angiotomografia y test de esfuerzo
                Console.WriteLine("se hizo hemograma, angiotomografia y test de esfuerzo" + modelo);
            }
            else if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked == true && checkBox5.Checked == true)
            {
                modelo = 15; // se hizo TODO
                Console.WriteLine("se hizo TODO" + modelo);
            }
            else
            {
                MessageBox.Show("Ingreso datos no compatibles con los modelos existentes.\n \nPor favor vuelva a intentarlo.\n \nPara saber los datos compatibles refierase al boton \"Examenes Compatibles\"");
                modelo = 0;
            }
            //--------ojo-------------por ejemplo combinacio hemograma, electro y perfil no existe. Si la ingresa que pasa+++

            //debemos con las columnas de excel entrear la probabilidad.
            if (modelo != 0)
            {
                // Lectura de archivo
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                string workbookPatch = Application.StartupPath + @"\modelos2.xlsx";
                Microsoft.Office.Interop.Excel.Workbook wbook = excel.Workbooks.Open(workbookPatch);
                Microsoft.Office.Interop.Excel.Worksheet x = excel.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
                //ojo [row, columna], la columna es el numero de modelo +1
                int columna = modelo + 1;

                Microsoft.Office.Interop.Excel.Range C1 = (Microsoft.Office.Interop.Excel.Range)x.Cells[2, columna];
                double c1 = C1.Value;
                Microsoft.Office.Interop.Excel.Range C2 = (Microsoft.Office.Interop.Excel.Range)x.Cells[3, columna];
                double c2 = C2.Value;
                Microsoft.Office.Interop.Excel.Range C3 = (Microsoft.Office.Interop.Excel.Range)x.Cells[4, columna];
                double c3 = C3.Value;
                Microsoft.Office.Interop.Excel.Range C4 = (Microsoft.Office.Interop.Excel.Range)x.Cells[5, columna];
                double c4 = C4.Value;
                Microsoft.Office.Interop.Excel.Range C5 = (Microsoft.Office.Interop.Excel.Range)x.Cells[6, columna];
                double c5 = C5.Value;
                Microsoft.Office.Interop.Excel.Range C6 = (Microsoft.Office.Interop.Excel.Range)x.Cells[7, columna];
                double c6 = C6.Value;
                Microsoft.Office.Interop.Excel.Range C7 = (Microsoft.Office.Interop.Excel.Range)x.Cells[8, columna];
                double c7 = C7.Value;
                Microsoft.Office.Interop.Excel.Range C8 = (Microsoft.Office.Interop.Excel.Range)x.Cells[9, columna];
                double c8 = C8.Value;
                Microsoft.Office.Interop.Excel.Range C9 = (Microsoft.Office.Interop.Excel.Range)x.Cells[10, columna];
                double c9 = C9.Value;
                Microsoft.Office.Interop.Excel.Range C10 = (Microsoft.Office.Interop.Excel.Range)x.Cells[11, columna];
                double c10 = C10.Value;
                Microsoft.Office.Interop.Excel.Range C11 = (Microsoft.Office.Interop.Excel.Range)x.Cells[12, columna];
                double c11 = C11.Value;
                Microsoft.Office.Interop.Excel.Range C12 = (Microsoft.Office.Interop.Excel.Range)x.Cells[13, columna];
                double c12 = C12.Value;
                Microsoft.Office.Interop.Excel.Range C13 = (Microsoft.Office.Interop.Excel.Range)x.Cells[14, columna];
                double c13 = C13.Value;
                Microsoft.Office.Interop.Excel.Range certez = (Microsoft.Office.Interop.Excel.Range)x.Cells[15, columna];
                double certeza = certez.Value;
             

                double exponente = c1 * dummysexo + c2 * dummyDolorPecho +c3* presiondiastolica + c4 * dummyhemograma + c5 * colesterol + c6 * dummyelectro +
                     c7 * rca2 + c8* rca3 + c9 * rca4 + c10 * heartrate + c11 * dummyExIndAngina + c12 * dummystexcercise + c13;

                double riesgo = Math.Round( 1 / (1 + Math.Exp(-exponente)),3);
                for (int i = 1; i < 15; i++)
                {
                   
                    Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)x.Cells[i, columna];
                    // string cellValue = range.Value.ToString();
                    double cellValue = range.Value;
                    Console.WriteLine("coef numero " + i + "-" + cellValue);
                }
                excel.Quit();
                Console.WriteLine("RIESGO " + riesgo);
                Console.WriteLine("certeza " + certeza);
                double proximaVisita = Math.Round((1-riesgo) * certeza * 24 /100);
                MessageBox.Show("Usted tiene una probabilidad de tener una enfermedad cardiaca de " + riesgo*100 + "%. "+ "Debe volver en "+ proximaVisita + " meses");


            }
            //si la persona responde efecto fijo o reversible, variable 1
            // si ponenormal es 0

            //rca2 = 1 cuando ca= 1
            //rca3 = 1 cuando ca= 2
            //rca4 = 1 cuando ca= 3

            //stexcercise = 0 o 1, dummy=0
            //stexcersise = 2 o 3 , dummy = 1

            //exc angina yes=1, no=0

            //electocardiograma
            //norm = 0
            // else = 1

            //cp contesta 0 es 0, else (1,2 o 3) es 1

            //hombre 1
            //mujer 0


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) comboBox2.Enabled = true;
            else comboBox2.Enabled = false;
            verificarTodosCampos();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) textBox1.Enabled = true;
            else textBox1.Enabled = false;
            verificarTodosCampos();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked) comboBox3.Enabled = true;
            else comboBox3.Enabled = false;
            verificarTodosCampos();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked) comboBox4.Enabled = true;
            else comboBox4.Enabled = false;
            verificarTodosCampos();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                comboBox6.Enabled = true;
                comboBox7.Enabled = true;
                textBox3.Enabled = true;
            }
            else
            {
                comboBox6.Enabled = false;
                comboBox7.Enabled = false;
                textBox3.Enabled = false; 
            }
            verificarTodosCampos();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificarTodosCampos();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificarTodosCampos();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            verificarTodosCampos();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificarTodosCampos();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            verificarTodosCampos();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificarTodosCampos();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificarTodosCampos();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificarTodosCampos();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            verificarTodosCampos();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificarTodosCampos();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Examenes_Compatibles nuevaVentana = new Examenes_Compatibles();
            nuevaVentana.Show();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (!textBox2.Text.Equals(""))
            {
                if (Int32.Parse(textBox2.Text) > 250) MessageBox.Show("Ingreso un valor excedido de presion sistolica. Vuelva a intentarlo.");
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                if (Int32.Parse(textBox1.Text) > 400) MessageBox.Show("Ingreso un valor excedido de colesterol. Vuelva a intentarlo.");
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (!textBox3.Text.Equals(""))
            {
                if (Int32.Parse(textBox3.Text) > 250) MessageBox.Show("Ingreso un valor excedido de pulso cardiaco. Vuelva a intentarlo.");
            }
        }
    }
}
