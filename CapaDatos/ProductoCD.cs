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
        //Metodos del crud
        // Leer Datos
        public List<ProductoCE> readerProductos(string query, int idBuscar = 0, string buscar = "")
        {
            db.abrirConexion();

            cmd = db.comando();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@valor", buscar);
            cmd.Parameters.AddWithValue("@id", idBuscar);
            drProducto = cmd.ExecuteReader();
            // Declarar una coleccion de productos
            List<ProductoCE> lstProductos = new List<ProductoCE>();

            // Moviendo el puntero de registro
            // Hasta finalizar la tabla
            while (drProducto.Read())
            {
                int id = Convert.ToInt32(drProducto["id"]);
                string descripcion = drProducto["descripcion"].ToString();
                string categoria = drProducto["categoria"].ToString();
                double precio = Convert.ToDouble(drProducto["precio"]);
                // Instanciar un nuevo producto
                ProductoCE producto = new ProductoCE(id, descripcion, categoria, precio);
                lstProductos.Add(producto);
            }
            db.cerrarConexion();
            return lstProductos;
        }

        // Insertar, Actualizar y Eliminar;
        public void executeProductos(string query, ProductoCE producto)
        {
            db.abrirConexion();
            //crear un comando vinculado a la conexión.
            // Establecer el tipo
            cmd = db.comando();
            // Asignar el script SQL al comando
            cmd.CommandText = query;
            // Leer valores a actualizar
            cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
            cmd.Parameters.AddWithValue("@categoria", producto.Categoria);
            cmd.Parameters.AddWithValue("@precio", producto.Precio);
            cmd.Parameters.AddWithValue("@id", producto.Id);

            //Ejecutar comando
            cmd.ExecuteNonQuery(); // UPDATE, INSERT, DELETE

            db.cerrarConexion();
        }

    }
}
