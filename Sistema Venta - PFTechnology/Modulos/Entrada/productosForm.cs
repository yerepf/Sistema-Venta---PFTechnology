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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sistema_Venta___PFTechnology.Modulos.Entrada
{
    public partial class productosForm : Form
    {
        BackendProductos Backend = new BackendProductos();
        bool modoEdicion = false;

        public productosForm()
        {
            InitializeComponent();
            Backend.ActualizarGrid(tablaControl);
            BuscarComboBox.SelectedIndex = 0;
            ActivoFiltro.Visible = false;

            Backend.ActualizarCategorias(categoriaCBox);
            IDBox.Text = (Backend.UltimoID() + 1).ToString();
            tablaControl.DefaultCellStyle.ForeColor = Color.Black;
        }

        public void LimpiarCampos()
        {
            IDBox.Text = (Backend.UltimoID() + 1).ToString();
            DescripcionBox.Text = string.Empty;
            PrecioBox.Text = string.Empty;
            StockBox.Value = 1;
            StockMinBox.Value = 0;

            categoriaCBox.ResetText();

            EstadocCBox.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (modoEdicion) modoEdicion = false;
            button2.Text = "Guardar";
            LimpiarCampos();
        }

        private void categoriaCBox_Enter(object sender, EventArgs e)
        {
            Backend.ActualizarCategorias(categoriaCBox);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DatoBox.Text = string.Empty;
            Backend.ActualizarGrid(tablaControl);
            BuscarComboBox.SelectedIndex = 0;
        }

        private void DatoBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DatoBox.Text))
                Backend.Filtrar(tablaControl, BuscarComboBox.SelectedIndex, DatoBox.Text);
            else
                Backend.ActualizarGrid(tablaControl);
        }

        private void ActivoFiltro_CheckedChanged(object sender, EventArgs e)
        {
            if (ActivoFiltro.Checked) Backend.Filtrar(tablaControl, BuscarComboBox.SelectedIndex, "1");
            else Backend.Filtrar(tablaControl, BuscarComboBox.SelectedIndex, "0");
        }

        private void BuscarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatoBox.Text = string.Empty;
            Backend.ActualizarGrid(tablaControl);

            if (BuscarComboBox.SelectedIndex == 6)
            {
                ActivoFiltro.Visible = true;
                DatoBox.Visible = false;
                Backend.Filtrar(tablaControl, BuscarComboBox.SelectedIndex, "0");
            }
            else
            {
                ActivoFiltro.Visible = false;
                DatoBox.Visible = true;
            }
        }

        private void DatoBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) e.SuppressKeyPress = true;
        }

        private void DatoBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(BuscarComboBox.SelectedIndex != 2)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (BuscarComboBox.SelectedIndex == 0 || BuscarComboBox.SelectedIndex == 2 || BuscarComboBox.SelectedIndex == 3 || BuscarComboBox.SelectedIndex == 4 || BuscarComboBox.SelectedIndex == 5)) e.Handled = true;
            }
            else
            {
                if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) e.Handled = false;
                else if (e.KeyChar == '.' && DatoBox.Text.IndexOf('.') == -1 && DatoBox.Text.Any(char.IsDigit)) e.Handled = false;
                else e.Handled = true;
            }

        }

        private void textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
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

                IDBox.Text = valorPrimeraColumna;
                if (valorCuartaColumna != "") categoriaCBox.Text = Backend.ObtenerDescripcionCategoriaDesdeBD(valorSegundaColumna);
                DescripcionBox.Text = valorTerceraColumna;
                PrecioBox.Text = valorCuartaColumna;
                StockBox.Text = valorQuintaColumna;
                StockMinBox.Text = valorSextaColumna;
                EstadocCBox.Checked = valorSeptimaColumna;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            bool estado = EstadocCBox.Checked;
            string descripcion = DescripcionBox.Text, categoria = categoriaCBox.Text, id = IDBox.Text;
            decimal precio = 00;
            if(PrecioBox.Text != string.Empty) precio = Convert.ToDecimal(PrecioBox.Text);
            int stock = Convert.ToInt32(StockBox.Text), stockMin = Convert.ToInt32(StockMinBox.Text);

            //guardar
            if (!modoEdicion)
            {
                if ((descripcion != "" || categoria != "") && precio > 0)
                {
                    string resultado = Backend.Guardar(tablaControl, descripcion, precio, categoria, stock, stockMin, estado);
                    if (resultado == "Guardar")
                    {
                        LimpiarCampos();
                        MessageBox.Show("El registro se ha agregado correctamente", "Agregación realizada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else MessageBox.Show("Campos vacios o precio igual o inferior a 0.", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //modificacion
            else
            {

                if ((descripcion != "" || categoria != "") && precio > 0)
                {
                    // Llamamos al método Modificar del backend para realizar la modificación en la base de datos
                    string resultado = Backend.Modificar(tablaControl, id, descripcion, estado, precio, stock, stockMin, categoria);

                    if (resultado == "Guardar")
                    {
                        MessageBox.Show("El registro se ha modificado correctamente", "Modificación realizada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        modoEdicion = false;
                        button2.Text = "Guardar";
                        button3.PerformClick();
                        // Limpiamos los campos después de la modificación
                        LimpiarCampos();
                    }
                }
                else MessageBox.Show("Campos vacios o precio igual o inferior a 0.", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void productosForm_Enter(object sender, EventArgs e)
        {
            button1.PerformClick();
            button3.PerformClick();
        }

        private void PrecioBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) e.Handled = false;
            else if (e.KeyChar == '.' && PrecioBox.Text.IndexOf('.') == -1 && PrecioBox.Text.Any(char.IsDigit)) e.Handled = false;
            else e.Handled = true;
        }
    }
}
