using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFTechnology.Backend
{
    internal class BackendProductos
    { 
        public int UltimoID()
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            string query = "SELECT Top 1 ID_Producto FROM Productos ORDER BY ID_Producto DESC;";
            conectar.Open();
            int id = 0;

            SqlCommand cmd = new SqlCommand(query, conectar);

            object result = cmd.ExecuteScalar();

            if (result != null) id = Convert.ToInt32(result);
            conectar.Close();
            return id;
        }

        public void ActualizarCategorias(ComboBox cb)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;

            try
            {
                conectar.Open();

                // Consulta SQL
                string query = "SELECT Descripcion FROM Categorias Where Estado = 1";
                SqlCommand command = new SqlCommand(query, conectar);

                // Llenar el ComboBox con los resultados
                SqlDataReader reader = command.ExecuteReader();
                cb.Items.Clear();
                while (reader.Read())
                {
                    cb.Items.Add(reader["Descripcion"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
            finally
            {
                conectar.Close();
            }
        }

        public void ActualizarGrid(DataGridView grid)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = connStr;
            conectar.Open();

            string query = "SELECT * FROM Productos";
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
        public string Guardar(DataGridView grid, string descripcion, decimal precio, string categoria, int stock, int stockminimo, bool estado)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            string resultado = "No guardar";
            conectar.Open();

            SqlCommand cmd = new SqlCommand("SP_AGREGAR_PRODUCTO", conectar);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@precio", precio);
            cmd.Parameters.AddWithValue("@categoria", categoria);
            cmd.Parameters.AddWithValue("@stock", stock);
            cmd.Parameters.AddWithValue("@stock_minimo", stockminimo);
            cmd.Parameters.AddWithValue("@estado", estado);

            try
            {
                cmd.ExecuteNonQuery();
                resultado = "Guardar";
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            conectar.Close();

            ActualizarGrid(grid);
            return resultado;
        }
        public string Modificar(DataGridView grid, string id, string descripcion, bool estado, decimal precio,int stock, int stockminimo, string categoria)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            string resultado = "No guardar";
            SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_PRODUCTO", conectar);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_id", id);
            cmd.Parameters.AddWithValue("@p_descripcion", descripcion);
            cmd.Parameters.AddWithValue("@p_precio", precio);
            cmd.Parameters.AddWithValue("@p_stock", stock);
            cmd.Parameters.AddWithValue("@p_stockminimo", stockminimo);
            cmd.Parameters.AddWithValue("@p_estado", estado);
            cmd.Parameters.AddWithValue("@p_categoria", categoria);
            conectar.Open();

            try
            {
                cmd.ExecuteNonQuery();
                resultado = "Guardar";
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            conectar.Close();

            ActualizarGrid(grid);
            return resultado;
        }

        public void Filtrar(DataGridView grid, int opcion, string dato)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = connStr;
            string query = "SELECT * FROM Productos ";
            conectar.Open();


            if (opcion == 0) query += $"WHERE ID_Producto = '{dato}';";
            else if (opcion == 1) query += $"WHERE Descripcion like '%{dato}%';";
            else if (opcion == 2) query += $"WHERE Precio = {dato};";
            else if (opcion == 3) query += $"WHERE Stock = {dato};";
            else if (opcion == 4) query += $"WHERE Stock_Minimo = {dato};";
            else if (opcion == 5) query += $"WHERE ID_Categoria = {dato};";
            else if (opcion == 6) query += $"WHERE Estado = {dato};";
            else MessageBox.Show("Opcion invalida");

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

        public string ObtenerDescripcionCategoriaDesdeBD(string categoriaID)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;

            string query = $"SELECT Descripcion FROM Categorias WHERE ID_Categoria = '{categoriaID}'";
            SqlCommand cmd = new SqlCommand(query, conectar);
            conectar.Open();
            string descripcion = cmd.ExecuteScalar()?.ToString();
            conectar.Close();

            return descripcion ?? "Desconocida";
        }
    }
}
