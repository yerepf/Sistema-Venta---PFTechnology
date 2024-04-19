using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFTechnology.Backend
{
    internal class BackendLogin
    {
        public bool IniciarSesion(string user, string pass)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            conectar.Open();

            string query = "SELECT Count(*) FROM Usuarios WHERE Nombre = '" + user + "' and Contraseña = '" + pass + "' and Estado = 1;";

            SqlCommand cmd = new SqlCommand(query, conectar);
            try
            {
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    if (Convert.ToInt32(result) > 0) return true;
                    else MessageBox.Show("Sesion Fallida.");
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            conectar.Close();
            return false;
            
        }

        public int GetID(string user, string pass) 
        {
            var idusuario = 0;
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            conectar.Open();

            SqlCommand cmd = new SqlCommand($"Select ID_Usuario from Usuarios where Nombre = '{user}' and Contraseña = '{pass}';", conectar);

            try
            {
                object resultado = cmd.ExecuteScalar();
                if (resultado != null) idusuario = Convert.ToInt32(resultado);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            conectar.Close();
            return idusuario;
        }
    }
}
