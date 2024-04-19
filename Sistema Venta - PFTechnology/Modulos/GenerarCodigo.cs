using PFTechnology.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Venta___PFTechnology.Modulos
{
    public partial class GenerarCodigo : Form
    {
        private int cantidadImagenes;
        private Image imagen;
        string textcodigo;
        public void ActualizarGrid(DataGridView grid)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = connStr;
            conectar.Open();

            string query = "SELECT ID_Producto, Descripcion, Precio, Stock, Stock_Minimo, ID_Categoria FROM Productos";
            SqlCommand cmd = new SqlCommand(query, conectar);

            try
            {
                cmd.ExecuteNonQuery();
                adapter.SelectCommand = cmd;
                adapter.Fill(contenedor);
                grid.DataSource = contenedor;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Message + ".");
                throw;
            }
            conectar.Close();
        }
        public void Filtrar(DataGridView grid, int opcion, string dato)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = connStr;
            string query = "SELECT ID_Producto, Descripcion, Precio, Stock, Stock_Minimo, ID_Categoria FROM Productos ";
            string estadoOn = " and Estado = 1;";
            conectar.Open();


            if (opcion == 0) query += $"WHERE ID_Producto = '{dato}'";
            else if (opcion == 1) query += $"WHERE Descripcion like '%{dato}%'";
            else if (opcion == 2) query += $"WHERE Precio = {dato}";
            else if (opcion == 3) query += $"WHERE Stock = {dato}";
            else if (opcion == 4) query += $"WHERE Stock_Minimo = {dato}";
            else if (opcion == 5) query += $"WHERE ID_Categoria = {dato}";
            else MessageBox.Show("Opcion invalida");

            query += estadoOn;
            SqlCommand cmd = new SqlCommand(query, conectar);

            try
            {
                cmd.ExecuteNonQuery();
                adapter.SelectCommand = cmd;
                adapter.Fill(contenedor);
                grid.DataSource = contenedor;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Message);
                throw;
            }
            conectar.Close();
        }


        public GenerarCodigo()
        {
            InitializeComponent();

            ActualizarGrid(tablaControl);
            BuscarComboBox.SelectedIndex = 0;
            tablaControl.DefaultCellStyle.ForeColor = Color.Black;
        }

        private void tablaControl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegúrate de que se haya hecho clic en una fila válida
            {
                DataGridViewRow filaSeleccionada = tablaControl.Rows[e.RowIndex];
                IDBox.Text = filaSeleccionada.Cells[0].Value.ToString();
                NombreBox.Text = filaSeleccionada.Cells[1].Value.ToString();

                Generarcodigo();
            }
        }

        private void Generarcodigo()
        {
            Zen.Barcode.Code128BarcodeDraw mGeneradorCB = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            textcodigo = IDBox.Text + ", " + NombreBox.Text;
            codigoBarrasPB.Image = mGeneradorCB.Draw(textcodigo, 60);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            IDBox.Text = string.Empty; 
            NombreBox.Text = string.Empty;
            codigoBarrasPB.Image = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            imagen = codigoBarrasPB.Image;

            // Obtener la cantidad de veces que se repetirá la imagen
            cantidadImagenes = int.Parse(CantidadBox.Text);


            if(DatoBox.Text != null && imagen != null)
            {
                // Configurar e imprimir el documento
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                pd.Print();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún codigo de barras", "Selecciona un producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float x = 10.0F, y = 10.0F, espacioEntreImagenes = 30.0F,espacioTopImg = 10.0f;
            string textoDebajoImg = textcodigo;

            // Dibujar la imagen la cantidad de veces especificada
            for (int i = 0; i < cantidadImagenes; i++)
            {
                // Si la próxima imagen se dibujará fuera del margen derecho de la página, pasar a la siguiente línea
                if (x + imagen.Width > ev.MarginBounds.Right)
                {
                    x = 10.0F; // Restablecer la posición x al margen izquierdo
                    y += imagen.Height + espacioEntreImagenes + espacioTopImg; // Pasar a la siguiente línea
                }

                // Si la próxima imagen se dibujará fuera del margen inferior de la página, iniciar una nueva página
                if (y + imagen.Height > ev.MarginBounds.Bottom)
                {
                    ev.HasMorePages = true; // Indicar que hay más páginas
                    return; // Salir del método para iniciar una nueva página
                }

                ev.Graphics.DrawImage(imagen, new PointF(x, y));
                ev.Graphics.DrawString(textoDebajoImg, new Font("Arial", 10), Brushes.Black, new PointF(x, y + 62.0f));

                // Ajustar la posición x para la siguiente imagen
                x += imagen.Width + espacioEntreImagenes;
            }

            ev.HasMorePages = false; // Indicar que no hay más páginas
        }

        private void GenerarCodigo_VisibleChanged(object sender, EventArgs e)
        {
            ActualizarGrid(tablaControl);
        }


        private void DatoBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) e.SuppressKeyPress = true;
        }

        private void DatoBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (BuscarComboBox.SelectedIndex == 0 || BuscarComboBox.SelectedIndex == 2 || BuscarComboBox.SelectedIndex == 3 || BuscarComboBox.SelectedIndex == 4 || BuscarComboBox.SelectedIndex == 5)) e.Handled = true;
        }

        private void BuscarComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatoBox.Text = "";
        }

        private void DatoBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DatoBox.Text))
                Filtrar(tablaControl, BuscarComboBox.SelectedIndex, DatoBox.Text);
            else
                ActualizarGrid(tablaControl);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BuscarComboBox.SelectedIndex = 0;
            DatoBox.Text = string.Empty;
            ActualizarGrid(tablaControl);
        }
    }
}
