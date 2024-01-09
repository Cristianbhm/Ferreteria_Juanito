using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APISistema.BO
{
    public class UsuarioBO
    {
        public int idUsuario { get; set; }
        public string usuario { get; set; }
        public string nombreUsuario { get; set; }
        public string apellidoUsuario { get; set; }
        public string mailUsuario { get; set; }
        public string passUsuario { get; set; }
        public int idRol { get; set; }
        public string nomTipoRol { get; set; }
    }
}
