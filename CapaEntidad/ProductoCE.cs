using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ProductoCE
    {
        //Propiedades
        private int id;
        private string descripcion;
        private string categoria;
        private double precio;

        //Constructor
        public ProductoCE() {}
        public ProductoCE(int vId, string vDescripcion, string vCategoria, double vPrecio)
        {
            this.id = vId;
            this.descripcion = vDescripcion;
            this.categoria = vCategoria;
            this.precio = vPrecio;
        }

        //Encapsulados
        public int Id { get { return id; } set { id = value; } }
        public string Descripcion { get { return descripcion; } set { descripcion = value; } }
        public string Categoria { get { return categoria; } set { categoria = value; } }
        public double Precio { get { return precio; } set { precio = value; } }

    }
}
