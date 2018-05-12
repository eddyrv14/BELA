using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bela.Datos;
using Bela.DAL.Interfaces;
using ServiceStack.OrmLite;
using System.Data;
using System.Data.SqlClient;

namespace Bela.DAL.Metodos
{
   public class MUsuarioDal:IUsuario
    {
       private OrmLiteConnectionFactory _conex;
       private IDbConnection _db;
       private  SqlConnection cn;

       public MUsuarioDal()
       {
           cn = new SqlConnection(BD.Default.conexion);
           _conex = new OrmLiteConnectionFactory(BD.Default.conexion, SqlServerDialect.Provider);
           _db = _conex.Open();

       }

        public Usuario Login(string usuario, string contrasena)
        {
            var re = _db.SqlList<Usuario>("EXEC login @usuario,@contrasena", new { usuario = usuario,contrasena=contrasena }).FirstOrDefault();
            return re;
        }


        public string ActivarNotificaciones(string correo)
        {
            string res = "";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "agregarCorreoNotiEx";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@correo", SqlDbType.VarChar,100).Value = correo;
                res = cmd.ExecuteNonQuery() == 1 ? "Se agrego correo" : "Error al agregar";
                
            }
            catch (Exception ex)
            {
                res = ex.Message;
                cn.Close();
            }
            cn.Close();
            return res;
        }

        public string ActivarNotificacionesInternas(string correo)
        {
            string res = "";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "agregarCorreoNotiInter";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@correo", SqlDbType.VarChar, 100).Value = correo;
                res = cmd.ExecuteNonQuery() == 1 ? "Se agrego correo" : "Error al agregar";

            }
            catch (Exception ex)
            {
                res = ex.Message;
                cn.Close();
            }
            cn.Close();
            return res;

        }


        public List<NotiExternas> ListaCorreoNotiExternas()
        {
            return _db.Select<NotiExternas>().ToList();
        }


        public List<NotiInternas> ListaCorreoNotiInternas()
        {
            return _db.Select<NotiInternas>().ToList();
        }

    }
}
