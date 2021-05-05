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
            return pCD.readerProductos(consulta, 0, buscar);
        }

        public List<ProductoCE> buscarProductoId(int id)
        {
            consulta = "SELECT * FROM producto where id = @id";
            return pCD.readerProductos(consulta, id, "");
        }


        // Actualizar Producto
        public void actualizarProducto(ProductoCE producto)
        {
            consulta = "UPDATE producto set descripcion = @descripcion, categoria = @categoria, precio = @precio where id = @id";
            pCD.executeProductos(consulta, producto);
        }

        // Insertar Producto
        public void insertarProducto(ProductoCE producto)
        {
            consulta = "INSERT INTO producto(descripcion, categoria, precio) VALUES(@descripcion, @categoria, @precio)";
            pCD.executeProductos(consulta, producto);
        }

        // Eliminar Producto
        public void eliminarProducto(ProductoCE producto)
        {
            consulta = "DELETE FROM producto where id = @id";
            pCD.executeProductos(consulta, producto);
        }
    }
}
