using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFTechnology.Backend
{
    internal class BackendSucursales
    {
        public int ultimoID()
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            string query = $"SELECT Top 1 ID_Sucursal FROM Sucursales ORDER BY ID_Sucursal DESC;";
            conectar.Open();
            int id = 0;

            SqlCommand cmd = new SqlCommand(query, conectar);

            object result = cmd.ExecuteScalar();

            if (result != null) id = Convert.ToInt32(result);
            conectar.Close();
            return id;
        }

        //actualizar datos en la base de datos

        public void ActualizarGrid(DataGridView grid)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = connStr;
            conectar.Open();

            string query = "SELECT * FROM Sucursales";
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


        //Insertar datos en la tabla
        public string Guardar(DataGridView grid, string nombre, string ubicacion, bool estado)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            conectar.Open();
            string resultado = "No guardar";

            SqlCommand cmd = new SqlCommand("SP_AGREGAR_SUCURSAL", conectar);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@ubicacion", ubicacion);
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
            string query = "SELECT * FROM Sucursales";
            conectar.Open();

            if (opcion == 0) query = "SELECT * FROM Sucursales WHERE ID_Sucursal = '" + dato + "';";
            else if (opcion == 1) query = "SELECT * FROM Sucursales WHERE Nombre like '%" + dato + "%';";
            else if (opcion == 2) query = "SELECT * FROM Sucursales WHERE Ubicacion like '%" + dato + "%';";
            else if (opcion == 3) query = "SELECT * FROM Sucursales WHERE Estado = " + dato + ";";
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


        //modificar
        public string Modificar(DataGridView grid, string id, string nombre, bool estado, string ubicacion)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            string query = "UPDATE Sucursales SET Nombre = '" + nombre + "', Estado = '" + estado + "', Ubicacion = '" + ubicacion + "' WHERE ID_Sucursal = " + id + ";";
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
