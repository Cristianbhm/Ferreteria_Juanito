using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APISistema.BO;
using APISistema.Negocio;


namespace APISistema.Controllers
{
    public class UsuariosController : ApiController
    {
       

        [HttpGet]
        [Route("api/Usuarios")]
        public IEnumerable<UsuarioBO> getProductos()
        {
            UsuarioNegocio _negocio = new UsuarioNegocio();

            IEnumerable<UsuarioBO> listUsuarios = _negocio.GetUsuariosBOs();

            return listUsuarios;
        }



        [HttpPost]
        [Route("api/InsertaUsuario")]
        public bool setInsertaUsuario([FromBody] UsuarioBO _usuario)
        {
            UsuarioNegocio _negocio = new UsuarioNegocio();
            return _negocio.setInsertaUsuario(_usuario);
        }


        [HttpGet]
        [Route("api/DeleteUsuario")]
        public bool setDeleteProductos(string _idUsuario)
        {
            UsuarioNegocio _negocio = new UsuarioNegocio();
            return _negocio.setDeleteUsuario(_idUsuario);
        }


        [HttpPost]
        [Route("api/UpdateUsuario")]
        public bool setUpdateUsuario([FromBody] UsuarioBO _usuario)
        {
            UsuarioNegocio _negocio = new UsuarioNegocio();
            return _negocio.setUpdateUsuario(_usuario);
        }

   
    }
}
