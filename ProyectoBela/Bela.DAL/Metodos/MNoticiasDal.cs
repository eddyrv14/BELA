using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using System.Data;
using Bela.DAL.Interfaces;
using Bela.Datos;
using System.Data.SqlClient;

namespace Bela.DAL.Metodos
{
    public class MNoticiasDal : INoticia
    {

        private OrmLiteConnectionFactory _conex;
        private IDbConnection _db;
        private SqlConnection cn;

        public MNoticiasDal()
        {
            cn = new SqlConnection(BD.Default.conexion);
            _conex = new OrmLiteConnectionFactory(BD.Default.conexion, SqlServerDialect.Provider);
        }



        public List<Noticia> listaNoticias()
        {
            //var re = _db.SqlList<Noticia>("EXEC listaNoticiasPublicas").ToList();
            //return re;

            var listaNoticiasPublicas = new List<Noticia>();

            using (cn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("listaNoticiasPublicas", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var noticia = new Noticia();
                    noticia.idNoticia = Convert.ToInt32(rdr["idNoticia"]);
                    noticia.idtipo = Convert.ToInt32(rdr["idTipo"]);
                    noticia.descripcion = rdr["descripcion"].ToString();
                    noticia.imagen = rdr["imagen"].ToString();
                    noticia.fechaYHora = Convert.ToDateTime(rdr["fechaYHora"]);

                    listaNoticiasPublicas.Add(noticia);
                    
                }
                cn.Close();
            }

            return listaNoticiasPublicas;
        }

        public List<Noticia> listaNoticiasInternas()
        {
            _db = _conex.Open();
            var re = _db.SqlList<Noticia>("EXEC listaNoticiasInternas").ToList();
            _db.Close();
            return re;
        }

        public List<Noticia> ultimasNoticias()
        {
            //var re = _db.SqlList<Noticia>("EXEC ultimasNoticias").ToList();
            //return re;

            var UltimasNoticiasPublicas = new List<Noticia>();

            using (cn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("ultimasNoticias", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var noticia = new Noticia();
                    noticia.idNoticia = Convert.ToInt32(rdr["idNoticia"]);
                    noticia.idtipo = Convert.ToInt32(rdr["idTipo"]);
                    noticia.descripcion = rdr["descripcion"].ToString();
                    noticia.imagen = rdr["imagen"].ToString();
                    noticia.fechaYHora = Convert.ToDateTime(rdr["fechaYHora"]);

                    UltimasNoticiasPublicas.Add(noticia);
                   
                }
                cn.Close();
            }

            return UltimasNoticiasPublicas;
        }

        public void insertarNoticia(Noticia noticia)
        {
            _db = _conex.Open();
            _db.SqlScalar<Noticia>("EXEC crearNoticia @idAdmin,@idTipo,@titulo,@descripcion,@contenido,@imagen,@fechaHora",
                new { idAdmin = noticia.idUsuario, idTipo = noticia.idtipo, titulo = noticia.titulo, descripcion = noticia.descripcion, contenido = noticia.contenido, imagen = noticia.imagen, fechaHora = noticia.fechaYHora });
            _db.Close();
        }

        public void insertarImagenesAdicionales(string imagenes)
        {
            _db = _conex.Open();
            _db.SqlScalar<ImagenNoticia>("EXEC insertarImagenes @imagenes", new { imagenes = imagenes });
            _db.Close();
        }


        public NoticiaDetalles buscarNoticiaDetalle(int idNoticia)
        {
            _db = _conex.Open();
            var re = _db.SqlList<NoticiaDetalles>("EXEC detalleNoticia @idNoticia", new { idNoticia = idNoticia }).FirstOrDefault();
            _db.Close();
            return re;
        }

        public Noticia buscarNoticia(int idNoticia)
        {
            _db = _conex.Open();
            var re=_db.Select<Noticia>(x => x.idNoticia == idNoticia).FirstOrDefault();
            _db.Close();
            return re;
        }


        public List<TipoNoticia> listaTipoNoticias()
        {
            _db = _conex.Open();
            var re=_db.Select<TipoNoticia>();
            _db.Close();
            return re;
        }


        public List<ImagenNoticia> listaImagenesNoticia(int idNoticia)
        {
            _db = _conex.Open();
            var re=_db.Select<ImagenNoticia>(x => x.idNoticia == idNoticia);
            _db.Close();
            return re;
        }


        public List<Noticia> ListaNoticiasAdmin(int idAdmin)
        {
            _db = _conex.Open();
            var re = _db.Select<Noticia>(x => x.idUsuario == idAdmin).OrderByDescending(x => x.idNoticia).ToList();
            _db.Close();
            return re;
        }

        public string EliminarNoticia(int idNoticia)
        {
            string res = "";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "eliminarImagenNoticia";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idNoticia", SqlDbType.Int).Value = idNoticia;
                res = cmd.ExecuteNonQuery() == 1 ? "Imagenes eliminadas" : "Error al eliminar";


                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = cn;
                cmd2.CommandText = "eliminarNoticia";
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add("@idNoticia", SqlDbType.Int).Value = idNoticia;
                res = cmd2.ExecuteNonQuery() == 1 ? "Noticia eliminada" : "Error al eliminar";

            }
            catch (Exception e)
            {
                cn.Close();
                res = e.Message;
            }
            cn.Close();
            return res;
        }

        public string ModificarNoticia(Noticia noticia)
        {
            string res = "";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "modificarNoticia";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("idNoticia", SqlDbType.Int).Value = noticia.idNoticia;
                cmd.Parameters.Add("@idTipo", SqlDbType.Int).Value = noticia.idtipo;
                cmd.Parameters.Add("@titulo", SqlDbType.VarChar, 60).Value = noticia.titulo;
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 60).Value = noticia.descripcion;
                cmd.Parameters.Add("@contenido", SqlDbType.VarChar, 60).Value = noticia.contenido;
                cmd.Parameters.Add("@imagen", SqlDbType.VarChar, 60).Value = noticia.imagen;


                res = cmd.ExecuteNonQuery() == 1 ? "Noticia modificada" : "Error al modificar";

            }
            catch (Exception ex)
            {
                res = ex.Message;
                cn.Close();
            }
            cn.Close();
            return res;

        }


    }
}
