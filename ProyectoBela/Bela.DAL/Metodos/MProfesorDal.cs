using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using System.Data;
using System.Data.SqlClient;
using Bela.DAL.Interfaces;
using Bela.Datos;

namespace Bela.DAL.Metodos
{
   public  class MProfesorDal:IProfesor
    {
        private OrmLiteConnectionFactory _conex;
        private IDbConnection _db;
        private SqlConnection cn;

        public MProfesorDal()
        {
            cn = new SqlConnection(BD.Default.conexion);
            _conex = new OrmLiteConnectionFactory(BD.Default.conexion, SqlServerDialect.Provider);
            _db = _conex.Open();
        }


        public string crearMaterial(DetalleMaterial material)
        {
            string res = "";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insertarMaterial";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idUsuario", SqlDbType.Int).Value = material.idUsuario;
                cmd.Parameters.Add("@idDetalleMateria", SqlDbType.Int).Value = material.idDetalleMateria;
                cmd.Parameters.Add("titulo", 50).Value = material.titulo;
                cmd.Parameters.Add("mensaje", 300).Value = material.mensaje;
                cmd.Parameters.Add("material", 100).Value = material.material;
                cmd.Parameters.Add("nombreMaterial", 100).Value = material.nombreMaterial;
                cmd.Parameters.Add("fechaHora", SqlDbType.DateTime).Value = material.fechaHora;
                res = cmd.ExecuteNonQuery() == 1 ? "Material agregado" : "Error al agregar";
            }
            catch (Exception e)
            {
                res = e.Message;
            }
            return res;
        
        }


        public List<Datos.MateriaDeta> ListaMaterialesProfesores(int idUsuario)
        {
            var re = _db.SqlList<MateriaDeta>("EXEC listaMateriasProfesor @idUsuario", new { @idUsuario = idUsuario }).ToList();
            return re;
        }


        public MateriaDeta BuscarMateria(int idMateria)
        {
            var re = _db.SqlList<MateriaDeta>("EXEC buscarMateria @idMateria", new { @idMateria = idMateria }).FirstOrDefault();
            return re;
        }


        public void AgregarMaterialesAdicionales(string material, string nombreMaterial)
        {
            _db.SqlScalar<MasMaterial>("EXEC insertarMaterialesAdicionales @material,@nombreMaterial", new { material=material,nombreMaterial=nombreMaterial });
        }


        public List<MasMaterial> ListaMaterialesAdicionales(int idMaterial)
        {
            return _db.Select<MasMaterial>(x => x.idMaterial == idMaterial).ToList();
        }
    }
}
