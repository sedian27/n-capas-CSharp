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
        private int id = 0;
        private string descripcion = "";
        private string categoria = "";
        private double precio = 0.00;

        //Constructor
        public ProductoCE() {}
        public ProductoCE(int vId = 0, string vDescripcion = "", string vCategoria = "", double vPrecio = 0.00)
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
