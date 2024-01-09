using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APISistema.Models
{
    public class UsuarioModels
    {
        public string idUsuario { get; set; }
        public string usuario { get; set; }
        public string nombreUsuario { get; set; }
        public string apellidoUsuario { get; set; }
        public string mailUsuario { get; set; }
        public string passUsuario { get; set; }
        public int rolUsuario { get; set; }
        public int idRol { get; set; }
        public List<UsuarioModels> _listRolUsuario { get; set; }
    }


}