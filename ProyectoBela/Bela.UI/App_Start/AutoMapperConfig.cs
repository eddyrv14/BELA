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
                cfg.CreateMap<Models.Usuario, Bela.Datos.Usuario>();

                //// Selects
                cfg.CreateMap<Bela.Datos.MensajeContacto, Models.MensajeContacto>();
                cfg.CreateMap<Bela.Datos.Noticia, Models.Noticia>();
                cfg.CreateMap<Bela.Datos.NoticiaDetalles, Models.NoticiaDetalles>();
                cfg.CreateMap<Bela.Datos.Usuario, Models.Usuario>();
            });
        }

    }


}

