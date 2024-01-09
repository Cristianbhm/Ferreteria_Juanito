using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ferreteria_Juanito.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult validaUsuario(Models.UsuarioModel usuarioLogin)
        {
            string usuario = usuarioLogin.usuario.ToString();

            if (usuario == "admin")
            {
                return RedirectToAction("ViewMantenedor", "Mantenedor");

            }else
            {
                return RedirectToAction("ViewMantenedor", "Mantenedor");
            }
        }
    }
}