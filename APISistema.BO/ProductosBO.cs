using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISistema.BO
{
    public class ProductosBO
    {
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public int valorNetoProducto { get; set; }
        public int valorIvaProducto { get; set; }
        public int valorTotalProducto { get; set; }
        public string desAdicionalProducto { get; set; }
        public string categoriaProducto { get; set; }
        public int stockProducto { get; set; }
        public string marcaProducto { get; set; }

    }
}
