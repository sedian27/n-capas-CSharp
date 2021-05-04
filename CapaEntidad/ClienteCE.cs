using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClienteCE
    {
        //Propiedades
        private int id;
        private string nombre;
        private string numruc;
        private string direccion;
        private int telefono;

        //Constructor
        public ClienteCE(){}
        public ClienteCE(int vId, string vNombre, string vNumRuc, string vDireccion, int vTelefono)
        {
            this.id = vId;
            this.nombre = vNombre;
            this.numruc = vNumRuc;
            this.direccion = vDireccion;
            this.telefono = vTelefono;
        }

        //Encapsulados
        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string NumRuc { get { return numruc; } set { numruc = value; } }
        public string Direccion { get { return direccion; } set { direccion = value; } }
        public int Telefono { get { return telefono; } set { telefono = value; } }

        
    }
}
