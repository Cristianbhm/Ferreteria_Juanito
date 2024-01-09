using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APISistema.BO;
using APISistema.Data;

namespace APISistema.Negocio
{
    public class RolNegocio
    {
        public List<RolBO> GetRolBOs()
        {
            _Data _data = new _Data();


             return _data.getListaRol();
        }
    }
}
