using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Venta___PFTechnology.Backend
{
    internal class BackendReportes
    {

        public string ObtenerEmailUsuario(string user, string pass)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            conectar.Open();

            string query = $"select E.Email From Empleados E join Usuarios U on U.ID_Empleado = E.ID_Empleado where U.Nombre = '{user}' and U.Contraseña = '{pass}' and U.Estado = 1;";
            SqlCommand cmd = new SqlCommand(query, conectar);
            string resultado = "Sin Correo";

            try
            {
                resultado = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {     
                MessageBox.Show("Error " + ex.Message + ".");
                throw;
            }
            conectar.Close();
            return resultado;
        }
    }
}
