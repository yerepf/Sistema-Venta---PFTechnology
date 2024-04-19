using PFTechnology.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Sistema_Venta___PFTechnology.Modulos.Entrada
{
    public partial class clientesForm : Form
    {
        BackendClientes backend = new BackendClientes();
        bool modoEdicion;
        bool soloNumeros = true;
        public clientesForm()
        {
            InitializeComponent();

            backend.ActualizarGrid(tablaControl);
            BuscarComboBox.SelectedIndex = 0;
            ActivoFiltro.Visible = false;


            IDBox.Text = (backend.ultimoID() + 1).ToString();
            tablaControl.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void tablaControl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegúrate de que se haya hecho clic en una fila válida
            {
                modoEdicion = true;
                button2.Text = "Modificar";

                DataGridViewRow filaSeleccionada = tablaControl.Rows[e.RowIndex];

                string valorPrimeraColumna = filaSeleccionada.Cells[0].Value.ToString();
                string valorSegundaColumna = filaSeleccionada.Cells[1].Value.ToString();
                string valorTerceraColumna = filaSeleccionada.Cells[2].Value.ToString();
                bool valorCuartaColumna = Convert.ToBoolean(filaSeleccionada.Cells[3].Value);
                string valorQuintaColumna = filaSeleccionada.Cells[4].Value.ToString();

                bool valorSextaColumna = Convert.ToBoolean(filaSeleccionada.Cells[5].Value);
                string valorSeptimaColumna = filaSeleccionada.Cells[6].Value.ToString();

                IDBox.Text = valorPrimeraColumna;
                NombreBox.Text = valorSegundaColumna;
                ApellidoBox.Text = valorTerceraColumna;
                SocioCBox.Checked = valorCuartaColumna;
                EstadocCBox.Checked = valorSextaColumna;
                EmailBox.Text = valorQuintaColumna;
                CedulaBox.Text = valorSeptimaColumna;


            }
        }

        public bool EmailValido(string email)
        {
            Regex regex = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            return regex.IsMatch(email);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool estado = EstadocCBox.Checked, socio = SocioCBox.Checked;
            string id = IDBox.Text, nombre = NombreBox.Text, apellido = ApellidoBox.Text, email = EmailBox.Text, cedula = CedulaBox.Text;

            //guardar
            if (!modoEdicion)
            {
                if (nombre != "" && apellido != "" && email != "" && CedulaBox.Text != "" && !Regex.IsMatch(CedulaBox.Text, @"^[-\s]*$")
    && CedulaBox.Text.Replace(" ", "").Length == 13) 
                { 
                    //bool estado = EstadocCBox.Checked;
                    //string nombre = NombreBox.Text, apellido = ApellidoBox.Text, idempleado;

                    if (EmailValido(EmailBox.Text))
                    {
                        string resultado = backend.Guardar(tablaControl, nombre, apellido, socio, email, cedula, estado);
                        if (resultado == "Guardar")
                        {
                            MessageBox.Show("El registro se ha agregado correctamente.", "Agregación realizada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El email introducido contiene un formato no apropiado.", "Email invalido.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else MessageBox.Show("Introduzca información en los campos, por favor.", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            //modificacion
            else
            {
                

                if (nombre != "" && apellido != "" && email != "" && CedulaBox.Text != "" && !Regex.IsMatch(CedulaBox.Text, @"^[-\s]*$")
                    && CedulaBox.Text.Replace(" ", "").Length == 13)
                {
                    if (EmailValido(EmailBox.Text))
                    {
                        // Llamamos al método Modificar del backend para realizar la modificación en la base de datos
                        string resultado = backend.Modificar(tablaControl, id, nombre, estado, socio, apellido, email, cedula);

                        if (resultado == "Guardar")
                        {
                            modoEdicion = false;
                            button2.Text = "Guardar";
                            button3.PerformClick();
                            // Limpiamos los campos después de la modificación
                            MessageBox.Show("El registro se ha modificado correctamente.", "Modificación realizada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarCampos();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El email introducido contiene un formato no apropiado.","Email invalido.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else MessageBox.Show("Introduzca información en los campos, por favor.", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
        }

        private void LimpiarCampos()
        {
            IDBox.Text = (backend.ultimoID() + 1).ToString();

            NombreBox.Text = "";
            ApellidoBox.Text = "";
            CedulaBox.Text = "";
            EmailBox.Text = "";
            SocioCBox.Checked = false;
            EstadocCBox.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IDBox.Text = (backend.ultimoID() + 1).ToString();

            if (modoEdicion) modoEdicion = false;
            NombreBox.Text = "";
            ApellidoBox.Text = "";
            EmailBox.Text = "";
            CedulaBox.Text = "";
            SocioCBox.Checked = false;
            EstadocCBox.Checked = true;
        }

        private void BuscarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatoBox.Text = string.Empty;
            cedulaFiltroBox.Text = string.Empty;
            ActivoFiltro.Checked = false;

            backend.ActualizarGrid(tablaControl);

            if (BuscarComboBox.SelectedIndex == 5 || BuscarComboBox.SelectedIndex == 6)
            {
                ActivoFiltro.Visible = true;
                DatoBox.Visible = false;
                backend.Filtrar(tablaControl, BuscarComboBox.SelectedIndex, "0");
                cedulaFiltroBox.Visible = false;
                ActivoFiltro.Focus();
            }
            else if (BuscarComboBox.SelectedIndex == 4)
            {
                ActivoFiltro.Visible = false;
                cedulaFiltroBox.Visible = true;
                DatoBox.Visible = false;
                backend.ActualizarGrid(tablaControl);
                cedulaFiltroBox.Focus();
            }
            else
            {
                ActivoFiltro.Visible = false;
                DatoBox.Visible = true;
                cedulaFiltroBox.Visible = false;
                backend.ActualizarGrid(tablaControl);
                DatoBox.Focus();
            }

            if (BuscarComboBox.SelectedIndex == 0) soloNumeros = true;
            else soloNumeros = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DatoBox.Text = string.Empty;
            backend.ActualizarGrid(tablaControl);
            BuscarComboBox.SelectedIndex = 0;
        }

        private void DatoBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DatoBox.Text))
                backend.Filtrar(tablaControl, BuscarComboBox.SelectedIndex, DatoBox.Text);
            else
                backend.ActualizarGrid(tablaControl);
        }

        private void cedulaFiltroBox_TextChanged(object sender, EventArgs e)
        {
            // saber si el maskedbox no contiene algo
            if (Regex.IsMatch(cedulaFiltroBox.Text, @"^[-\s]*$")) backend.ActualizarGrid(tablaControl);
            else backend.Filtrar(tablaControl, BuscarComboBox.SelectedIndex, cedulaFiltroBox.Text);
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

        //Eventos Key personalizados por el textbox

        private void DatoBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && soloNumeros) e.Handled = true; // Evita que se ingrese el carácter no válido
        }

        private void ActivoFiltro_CheckedChanged(object sender, EventArgs e)
        {
            if (ActivoFiltro.Checked) backend.Filtrar(tablaControl, BuscarComboBox.SelectedIndex, "1");
            else backend.Filtrar(tablaControl, BuscarComboBox.SelectedIndex, "0");
        }
    }
}
