using Sistema_Venta___PFTechnology.Modulos;
using Sistema_Venta___PFTechnology.Modulos.Entrada;
using Sistema_Venta___PFTechnology.Modulos.Procesamiento;
using Sistema_Venta___PFTechnology.Modulos.Salida;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sistema_Venta___PFTechnology
{
    public partial class InicioForm : Form
    {
        int iduser;
        ventaForm sellfrm;
        loginForm lgfrm = new loginForm();
        usuariosForm userfrm = new usuariosForm();
        clientesForm clfrm = new clientesForm();
        empleadosForm empfrm = new empleadosForm();
        reportesForm repfrm = new reportesForm();
        productosForm prfrm = new productosForm();
        CategoriasForm catfrm = new CategoriasForm();
        departamentosForm dpfrm = new departamentosForm();
        sucursalesForm scfrm = new sucursalesForm();
        GenerarCodigo qrfrm = new GenerarCodigo();

        public InicioForm(int idusuario)
        {
            InitializeComponent();
            this.BackColor = Color.White;
            iduser = idusuario;
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                if(item.Tag != "10") item.Enabled = false;
            }

            switch (ObtenerIDROL(iduser))
            {
                case 1:
                    ventaToolStripMenuItem.Enabled = true;
                    clientesToolStripMenuItem.Enabled = true;
                    break;
                case 2:
                    productosToolStripMenuItem.Enabled = true;
                    categoriasToolStripMenuItem.Enabled = true;
                    cToolStripMenuItem.Enabled = true;
                    break;
                case 3:

                    empleadosToolStripMenuItem.Enabled = true;
                    departamentosToolStripMenuItem.Enabled = true;
                    sucursalesToolStripMenuItem.Enabled = true;
                    break;
                case 4:
                    clientesToolStripMenuItem.Enabled = true;
                    break;
                case 5:
                    foreach (ToolStripMenuItem item in menuStrip1.Items)
                    {
                        item.Enabled = true;
                    }
                    break;
                case 6:
                    reportesToolStripMenuItem.Enabled = true;
                    break;
            }   
        }

        public int ObtenerIDROL(int iduser)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            string query = $"select ID_ROL From Usuarios where ID_Usuario = {iduser};";

            SqlCommand cmd = new SqlCommand(query, conectar);

            conectar.Open();
            object result = cmd.ExecuteScalar();
            conectar.Close();

            if (result != null) return Convert.ToInt32(result);
            else return 0;
        }

        private void InicioForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            // Verifica si el objeto 'sender' es un ToolStripMenuItem
            if (sender is ToolStripMenuItem menuItem)
            {
                // Accede al 'Tag' del ToolStripMenuItem
                var tag = menuItem.Tag;
                // Verifica si el 'Tag' no es nulo
                if (tag != null)
                {
                    switch (Convert.ToInt32(tag))
                    {
                        case 1:
                            sellfrm = new ventaForm(iduser);
                            menuSeleccionado(sellfrm); break;
                        case 2:
                            menuSeleccionado(userfrm); break;
                        case 3:
                            menuSeleccionado(clfrm); break;
                        case 4:
                            menuSeleccionado(empfrm); break;
                        case 5:
                            menuSeleccionado(dpfrm); break;
                        case 6:
                            menuSeleccionado(scfrm); break;
                        case 7:
                            menuSeleccionado(prfrm); break;
                        case 8:
                            menuSeleccionado(catfrm); break;
                        case 9:
                            menuSeleccionado(repfrm); break;
                        case 10:
                            lgfrm.Show(); this.Hide(); break;
                        case 11:
                            menuSeleccionado(qrfrm); break;
                    }
                }
            }
        }

        public void menuSeleccionado(Form frm)
        {
            pictureBox1.Visible = false;
            ocultarForms();
            frm.TopLevel = false;
            mainPanel.Controls.Add(frm);
            frm.Show();
        }

        private void ocultarForms()
        {
            sellfrm?.Hide();
            userfrm.Hide();
            repfrm.Hide();
            clfrm.Hide();
            empfrm.Hide();
            prfrm.Hide();
            catfrm.Hide();
            scfrm.Hide();
            dpfrm.Hide();
            qrfrm.Hide();
        }
    }
}
