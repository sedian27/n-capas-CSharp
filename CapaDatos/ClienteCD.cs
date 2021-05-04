using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ClienteCD
    {
        //Propiedades
        ConexionCD db = new ConexionCD();
        SqlCommand cmd;
        SqlDataReader drCliente;
        int id; string nombre; string numruc; string direccion; int telefono;
        //Metodos del crud
        // Leer Datos
        public List<ClienteCE> readerProductos(string query, string buscar = "")
        {
            db.abrirConexion();

            cmd = db.comando();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@valor", buscar);
            drCliente = cmd.ExecuteReader();
            // Declarar una coleccion de productos
            List<ClienteCE> lstProductos = new List<ClienteCE>();

            // Moviendo el puntero de registro
            // Hasta finalizar la tabla
            while (drCliente.Read())
            {
                id = Convert.ToInt32(drCliente["id"]);
                nombre = drCliente["nombre"].ToString();
                numruc = drCliente["numruc"].ToString();
                direccion = drCliente["direccion"].ToString();
                telefono = Convert.ToInt32(drCliente["telefono"]);
                // Instanciar un nuevo producto
                ClienteCE producto = new ClienteCE(id, nombre, numruc, direccion, telefono);
                lstProductos.Add(producto);
            }
            db.cerrarConexion();
            return lstProductos;
        }

        // Insertar, Actualizar y Eliminar;

        public void executeProductos(string query, string nombre = "", string numruc = "", string direccion = "",int telefono = 0, int id = 0)
        {
            db.abrirConexion();
            //crear un comando vinculado a la conexión.
            // Establecer el tipo
            cmd = db.comando();
            // Asignar el script SQL al comando
            cmd.CommandText = query;
            // Leer valores a actualizar
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@numruc", numruc);
            cmd.Parameters.AddWithValue("@direccion", direccion);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@id", id);

            //Ejecutar comando
            cmd.ExecuteNonQuery(); // UPDATE, INSERT, DELETE

            db.cerrarConexion();
        }
    }
}
