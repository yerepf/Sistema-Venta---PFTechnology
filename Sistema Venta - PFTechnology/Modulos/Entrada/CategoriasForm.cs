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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Sistema_Venta___PFTechnology.Modulos.Entrada
{
    public partial class CategoriasForm : Form
    {
        BackendCategoria Backend = new BackendCategoria();
        bool modoEdicion = false;

        public CategoriasForm()
        {
            InitializeComponent();
            Backend.ActualizarGrid(tablaControl);
            BuscarComboBox.SelectedIndex = 0;
            ActivoFiltro.Visible = false;


            IDBox.Text = (Backend.UltimoID() + 1).ToString();
            tablaControl.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void BuscarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatoBox.Text = string.Empty;
            Backend.ActualizarGrid(tablaControl);

            if (BuscarComboBox.SelectedIndex == 2)
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

        private void button2_Click(object sender, EventArgs e)
        {
            //guardar
            if (!modoEdicion)
            {
                if (DescripcionBox.Text != "")
                {
                    bool estado = EstadocCBox.Checked;
                    string descripcion = DescripcionBox.Text;


                    string resultado = Backend.Guardar(tablaControl, descripcion, estado);

                    if (resultado == "Guardar")
                    {
                        MessageBox.Show("El registro se ha agregado correctamente", "Agregación realizada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();

                    }
                }
                else MessageBox.Show("Descripción no indicada.", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //modificacion
            else
            {
                bool estado = EstadocCBox.Checked;
                string id = IDBox.Text, descripcion = DescripcionBox.Text;


                if (descripcion != "")
                {
                        // Llamamos al método Modificar del backend para realizar la modificación en la base de datos
                        string resultado = Backend.Modificar(tablaControl, id, descripcion, estado);

                        if (resultado == "Guardar")
                        {
                            MessageBox.Show("El registro se ha actualizado correctamente","Modificación realizada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            modoEdicion = false;
                            button2.Text = "Guardar";
                            button3.PerformClick();
                            // Limpiamos los campos después de la modificación
                            LimpiarCampos();
                        }
                }
                else MessageBox.Show("La descripción no puede estar vacíos.", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            
        }

        public void LimpiarCampos()
        {
            IDBox.Text = (Backend.UltimoID() + 1).ToString();
            DescripcionBox.Text = "";
            EstadocCBox.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (modoEdicion) modoEdicion = false;
            button2.Text = "Guardar";
            LimpiarCampos();
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

        private void DatoBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) e.SuppressKeyPress = true;
        }

        private void DatoBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && BuscarComboBox.SelectedIndex == 0) e.Handled = true;
        }

        private void tablaControl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                modoEdicion = true;
                button2.Text = "Modificar";

                DataGridViewRow filaSeleccionada = tablaControl.Rows[e.RowIndex];

                IDBox.Text = filaSeleccionada.Cells[0].Value.ToString();
                DescripcionBox.Text = filaSeleccionada.Cells[1].Value.ToString();
                EstadocCBox.Checked = Convert.ToBoolean(filaSeleccionada.Cells[2].Value);

            }
        }
    }
}
