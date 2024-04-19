using PFTechnology.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Venta___PFTechnology.Modulos.Entrada
{
    public partial class sucursalesForm : Form
    {
        BackendSucursales backend = new BackendSucursales();
        bool modoEdicion = false;

        public sucursalesForm()
        {
            InitializeComponent();
            tablaControl.DefaultCellStyle.ForeColor = Color.Black;

            backend.ActualizarGrid(tablaControl);
            BuscarComboBox.SelectedIndex = 0;
            ActivoFiltro.Visible = false;

            IDBox.Text = (backend.ultimoID() + 1).ToString();
        }

        public void LimpiarCampos()
        {
            IDBox.Text = (backend.ultimoID() + 1).ToString();
            NombreBox.Text = "";
            UbicacionBox.Text = "";
            EstadocCBox.Checked = true;
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

                IDBox.Text = valorPrimeraColumna;
                NombreBox.Text = valorSegundaColumna;
                UbicacionBox.Text = valorTerceraColumna;
                EstadocCBox.Checked = valorCuartaColumna;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DatoBox.Text = string.Empty;
            backend.ActualizarGrid(tablaControl);
            BuscarComboBox.SelectedIndex = 0;
        }

        private void BuscarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatoBox.Text = string.Empty;
            backend.ActualizarGrid(tablaControl);

            if (BuscarComboBox.SelectedIndex == 3)
            {
                ActivoFiltro.Checked = false;

                ActivoFiltro.Visible = true;
                DatoBox.Visible = false;

                if (ActivoFiltro.Checked) backend.Filtrar(tablaControl, BuscarComboBox.SelectedIndex, "1");
                else backend.Filtrar(tablaControl, BuscarComboBox.SelectedIndex, "0");

            }
            else
            {
                ActivoFiltro.Visible = false;
                DatoBox.Visible = true;
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            //guardar
            if (!modoEdicion)
            {
                if (NombreBox.Text != "" && UbicacionBox.Text != "")

                {
                    bool estado = EstadocCBox.Checked;
                    string nombre = NombreBox.Text;
                    string ubicacion = UbicacionBox.Text;


                    string resultado = backend.Guardar(tablaControl, nombre, ubicacion, estado);
                    if (resultado == "Guardar")
                    {
                        MessageBox.Show("El registro de ha agregado correctamente.", "Agregación realizada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                    }
                       
                }
                else MessageBox.Show("Nombre y/o Ubicación no indicada.", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //modificacion
            else
            {
                bool estado = EstadocCBox.Checked;
                string id = IDBox.Text, nombre = NombreBox.Text, ubicacion = UbicacionBox.Text;


                if (nombre != "" && ubicacion != "")
                {
                    // Llamamos al método Modificar del backend para realizar la modificación en la base de datos
                    string resultado = backend.Modificar(tablaControl, id, nombre, estado, ubicacion);

                    if (resultado == "Guardar")
                    {
                        MessageBox.Show("El registro se ha modificado correctamente.", "Modificación realizada.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        modoEdicion = false;
                        button2.Text = "Guardar";
                        button3.PerformClick();
                        // Limpiamos los campos después de la modificación
                        LimpiarCampos();
                    }
                }
                else MessageBox.Show("Nombre y/o Ubicación no indicada.", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void DatoBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) e.SuppressKeyPress = true;
        }

        private void DatoBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && BuscarComboBox.SelectedIndex == 0) e.Handled = true;
        }
    }
}
