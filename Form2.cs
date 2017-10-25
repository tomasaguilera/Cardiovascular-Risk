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
    public partial class Form2 : Form
    {
        List<int> CostosFonasa = new List<int>();
        List<int> CostosIsapre = new List<int>();
        double restriccionpresupuestaria;
        double modelo_escogido = -1;
        String sexo;
        int costo;
        int ingreso;
        int rangoingreso;
        int dummyIsapre; //1 isapre 0 fonasa
        String sistemasalud;
        Boolean dolorpecho;
        int presion;
        public Form2(Form Ventana1)
        {
            InitializeComponent();
            CostosFonasa.Add(1930);
            CostosFonasa.Add(3900);
            CostosFonasa.Add(9000);
            CostosFonasa.Add(35090);
            CostosFonasa.Add(130000);
            CostosIsapre.Add(5146);
            CostosIsapre.Add(10051);
            CostosIsapre.Add(19100);
            CostosIsapre.Add(70500);
            CostosIsapre.Add(150000);
       //     textBox1.Enabled = false;
            button1.Enabled = verificaCasillas();
            
        }
        //boton 
        private void button1_Click(object sender, EventArgs e)
        {
            leerVariables();
            //debo leer el excel

            if (dummyIsapre == 0)//ocupo las celdas de fonasa
            {
                int fila = 3;
                int columna = rangoingreso + 2;
                // Lectura de archivo
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                string workbookPatch = Application.StartupPath + @"\COST EFF.xlsx";
                Microsoft.Office.Interop.Excel.Workbook wbook = excel.Workbooks.Open(workbookPatch);
                Microsoft.Office.Interop.Excel.Worksheet x = excel.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
                //ojo [row, columna]

                //Quiero que se recorran las filas hasta que le alcance con su ingreso
                while (fila < 18)
                {
                    Microsoft.Office.Interop.Excel.Range minimo = (Microsoft.Office.Interop.Excel.Range)x.Cells[fila, columna];
                    double ingreso_minimo = minimo.Value;
                    Console.WriteLine("minimo ing " + ingreso_minimo);
                    if (ingreso >= ingreso_minimo)
                    {
                        //no debe segir recorriendo y se debe quedar con el valor del modelo escogido
                        Microsoft.Office.Interop.Excel.Range esc = (Microsoft.Office.Interop.Excel.Range)x.Cells[fila, 1];
                        modelo_escogido = esc.Value;
                        Console.WriteLine("Mod escogido " + modelo_escogido);
                        fila = 100000; //para que se salga del while
                    }
                    fila++;
                }
                
            }
            if (dummyIsapre == 1)//ocupo las celdas de isapre
            {
                int fila = 22;
                int columna = rangoingreso + 2;
                // Lectura de archivo
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                string workbookPatch = Application.StartupPath + @"\COST EFF.xlsx";
                Microsoft.Office.Interop.Excel.Workbook wbook = excel.Workbooks.Open(workbookPatch);
                Microsoft.Office.Interop.Excel.Worksheet x = excel.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
                //ojo [row, columna]

                //Quiero que se recorran las filas hasta que le alcance con su ingreso
                while (fila < 37)
                {
                    Microsoft.Office.Interop.Excel.Range minimo = (Microsoft.Office.Interop.Excel.Range)x.Cells[fila, columna];
                    double ingreso_minimo = minimo.Value;
                    Console.WriteLine("minimo ing " + ingreso_minimo);
                    if (ingreso >= ingreso_minimo)
                    {
                        //no debe segir recorriendo y se debe quedar con el valor del modelo escogido
                        Microsoft.Office.Interop.Excel.Range esc = (Microsoft.Office.Interop.Excel.Range)x.Cells[fila, 1];
                        double modelo_esc= esc.Value;
                        modelo_escogido = Convert.ToInt32(modelo_esc);
                        Console.WriteLine("Mod escogido " + modelo_escogido);
                        fila = 100000; //para que se salga del while
                        
                    }
                    fila++;
                }
                
            }
      
            //ahora le tengo que decir los examenes que se debe hacer, estos dependen del modelo escogido

            if (modelo_escogido == 1)
            {
                //se le deberia abrir la otra consola altiro ya que alno hacerse examenes no es necesario que vuelva
                NoSeHaceExamenes vent = new NoSeHaceExamenes();
                vent.Show();
            }
            if (modelo_escogido == 2)
            {
                if (dummyIsapre == 0) { costo = CostosFonasa[0]; }
                if (dummyIsapre == 1) { costo = CostosIsapre[0]; }
                MessageBox.Show("Se debe hacer un Hemograma, el costo en " + sistemasalud + " es de $" + costo);
            }
            if (modelo_escogido == 3)
            {
                if (dummyIsapre == 0) { costo = CostosFonasa[1]; }
                if (dummyIsapre == 1) { costo = CostosIsapre[1]; }
                MessageBox.Show("Se debe hacer un Perfil Lipídico, el costo en " + sistemasalud + " es de $" + costo);
            }
            if (modelo_escogido == 4)
            {
                if (dummyIsapre == 0) { costo = CostosFonasa[2]; }
                if (dummyIsapre == 1) { costo = CostosIsapre[2]; }
                MessageBox.Show("Se debe hacer un Electrocardiograma, el costo en " + sistemasalud + " es de $" + costo);
            }
            if (modelo_escogido == 5)
            {
                if (dummyIsapre == 0) { costo = CostosFonasa[2] + CostosFonasa[0]; }
                if (dummyIsapre == 1) { costo = CostosIsapre[2] + CostosIsapre[0]; }
                MessageBox.Show("Se debe hacer un Hemograma y un Electrocardiograma, el costo total en " + sistemasalud + " es de $" + costo);
            }
            if (modelo_escogido == 6)
            {
                if (dummyIsapre == 0) { costo = CostosFonasa[4]; }
                if (dummyIsapre == 1) { costo = CostosIsapre[4]; }
                MessageBox.Show("Se debe hacer un Test de esfuerzo, el costo total en " + sistemasalud + " es de $" + costo);
            }
            if (modelo_escogido == 7)
            {
                if (dummyIsapre == 0) { costo = CostosFonasa[0] + CostosFonasa[4]; }
                if (dummyIsapre == 1) { costo = CostosIsapre[0] + CostosIsapre[4]; }
                MessageBox.Show("Se debe hacer un Hemograma y un Test de esfuerzo, el costo total en " + sistemasalud + " es de $" + costo);
            }
            if (modelo_escogido == 8)
            {
                if (dummyIsapre == 0) { costo = CostosFonasa[1] + CostosFonasa[4]; }
                if (dummyIsapre == 1) { costo = CostosIsapre[1] + CostosIsapre[4]; }
                MessageBox.Show("Se debe hacer un Perfil Lipídico y un Test de esfuerzo, el costo total en " + sistemasalud + " es de $" + costo);
            }
            if (modelo_escogido == 9)
            {
                if (dummyIsapre == 0) { costo = CostosFonasa[0] + CostosFonasa[1] + CostosFonasa[4]; }
                if (dummyIsapre == 1) { costo = CostosIsapre[0] + CostosIsapre[1] + CostosIsapre[4]; }
                MessageBox.Show("Se debe hacer un Hemograma, un Perfil Lipídico y un Test de esfuerzo. El costo total en " + sistemasalud + " es de $" + costo);
            }
            if (modelo_escogido == 10)
            {
                if (dummyIsapre == 0) { costo = CostosFonasa[3]; }
                if (dummyIsapre == 1) { costo = CostosIsapre[3]; }
                MessageBox.Show("Se debe hacer una Angiotomografía, el costo total en " + sistemasalud + " es de $" + costo);
            }
            if (modelo_escogido == 11)
            {
                if (dummyIsapre == 0) { costo = CostosFonasa[0] + CostosFonasa[3]; }
                if (dummyIsapre == 1) { costo = CostosIsapre[0] + CostosIsapre[3]; }
                MessageBox.Show("Se debe hacer un Hemograma y una Angiotomografía, el costo total en " + sistemasalud + " es de $" + costo);
            }
            if (modelo_escogido == 12)
            {
                if (dummyIsapre == 0) { costo = CostosFonasa[0] + CostosFonasa[1] + CostosFonasa[4]; }
                if (dummyIsapre == 1) { costo = CostosIsapre[0] + CostosIsapre[1] + CostosIsapre[4]; }
                MessageBox.Show("Se debe hacer un Hemograma, un Perfil Lipídico, un Electrocardiograma y una Angiotomografía. El costo total en " + sistemasalud + " es de $" + costo);
            }
            if (modelo_escogido == 13)
            {
                if (dummyIsapre == 0) { costo = CostosFonasa[3]+ CostosFonasa[4]; }
                if (dummyIsapre == 1) { costo = CostosIsapre[3]+ CostosIsapre[4]; }
                MessageBox.Show("Se debe hacer una Angiotomografía y un Test de esfuerzo, el costo total en " + sistemasalud + " es de $" + costo);
            }
            if (modelo_escogido == 14)
            {
                if (dummyIsapre == 0) { costo = CostosFonasa[0]+ CostosFonasa[3] + CostosFonasa[4]; }
                if (dummyIsapre == 1) { costo = CostosIsapre[0] +CostosIsapre[3] + CostosIsapre[4]; }
                MessageBox.Show("Se debe hacer un Hemograma, una Angiotomografía y un Test de esfuerzo. El costo total en " + sistemasalud + " es de $" + costo);
            }
            if (modelo_escogido == 15)
            {
                if (dummyIsapre == 0) { costo = CostosFonasa[0] + CostosFonasa[1] + CostosFonasa[2]+ CostosFonasa[3] + CostosFonasa[4]; }
                if (dummyIsapre == 1) { costo = CostosIsapre[0] + CostosIsapre[1] + CostosIsapre[2]+ CostosIsapre[3] + CostosIsapre[4]; }
                MessageBox.Show("Se debe hacer un Hemograma, un Perfil Lipídico, un Electrocardiograma, una Angiotomografía y un Test de esfuerzo. El costo total en " + sistemasalud + " es de $" + costo);
            }
         
        }
        private void leerVariables()
        {
            sexo = comboBox1.Text;
            if (Int32.TryParse(textBox1.Text, out ingreso)) { }
            else
            {
                MessageBox.Show("Error en ingreso");
            }
            //  rangoingreso = comboBox2.SelectedIndex + 1;
            sistemasalud = comboBox3.Text;
            if (comboBox3.SelectedIndex == 0) //es fonasa
            { dummyIsapre = 0; }
            if (comboBox3.SelectedIndex == 1) //es isapre
            { dummyIsapre = 1; }

            // vemos en que quintil de ingreso esta la persona para saber cuanto dinero gastara en salud
            if (ingreso <= 250000)
            {
                rangoingreso = 1;
            }
            if (ingreso > 250000 && ingreso <= 380000)
            {
                rangoingreso = 2;
            }
            if (ingreso > 380000 && ingreso <= 560000)
            {
                rangoingreso = 3;
            }
            if (ingreso > 560000 && ingreso <= 1200000)
            {
                rangoingreso = 4;
            }
            if (ingreso > 1200000 )
            {
                rangoingreso = 5;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = verificaCasillas();
            textBox1.Enabled = false;
       /*     if (comboBox2.SelectedIndex > -1)
            {
                ingreso = comboBox2.SelectedIndex + 1;
                if (comboBox2.SelectedIndex == 0 || comboBox2.SelectedIndex == 1)
                {
                    comboBox3.SelectedIndex = 0;
                }
                else if (comboBox2.SelectedIndex == 2 || comboBox2.SelectedIndex == 3)
                {
                    comboBox3.SelectedIndex = -1;
                }
                else if (comboBox2.SelectedIndex == 4)
                {
                    comboBox3.SelectedIndex = 1;
                    textBox1.Enabled = true;
                }
            }
            */
        }
        private Boolean verificaCasillas()
        {
            int ingreso;
            int presion;
            ///RELLENAR
            return true;

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = verificaCasillas();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = verificaCasillas();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = verificaCasillas();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = verificaCasillas();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
