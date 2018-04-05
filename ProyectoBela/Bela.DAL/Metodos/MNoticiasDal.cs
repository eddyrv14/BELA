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
            _db = _conex.Open();

        }

        public List<Noticia> listaNoticias()
        {
            var re = _db.SqlList<Noticia>("EXEC listaNoticiasPublicas").ToList();
            return re;
        }

        public List<Noticia> listaNoticiasInternas()
        {
            var re = _db.SqlList<Noticia>("EXEC listaNoticiasInternas").ToList();
            return re;
        }

        public List<Noticia> ultimasNoticias()
        {
            var re = _db.SqlList<Noticia>("EXEC ultimasNoticias").ToList();
            return re;
        }

        public void insertarNoticia(Noticia noticia)
        {
            _db.SqlScalar<Noticia>("EXEC crearNoticia @idAdmin,@idTipo,@titulo,@descripcion,@contenido,@imagen,@fechaHora",
                new { idAdmin = noticia.idUsuario, idTipo = noticia.idtipo, titulo = noticia.titulo, descripcion = noticia.descripcion, contenido = noticia.contenido, imagen = noticia.imagen, fechaHora = noticia.fechaYHora });
        }

        public void insertarImagenesAdicionales(string imagenes)
        {
            _db.SqlScalar<ImagenNoticia>("EXEC insertarImagenes @imagenes", new { imagenes = imagenes });
        }


        public NoticiaDetalles buscarNoticiaDetalle(int idNoticia)
        {
            var re = _db.SqlList<NoticiaDetalles>("EXEC detalleNoticia @idNoticia", new { idNoticia = idNoticia }).FirstOrDefault();
            return re;
        }

        public Noticia buscarNoticia(int idNoticia)
        {
            return _db.Select<Noticia>(x => x.idNoticia == idNoticia).FirstOrDefault();
        }


        public List<TipoNoticia> listaTipoNoticias()
        {

            return _db.Select<TipoNoticia>();
        }


        public List<ImagenNoticia> listaImagenesNoticia(int idNoticia)
        {
            return _db.Select<ImagenNoticia>(x => x.idNoticia == idNoticia);
        }


        public List<Noticia> ListaNoticiasAdmin(int idAdmin)
        {
            return _db.Select<Noticia>(x => x.idUsuario == idAdmin).OrderByDescending(x => x.idNoticia).ToList();
        }

        public string EliminarNoticia(int idNoticia)
        {
            throw new NotImplementedException();
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