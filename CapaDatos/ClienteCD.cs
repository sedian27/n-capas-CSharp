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
        //Metodos del crud
        // Leer Datos
        public List<ClienteCE> readerCliente(string query, string buscar = "")
        {
            db.abrirConexion();

            cmd = db.comando();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@valor", buscar);
            drCliente = cmd.ExecuteReader();
            // Declarar una coleccion de clientes
            List<ClienteCE> lstCliente = new List<ClienteCE>();

            // Moviendo el puntero de registro
            // Hasta finalizar la tabla
            while (drCliente.Read())
            {
                int id = Convert.ToInt32(drCliente["id"]);
                string nombre = drCliente["nombre"].ToString();
                string numruc = drCliente["numruc"].ToString();
                string direccion = drCliente["direccion"].ToString();
                int telefono = Convert.ToInt32(drCliente["telefono"]);
                // Instanciar un nuevo cliente
                ClienteCE cliente = new ClienteCE(id, nombre, numruc, direccion, telefono);
                lstCliente.Add(cliente);
            }
            db.cerrarConexion();
            return lstCliente;
        }

        // Insertar, Actualizar y Eliminar;

        public void executeCliente(string query, ClienteCE cliente)
        {
            db.abrirConexion();
            //crear un comando vinculado a la conexión.
            // Establecer el tipo
            cmd = db.comando();
            // Asignar el script SQL al comando
            cmd.CommandText = query;
            // Leer valores a actualizar
            cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
            cmd.Parameters.AddWithValue("@numruc", cliente.NumRuc);
            cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
            cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
            cmd.Parameters.AddWithValue("@id", cliente.Id);

            //Ejecutar comando
            cmd.ExecuteNonQuery(); // UPDATE, INSERT, DELETE

            db.cerrarConexion();
        }
    }
}
