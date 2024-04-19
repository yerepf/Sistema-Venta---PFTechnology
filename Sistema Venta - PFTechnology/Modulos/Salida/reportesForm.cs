using Sistema_Venta___PFTechnology.Modulos.Salida.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Venta___PFTechnology.Modulos.Salida
{
    public partial class reportesForm : Form
    {

        public static class ReportesClase
        {
            public static bool generales = false;
            public static int idreport = -1;
        }
        

        public reportesForm()
        {
            InitializeComponent();
        }


        //generales 

        //Producto
        private void button1_Click(object sender, EventArgs e)
        {
            ReportesClase.generales = true;
            ReportesClase.idreport = 1;
            ReporteGenerado rG = new ReporteGenerado();
            rG.ShowDialog();
            
        }

        //Cliente
        private void button2_Click(object sender, EventArgs e)
        {
            ReportesClase.generales = true; ReportesClase.idreport = 2;
            ReporteGenerado rG = new ReporteGenerado();
            rG.ShowDialog();
        }
        //Empleado
        private void button3_Click(object sender, EventArgs e)
        {
            ReportesClase.generales = true;
            ReportesClase.idreport = 3;
            ReporteGenerado rG = new ReporteGenerado();
            rG.ShowDialog();
        }
        //Especificos

        //venta x rango de fecha
        private void button4_Click(object sender, EventArgs e)
        {
            ReportesClase.generales = false;
            ReportesClase.idreport = 4;
            ReporteGenerado rG = new ReporteGenerado();
            rG.ShowDialog();
        }
        //venta x Empleado
        private void button8_Click(object sender, EventArgs e)
        {
            ReportesClase.generales = false;
            ReportesClase.idreport = 5;
            ReporteGenerado rG = new ReporteGenerado();
            rG.ShowDialog();
        }
        //venta x Cliente
        private void button7_Click(object sender, EventArgs e)
        {
            ReportesClase.generales = false;
            ReportesClase.idreport = 6;
            ReporteGenerado rG = new ReporteGenerado();
            rG.ShowDialog();
        }
        //venta x Producto
        private void button6_Click(object sender, EventArgs e)
        {
            ReportesClase.generales = false;
            ReportesClase.idreport = 7;
            ReporteGenerado rG = new ReporteGenerado();
            rG.ShowDialog();
        }
        //venta x Categoría
        private void button5_Click(object sender, EventArgs e)
        {
            ReportesClase.generales = false;
            ReportesClase.idreport = 8;
            ReporteGenerado rG = new ReporteGenerado();
            rG.ShowDialog();
        }
    }
}
