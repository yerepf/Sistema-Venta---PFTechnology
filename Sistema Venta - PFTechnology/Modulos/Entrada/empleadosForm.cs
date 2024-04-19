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

namespace Sistema_Venta___PFTechnology.Modulos.Entrada
{
    public partial class empleadosForm : Form
    {
        bool modoEdicion = false;
        BackendEmpleados backend = new BackendEmpleados();


        public empleadosForm()
        {
            InitializeComponent();
            tablaControl.DefaultCellStyle.ForeColor = Color.Black;

            backend.ActualizarGrid(tablaControl);
            BuscarComboBox.SelectedIndex = 0;
            ActivoFiltro.Visible = false;


            IDBox.Text = (backend.UltimoID() + 1).ToString();

            backend.ActualizarDepartamentos(DeptoComboBox);
            backend.ActualizarSucursales(SucursalComboBox);
        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            backend.ActualizarDepartamentos(DeptoComboBox);
        }
        private void SucursalComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            backend.ActualizarSucursales(SucursalComboBox);
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
                string valorCuartaColumna = filaSeleccionada.Cells[3].Value.ToString();
                string valorQuintaColumna = filaSeleccionada.Cells[4].Value.ToString();
                string valorSextaColumna = filaSeleccionada.Cells[5].Value.ToString();
                bool valorSeptimaColumna = Convert.ToBoolean(filaSeleccionada.Cells[6].Value);
                string valorOctavaColumna = filaSeleccionada.Cells[7].Value.ToString();
                string valorNovenaColumna = filaSeleccionada.Cells[8].Value.ToString();

                IDBox.Text = valorPrimeraColumna;
                DeptoComboBox.Text = valorSegundaColumna;
                SucursalComboBox.Text = valorTerceraColumna;
                NombreBox.Text = valorCuartaColumna;
                ApellidosBox.Text = valorQuintaColumna;
                EmailBox.Text = valorSextaColumna;
                EstadocCBox.Checked = valorSeptimaColumna;
                CedulaBox.Text = valorOctavaColumna;
                NCelularBox.Text = valorNovenaColumna;

                if (valorSegundaColumna != "") DeptoComboBox.Text = backend.ObtenerDescripcionDepartamentoDesdeBD(valorSegundaColumna);
                if (valorTerceraColumna != "") SucursalComboBox.Text = backend.ObtenerNombreSucursalDesdeBD(valorTerceraColumna);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!modoEdicion)
            {
                if (NombreBox.Text != "" && ApellidosBox.Text != "" &&
                    NCelularBox.Text != "" && CedulaBox.Text != "" &&
                    EmailBox.Text != "" && DeptoComboBox.Text != "" &&
                    SucursalComboBox.Text != "" && !Regex.IsMatch(CedulaBox.Text, @"^[-\s]*$")
                    && CedulaBox.Text.Replace(" ", "").Length == 13)
                {
                    bool estado = false;
                    if (EstadocCBox.Checked) estado = true;

                    string nombre = NombreBox.Text;
                    string apellidos = ApellidosBox.Text;
                    string ncelular = NCelularBox.Text;
                    string cedula = CedulaBox.Text;
                    string email = EmailBox.Text;
                    string departamento = DeptoComboBox.Text;
                    string sucursal = SucursalComboBox.Text;

                    if (EmailValido(email))
                    {
                        backend.Guardar(tablaControl, nombre, apellidos, email, cedula, ncelular, departamento, sucursal, estado);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Email Invalido");
                    }


                }
                else MessageBox.Show("Por favor, verifique que todos los datos sean correctos y explícitos en el formulario.", "Campos vacios o erroneos.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //modo edicion
            else
            {
                if (NombreBox.Text != "" && ApellidosBox.Text != "" &&
                    NCelularBox.Text != "" && CedulaBox.Text != "" &&
                    EmailBox.Text != "" && DeptoComboBox.Text != "" &&
                    SucursalComboBox.Text != "" && !Regex.IsMatch(CedulaBox.Text, @"^[-\s]*$")
                    && CedulaBox.Text.Replace(" ", "").Length == 13)
                {
                    if (EmailValido(EmailBox.Text))
                    {
                        if (EstadocCBox.Checked) backend.Modificar(tablaControl, IDBox.Text, NombreBox.Text, ApellidosBox.Text, EmailBox.Text, CedulaBox.Text, NCelularBox.Text, "1", DeptoComboBox.Text, SucursalComboBox.Text);
                        else backend.Modificar(tablaControl, IDBox.Text, NombreBox.Text, ApellidosBox.Text, EmailBox.Text, CedulaBox.Text, NCelularBox.Text, "0", DeptoComboBox.Text, SucursalComboBox.Text);
                        MessageBox.Show("El registro seleccionado se ha modificado exitosamente.", "Modificacion Realizada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        modoEdicion = false;

                        Limpiar();

                        button2.Text = "Agregar";
                    }
                    else MessageBox.Show("Email Invalido");
                    
                }
                else MessageBox.Show("Por favor, verifique que todos los datos sean correctos y explícitos en el formulario.", "Campos vacios o erroneos.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Limpiar()
        {
            IDBox.Text = (backend.UltimoID() + 1).ToString();

            ApellidosBox.Text = "";
            CedulaBox.Text = "";
            EmailBox.Text = "";
            NCelularBox.Text = "";
            NombreBox.Text = "";
            DeptoComboBox.Text = "";
            SucursalComboBox.Text = "";
            EstadocCBox.Checked = true;
        }

        public bool EmailValido(string email)
        {
            Regex regex = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            return regex.IsMatch(email);
        }

        private void BuscarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatoBox.Text = string.Empty;
            cedulaFiltroBox.Text = string.Empty;
            backend.ActualizarGrid(tablaControl);

            if (BuscarComboBox.SelectedIndex == 8)
            {
                ActivoFiltro.Visible = true;
                DatoBox.Visible = false;
                cedulaFiltroBox.Visible = false;
                NCelularBoxFiltro.Visible = false;

                if (ActivoFiltro.Checked) backend.Filtrar(tablaControl, BuscarComboBox.SelectedIndex, "1");
                else backend.Filtrar(tablaControl, BuscarComboBox.SelectedIndex, "0");
            }
            else if (BuscarComboBox.SelectedIndex == 4)
            {
                cedulaFiltroBox.Visible = true;
                ActivoFiltro.Visible = false;
                DatoBox.Visible = false;
                NCelularBoxFiltro.Visible = false;
            }
            else if(BuscarComboBox.SelectedIndex == 5)
            {
                NCelularBoxFiltro.Visible = true;
                cedulaFiltroBox.Visible = false;
                ActivoFiltro.Visible = false;
                DatoBox.Visible=false;
            }
            else
            {
                ActivoFiltro.Visible = false;
                DatoBox.Visible = true;
                cedulaFiltroBox.Visible = false;
                NCelularBoxFiltro.Visible = false;
            }
        }

        private void cedulaFiltroBox_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(cedulaFiltroBox.Text, @"^[-\s]*$")) backend.ActualizarGrid(tablaControl);
            else backend.Filtrar(tablaControl, BuscarComboBox.SelectedIndex, cedulaFiltroBox.Text);
        }

        private void DatoBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DatoBox.Text))
                backend.Filtrar(tablaControl, BuscarComboBox.SelectedIndex, DatoBox.Text);
            else
                backend.ActualizarGrid(tablaControl);
        }

        private void ActivoFiltro_CheckedChanged(object sender, EventArgs e)
        {
            if (ActivoFiltro.Checked) backend.Filtrar(tablaControl, BuscarComboBox.SelectedIndex, "1");
            else backend.Filtrar(tablaControl, BuscarComboBox.SelectedIndex, "0");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DatoBox.Text = string.Empty;
            cedulaFiltroBox.Text = string.Empty;
            ActivoFiltro.Checked = false;
            backend.ActualizarGrid(tablaControl);
            BuscarComboBox.SelectedIndex = 0;
            NCelularBoxFiltro.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IDBox.Text = (backend.UltimoID() + 1).ToString();

            if (modoEdicion)
            {
                modoEdicion = false;
                button2.Text = "Agregar";
            }

            ApellidosBox.Text = "";
            CedulaBox.Text = "";
            NCelularBox.Text = "";
            NombreBox.Text = "";
            EmailBox.Text = "";
            DeptoComboBox.Text = "";
            SucursalComboBox.Text = "";
            EstadocCBox.Checked = true;
        }

        private void DatoBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) e.SuppressKeyPress = true;
        }

        private void DatoBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (BuscarComboBox.SelectedIndex == 0 || (BuscarComboBox.SelectedIndex == 6 || BuscarComboBox.SelectedIndex == 7))) e.Handled = true;
        }

        private void NCelularBoxFiltro_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(NCelularBoxFiltro.Text, @"^[-\s()]*$")) backend.ActualizarGrid(tablaControl);
            else backend.Filtrar(tablaControl, BuscarComboBox.SelectedIndex, NCelularBoxFiltro.Text);
        }
    }

   
}

