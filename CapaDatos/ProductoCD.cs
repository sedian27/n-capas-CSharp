using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Importar la CapaEntidad
using CapaEntidad;
// Importar Librerias de datos
using System.Data;
// Importar la libreria para Sql
using System.Data.SqlClient;


namespace CapaDatos
{
    public class ProductoCD
    {
        //Propiedades
        ConexionCD db = new ConexionCD();
        SqlCommand cmd;
        SqlDataReader drProducto;
        int id; string descripcion; string categoria; double precio;
        //Metodos del crud
        // Leer Datos
        public List<ProductoCE> readerProductos(string query, string buscar = "")
        {
            db.abrirConexion();

            cmd = db.comando();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@valor", buscar);
            drProducto = cmd.ExecuteReader();
            // Declarar una coleccion de productos
            List<ProductoCE> lstProductos = new List<ProductoCE>();

            // Moviendo el puntero de registro
            // Hasta finalizar la tabla
            while (drProducto.Read())
            {
                id = Convert.ToInt32(drProducto["id"]);
                descripcion = drProducto["descripcion"].ToString();
                categoria = drProducto["categoria"].ToString();
                precio = Convert.ToDouble(drProducto["precio"]);
                // Instanciar un nuevo producto
                ProductoCE producto = new ProductoCE(id, descripcion, categoria, precio);
                lstProductos.Add(producto);
            }
            db.cerrarConexion();
            return lstProductos;
        }

        // Insertar, Actualizar y Eliminar;

        public void executeProductos(string query, string descripcion = "", string categoria = "", double precio = 0.00, int id = 0)
        {
            db.abrirConexion();
            //crear un comando vinculado a la conexión.
            // Establecer el tipo
            cmd = db.comando();
            // Asignar el script SQL al comando
            cmd.CommandText = query;
            // Leer valores a actualizar
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@categoria", categoria);
            cmd.Parameters.AddWithValue("@precio", precio);
            cmd.Parameters.AddWithValue("@id", id);

            //Ejecutar comando
            cmd.ExecuteNonQuery(); // UPDATE, INSERT, DELETE

            db.cerrarConexion();
        }

    }
}
