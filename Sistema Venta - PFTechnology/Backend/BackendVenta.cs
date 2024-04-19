using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace PFTechnology.Backend
{
    internal class BackendVenta
    {
        public void ActualizarGridProductos(DataGridView grid)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = connStr;
            conectar.Open();

            string query = "SELECT ID_Producto, Productos.ID_Categoria, Productos.Descripcion as Producto, Categorias.Descripcion as Categoria, Precio, Stock, Stock_Minimo FROM Productos join Categorias on Productos.ID_Categoria = Categorias.ID_Categoria Where Productos.Estado = 1";
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

        public void FiltrarProductos(DataGridView grid, int opcion, string dato)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = connStr;
            string query = "SELECT ID_Producto, Productos.ID_Categoria, Productos.Descripcion as Producto, Categorias.Descripcion as Categoria, Precio, Stock, Stock_Minimo FROM Productos join Categorias on Productos.ID_Categoria = Categorias.ID_Categoria Where Productos.Estado = 1 ";
            conectar.Open();

            switch (opcion)
            {
                case 0:
                    query += $"And Productos.ID_Producto = {dato};";
                    break;
                case 1:
                    query += $"And Productos.Descripcion like '%{dato}%';";
                    break;
                case 2:
                    query += $"And Precio = {dato};";
                    break;
                case 3:
                    query += $"And Stock = {dato};";
                    break;
                case 4:
                    query += $"And Stock_Minimo = {dato};";
                    break;
                case 5:
                    query += $"And Productos.ID_Categoria = {dato};";
                    break;
                case 6:
                    query += $"And Categorias.Descripcion like '%{dato}%';";
                    break;
                default:
                    MessageBox.Show("Opcion invalida");
                    break;
            }
            

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

        public void ActualizarGridClientes(DataGridView grid)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = connStr;
            conectar.Open();

            string query = "SELECT ID_Cliente, Nombre, Apellido, Socio, Email, Cedula FROM Clientes Where Estado = 1";
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
        }

        public void FiltrarClientes(DataGridView grid, int opcion, string dato)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = connStr;
            string query = "SELECT ID_Cliente, Nombre, Apellido, Socio, Email, Cedula FROM Clientes Where Estado = 1 ";
            conectar.Open();

            switch (opcion)
            {
                case 0:
                    query += $"And ID_Cliente = {dato};";
                    break;
                case 1:
                    query += $"And Nombre like '%{dato}%'";
                    break;
                case 2:
                    query += $"And Apellido like '%{dato}%'";
                    break;
                case 3:
                    query += $"And Email = '{dato}'";
                    break;
                case 4:
                    query += $"And Cedula = '{dato}';";
                    break;
                case 5:
                    query += $"And Socio = '{dato}';";
                    break;
                default:
                    MessageBox.Show("Opcion invalida");
                    break;
            }

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

        public int ObtenerIDVenta()
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            conectar.Open();
            int id;

            string query = "Select Top 1 ID_Venta from Ventas Order By ID_Venta Desc";
            SqlCommand cmd = new SqlCommand(query, conectar);

            try
            {
                id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Message + ".");
                throw;
            }
            conectar.Close();

            //MessageBox.Show(id.ToString());
            return id;
        }

        public void ActualizarGridVenta(DataGridView grid, int idventa)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable contenedor = new DataTable();
            conectar.ConnectionString = connStr;
            conectar.Open();
            string query;

            query = "SELECT D.ID_Venta, D.ID_Producto, D.Precio_Unitario, D.Cantidad, D.Subtotal, D.Descuento, P.Descripcion FROM DetalleVentas D join Productos P on D.ID_Producto = P.ID_Producto where ID_Venta = " + idventa + ";";
            
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

        public double ObtenerTotal(int idventa)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;

            string criterios = $" from DetalleVentas where ID_Venta = {idventa};";
            string consulta1 = "select Count(*)" + criterios;
            string consulta2 = "Select SUM(Subtotal)" + criterios;

            conectar.Open();
            SqlCommand cmd;
            
            double total = 0;
            int conteo;

            try
            {
                cmd = new SqlCommand(consulta1, conectar);
                conteo = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException)
            {
                MessageBox.Show("Error contando los registros del detalle");
                throw;
            }

            if(conteo > 0)
            {
                try
                {
                    cmd = new SqlCommand(consulta2, conectar);
                    total = Convert.ToDouble(cmd.ExecuteScalar());
                }
                catch (SqlException)
                {
                    MessageBox.Show("Error calculando el total");
                    throw;
                }
            }
            

            conectar.Close();
            return total;
        }

        public void Crearfactura(int idcliente, int idusuario)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;

            conectar.Open();

            SqlCommand cmdsp = new SqlCommand("SP_AGREGAR_VENTA", conectar);

            cmdsp.CommandType = CommandType.StoredProcedure;
            cmdsp.Parameters.AddWithValue("@idcliente", idcliente);
            cmdsp.Parameters.AddWithValue("@idusuario", idusuario);

            try
            {
                cmdsp.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            conectar.Close();
        }

        public string AgregarProductoAlDetalle(DataGridView grid, int idventa, int idproducto, int cantidad, int descuento)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            conectar.Open();

            SqlCommand cmd;
            string resultado = VerificarStock(idproducto, cantidad);
            if(resultado == "Agregar")
            {
                cmd = new SqlCommand("SP_AGREGAR_DETALLEVENTA", conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idventa", idventa);
                cmd.Parameters.AddWithValue("@idproducto", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@descuento", descuento);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            
            conectar.Close();
            ActualizarGridVenta(grid, idventa);
            return resultado;
        }
        public string ActualizarProductoenDetalle(int idventa, int idprod, DataGridView grid, int cantidad, int descuento)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            conectar.Open();

            SqlCommand cmd = new SqlCommand("SP_MODIFICAR_DETALLEVENTA", conectar);
            string resultado = VerificarStock(idprod, cantidad);

            if(resultado == "Agregar")
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idventa", idventa);
                cmd.Parameters.AddWithValue("@idproducto", idprod);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@descuento", descuento);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            conectar.Close();
            ActualizarGridVenta(grid, idventa);
            return resultado;
        }

        public string VerificarStock(int idprod, int cantidad)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            conectar.Open();
            string resultado;


            SqlCommand cmd = new SqlCommand($"Select Stock from Productos where ID_Producto = {idprod}", conectar);

            int Stock = 0;
            try
            {
                Stock = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch
            {
                MessageBox.Show("no se pudo obtener el valor del stock del producto elegido");
            }

            if (Stock >= cantidad)
            {
                resultado = "Agregar";
            }
            else
            {
                resultado = "SinStock";
            }
            return resultado;
        }

        public void TerminarVenta(int idventa) 
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            conectar.Open();

            SqlCommand cmd = new SqlCommand("SP_TERMINAR_VENTA", conectar);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idventa", idventa);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            conectar.Close();
        }

        public int ContarDetalles(int idventa)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            conectar.Open();
            int cantidad = 0;

            SqlCommand cmd = new SqlCommand("Select Count(*) from DetalleVentas where ID_Venta = " + idventa + ";", conectar);
            try
            {
                cantidad  = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            conectar.Close();
            return cantidad;
        }

        public string ObtenerDescripcionPorID(int id)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            conectar.Open();
            string query;

            query = "SELECT Descripcion FROM Productos where ID_Producto = " + id + ";";
            SqlCommand cmd = new SqlCommand(query, conectar);
            string desc;

            try
            {
                desc = cmd.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Message + ".");
                throw;
            }
            conectar.Close();

            return desc;
        }

        public string EmailPorIDCliente(int idcliente)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            conectar.Open();
            string query;

            query = $"SELECT Email FROM Clientes where ID_Cliente = {idcliente};";
            SqlCommand cmd = new SqlCommand(query, conectar);
            string email;

            try
            {
                email = cmd.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Message + ".");
                throw;
            }
            conectar.Close();

            return email;
        }

        public string SucursalPorIDUsuario(int idusuario)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            conectar.Open();
            string query;

            query = $"SELECT Sucursales.ID_Sucursal FROM Usuarios INNER JOIN Empleados ON Usuarios.ID_Empleado = Empleados.ID_Empleado INNER JOIN Sucursales ON Empleados.ID_Sucursal = Sucursales.ID_Sucursal WHERE Usuarios.ID_Usuario = {idusuario};";
            SqlCommand cmd = new SqlCommand(query, conectar);
            string idsucursal;

            try
            {
                idsucursal = cmd.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Message + ".");
                throw;
            }
            conectar.Close();

            return idsucursal;
        }

        public void EliminarDetalle(int idprod, int idventa, DataGridView grid)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            conectar.Open();

            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_DETALLEVENTA", conectar);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idventa", idventa);
            cmd.Parameters.AddWithValue("@idproducto", idprod);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            conectar.Close();

            ActualizarGridVenta(grid,idventa);
        }

        public bool ComprobarProdenDetalle(int idprod, int idventa)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            conectar.Open();
            string query;

            query = "SELECT Count(*) FROM DetalleVentas where ID_Producto = " + idprod + " and ID_Venta = " + idventa + ";";
            SqlCommand cmd = new SqlCommand(query, conectar);

            try
            {
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    if (Convert.ToInt32(result) > 0) return true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Message + ".");
                throw;
            }
            conectar.Close();

            return false;
        }

        public void CambiarCliente(int idventa, int idcliente)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            conectar.Open();

            SqlCommand cmd = new SqlCommand("SP_CAMBIAR_CLIENTE", conectar);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idventa", idventa);
            cmd.Parameters.AddWithValue("@idcliente", idcliente);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cambiado Correctamente");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }


            conectar.Close();
        }

        public void CancelarVenta(int idventa)
        {
            string connStr = "Data Source = YERELAPTOP\\MSSQLSERVER01; Initial Catalog=PFTechnology; Integrated Security = True;";
            SqlConnection conectar = new SqlConnection();
            conectar.ConnectionString = connStr;
            conectar.Open();

            string queryDetalle = $"Delete FROM DetalleVentas where ID_Venta = {idventa};";
            string queryVenta = $"Delete FROM Ventas where ID_Venta = {idventa};";

            SqlCommand cmd = new SqlCommand(queryDetalle, conectar); ;

            try
            {
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand(queryVenta, conectar);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Venta cancelada correctamente.", "Se ha cancelado la venta");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Message + ".");
                throw;
            }
            conectar.Close();
        }
    }
}
