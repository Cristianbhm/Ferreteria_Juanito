using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APISistema.BO;
using APISistema.Data;

namespace APISistema.Negocio
{
    public class UsuarioNegocio
    {
        public List<UsuarioBO> GetUsuariosBOs()
        {
            _Data _data = new _Data();
            return _data.getListaUsuarios();
        }


        public bool setInsertaUsuario(UsuarioBO _usuario)
        {
            _Data _data = new _Data();
            return _data.setInsertaUsuario(_usuario);
        }

        public bool setDeleteUsuario(string _idUsuarios)
        {
            _Data _data = new _Data();
            return _data.setDeleteUsuario(_idUsuarios); 
        }

        public bool setUpdateUsuario(UsuarioBO _usuario)
        {
            _Data _data = new _Data();
            return _data.setUpdateUsuario(_usuario); ;
        }

   


    }
}
