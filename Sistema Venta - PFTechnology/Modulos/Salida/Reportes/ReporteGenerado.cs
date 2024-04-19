using Microsoft.Reporting.WinForms;
using MimeKit;
using Sistema_Venta___PFTechnology.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Sistema_Venta___PFTechnology.loginForm;
using static Sistema_Venta___PFTechnology.Modulos.Salida.reportesForm;

namespace Sistema_Venta___PFTechnology.Modulos.Salida.Reportes
{
    public partial class ReporteGenerado : Form
    {
        BackendReportes backendReportes = new BackendReportes();
        string email;

        public ReporteGenerado()
        {
            InitializeComponent();

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

        }

        private void ReporteGenerado_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();

            if (ReportesClase.idreport == 1)
            {
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\yerem\\source\\repos\\Sistema Venta - PFTechnology\\Sistema Venta - PFTechnology\\Modulos\\Salida\\Reportes\\Generales\\Productos.rdlc";
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", REPORTE_GENERAL_PRODUCTOSBindingSource));
                rEPORTE_GENERAL_PRODUCTOSTableAdapter.Fill(dataSet1.REPORTE_GENERAL_PRODUCTOS);
            }
            else if(ReportesClase.idreport == 2)
            {
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\yerem\\source\\repos\\Sistema Venta - PFTechnology\\Sistema Venta - PFTechnology\\Modulos\\Salida\\Reportes\\Generales\\Clientes.rdlc";
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", rEPORTEGENERALCLIENTESBindingSource));
                rEPORTE_GENERAL_CLIENTESTableAdapter.Fill(pFTechnologyDataSet.REPORTE_GENERAL_CLIENTES);
            }
            else if (ReportesClase.idreport == 3)
            {
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\yerem\\source\\repos\\Sistema Venta - PFTechnology\\Sistema Venta - PFTechnology\\Modulos\\Salida\\Reportes\\Generales\\Empleados.rdlc";
               reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", REPORTE_GENERAL_EMPLEADOSBindingSource));
                rEPORTE_GENERAL_EMPLEADOSTableAdapter.Fill(dataSet1.REPORTE_GENERAL_EMPLEADOS);
            }

            reportViewer1.RefreshReport();
        }

          private void button1_Click(object sender, EventArgs e)
          {
            // Renderizar el informe en formato PDF
            string mimeType, encoding, filenameExtension;
            string[] streamids;
            Warning[] warnings;
            byte[] bytes = reportViewer1.LocalReport.Render(
                "PDF", null, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);

            // Guardar el PDF en un archivo temporal
            string tempFilePath = Path.GetTempFileName().Replace(".tmp", ".pdf");
            using (FileStream fs = new FileStream(tempFilePath, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }

            // Paso 2: Enviar el PDF por correo electrónico con MailKit
            var message = new MimeMessage();
                  message.From.Add(new MailboxAddress("PFTechnology", "yeremy.pujols.f@gmail.com"));
                  message.To.Add(new MailboxAddress("Analista", email));
                  message.Subject = "Aquí está tu informe";

                  // Crear el cuerpo del correo con el archivo adjunto
                  var body = new TextPart("plain") { Text = "Adjunto encontrarás el informe en formato PDF." };
                  var attachment = new MimePart("application", "pdf")
                  {
                      Content = new MimeContent(File.OpenRead(tempFilePath), ContentEncoding.Default),
                      ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                      ContentTransferEncoding = ContentEncoding.Base64,
                      FileName = Path.GetFileName(tempFilePath)
                  };
                  var multipart = new Multipart("mixed") { body, attachment };
                  message.Body = multipart;

                  // Configurar el cliente SMTP y enviar el correo
                  using (var client = new MailKit.Net.Smtp.SmtpClient())
                  {
                      client.Connect("smtp.gmail.com", 587, false);
                      client.Authenticate("yeremy.pujols.f@gmail.com", "wota uyrf mrwx crvg");
                      client.Send(message);
                      attachment.Dispose();
                      client.Disconnect(true);
                  }

                  MessageBox.Show("Enviado Correctamente");
            // Eliminar el archivo temporal
                 File.Delete(tempFilePath);
          }

        private void ReporteGenerado_VisibleChanged(object sender, EventArgs e)
        {
            if (reportesForm.ReportesClase.generales) groupBox2.Visible = false;
            else groupBox2.Visible = true;
            email = backendReportes.ObtenerEmailUsuario(Login.user, Login.pass);
            this.WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dateTimePicker1.Value;
            DateTime fechaFin = dateTimePicker2.Value;
            //Rango de fecha
            if (ReportesClase.idreport == 4)
            {
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\yerem\\source\\repos\\Sistema Venta - PFTechnology\\Sistema Venta - PFTechnology\\Modulos\\Salida\\Reportes\\Especificos\\VentaXRangodeFecha.rdlc";
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", sPVENTASPORFECHABindingSource));
                sP_VENTASPORFECHATableAdapter.Fill(dataSet1.SP_VENTASPORFECHA, dateTimePicker1.Value, dateTimePicker2.Value);

                ReportParameter[] reportParameters = new ReportParameter[2];
                reportParameters[0] = new ReportParameter("FechaInicio", fechaInicio.ToString("yyyy-MM-dd"), false);
                reportParameters[1] = new ReportParameter("FechaFinal", fechaFin.ToString("yyyy-MM-dd"), false);

                reportViewer1.LocalReport.SetParameters(reportParameters);
            }
                //empleado
            else if(ReportesClase.idreport == 5)
            {
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\yerem\\source\\repos\\Sistema Venta - PFTechnology\\Sistema Venta - PFTechnology\\Modulos\\Salida\\Reportes\\Especificos\\VentaXEmpleado.rdlc";
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", sPVENTASPOREMPLEADOBindingSource1));
                sP_VENTASPOREMPLEADOTableAdapter.Fill(dataSet1.SP_VENTASPOREMPLEADO, dateTimePicker1.Value, dateTimePicker2.Value);

                ReportParameter[] reportParameters = new ReportParameter[2];
                reportParameters[0] = new ReportParameter("FechaInicio", fechaInicio.ToString("yyyy-MM-dd"), false);
                reportParameters[1] = new ReportParameter("FechaFinal", fechaFin.ToString("yyyy-MM-dd"), false);

                reportViewer1.LocalReport.SetParameters(reportParameters);
            }
                //cliente
            else if(ReportesClase.idreport == 6)
            {
                

                reportViewer1.LocalReport.ReportPath = "C:\\Users\\yerem\\source\\repos\\Sistema Venta - PFTechnology\\Sistema Venta - PFTechnology\\Modulos\\Salida\\Reportes\\Especificos\\VentaXCliente.rdlc";
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", sPVENTASPORCLIENTEBindingSource));
                sP_VENTASPORCLIENTETableAdapter.Fill(dataSet1.SP_VENTASPORCLIENTE, fechaInicio, fechaFin);

                ReportParameter[] reportParameters = new ReportParameter[2];
                reportParameters[0] = new ReportParameter("FechaInicio", fechaInicio.ToString("yyyy-MM-dd"), false);
                reportParameters[1] = new ReportParameter("FechaFinal", fechaFin.ToString("yyyy-MM-dd"), false);

                reportViewer1.LocalReport.SetParameters(reportParameters);

            }
                //Producto
            else if (ReportesClase.idreport == 7)
            {
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\yerem\\source\\repos\\Sistema Venta - PFTechnology\\Sistema Venta - PFTechnology\\Modulos\\Salida\\Reportes\\Especificos\\VentaXProducto.rdlc";
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", sPVENTASPORPRODUCTOBindingSource));
                sP_VENTASPORPRODUCTOTableAdapter.Fill(dataSet1.SP_VENTASPORPRODUCTO, fechaInicio, fechaFin);

                ReportParameter[] reportParameters = new ReportParameter[2];
                reportParameters[0] = new ReportParameter("FechaInicial", fechaInicio.ToString("yyyy-MM-dd"), false);
                reportParameters[1] = new ReportParameter("FechaFinal", fechaFin.ToString("yyyy-MM-dd"), false);

                reportViewer1.LocalReport.SetParameters(reportParameters);
            }
                //categoria
            else if (ReportesClase.idreport == 8)
            {
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\yerem\\source\\repos\\Sistema Venta - PFTechnology\\Sistema Venta - PFTechnology\\Modulos\\Salida\\Reportes\\Especificos\\VentaXCategoria.rdlc";
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", sPVENTASPORCATEGORIABindingSource));
                sP_VENTASPORCATEGORIATableAdapter.Fill(dataSet1.SP_VENTASPORCATEGORIA, dateTimePicker1.Value, dateTimePicker2.Value);

                ReportParameter[] reportParameters = new ReportParameter[2];
                reportParameters[0] = new ReportParameter("FechaInicio", fechaInicio.ToString("yyyy-MM-dd"), false);
                reportParameters[1] = new ReportParameter("FechaFinal", fechaFin.ToString("yyyy-MM-dd"), false);

                reportViewer1.LocalReport.SetParameters(reportParameters);
            }

            reportViewer1.RefreshReport();
        }
    }
}

