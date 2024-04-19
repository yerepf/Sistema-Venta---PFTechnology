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
    internal class BackendEmpleados
    {

        public int UltimoID()
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            string query = "SELECT Top 1 ID_Empleado FROM Empleados ORDER BY ID_Empleado DESC;";
            conectar.Open();
            int id = 0;

            SqlCommand cmd = new SqlCommand(query, conectar);

            object result = cmd.ExecuteScalar();

            if (result != null) id = Convert.ToInt32(result);
            conectar.Close();
            return id;
        }

        public void ActualizarSucursales(ComboBox cb)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;

            try
            {
                conectar.Open();

                // Consulta SQL
                string query = "SELECT Nombre FROM Sucursales Where Estado = 1";
                SqlCommand command = new SqlCommand(query, conectar);

                // Llenar el ComboBox con los resultados
                SqlDataReader reader = command.ExecuteReader();
                cb.Items.Clear();
                while (reader.Read())
                {
                    cb.Items.Add(reader["Nombre"].ToString());
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

        public void ActualizarDepartamentos(ComboBox cb)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;

            try
            {
                conectar.Open();

                // Consulta SQL
                string query = "SELECT Descripcion FROM Departamentos Where Estado = 1";
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

            string query = "SELECT * FROM Empleados";
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

        public void Guardar(DataGridView grid, string nombre, string apellidos, string email, string cedula, string ncelular, string departamento, string sucursal, bool estado)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            conectar.Open();
            int sino = 0;

            if (estado) sino = 1;

            SqlCommand cmd = new SqlCommand("SP_AGREGAR_EMPLEADO", conectar);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellidos);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@cedula", cedula);
            cmd.Parameters.AddWithValue("@telefono_celular", ncelular);
            cmd.Parameters.AddWithValue("@departamento", departamento);
            cmd.Parameters.AddWithValue("@sucursal", sucursal);
            cmd.Parameters.AddWithValue("@estado", sino);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            conectar.Close();

            ActualizarGrid(grid);
        }

        public void Filtrar(DataGridView grid, int opcion, string dato)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = connStr;
            string query = "SELECT * FROM Empleados ";
            conectar.Open();


            if (opcion == 0) query += $"WHERE ID_Empleado = {dato};";
            else if (opcion == 1) query += $"WHERE Nombre like '%{dato}%';";
            else if (opcion == 2) query += $"WHERE Apellido like '%{dato}%';";
            else if (opcion == 3) query += $"WHERE Email like '%{dato}%';";
            else if (opcion == 4) query += $"WHERE Cedula = '{dato}';";
            else if (opcion == 5) query += $"WHERE Telefono_Celular = '{dato}';";
            else if (opcion == 6) query += $"WHERE ID_Departamento = {dato};";
            else if (opcion == 7) query += $"WHERE ID_Sucursal = {dato};";
            else if (opcion == 8) query = "SELECT * FROM Empleados WHERE Estado = " + dato + ";";
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

        public void Modificar(DataGridView grid, string id, string nombre, string apellido, string email, string cedula, string ncelular, string estado, string departamento, string sucursal)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = connStr;

            SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_EMPLEADO", conectar);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@e_id", id);
            cmd.Parameters.AddWithValue("@e_nombre", nombre);
            cmd.Parameters.AddWithValue("@e_apellido", apellido);
            cmd.Parameters.AddWithValue("@e_email", email);
            cmd.Parameters.AddWithValue("@e_cedula", cedula);
            cmd.Parameters.AddWithValue("@e_estado", estado);
            cmd.Parameters.AddWithValue("@e_telefonocelular", ncelular);
            cmd.Parameters.AddWithValue("@e_departamento", departamento);
            cmd.Parameters.AddWithValue("@e_sucursal", sucursal);
            conectar.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            conectar.Close();

            ActualizarGrid(grid);
        }

        public string ObtenerDescripcionDepartamentoDesdeBD(string departamentoID)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;

            string query = $"SELECT Descripcion FROM Departamentos WHERE ID_Departamento = '{departamentoID}'";
            SqlCommand cmd = new SqlCommand(query, conectar);
            conectar.Open();
            string descripcion = cmd.ExecuteScalar()?.ToString();
            conectar.Close();

            return descripcion ?? "Desconocida";
        }

        public string ObtenerNombreSucursalDesdeBD(string sucursalID)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;

            string query = $"SELECT Nombre FROM Sucursales WHERE ID_Sucursal = '{sucursalID}'";
            SqlCommand cmd = new SqlCommand(query, conectar);
            conectar.Open();
            string descripcion = cmd.ExecuteScalar()?.ToString();
            conectar.Close();

            return descripcion ?? "Desconocida";
        }
    }


}
