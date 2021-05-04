using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    class ConexionCD
    {
        // Crear la conexión a la BD SQL SERVER
        // Instanciar la clase StringBuilder
        SqlConnection conexion;
        public ConexionCD()
        {
            SqlConnectionStringBuilder generarCadena = new SqlConnectionStringBuilder();
            //Asignar los valores a las propiedades del stringBuilder
            generarCadena.DataSource = "localhost"; //localhost
            generarCadena.InitialCatalog = "BDMARKET"; // base de datos
            generarCadena.UserID = "sa"; // id
            generarCadena.Password = "123456"; // contraseña
            // generarCadena.IntegratedSecurity = false; // seguridad windows

            //Recuperar la cadena de conexion generada
            string cadenaCnx = generarCadena.ConnectionString;//Devuelve la cadena de conexion

            this.conexion = new SqlConnection(cadenaCnx);
        }

        // Abrir la conexion
        public SqlConnection abrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }

        // Cerrar la conexion
        public SqlConnection cerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
            return conexion;
        }

        //Consultas
        public SqlCommand comando()
        {
            // Crear un comando vinculado a la conexion.
            SqlCommand cmd = conexion.CreateCommand();
            // Establecer el tipo
            cmd.CommandType = CommandType.Text;
            // Asignar el script SQL al comando
            return cmd;
        }

        //// Forma I: DataAdapter(Solo Lectura de datos) => DataTable 
        //// Instancia un DataAdapter
        //SqlDataAdapter daProducto = new SqlDataAdapter();
        ////Asignar el comando 
        //daProducto.SelectCommand = cmd;
        ////Instanciar un DataTable
        //DataTable dtProducto = new DataTable();
        ////Llenar el dtProducto con las filas del daProducto
        //daProducto.Fill(dtProducto);
        ////Mostrar los datos
        //dgvProductos.DataSource = dtProducto;

        // Forma II: DataReader
        // Crear un DataReader y asignar las filas
        //SqlDataReader dr = cmd.ExecuteReader();//Solo para "SELECT"
        //return dr;
    }
}
