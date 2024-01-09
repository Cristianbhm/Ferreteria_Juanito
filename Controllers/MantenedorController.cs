using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Ferreteria_Juanito.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Configuration;

namespace Ferreteria_Juanito.Controllers
{
    public class MantenedorController : Controller
    {
        private string urlBaseApiSistema = ConfigurationManager.AppSettings["APISistemaBase"].ToString();
        public ActionResult ViewMantenedor()
        {
            UsuarioModel _model = new UsuarioModel();
            ViewBag.Rol = GetListaRol();
            return View();
        }


        public List<RolModels> GetListaRol()
        {

            string url = urlBaseApiSistema+ "Rol";
            List<RolModels> rolModel;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

                request.Method = "GET";
                string data = String.Empty;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    data = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();

                }
                JavaScriptSerializer jss = new JavaScriptSerializer();
                rolModel = jss.Deserialize<List<RolModels>>(data);
                return rolModel;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public JsonResult GetListaProductos()
        {
            string url = urlBaseApiSistema + "Productos";
            List<ProductosModels> data;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

                request.Method = "GET";
                string _data = String.Empty;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    _data = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();

                }
                JavaScriptSerializer jss = new JavaScriptSerializer();
                data = jss.Deserialize<List<ProductosModels>>(_data);
                return Json(data, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        public JsonResult setInsertaProducto(ProductosModels _prod)
        {
            string url = urlBaseApiSistema + "insertaProducto";
            string result = string.Empty;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    string json = jss.Serialize(_prod);
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                return Json(result);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public JsonResult setUpdateProducto(ProductosModels _prod)
        {
            string url = urlBaseApiSistema + "UpdateProducto";
            string result = string.Empty;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    string json = jss.Serialize(_prod);
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                return Json(result);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public JsonResult setDeleteProducto(int _idProd)
        {

            string url = urlBaseApiSistema + "DeleteProducto?_idProd="+ _idProd.ToString() ;
            string result = string.Empty;
            try  
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                return Json(result);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        public JsonResult GetListaUsuarios()
        {
            string url = urlBaseApiSistema + "Usuarios";
            List<UsuarioModel> data;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

                request.Method = "GET";
                string _data = String.Empty;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    _data = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();

                }
                JavaScriptSerializer jss = new JavaScriptSerializer();
                data = jss.Deserialize<List<UsuarioModel>>(_data);
                return Json(data, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        public JsonResult setDeleteUsuario(int _idUsuario)
        {
            string url = urlBaseApiSistema + "DeleteUsuario?_idUsuario=" + _idUsuario.ToString();
            string result = string.Empty;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                return Json(result);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }



        [HttpPost]
        public JsonResult setInsertaUsuario(UsuarioModel _usuario)
        {
            string url = urlBaseApiSistema + "InsertaUsuario";
            string result = string.Empty;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    string json = jss.Serialize(_usuario);
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                return Json(result);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        public JsonResult setUpdateUsuario(UsuarioModel _usuarioModel)
        {
            string url = urlBaseApiSistema + "UpdateUsuario";
            string result = string.Empty;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    string json = jss.Serialize(_usuarioModel);
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                return Json(result);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}