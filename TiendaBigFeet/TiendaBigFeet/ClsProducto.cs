using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaBigFeet
{
    public class ClsProducto
    {

        public int ID { get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public int Talla { get; set; }
        public int Cantidad { get; set; }
        public Double PrecioCompra { get; set; }
        public Double PrecioVenta { get; set; }

    }
}
