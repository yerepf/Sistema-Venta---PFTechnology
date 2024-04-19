using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;

namespace PFTechnology.Backend
{
    internal class BackendClientes
    {

        public int ultimoID()
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            string query = $"SELECT Top 1 ID_Cliente FROM Clientes ORDER BY ID_Cliente DESC;";
            conectar.Open();
            int id = 0;

            SqlCommand cmd = new SqlCommand(query, conectar);

            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                id = Convert.ToInt32(result);
            }

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

            string query = "SELECT * FROM Clientes";
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

        public string Guardar(DataGridView grid, string nombre, string apellido, bool socio, string email, string cedula, bool estado)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            conectar.Open();
            int sinoE = 0;
            int sinoS = 0;
            string resultado = "No guardar";

            if (estado) sinoE = 1;
            if (socio) sinoS = 1;

            SqlCommand cmd = new SqlCommand("SP_AGREGAR_CLIENTE", conectar);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@socio", sinoS);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@cedula", cedula);
            cmd.Parameters.AddWithValue("@estado", sinoE);

            try
            {
                cmd.ExecuteNonQuery();
                resultado = "Guardar";
            }
            catch (SqlException)
            {
                MessageBox.Show("Error.", "No se pudo guardar esta fila.");
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
            string query = "SELECT * FROM Clientes";
            conectar.Open();

            if (opcion == 0) query = "SELECT * FROM Clientes WHERE ID_Cliente = " + dato + ";";
            else if (opcion == 1) query = "SELECT * FROM Clientes WHERE Nombre like '%" + dato + "%';";
            else if (opcion == 2) query = "SELECT * FROM Clientes WHERE Apellido like '%" + dato + "%';";
            else if (opcion == 3) query = "SELECT * FROM Clientes WHERE Email = '" + dato + "';";
            else if (opcion == 4) query = "SELECT * FROM Clientes WHERE Cedula = '" + dato + "';";
            else if (opcion == 5) query = "SELECT * FROM Clientes WHERE Socio = " + dato + ";";
            else if (opcion == 6) query = "SELECT * FROM Clientes WHERE Estado = " + dato + ";";
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

        public string Modificar(DataGridView grid, string id, string nombre, bool estado, bool socio, string apellido, string email, string cedula)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            string resultado = "No guardar";

            string sinoS = "0";
            if (socio) sinoS = "1";

            conectar.Open();

            SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_CLIENTE", conectar);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@c_id", id);
            cmd.Parameters.AddWithValue("@c_nombre", nombre);
            cmd.Parameters.AddWithValue("@c_apellido", apellido);
            cmd.Parameters.AddWithValue("@c_socio", sinoS);
            cmd.Parameters.AddWithValue("@c_email", email);
            cmd.Parameters.AddWithValue("@c_cedula", cedula);
            cmd.Parameters.AddWithValue("@c_estado", estado);

            try
            {
                cmd.ExecuteNonQuery();
                resultado = "Guardar";
            }
            catch (SqlException)
            {
                MessageBox.Show("Ha ocurrido un error en la modificación.", "Error.");
            }

            conectar.Close();
            ActualizarGrid(grid);
            return resultado;
        }
    }
}
