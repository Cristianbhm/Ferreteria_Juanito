using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APISistema.BO;
using APISistema.Data;


namespace APISistema.Negocio
{
    public class ProductoNegocio
    {
        
        public List<ProductosBO> GetProductosBOs()
        {
            _Data _data = new _Data();
            return _data.getListaProductos();
        }


        public bool setInsertaProductos(ProductosBO _prod)
        {
            _Data _data = new _Data();
            return _data.setInsertaProducto(_prod); ;
        }

        public bool setUpdateProductos(ProductosBO _prod)
        {
            _Data _data = new _Data();
            return _data.setUpdateProducto(_prod); ;
        }

        public bool setDeleteProductos(string _idProd)
        {
            _Data _data = new _Data();
            return _data.setDeleteProducto(_idProd); ;
        }


    }



}
