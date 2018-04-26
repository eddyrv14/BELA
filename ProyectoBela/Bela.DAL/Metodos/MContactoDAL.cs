using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bela.DAL.Interfaces;
using System.Data;
using ServiceStack.OrmLite;
using Bela.Datos;
using System.Data.SqlClient;



namespace Bela.DAL.Metodos
{
    public class MContactoDal : IContacto
    {


        private OrmLiteConnectionFactory _conex;
        private IDbConnection _db;
        private SqlConnection cn;

        public MContactoDal()
        {
            cn = new SqlConnection(BD.Default.conexion);
            _conex = new OrmLiteConnectionFactory(BD.Default.conexion, SqlServerDialect.Provider);
            _db = _conex.Open();
        }


        public string EnvioMensaje(MensajeContacto mensaje)
        {
           

            string res = "";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insertarMensaje";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@correo", 45).Value =mensaje.correo;
                cmd.Parameters.Add("@asunto", 60).Value = mensaje.asunto;
                cmd.Parameters.Add("@mensaje", 200).Value =mensaje.mensaje;
                res = cmd.ExecuteNonQuery() == 1 ? "Correo enviado" : "Error al enviar";

            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        }


        public List<MensajeContacto> listaMensajes()
        {
            return _db.Select<MensajeContacto>();
        }
    }
}

