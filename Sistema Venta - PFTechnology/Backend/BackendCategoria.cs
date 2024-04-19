using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;

namespace PFTechnology.Backend
{
    internal class BackendCategoria
    {
        public int UltimoID()
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            string query = $"SELECT Top 1 ID_Categoria FROM Categorias ORDER BY ID_Categoria DESC;";
            conectar.Open();

            int id = 0;

            SqlCommand cmd = new SqlCommand(query, conectar);

            object result = cmd.ExecuteScalar();

            if (result != null) id = Convert.ToInt32(result);
            

            conectar.Close();
            return id;
        }


        public void ActualizarGrid(DataGridView grid)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = connStr;
            conectar.Open();

            string query = "SELECT * FROM Categorias";
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



        public string Guardar(DataGridView grid, string descripcion, bool estado)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            string resultado = "No guardar";
            conectar.Open();

            SqlCommand cmd = new SqlCommand("SP_AGREGAR_CATEGORIA", conectar);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
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

        public void Filtrar(DataGridView grid, int opcion, string dato)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = connStr;
            string query = "SELECT * FROM Categorias ";
            conectar.Open();

            if (opcion == 0) query += "WHERE ID_Categoria = '" + dato + "';";
            else if (opcion == 1) query += "WHERE Descripcion like '%" + dato + "%';";
            else if (opcion == 2) query += "WHERE Estado = " + dato + ";";
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

        public string Modificar(DataGridView grid, string id, string descripcion, bool estado)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            
            conectar.ConnectionString = connStr;
            string query = "UPDATE Categorias SET Descripcion = '" + descripcion + "', Estado = '" + estado + "' WHERE ID_Categoria = " + id + ";";
            conectar.Open();
            string resultado = "No guardar";

            SqlCommand cmd = new SqlCommand(query, conectar);

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
    }
}
