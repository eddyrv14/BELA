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
using System.Configuration;

namespace Bela.DAL.Metodos
{
    public class MAdminDal : IAdmin
    {

        private OrmLiteConnectionFactory _conex;
        private IDbConnection _db;
        public SqlConnection cn;
        string conexionSql = BD.Default.conexion;

        public MAdminDal()
        {
            cn = new SqlConnection(BD.Default.conexion);
            _conex = new OrmLiteConnectionFactory(BD.Default.conexion, SqlServerDialect.Provider);
        }

        public List<Rol> ListaRoles()
        {
            _db = _conex.Open();
            var re = _db.Select<Rol>();
            _db.Close();
            return re;

            //var listaRoles = new List<Rol>();


            //using (cn)
            //{
            //    cn.Open();
            //    SqlCommand cmd = new SqlCommand("listaRoles", cn);
            //    cmd.CommandType = CommandType.StoredProcedure;

            //    SqlDataReader rdr = cmd.ExecuteReader();

            //    while (rdr.Read())
            //    {
            //        var rol = new Rol();
            //        rol.idRol = Convert.ToInt32(rdr["idRol"]);
            //        rol.nombre = rdr["nombre"].ToString();
            //        listaRoles.Add(rol);
            //    }
            //}

            //return listaRoles;
        }

        public List<Seccion> ListaSecciones()
        {
            _db = _conex.Open();
            var re = _db.Select<Seccion>();
            _db.Close();
            return re;

            //var listaSecciones = new List<Seccion>();

            //using (cn)
            //{
            //    cn.Open();
            //    SqlCommand cmd = new SqlCommand("listaSecciones", cn);
            //    cmd.CommandType = CommandType.StoredProcedure;

            //    SqlDataReader rdr = cmd.ExecuteReader();

            //    while (rdr.Read())
            //    {
            //        var seccion = new Seccion();
            //        seccion.idSeccion = Convert.ToInt32(rdr["idSeccion"]);
            //        seccion.nombre = rdr["nombre"].ToString();
            //        listaSecciones.Add(seccion);
            //    }
            //}

            //return listaSecciones;


        }

        public List<Materia> ListaMaterias()
        {
            _db = _conex.Open();
            var re = _db.Select<Materia>();
            _db.Close();
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
                cmd.Parameters.Add("@cedula", SqlDbType.VarChar, 20).Value = persona.cedula;
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

        public void InsertarEstudianteSeccion(int idSeccion)
        {
            _db = _conex.Open();
            _db.SqlScalar<EstudianteSeccion>("EXEC crearEstudianteSeccion @idSeccion", new { idSeccion = idSeccion });
            _db.Close();
        }


        public List<Usuario> ListaUsuarios()
        {
            _db = _conex.Open();
            var re = _db.SqlList<Usuario>("EXEC listaUsuarios").ToList();
            _db.Close();
            return re;
        }


        public Usuario BuscarCuenta(int idPersona)
        {
            _db = _conex.Open();
            var re = _db.SqlList<Usuario>("EXEC buscarCuenta @idUsuario", new { idUsuario = idPersona }).FirstOrDefault();
            _db.Close();
            return re;
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
                cmd.Parameters.Add("@cedula", SqlDbType.VarChar, 20).Value = usuario.cedula;
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


        public void ModificarEstudianteSeccion(int idUsuario, int idSeccion)
        {
            _db = _conex.Open();
            _db.SqlScalar<EstudianteSeccion>("EXEC modificarEstudianteSeccion @idUsuario,@idSeccion", new { idUsuario = idUsuario, idSeccion = idSeccion });
            _db.Close();
        }




        public string EliminarCuenta(int idUsuario)
        {
            string res = "";
            _db.Delete<EstudianteSeccion>(x => x.idUsuario == idUsuario);

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


        public string AgregarMateriaProf(int idMateria, int idUsuario, int idSeccion)
        {
            string res = "";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "agregarDetalleMateria";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idMateria", SqlDbType.Int).Value = idMateria;
                cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
                cmd.Parameters.Add("@idSeccion", SqlDbType.Int).Value = idSeccion;

                res = cmd.ExecuteNonQuery() == 1 ? "MateriaDetaAgre" : "Error al agregar";

                if (res.Equals("MateriaDetaAgre"))
                {
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = cn;
                    cmd2.CommandText = "agregarMateriaPro";
                    cmd2.CommandType = CommandType.StoredProcedure;

                    cmd2.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;

                    res = cmd2.ExecNonQuery() == 1 ? "MateriaAgregada" : "Error al agregar";
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


        public List<MateriaProf> ListaMateriasProf(int idUsuario)
        {
            //Por error de cuota ormlite
            //var re= _db.SqlList<MateriaProf>("EXEC buscarMateriaDetaProf @idProfesor", new { idProfesor = idUsuario }).ToList();
            //return re;

            var listaMateriasProf = new List<MateriaProf>();

            using (cn = new SqlConnection(conexionSql))
            {
                SqlCommand cmd = null;
                try
                {
                    cn.Open();
                    cmd = new SqlCommand("buscarMateriaDetaProf", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paridDetalleMateria = new SqlParameter();
                    paridDetalleMateria.ParameterName = ("@idProfesor");
                    paridDetalleMateria.SqlDbType = SqlDbType.Int;
                    paridDetalleMateria.Value = idUsuario;
                    cmd.Parameters.Add(paridDetalleMateria);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        var materia = new MateriaProf();
                        materia.idPrMa = Convert.ToInt32(rdr["idPrMa"]);
                        materia.idUsuario = Convert.ToInt32(rdr["idUsuario"]);
                        materia.nomMateria = rdr["nomMateria"].ToString();
                        materia.nomSeccion = rdr["nomSeccion"].ToString();
                        listaMateriasProf.Add(materia);
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    cmd = null;
                    if (cn != null)
                    {
                        cn.Close();
                    }
                }

            }

            return listaMateriasProf;
        }

        public string EliminarMateriaProf(int idMateriaPr)
        {
            string res = "";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "eliminarMateriaPro";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idMateria", SqlDbType.Int).Value = idMateriaPr;
                res = cmd.ExecuteNonQuery() == 1 ? "Materia eliminada" : "Error al eliminar";
            }
            catch (Exception ex)
            {
                res = ex.Message;
                cn.Close();
            }
            cn.Close();
            return res;

        }


        public List<EstudianteSeccionDeta> ListaEstudiantes()
        {
            var listaEstudiantes = new List<EstudianteSeccionDeta>();

            using (cn)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("listaEstudiantesSeccion", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var estudiante = new EstudianteSeccionDeta();
                    estudiante.idUsuario = Convert.ToInt32(rdr["idUsuario"]);
                    estudiante.nombre = rdr["nombre"].ToString();
                    estudiante.apellido1 = rdr["apellido1"].ToString();
                    estudiante.apellido2 = rdr["apellido2"].ToString();
                    estudiante.cedula = rdr["cedula"].ToString();
                    estudiante.Seccion = rdr["Seccion"].ToString();
                    listaEstudiantes.Add(estudiante);
                }
                cn.Close();
            }

            return listaEstudiantes;

        }
    }
}
