using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ProductoCN
    {
        // Propiedades
        ProductoCD pCD = new ProductoCD();
        
        string consulta;

        // Metodo -> Listar Productos
        public List<ProductoCE> listarProducto()
        {
            consulta = "SELECT * FROM producto";
            return pCD.readerProductos(consulta);
        }

        // Buscar Productos
        public List<ProductoCE> buscarProducto(string buscar)
        {

            consulta = "SELECT * FROM producto where descripcion like '%' + @valor + '%'";
            return pCD.readerProductos(consulta, buscar);
        }

        // Actualizar Producto
        public void actualizarProducto(int id, string descripcion, string categoria, double precio)
        {
            consulta = "UPDATE producto set descripcion = @descripcion, categoria = @categoria, precio = @precio where id = @id";
            pCD.executeProductos(consulta, descripcion, categoria, precio, id);
        }

        // Insertar Producto
        public void insertarProducto(string descripcion, string categoria, double precio)
        {
            consulta = "INSERT INTO producto(descripcion, categoria, precio) VALUES(@descripcion, @categoria, @precio)";
            pCD.executeProductos(consulta, descripcion, categoria, precio, 0);
        }

        // Eliminar Producto
        public void eliminarProducto(int id)
        {
            consulta = "DELETE FROM producto where id = @id";
            pCD.executeProductos(consulta, "", "", 0.00, id);
        }
    }
}
