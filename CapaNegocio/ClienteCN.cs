using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ClienteCN
    {
        // Propiedades globales
        ClienteCD cCD = new ClienteCD();
        string script;

        // Metodo -> Listar Clientes
        public List<ClienteCE> listarCliente()
        {
            script = "SELECT * FROM cliente";
            return cCD.readerProductos(script, "");
        }

        // Buscar Clientes
        public List<ClienteCE> buscarCliente(string buscar)
        {
            script = "SELECT * FROM cliente where nombre like '%' + @valor + '%'";
            return cCD.readerProductos(script,buscar);
        }

        // Actualizar Cliente
        public void actualizarCliente(int id, string nombre, string numruc, string direccion, int telefono)
        {
            script = "UPDATE cliente set nombre = @nombre, numruc = @numruc, direccion = @direccion, telefono = @telefono where id = @id";
            cCD.executeProductos(script, nombre, numruc, direccion, telefono, id);
        }

        // Insertar Cliente
        public void insertarCliente(string nombre, string numruc, string direccion, int telefono)
        {
            // Script SQL
            script = "INSERT INTO cliente(nombre, numruc, direccion, telefono) VALUES(@nombre, @numruc, @direccion, @telefono)";
            cCD.executeProductos(script, nombre, numruc, direccion, telefono, 0);
        }

        // Eliminar Cliente
        public void eliminarCliente(int id)
        {   // Script SQL
            script = "DELETE FROM cliente where id = @id";
            cCD.executeProductos(script,"","","",0, id);
        }
    }
}
