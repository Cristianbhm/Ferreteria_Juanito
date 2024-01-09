using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APISistema.Models;
using APISistema.Negocio;
using APISistema.BO;

namespace APISistema.Controllers
{
    public class RolController : ApiController
    {
        // GET: api/Rol
        public IEnumerable<string> Get()
        {
            return new string[] { "admin", "cliente" };
        }

        // GET: api/Rol/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rol
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Rol/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Rol/5
        public void Delete(int id)
        {
        }


        [HttpGet]
        [Route("api/Rol")]
        public IEnumerable<RolBO> getRol()
        {
            RolNegocio _negocio = new RolNegocio();
            
            var listRoles = _negocio.GetRolBOs();

            return listRoles;
        }
    }
}
