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

                //// Selects
                cfg.CreateMap<Bela.Datos.MensajeContacto, Models.MensajeContacto>();


            });
        }

    }


}
