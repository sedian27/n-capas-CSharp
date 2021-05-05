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
        private int id = 0;
        private string nombre = "";
        private string numruc = "";
        private string direccion = "";
        private int telefono = 0;

        //Constructor
        public ClienteCE(){}
        public ClienteCE(int vId = 0, string vNombre = "", string vNumRuc = "", string vDireccion = "", int vTelefono = 0)
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
