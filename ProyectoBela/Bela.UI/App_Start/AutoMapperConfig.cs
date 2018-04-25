using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Bela.Datos;

namespace Bela.UI.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                //Inserts, Update, Deletes
                cfg.CreateMap<Models.MensajeContacto, Bela.Datos.MensajeContacto>();
                cfg.CreateMap<Models.Noticia, Bela.Datos.Noticia>();
                cfg.CreateMap<Models.NoticiaDetalles, Bela.Datos.NoticiaDetalles>();
                cfg.CreateMap<Models.Usuario, Bela.Datos.Usuario>();
                cfg.CreateMap<Models.ImagenNoticia, Bela.Datos.ImagenNoticia>();
                cfg.CreateMap<Models.MateriaDeta, Bela.Datos.MateriaDeta>();
                cfg.CreateMap<Models.DetalleMaterial, Bela.Datos.DetalleMaterial>();
                cfg.CreateMap<Models.DetalleMateria, Bela.Datos.DetalleMateria>();
                //// Selects
                cfg.CreateMap<Bela.Datos.MensajeContacto, Models.MensajeContacto>();
                cfg.CreateMap<Bela.Datos.Noticia, Models.Noticia>();
                cfg.CreateMap<Bela.Datos.NoticiaDetalles, Models.NoticiaDetalles>();
                cfg.CreateMap<Bela.Datos.Usuario, Models.Usuario>();
                cfg.CreateMap<Bela.Datos.ImagenNoticia, Models.ImagenNoticia>();
                cfg.CreateMap<Bela.Datos.MateriaDeta, Models.MateriaDeta>();
                cfg.CreateMap<Bela.Datos.DetalleMaterial, Models.DetalleMaterial>();
                cfg.CreateMap<Bela.Datos.DetalleMateria, Models.DetalleMateria>();
            });
        }

    }


}

