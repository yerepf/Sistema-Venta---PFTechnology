using Microsoft.Reporting.WinForms;
using MimeKit;
using PFTechnology.Backend;
using Sistema_Venta___PFTechnology.DataSet1TableAdapters;
using Sistema_Venta___PFTechnology.Modulos.Entrada;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sistema_Venta___PFTechnology.Modulos.Procesamiento
{
    public partial class ventaForm : Form
    {
        BackendVenta backendVenta = new BackendVenta();
        int idVenta = 0, idusuarionew = 0, idAMod = -1;
        bool soloNumeros = true, modoescaner, edicionDetalle;

        string[] datos;

        public static class VariablesVenta
        {
            public static int idcliente;
        }


        public ventaForm(int idusuario)
        {
            InitializeComponent();
            clientesGBox.BringToFront();

            backendVenta.ActualizarGridProductos(tablaProductos);
            backendVenta.ActualizarGridClientes(tablaClientes);
            backendVenta.ActualizarGridVenta(tablaVenta, 0);

            clientesCBox.SelectedIndex = 0;
            productosCBox.SelectedIndex = 0;
            totalBox.Text = "0";

            SocioFiltroCliente.Visible = false;
            idusuarionew = idusuario;
            agregarClienteBtn.Enabled = false;
            cancelarCambioClienteBtn.Visible = false;
            eliminarBtn.Visible = false;
            agregarBtn.Enabled = false;

            tablaVenta.DefaultCellStyle.ForeColor = Color.Black;
        }


        private void agregarBtn_Click(object sender, EventArgs e)
        {
            backendVenta.ActualizarGridProductos(tablaProductos);



            VariablesVenta.idcliente = Convert.ToInt32(IDClienteBox.Text);
            if (agregarClienteBtn.Text == "Agregar")
            {
                clientesGBox.Visible = false;
                backendVenta.Crearfactura(VariablesVenta.idcliente, idusuarionew);
                idVenta = backendVenta.ObtenerIDVenta();
            }
            else
            {
                backendVenta.CambiarCliente(idVenta, VariablesVenta.idcliente);
                clientesGBox.Visible = false;
            }
        }

        private void cancelarCambioClienteBtn_Click(object sender, EventArgs e)
        {
            clientesGBox.Visible = false;
        }

        private void DatoBoxCliente_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DatoBoxCliente.Text)) backendVenta.FiltrarClientes(tablaClientes, clientesCBox.SelectedIndex, DatoBoxCliente.Text);
            else backendVenta.ActualizarGridClientes(tablaClientes);
        }

        private void clientesCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatoBoxCliente.Text = string.Empty;
            backendVenta.ActualizarGridClientes(tablaClientes);

            if (clientesCBox.SelectedIndex == 5)
            {
                SocioFiltroCliente.Visible = true;
                DatoBoxCliente.Visible = false;

                backendVenta.FiltrarClientes(tablaClientes, clientesCBox.SelectedIndex, "0");
            }
            else
            {
                SocioFiltroCliente.Visible = false;
                DatoBoxCliente.Visible = true;
            }
        }

        private void tablaClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = tablaClientes.Rows[e.RowIndex];

                if (filaSeleccionada.Cells[0].Value.ToString() != "")
                {
                    string valorID = filaSeleccionada.Cells[0].Value.ToString();
                    string valorNombreApellido = filaSeleccionada.Cells[1].Value.ToString() + " " + filaSeleccionada.Cells[2].Value.ToString();

                    if (agregarClienteBtn.Text == "Modificar")
                    {
                        if (valorID == idAMod.ToString())
                        {
                            agregarClienteBtn.Enabled = false;
                        }
                        else
                        {
                            agregarClienteBtn.Enabled = true;
                        }
                    }
                    else
                    {
                        agregarClienteBtn.Enabled = true;
                    }


                    IDClienteBox.Text = valorID;
                    NombreClienteBox.Text = valorNombreApellido;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (backendVenta.ContarDetalles(idVenta) > 0)
            {
                backendVenta.TerminarVenta(idVenta);

                if (checkBox2.Checked) MandarAlEmail(idVenta, true);
                else MandarAlEmail(idVenta, false);

                reiniciarVenta();
            }
            else MessageBox.Show("Se necesita al menos un producto para realizar la venta.");
        }

        private void MandarAlEmail(int idVenta, bool mandar)
        {
            // Crear una instancia de LocalReport (ReportViewer)
            LocalReport report = new LocalReport();

            // Definir la ruta del informe RDLC
            report.ReportPath = "C:\\Users\\yerem\\source\\repos\\Sistema Venta - PFTechnology\\Sistema Venta - PFTechnology\\Modulos\\Salida\\Reportes\\Factura.rdlc";

            // Configurar los datos del informe
            ReportDataSource rds = new ReportDataSource("DataSet1", bindingSource);
            report.DataSources.Add(rds);
            sP_FACTURADECONSUMOTableAdapter1.Fill(dataSet11.SP_FACTURADECONSUMO, idVenta);

            // Parámetros del informe (si los hay)
            ReportParameter[] parametros = new ReportParameter[6];
            parametros[0] = new ReportParameter("Cliente", VariablesVenta.idcliente.ToString());
            parametros[1] = new ReportParameter("Cajero", idusuarionew.ToString());
            parametros[2] = new ReportParameter("Sucursal", backendVenta.SucursalPorIDUsuario(idusuarionew));
            parametros[3] = new ReportParameter("Total", totalBox.Text.ToString());
            parametros[4] = new ReportParameter("Pagado", efectivoBox.Text.ToString());
            parametros[5] = new ReportParameter("Devuelta", cambioBox.Text.ToString());
            report.SetParameters(parametros);

            // Renderizar el informe en formato PDF
            string mimeType, encoding, filenameExtension;
            string[] streamids;
            Warning[] warnings;
            byte[] bytes = report.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

            // Guardar el PDF en un archivo temporal
            string tempFilePath = Path.GetTempFileName().Replace(".tmp", ".pdf");
            using (FileStream fs = new FileStream(tempFilePath, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
            
            Process proceso = new Process();
            proceso.StartInfo.FileName = tempFilePath;
            proceso.StartInfo.Verb = "Print";
            proceso.StartInfo.CreateNoWindow = true;
            proceso.Start();

            if (mandar == true)
            {
                //obtener email del cliente
                string email = backendVenta.EmailPorIDCliente(VariablesVenta.idcliente);

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

            }

            // Eliminar el archivo temporal
            File.Delete(tempFilePath);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            cancelarCambioClienteBtn.Visible = false;
            clientesGBox.Visible = true;
            clientesGBox.BringToFront();
            idAMod = Convert.ToInt32(IDClienteBox.Text);
            agregarClienteBtn.Text = "Modificar";
            agregarClienteBtn.Enabled = false;
            cancelarCambioClienteBtn.Visible = true;
        }

        public void reiniciarVenta()
        {

            agregarClienteBtn.Text = "Agregar";
            cancelarCambioClienteBtn.Visible = false;
            clientesGBox.Visible = true;
            cancelarCambioClienteBtn.Visible = false;
            IDClienteBox.Text = "";
            NombreClienteBox.Text = "";
            agregarClienteBtn.Enabled = false;
            checkBox2.Checked = false;

            backendVenta.ActualizarGridVenta(tablaVenta, 0);
            limpiarCamposFactura();
            limpiarCamposProd();
        }

        private void limpiarCamposProd()
        {
            IDProductoBox.Text = string.Empty;
            DescripcionProductoBox.Text = string.Empty;
            cantidadDescuento.Value = 0;
            cantidadProducto.Value = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            backendVenta.CancelarVenta(idVenta);
            reiniciarVenta();
        }

        private void totalBox_TextChanged(object sender, EventArgs e)
        {

            double total = 0, efectivo = 0, cambio;

            if (!string.IsNullOrWhiteSpace(totalBox.Text)) total = Convert.ToDouble(totalBox.Text);
            if (!string.IsNullOrWhiteSpace(efectivoBox.Text)) efectivo = Convert.ToDouble(efectivoBox.Text);

            cambio = total - efectivo;

            if (cambio != 0) cambioBox.Text = (cambio * -1).ToString();
            else cambioBox.Text = 0.ToString();
        }

        private void efectivoBox_TextChanged(object sender, EventArgs e)
        {

            double total = 0;
            double efectivo = 0;
            double cambio;

            if (!string.IsNullOrWhiteSpace(totalBox.Text)) total = Convert.ToDouble(totalBox.Text);
            if (!string.IsNullOrWhiteSpace(efectivoBox.Text)) efectivo = Convert.ToDouble(efectivoBox.Text);

            cambio = total - efectivo;

            if (cambio != 0) cambioBox.Text = (cambio * -1).ToString();
            else cambioBox.Text = 0.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            agregarProductoDetalle();
        }

        private void agregarProductoDetalle()
        {
            try
            {
                int idProducto = modoescaner ? Convert.ToInt32(datos[0]) : Convert.ToInt32(IDProductoBox.Text);
                int canProducto = modoescaner ? Convert.ToInt32(datos[2]) : Convert.ToInt32(cantidadProducto.Value);
                int canDescuento = modoescaner ? Convert.ToInt32(datos[3]) : Convert.ToInt32(cantidadDescuento.Value);

                string rs;
                if (!edicionDetalle) rs = backendVenta.AgregarProductoAlDetalle(tablaVenta, idVenta, idProducto, canProducto, canDescuento);
                else
                {
                    rs = backendVenta.ActualizarProductoenDetalle(idVenta, idProducto, tablaVenta, canProducto, canDescuento);

                    if (rs == "Agregar")
                    {
                        edicionDetalle = false;
                        agregarBtn.Text = "Agregar";
                        eliminarBtn.Visible = false;
                    }
                }

                if (rs == "Agregar")
                {
                    totalBox.Text = backendVenta.ObtenerTotal(idVenta).ToString();
                    agregarBtn.Enabled = false;
                    limpiarCamposProd();
                }
                else if (rs == "SinStock") MessageBox.Show("La cantidad disponible del producto no es suficiente para la cantidad solicitada", "Stock Insuficiente");
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingresa un número válido en los campos de texto.", "Error de formato");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            agregarBtn.Enabled = false;
            backendVenta.EliminarDetalle(Convert.ToInt32(IDProductoBox.Text), idVenta, tablaVenta);
            totalBox.Text = backendVenta.ObtenerTotal(idVenta).ToString();

            edicionDetalle = false;
            eliminarBtn.Visible = false;
            agregarBtn.Text = "Agregar";
            limpiarCamposProd();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            agregarBtn.Enabled = false;
            edicionDetalle = false;
            eliminarBtn.Visible = false;
            agregarBtn.Text = "Agregar";
            limpiarCamposProd();
        }

        private void productosCBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            DatoBoxProd.Text = string.Empty;
            backendVenta.ActualizarGridProductos(tablaProductos);

            if (productosCBox.SelectedIndex == 0 ||
                productosCBox.SelectedIndex == 2 ||
                productosCBox.SelectedIndex == 3 ||
                productosCBox.SelectedIndex == 4 ||
                productosCBox.SelectedIndex == 5)
                soloNumeros = true;
            else soloNumeros = false;

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DatoBoxProd.Text)) backendVenta.FiltrarProductos(tablaProductos, productosCBox.SelectedIndex, DatoBoxProd.Text);
            else backendVenta.ActualizarGridProductos(tablaProductos);
        }

        private void tablaProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = tablaProductos.Rows[e.RowIndex];
                

                if (filaSeleccionada.Cells[0].Value.ToString() != "")
                {

                    string valorID = filaSeleccionada.Cells[0].Value.ToString();
                    string valorDescripcion = filaSeleccionada.Cells[2].Value.ToString();


                    if (backendVenta.ComprobarProdenDetalle(Convert.ToInt32(valorID), idVenta))
                    {
                        MessageBox.Show("Este producto esta en factura ya");
                        agregarBtn.Enabled = false;
                    }
                    else
                    {
                        agregarBtn.Enabled = true;
                        IDProductoBox.Text = valorID;
                        DescripcionProductoBox.Text = valorDescripcion;
                    }
                }

                canFiltroProdBtn.PerformClick();

            }
        }

        private void tablaVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) // Asegúrate de que se haya hecho clic en una fila válida
            {
                DataGridViewRow filaSeleccionada = tablaVenta.Rows[e.RowIndex];

                if (filaSeleccionada.Cells[0].Value.ToString() != "")
                {
                    agregarBtn.Enabled = true;
                    edicionDetalle = true;
                    agregarBtn.Text = "Modificar";
                    eliminarBtn.Visible = true;

                    int IDProd = Convert.ToInt32(filaSeleccionada.Cells[1].Value);
                    int cantidadProd = Convert.ToInt32(filaSeleccionada.Cells[3].Value);
                    decimal descuento = Convert.ToDecimal(filaSeleccionada.Cells[5].Value);

                    IDProductoBox.Text = IDProd.ToString();
                    cantidadProducto.Text = cantidadProd.ToString();
                    cantidadDescuento.Text = descuento.ToString();
                    DescripcionProductoBox.Text = backendVenta.ObtenerDescripcionPorID(IDProd);
                }
            }
        }

        private void IDClienteBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DatoBoxCliente.Text)) backendVenta.FiltrarClientes(tablaClientes, clientesCBox.SelectedIndex, DatoBoxCliente.Text);
            else backendVenta.ActualizarGridClientes(tablaClientes);
        }

        private void SocioFiltroCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (SocioFiltroCliente.Checked) backendVenta.FiltrarClientes(tablaClientes, clientesCBox.SelectedIndex, "1");
            else backendVenta.FiltrarClientes(tablaClientes, clientesCBox.SelectedIndex, "0");
        }

        public void limpiarCamposFactura()
        {
            totalBox.Text = "0";
            efectivoBox.Text = "";
            cambioBox.Text = "0";
        }
        private void cantidadProducto_ValueChanged(object sender, EventArgs e)
        {
            if (cantidadProducto.Value == 0) cantidadProducto.Value++;
        }


        //Eventos Key generales

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) e.SuppressKeyPress = true;
        }
    

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true; // Evita que se ingrese el carácter no válido
        }

        bool soloNumerosCliente;
        private void DatoBoxCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (clientesCBox.SelectedIndex == 0) soloNumerosCliente = true;
            else soloNumerosCliente = false;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && soloNumerosCliente) e.Handled = true;
        }



        private void canFiltroProdBtn_Click(object sender, EventArgs e)
        {
            productosCBox.SelectedIndex = 0;
            DatoBoxProd.Text = "";
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            EscanerBox.Text = string.Empty;
            modoescaner = true;
            ProductoGroupBox.Visible = false;
            EscanerGroupBox.Visible = true;
            MessageBox.Show("Si mueve el cursor después de presionar <<Ok>> el modo escaner se va a cancelar","Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            EscanerBox.Focus();

           // MessageBox.Show("Esta opción estará disponible próximamente");
        }

        private void EscanerBox_TextChanged(object sender, EventArgs e)
        {
            escanearTimer.Enabled = true;
        }

        private void escanearTimer_Tick(object sender, EventArgs e)
        {
            escanearTimer.Enabled = false;

            datos = EscanerBox.Text.Split(',');

            for (int i = 1; i < datos.Length; i++)
            {
                datos[i] = datos[i].Trim();
            }

            descripcionEscaner.Text = datos[1];
            cantidadEscaner.Text = datos[2];
            descuentoEscaner.Text = datos[3];

            agregarProductoDetalle();

            EscanerBox.TextChanged -= EscanerBox_TextChanged;
            EscanerBox.Text = String.Empty;
            EscanerBox.TextChanged += EscanerBox_TextChanged;  
        }


        private void ventaForm_MouseMove(object sender, MouseEventArgs e)
        {
            if(modoescaner) 
            {
                ProductoGroupBox.Visible = true;
                EscanerGroupBox.Visible = false;
                modoescaner = false;
                MessageBox.Show("El modo escanear ha sido cancelado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

       

        //Eventos Key personalizados por el textbox

        private void DatoBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && soloNumeros) e.Handled = true; // Evita que se ingrese el carácter no válido
        }
    }
}
