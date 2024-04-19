using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PFTechnology.Backend
{
    internal class BackendUsuarios
    {

        const string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
        SqlConnection conectar = new SqlConnection();
     


        public int UltimoID()
        {
            conectar.ConnectionString = connStr;
            string query = $"SELECT Top 1 ID_Usuario FROM Usuarios ORDER BY ID_Usuario DESC;";
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

        public string BuscarIDEmpleadoPorCedula(string idcedula)
        {
            conectar.ConnectionString = connStr;
            conectar.Open();

            // Usar parámetros en la consulta para prevenir inyección SQL y manejar correctamente los valores de cadena
            string query = "SELECT ID_Empleado FROM Empleados WHERE Cedula = @idcedula;";
            SqlCommand cmd = new SqlCommand(query, conectar);
            cmd.Parameters.AddWithValue("@idcedula", idcedula);
            string resultado;

            try
            {
                // Si el valor no se encuentra, ExecuteScalar devolverá null, por lo que se debe verificar antes de convertirlo a string
                object resultObj = cmd.ExecuteScalar();
                resultado = resultObj != null ? Convert.ToString(resultObj) : null;
            }
            catch (SqlException)
            {
                MessageBox.Show("Error");
                throw;
            }
            finally
            {
                conectar.Close(); // Se recomienda cerrar la conexión en un bloque finally para asegurarse de que se cierre correctamente incluso si se produce una excepción
            }

            return resultado;
        }

        public string BuscarCedulaEmpleadoPorID(string idcedula)
        {
            conectar.ConnectionString = connStr;
            conectar.Open();

            string query = $"Select Cedula from Empleados where ID_Empleado = {idcedula};";
            SqlCommand cmd = new SqlCommand(query, conectar);
            string resultado;

            try
            {
                resultado = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex);
                throw;
            }

            conectar.Close();
            return resultado;
        }

        public void ActualizarGrid(DataGridView grid)
        {
            conectar.ConnectionString = connStr;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.Open();

            string query = "SELECT U.ID_Usuario, U.Nombre AS Nombre_Usuario, U.Contraseña, U.Estado, U.ID_Empleado, E.Cedula, U.ID_Rol, R.Nombre AS Nombre_Rol FROM Usuarios U JOIN Empleados E ON U.ID_Empleado = E.ID_Empleado JOIN Roles R ON U.ID_Rol = R.ID_Rol;";
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

        public string Guardar(DataGridView grid, string nombre, string contraseña,string idempleado, bool estado, int idRol)
        {
            conectar.ConnectionString = connStr;
            conectar.Open();
            int sinoE = 0;
            if (estado) sinoE = 1;
            SqlCommand cmd = new SqlCommand("SP_AGREGAR_USUARIO", conectar);
            string resultado = "No guardar";

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@contraseña", contraseña);
            cmd.Parameters.AddWithValue("@id_empleado", idempleado);
            cmd.Parameters.AddWithValue("@id_rol", idRol);
            cmd.Parameters.AddWithValue("@estado", sinoE);

            try
            {
                cmd.ExecuteNonQuery();
                resultado = "Guardar";
            }
            catch (SqlException)
            {
                MessageBox.Show("El ID del empleado que ingreso no esta registrado.", "Empleado no encontrado.");
            }

            conectar.Close();
            ActualizarGrid(grid);
            return resultado;
        }

    

        public void Filtrar(DataGridView grid, int opcion, string dato)
        {
            conectar.ConnectionString = connStr;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();

            string query = "SELECT U.ID_Usuario, U.Nombre, U.Contraseña, U.Estado, U.ID_Empleado, E.Cedula, U.ID_Rol, R.Nombre AS Nombre_Rol FROM Usuarios U JOIN Empleados E ON U.ID_Empleado = E.ID_Empleado JOIN Roles R ON U.ID_Rol = R.ID_Rol ";
            conectar.Open();

            if (opcion == 0)
                query += "WHERE U.ID_Usuario = " + dato + ";";
            else if (opcion == 1)
                query += "WHERE U.Nombre like '%" + dato + "%';";
            else if (opcion == 2)
                query += "WHERE U.Contraseña = '" + dato + "';";
            else if (opcion == 3)
                query += "WHERE U.Estado = " + dato + ";";
            else if (opcion == 4)
                query += "WHERE U.ID_Rol = " + dato + ";";
            else if (opcion == 5)
                query += "WHERE U.ID_Empleado = " + dato + ";";
            else if (opcion == 6)
                query += "WHERE E.Cedula = '" + dato + "';";
            else if (opcion == 7)
                query += "WHERE R.Nombre like '%" + dato + "%';";
            else
                MessageBox.Show("Opción inválida");

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

        public string Modificar(DataGridView grid, string id, string nombre, bool estado, int idRol, string idempleado, string contraseña)
        {
            conectar.ConnectionString = connStr;
            string resultado = "No guardar";

            conectar.Open();

            SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_USUARIO", conectar);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@c_id", id);
            cmd.Parameters.AddWithValue("@c_nombre", nombre);
            cmd.Parameters.AddWithValue("@c_contraseña", contraseña);
            cmd.Parameters.AddWithValue("@c_estado", estado);
            cmd.Parameters.AddWithValue("@c_idempleado", idempleado);
            cmd.Parameters.AddWithValue("@c_idrol", idRol);

            try
            {
                cmd.ExecuteNonQuery();
                resultado = "Guardar";
            }
            catch (SqlException)
            {
                MessageBox.Show($"El ID del empleado que ingreso no esta registrado.", "Empleado no encontrado.");
            }

            conectar.Close();
            ActualizarGrid(grid);
            return resultado;
        }
    }
}
