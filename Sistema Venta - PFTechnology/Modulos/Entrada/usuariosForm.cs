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
    public partial class usuariosForm : Form
    {

        BackendUsuarios Backend = new BackendUsuarios();
        bool modoEdicion, cedula, soloNumeros = true;

        public usuariosForm()
        {
            InitializeComponent();

            ActiveControl = label1; //unfocus textbox controls

            Backend.ActualizarGrid(tablaControl);
            BuscarComboBox.SelectedIndex = 0;
            ActivoFiltro.Visible = false;

            IDBox.Text = (Backend.UltimoID() + 1).ToString();

            tablaControl.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DatoBox.Text = string.Empty;
            Backend.ActualizarGrid(tablaControl);
            BuscarComboBox.SelectedIndex = 0;
        }

        private void BuscarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatoBox.Text = string.Empty;
            cedulaFiltroBox.Text = string.Empty;
            ActivoFiltro.Checked = false;

            Backend.ActualizarGrid(tablaControl);

            if (BuscarComboBox.SelectedIndex == 3)
            {
                ActivoFiltro.Visible = true;
                DatoBox.Visible = false;
                Backend.Filtrar(tablaControl, BuscarComboBox.SelectedIndex, "0");
                cedulaFiltroBox.Visible = false;
                ActivoFiltro.Focus();
            }
            else if(BuscarComboBox.SelectedIndex == 6)
            {
                ActivoFiltro.Visible = false;
                cedulaFiltroBox.Visible = true;
                DatoBox.Visible = false;
                Backend.ActualizarGrid(tablaControl);
                cedulaFiltroBox.Focus();
            }
            else
            {
                ActivoFiltro.Visible = false;
                DatoBox.Visible = true;
                cedulaFiltroBox.Visible = false;
                Backend.ActualizarGrid(tablaControl);
                DatoBox.Focus();
            }

            if (BuscarComboBox.SelectedIndex == 0 || BuscarComboBox.SelectedIndex == 4 || BuscarComboBox.SelectedIndex == 5) soloNumeros = true;
            else soloNumeros= false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (modoEdicion) modoEdicion = false;
            button2.Text = "Guardar";
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            IDBox.Text = (Backend.UltimoID() + 1).ToString();

            NombreBox.Text = "";
            ContraseñaBox.Text = "";
            IDEmpleadoBox.Text = "";
            CedulaEmpleadoBox.Text = "";

            if(cedula)
            {
                label6.Text = "ID Empleado";
                cedula = false;
                IDEmpleadoBox.Visible = true;
                CedulaEmpleadoBox.Visible = false;
            }

            EstadocCBox.Checked = true;
            VentaCBox.Checked = false;
            AnalistaCBox.Checked = false;
            InventarioCBox.Checked = false;
            AdministradorCBox.Checked = false;
            SACBox.Checked = false;
            RHBox.Checked = false;
        }


        //evento click boton guardar o modificiar
        private void button2_Click(object sender, EventArgs e)
        {
            bool estado = EstadocCBox.Checked;
            string id = IDBox.Text, nombre = NombreBox.Text, contraseña = ContraseñaBox.Text, idEmpleado = "";

                //obtener id del empleado del textbox
                if (!cedula) idEmpleado = IDEmpleadoBox.Text;
                //buscar id empleado con la cedula
                else idEmpleado = Backend.BuscarIDEmpleadoPorCedula(CedulaEmpleadoBox.Text);

            //guardar
            if (!modoEdicion)
            {
                if (NombreBox.Text != "" && ContraseñaBox.Text != "")
                {
                    if (idEmpleado != "")
                    {
                        int opcionRol = -1;

                        foreach (RadioButton rb in groupBox3.Controls)
                        {
                            if (rb.Checked)
                            {
                                opcionRol = Convert.ToInt32(rb.Tag);
                                break;
                            }
                        }
                        if (opcionRol != -1)
                        {
                            string resultado = Backend.Guardar(tablaControl, nombre, contraseña, idEmpleado, estado, opcionRol);
                            if (resultado == "Guardar") LimpiarCampos();
                        }
                        else MessageBox.Show("No has selecionado un permiso para este usuario.", "Selecciona un permiso.");
                    }
                    else MessageBox.Show("Verifique nuevamente la cedula del empleado.", "Empleado no encontrado.");
                }
                else MessageBox.Show("Nombre, contraseña y ID o cedula empleado no pueden estar vacíos.", "Campos vacios");
            }
            //modificacion
            else
            {
                

                if (nombre != "" && contraseña != "")
                {
                    if (idEmpleado != "")
                    {
                        int opcionRol = -1;

                        foreach (RadioButton rb in groupBox3.Controls)
                        {
                            if (rb.Checked)
                            {
                                opcionRol = Convert.ToInt32(rb.Tag);
                                break;
                            }
                        }

                        // Llamamos al método Modificar del backend para realizar la modificación en la base de datos
                        string resultado = Backend.Modificar(tablaControl, id, nombre, estado, opcionRol, idEmpleado, contraseña);

                        if (resultado == "Guardar")
                        {
                            MessageBox.Show("Modificación realizada.");
                            modoEdicion = false;
                            button2.Text = "Guardar";
                            button3.PerformClick();
                            // Limpiamos los campos después de la modificación
                            LimpiarCampos();
                        }
                    }else MessageBox.Show("Verifique nuevamente la cedula o el id del empleado.", "Empleado no encontrado.");
                } else MessageBox.Show("Nombre, contraseña no pueden ir vacios", "Campos vacios");

            }
        }

        private void tablaControl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                modoEdicion = true;
                button2.Text = "Modificar";

                DataGridViewRow filaSeleccionada = tablaControl.Rows[e.RowIndex];

                IDBox.Text = filaSeleccionada.Cells[0].Value.ToString();
                NombreBox.Text = filaSeleccionada.Cells[1].Value.ToString();
                ContraseñaBox.Text = filaSeleccionada.Cells[2].Value.ToString();
                EstadocCBox.Checked = Convert.ToBoolean(filaSeleccionada.Cells[3].Value);

                //comprobar si cuando se selecciona la fila en Procesar Usuario esta con cedula y no con ID
                if(!cedula) IDEmpleadoBox.Text = filaSeleccionada.Cells[4].Value.ToString();
                else CedulaEmpleadoBox.Text = Backend.BuscarCedulaEmpleadoPorID(filaSeleccionada.Cells[4].Value.ToString());

                switch (filaSeleccionada.Cells[6].Value.ToString())
                {
                    case "1":
                        VentaCBox.Checked = true;
                        break;
                    case "2":
                        InventarioCBox.Checked = true;
                        break;
                    case "3":
                        RHBox.Checked = true;
                        break;
                    case "4":
                        SACBox.Checked = true;
                        break;
                    case "5":
                        AdministradorCBox.Checked = true;
                        break;
                    case "6":
                        AnalistaCBox.Checked = true;
                        break;
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!cedula)
            {

                var IDEmpleado = IDEmpleadoBox.Text;

                if (IDEmpleado != "")
                {
                    IDEmpleado = Backend.BuscarCedulaEmpleadoPorID(IDEmpleado);
                    if (IDEmpleado != string.Empty) CedulaEmpleadoBox.Text = IDEmpleado;
                    else CedulaEmpleadoBox.Text = string.Empty;
                }
                else IDEmpleadoBox.Text = string.Empty;

                label6.Text = "Cedula Empleado";
                cedula = true;
                IDEmpleadoBox.Visible = false;
                CedulaEmpleadoBox.Visible = true;
            }
            else
            {
                var CedulaEmpleado = CedulaEmpleadoBox.Text;
                if (CedulaEmpleado != "")
                {
                    CedulaEmpleado = Backend.BuscarIDEmpleadoPorCedula(CedulaEmpleado);
                    if (CedulaEmpleado != string.Empty) IDEmpleadoBox.Text = CedulaEmpleado;
                    else IDEmpleadoBox.Text = string.Empty;
                }
                else IDEmpleadoBox.Text = string.Empty;

                label6.Text = "ID Empleado";
                cedula = false;
                IDEmpleadoBox.Visible = true;
                CedulaEmpleadoBox.Visible = false;
            }
        }

        //Eventos Key generales

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) e.SuppressKeyPress = true; 
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

        private void cedulaFiltroBox_TextChanged(object sender, EventArgs e)
        {
            // saber si el maskedbox no contiene algo
            if (Regex.IsMatch(cedulaFiltroBox.Text, @"^[-\s]*$")) Backend.ActualizarGrid(tablaControl);
            else Backend.Filtrar(tablaControl, BuscarComboBox.SelectedIndex, cedulaFiltroBox.Text);
        }

    }
}
