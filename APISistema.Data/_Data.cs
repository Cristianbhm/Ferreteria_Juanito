using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using APISistema.BO;
using System.Data.SQLite;


namespace APISistema.Data
{

    public class _Data
    {
        private static string stringConn = ConfigurationManager.ConnectionStrings["BD_FerreteriaJuanito"].ConnectionString;
        private static _Data _instancia = null;
        public _Data()
        {

        }
        public static _Data Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new _Data();
                }
                return _instancia;
            }

        }

        public List<RolBO> getListaRol()
        {
            List<RolBO> listRol = new List<RolBO>();
            string _mensaje = string.Empty;
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(stringConn))
                {
                    conn.Open();
                    string query = "SELECT * FROM Tipo_Rol";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listRol.Add(new RolBO()
                            {
                                idRol = int.Parse(dr["ID_TIPO_ROL"].ToString()),
                                nombreRol = dr["NOM_TIPO_ROL"].ToString()
                            });
                        }
                    }
                }
                return listRol;
            }
            catch (Exception ex)
            {
                insertControlLogs(ex.Message.ToString());
                throw ex;
            }
        }

        public List<ProductosBO> getListaProductos()
        {
            List<ProductosBO> listProductos = new List<ProductosBO>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(stringConn))
                {
                    conn.Open();
                    string query = "SELECT * FROM Productos_FJ";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listProductos.Add(new ProductosBO()
                            {
                                idProducto = int.Parse(dr["ID_PRODUCTO_FJ"].ToString()),
                                nombreProducto = dr["NOMBRE_PRODUCTO_FJ"].ToString(),
                                valorNetoProducto = int.Parse(dr["VALOR_NETO_PRODUCTO_FJ"].ToString()),
                                valorIvaProducto = int.Parse(dr["VALOR_IVA_PRODUCTO_FJ"].ToString()),
                                valorTotalProducto = int.Parse(dr["VALOR_TOTAL_PRODUCTO_FJ"].ToString()),
                                desAdicionalProducto = dr["DES_ADICIONAL_PRODUCTO_FJ"].ToString(),
                                categoriaProducto = dr["CATEGORIA_PRODUCTO_FJ"].ToString(),
                                stockProducto = int.Parse(dr["STOCK_PRODUCTO_FJ"].ToString()),
                                marcaProducto = dr["MARCA_PRODUCTO_FJ"].ToString()

                            });
                        }
                    }
                }

                return listProductos;
            }
            catch (Exception ex)
            {
                insertControlLogs(ex.Message.ToString());
                throw ex;
            }

        }

        public bool setInsertaProducto(ProductosBO _prod)
        {
            try
            {
                string _mensaje = "Error al insertar producto";
                bool resp = false;
                using (SQLiteConnection conn = new SQLiteConnection(stringConn))
                {
                    conn.Open();
                    string query = "INSERT INTO Productos_FJ (NOMBRE_PRODUCTO_FJ, VALOR_NETO_PRODUCTO_FJ, VALOR_IVA_PRODUCTO_FJ, " +
                        "VALOR_TOTAL_PRODUCTO_FJ, DES_ADICIONAL_PRODUCTO_FJ, CATEGORIA_PRODUCTO_FJ, STOCK_PRODUCTO_FJ, MARCA_PRODUCTO_FJ) " +
                        "VALUES (@nombreProducto, @valorNetoProducto,@valorIvaProducto,@valorTotalProducto,@desProducto,@categoriaProducto,@stockProducto,@marcaProducto)";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.Add(new SQLiteParameter("@nombreProducto", _prod.nombreProducto));
                    cmd.Parameters.Add(new SQLiteParameter("@valorNetoProducto", _prod.valorNetoProducto));
                    cmd.Parameters.Add(new SQLiteParameter("@valorIvaProducto", _prod.valorIvaProducto));
                    cmd.Parameters.Add(new SQLiteParameter("@valorTotalProducto", _prod.valorTotalProducto));
                    cmd.Parameters.Add(new SQLiteParameter("@desProducto", _prod.desAdicionalProducto));
                    cmd.Parameters.Add(new SQLiteParameter("@categoriaProducto", _prod.categoriaProducto));
                    cmd.Parameters.Add(new SQLiteParameter("@stockProducto", _prod.stockProducto));
                    cmd.Parameters.Add(new SQLiteParameter("@marcaProducto", _prod.marcaProducto));
                    cmd.CommandType = System.Data.CommandType.Text;

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        _mensaje = "Producto " + _prod.nombreProducto  + " Insertado Correctamente" ;
                        resp = true;
                    }
                }
                insertControlLogs(_mensaje);
                return resp;
            }
            catch (Exception ex)
            {
                insertControlLogs(ex.Message.ToString());
                throw ex;
            }

        }

        public bool setUpdateProducto(ProductosBO _prod)
        {
            try
            {
                string _mensaje = "Error al modificar producto";
                bool resp = false;
                using (SQLiteConnection conn = new SQLiteConnection(stringConn))
                {
                    conn.Open();
                    string query = "UPDATE Productos_FJ SET " +
                                   "NOMBRE_PRODUCTO_FJ = @nombreProducto," +
                                   "VALOR_NETO_PRODUCTO_FJ = @valorNetoProducto, " +
                                   "VALOR_IVA_PRODUCTO_FJ = @valorIvaProducto ," +
                                   "VALOR_TOTAL_PRODUCTO_FJ = @valorTotalProducto ," +
                                   "DES_ADICIONAL_PRODUCTO_FJ = @desProducto ," +
                                   "CATEGORIA_PRODUCTO_FJ = @categoriaProducto ," +
                                   "STOCK_PRODUCTO_FJ = @stockProducto," +
                                   "MARCA_PRODUCTO_FJ = @marcaProducto " +
                                   "WHERE ID_PRODUCTO_FJ = @idProducto";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.Add(new SQLiteParameter("@idProducto", _prod.idProducto));
                    cmd.Parameters.Add(new SQLiteParameter("@nombreProducto", _prod.nombreProducto));
                    cmd.Parameters.Add(new SQLiteParameter("@valorNetoProducto", _prod.valorNetoProducto));
                    cmd.Parameters.Add(new SQLiteParameter("@valorIvaProducto", _prod.valorIvaProducto));
                    cmd.Parameters.Add(new SQLiteParameter("@valorTotalProducto", _prod.valorTotalProducto));
                    cmd.Parameters.Add(new SQLiteParameter("@desProducto", _prod.desAdicionalProducto));
                    cmd.Parameters.Add(new SQLiteParameter("@categoriaProducto", _prod.categoriaProducto));
                    cmd.Parameters.Add(new SQLiteParameter("@stockProducto", _prod.stockProducto));
                    cmd.Parameters.Add(new SQLiteParameter("@marcaProducto", _prod.marcaProducto));

                    cmd.CommandType = System.Data.CommandType.Text;

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        _mensaje = "Producto " + _prod.nombreProducto + " Modificado Correctamente";
                        resp = true;
                    }
                }
                insertControlLogs(_mensaje);
                return resp;
            }
            catch (Exception ex)
            {
                insertControlLogs(ex.Message.ToString());
                throw ex;
            }

        }

        public bool setDeleteProducto(string _idProd)
        {
            try
            {
                string _mensaje = "Error al eliminar producto";
                bool resp = false;
                using (SQLiteConnection conn = new SQLiteConnection(stringConn))
                {
                    conn.Open();
                    string query = "DELETE FROM Productos_FJ WHERE ID_PRODUCTO_FJ = @idProducto";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.Add(new SQLiteParameter("@idProducto", _idProd));
                    cmd.CommandType = System.Data.CommandType.Text;
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        _mensaje = "Producto " + _idProd + " Eliminado";
                        resp = true;
                    }
                }
                insertControlLogs(_mensaje);
                return resp;
            }
            catch (Exception ex)
            {
                insertControlLogs(ex.Message.ToString());
                throw ex;
            }
        }

        public List<UsuarioBO> getListaUsuarios()
        {
            try
            {
                List<UsuarioBO> listUsuarios = new List<UsuarioBO>();
                using (SQLiteConnection conn = new SQLiteConnection(stringConn))
                {
                    conn.Open();
                    string query = "SELECT U.*, R.NOM_TIPO_ROL FROM Usuarios_FJ AS U LEFT JOIN Tipo_Rol AS R ON U.ROL_USUARIO_FJ = R.ID_TIPO_ROL";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listUsuarios.Add(new UsuarioBO()
                            {
                                idUsuario = int.Parse(dr["ID_USUARIO_FJ"].ToString()),
                                usuario = dr["USUARIO_FJ"].ToString(),
                                nombreUsuario = dr["NOMBRE_USUARIO_FJ"].ToString(),
                                apellidoUsuario = dr["APELLIDO_USUARIO_FJ"].ToString(),
                                mailUsuario = dr["MAIL_USUARIO_FJ"].ToString(),
                                idRol = int.Parse(dr["ROL_USUARIO_FJ"].ToString()),
                                nomTipoRol = dr["NOM_TIPO_ROL"].ToString(),
                            });
                        }
                    }
                }

                return listUsuarios;
            }
            catch (Exception ex)
            {
                insertControlLogs(ex.Message.ToString());
                throw ex;
            }

        }
        public bool setDeleteUsuario(string _idUsuario)
        {
            try
            {
                string _mensaje = "Error al Eliminar usuario";
                bool resp = false;
                using (SQLiteConnection conn = new SQLiteConnection(stringConn))
                {
                    conn.Open();
                    string query = "DELETE FROM Usuarios_FJ WHERE ID_USUARIO_FJ = @idUsuario";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.Add(new SQLiteParameter("@idUsuario", _idUsuario));
                    cmd.CommandType = System.Data.CommandType.Text;
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        _mensaje = "Usuario " + _idUsuario + " Eliminado";
                        resp = true;
                    }
                }
                insertControlLogs(_mensaje);
                return resp;
            }
            catch (Exception ex)
            {
                insertControlLogs(ex.Message.ToString());
                throw ex;
            }

        }


        public bool setInsertaUsuario(UsuarioBO _usuario)
        {
            try
            {
                string _mensaje = "Error al insertar usuario";
                bool resp = false;
                using (SQLiteConnection conn = new SQLiteConnection(stringConn))
                {
                    conn.Open();
                    string query = "INSERT INTO Usuarios_FJ (USUARIO_FJ, NOMBRE_USUARIO_FJ, APELLIDO_USUARIO_FJ, MAIL_USUARIO_FJ, PASS_USUARIO_FJ, ROL_USUARIO_FJ) " +
                        "VALUES (@usuario, @nombreUsuario,@apellidoUsuario,@mailUsuario,@passUsuario,@rolUsuario)";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.Add(new SQLiteParameter("@usuario", _usuario.usuario));
                    cmd.Parameters.Add(new SQLiteParameter("@nombreUsuario", _usuario.nombreUsuario));
                    cmd.Parameters.Add(new SQLiteParameter("@apellidoUsuario", _usuario.apellidoUsuario));
                    cmd.Parameters.Add(new SQLiteParameter("@mailUsuario", _usuario.mailUsuario));
                    cmd.Parameters.Add(new SQLiteParameter("@passUsuario", _usuario.passUsuario));
                    cmd.Parameters.Add(new SQLiteParameter("@rolUsuario", _usuario.idRol));
                    cmd.CommandType = System.Data.CommandType.Text;
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        _mensaje = "Usuario " + _usuario.usuario + " registrado";
                         resp = true;
                    }
                }
                insertControlLogs(_mensaje);
                return resp;
            }
            catch (Exception ex)
            {
                
                insertControlLogs(ex.Message.ToString());
                throw ex;
            }

        }


        public bool setUpdateUsuario(UsuarioBO _usuario)
        {
            try
            {
                string _mensaje = "Error al modificar usuario";
                bool resp = false;
                using (SQLiteConnection conn = new SQLiteConnection(stringConn))
                {
                    conn.Open();
                    string query = "UPDATE Usuarios_FJ SET " +
                                   "USUARIO_FJ = @usuario," +
                                   "NOMBRE_USUARIO_FJ = @nombreUsuario, " +
                                   "APELLIDO_USUARIO_FJ = @apellidoUsuario ," +
                                   "MAIL_USUARIO_FJ = @mailUsuario ," +
                                   "PASS_USUARIO_FJ = @passUsuario ," +
                                   "ROL_USUARIO_FJ = @rolUsuario " +
                                   "WHERE ID_USUARIO_FJ = @idUsuario";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.Add(new SQLiteParameter("@usuario", _usuario.usuario));
                    cmd.Parameters.Add(new SQLiteParameter("@nombreUsuario", _usuario.nombreUsuario));
                    cmd.Parameters.Add(new SQLiteParameter("@apellidoUsuario", _usuario.apellidoUsuario));
                    cmd.Parameters.Add(new SQLiteParameter("@mailUsuario", _usuario.mailUsuario));
                    cmd.Parameters.Add(new SQLiteParameter("@passUsuario", _usuario.passUsuario));
                    cmd.Parameters.Add(new SQLiteParameter("@rolUsuario", _usuario.idRol));
                    cmd.Parameters.Add(new SQLiteParameter("@idUsuario", _usuario.idUsuario));

                    cmd.CommandType = System.Data.CommandType.Text;

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        _mensaje = "Usuario " + _usuario.usuario + " modificado";
                        resp = true;
                    }
                }
                insertControlLogs(_mensaje);
                return resp;
            }
            catch (Exception ex)
            {
                insertControlLogs(ex.Message.ToString());
                throw ex;
            }

        }

        public void insertControlLogs(string _mensaje)
        {
            string fechaActual = DateTime.Today.ToString();
            using (SQLiteConnection conn = new SQLiteConnection(stringConn))
            {
                conn.Open();
                string query = "INSERT INTO Logs_FJ (FECHA_LOGS_FJ, DESCRIPCION_LOGS_FJ) VALUES (@fechaLog, @desLog)";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.Add(new SQLiteParameter("@fechaLog", fechaActual));
                cmd.Parameters.Add(new SQLiteParameter("@desLog", _mensaje));
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();

            }
        }
    }
}
