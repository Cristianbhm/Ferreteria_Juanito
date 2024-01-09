using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APISistema.BO;
using APISistema.Negocio;
using System.Configuration;
using System.Web.Script.Serialization;

namespace APISistema.Controllers
{
    public class ProductosController : ApiController
    {
        // GET: api/Productos
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Productos/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Productos
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Productos/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Productos/5
        //public void Delete(int id)
        //{
        //}



        [HttpGet]
        [Route("api/Productos")]
        public IEnumerable<ProductosBO> getProductos()
        {
            ProductoNegocio _negocio = new ProductoNegocio();

            IEnumerable<ProductosBO> listProductos = _negocio.GetProductosBOs();

            return listProductos;
        }


        [HttpPost]
        [Route("api/InsertaProducto")]
        public bool setInsertaProductos([FromBody]ProductosBO _prod)
        {
            
            ProductoNegocio _negocio = new ProductoNegocio();
            return _negocio.setInsertaProductos(_prod) ;
        }



        [HttpPost]
        [Route("api/UpdateProducto")]
        public bool setUpdateProductos([FromBody] ProductosBO _prod)
        {
            ProductoNegocio _negocio = new ProductoNegocio();
            return _negocio.setUpdateProductos(_prod);
        }

        [HttpGet]
        [Route("api/DeleteProducto")]
        public bool setDeleteProductos(string _idProd)
        {
            ProductoNegocio _negocio = new ProductoNegocio();
            return _negocio.setDeleteProductos(_idProd);
        }
    }
}