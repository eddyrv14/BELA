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
    public class MMaterialDal : IMaterial
    {

        private OrmLiteConnectionFactory _conex;
        private IDbConnection _db;
        //private SqlConnection cn;

        public MMaterialDal()
        {
            //cn = new SqlConnection(BD.Default.conexion);
            _conex = new OrmLiteConnectionFactory(BD.Default.conexion, SqlServerDialect.Provider);
            _db = _conex.Open();
        }


        public List<DetalleMaterial> ListaMateriales(int idDetalleMateria)
        {
            var re = _db.SqlList<DetalleMaterial>("EXEC listaMaterialesMateria @idDetalleMateria", new { idDetalleMateria = idDetalleMateria }).ToList();
            return re;
            //var lista = new List<DetalleMaterial>();

            //SqlCommand cmd = new SqlCommand("listaMaterialesMateria", cn);
            //cmd.CommandType = CommandType.StoredProcedure;

            //SqlParameter paridDetalleMateria = new SqlParameter();
            //paridDetalleMateria.ParameterName = ("@idDetallemateria");
            //paridDetalleMateria.SqlDbType = SqlDbType.Int;
            //paridDetalleMateria.Value = idDetalleMateria;
            //cmd.Parameters.Add(paridDetalleMateria);


            //using (cn)
            //{
            //    using (cmd)
            //    {
            //        cn.Open();
            //        using (SqlDataReader reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                var material = new DetalleMaterial();
            //                material.idMaterial = Convert.ToInt32(reader["idMaterial"]);
            //                material.idUsuario = Convert.ToInt32(reader["idUsuario"]);
            //                lista.Add(material);
            //            }
            //        }
            //    }
            //    cn.Close();
            //    return lista;
            
        }




        public DetalleMaterial BuscarMaterial(int idMaterial)
        {
            var re = _db.SqlList<DetalleMaterial>("EXEC detalleMaterial @idMaterial", new { idMaterial = idMaterial }).FirstOrDefault();
            return re;
        }
    }
}
