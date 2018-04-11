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
    public class MUsuarioDal : IUsuario
    {
        private OrmLiteConnectionFactory _conex;
        private IDbConnection _db;
        private SqlConnection cn;

        public MUsuarioDal()
        {
            _conex = new OrmLiteConnectionFactory(BD.Default.conexion, SqlServerDialect.Provider);
            _db = _conex.Open();
            cn = new SqlConnection(BD.Default.conexion);

        }

        public Usuario Login(string usuario, string contrasena)
        {
            var re = _db.SqlList<Usuario>("EXEC login @usuario,@contrasena", new { usuario = usuario, contrasena = contrasena }).FirstOrDefault();
            return re;
        }


        public List<Rol> ListaRoles()
        {
            var re = _db.Select<Rol>();
            return re;
        }

        public string InsertPersona(Usuario persona)
        {
            string res = "";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "crearPersona";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 60).Value = persona.nombre;
                cmd.Parameters.Add("@apellido1", SqlDbType.VarChar, 60).Value = persona.apellido1;
                cmd.Parameters.Add("@apellido2", SqlDbType.VarChar, 60).Value = persona.apellido2;
                cmd.Parameters.Add("@correo", SqlDbType.VarChar, 60).Value = persona.correo;


                res = cmd.ExecuteNonQuery() == 1 ? "Persona agregada" : "Error al agregar";

                if (res.Equals("Persona agregada"))
                {
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = cn;
                    cmd2.CommandText = "crearUsuario";
                    cmd2.CommandType = CommandType.StoredProcedure;


                    cmd2.Parameters.Add("@idRol", SqlDbType.Int).Value = persona.rol;
                    cmd2.Parameters.Add("@usuario", SqlDbType.VarChar, 30).Value = persona.usuario;
                    cmd2.Parameters.Add("@contrasena", SqlDbType.VarChar, 30).Value = persona.contrasena;
                    res = cmd2.ExecNonQuery() == 1 ? "Usuario creado" : "Error al crear cuenta";
                }


            }
            catch (Exception ex)
            {
                res = ex.Message;
                cn.Close();
            }
            cn.Close();
            return res;

        }

        public List<Usuario> ListaUsuarios()
        {
            return _db.SqlList<Usuario>("EXEC listaUsuarios").ToList();
        }

        public Usuario BuscarCuenta(int idPersona)
        {
            return _db.SqlList<Usuario>("EXEC buscarCuenta @idUsuario", new { idUsuario = idPersona }).FirstOrDefault();
        }

        public string ModificarCuenta(Usuario usuario)
        {
            string res = "";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "modificarPersona";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idPersona", SqlDbType.Int).Value = usuario.idPersona;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 60).Value = usuario.nombre;
                cmd.Parameters.Add("@apellido1", SqlDbType.VarChar, 60).Value = usuario.apellido1;
                cmd.Parameters.Add("@apellido2", SqlDbType.VarChar, 60).Value = usuario.apellido2;
                cmd.Parameters.Add("@correo", SqlDbType.VarChar, 60).Value = usuario.correo;


                res = cmd.ExecuteNonQuery() == 1 ? "Persona modificada" : "Error al agregar";

                if (res.Equals("Persona modificada"))
                {
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = cn;
                    cmd2.CommandText = "modificarUsuario";
                    cmd2.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = usuario.idUsuario;
                    cmd2.Parameters.Add("@idRol", SqlDbType.Int).Value = usuario.rol;
                    cmd2.Parameters.Add("@usuario", SqlDbType.VarChar, 30).Value = usuario.usuario;
                    cmd2.Parameters.Add("@contrasena", SqlDbType.VarChar, 30).Value = usuario.contrasena;
                    res = cmd2.ExecNonQuery() == 1 ? "Usuario modificado" : "Error al modificar cuenta";
                }


            }
            catch (Exception ex)
            {
                res = ex.Message;
                cn.Close();
            }
            cn.Close();
            return res;
        }

        public string EliminarCuenta(int idUsuario)
        {
            string res = "";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "eliminarUsuario";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                res = cmd.ExecuteNonQuery() == 1 ? "Usuario eliminado" : "Error al eliminar";

                if (res.Equals("Usuario eliminado"))
                {
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = cn;
                    cmd2.CommandText = "eliminarPersona";
                    cmd2.CommandType = CommandType.StoredProcedure;

                    cmd2.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

                    res = cmd2.ExecNonQuery() == 1 ? "Cuenta eliminada" : "Error al eliminar cuenta";
                }


            }
            catch (Exception ex)
            {
                res = ex.Message;
                cn.Close();
            }
            cn.Close();
            return res;
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

        public List<NotiInternas> ListaCorreoNotiInternas()
        {
            return _db.Select<NotiInternas>().ToList();
        }
    }
}

