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
            return cCD.readerCliente(script, "");
        }

        // Buscar Clientes
        public List<ClienteCE> buscarCliente(string buscar)
        {
            script = "SELECT * FROM cliente where nombre like '%' + @valor + '%'";
            return cCD.readerCliente(script,buscar);
        }

        // Actualizar Cliente
        public void actualizarCliente(ClienteCE cliente)
        {
            script = "UPDATE cliente set nombre = @nombre, numruc = @numruc, direccion = @direccion, telefono = @telefono where id = @id";
            cCD.executeCliente(script, cliente);
        }

        // Insertar Cliente
        public void insertarCliente(ClienteCE cliente)
        {
            // Script SQL
            script = "INSERT INTO cliente(nombre, numruc, direccion, telefono) VALUES(@nombre, @numruc, @direccion, @telefono)";
            cCD.executeCliente(script, cliente);
        }

        // Eliminar Cliente
        public void eliminarCliente(ClienteCE cliente)
        {   // Script SQL
            script = "DELETE FROM cliente where id = @id";
            cCD.executeCliente(script, cliente);
        }
    }
}
