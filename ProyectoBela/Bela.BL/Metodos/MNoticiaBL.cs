using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bela.BL.Interfaces;
using Bela.Datos;
using Bela.DAL.Metodos;
using System.Text.RegularExpressions;


namespace Bela.BL.Metodos
{
   public class MNoticiaBL:INoticia
    {
        MNoticiasDal noticias = new MNoticiasDal();

        public List<Noticia> listaNoticias()
        {
            return noticias.listaNoticias();
        }

        public List<Noticia> listaNoticiasInternas()
        {
            return noticias.listaNoticiasInternas();
        }

        public List<Noticia> ultimasNoticias()
        {
            return noticias.ultimasNoticias();
        }


        public void insertarNoticia(Noticia noticia)
        {
            DateTime fecha = Convert.ToDateTime(DateTime.Now.ToString("G"));
            string limImagen = Regex.Replace(noticia.imagen, @"^[~]", "");
            noticia.fechaYHora = fecha;
            noticia.imagen = limImagen;
            noticias.insertarNoticia(noticia);
        }

        public void insertarImagenesAdicionales(string imagenes)
        {
            string limImg = Regex.Replace(imagenes, @"^[~]", "");
            noticias.insertarImagenesAdicionales(limImg);
        }

        public NoticiaDetalles buscarNoticiaDetalle(int idNoticia)
        {
            return noticias.buscarNoticiaDetalle(idNoticia);
        }

        public Noticia buscarNoticia(int idNoticia)
        {
            return noticias.buscarNoticia(idNoticia);
        }

        public List<TipoNoticia> listaTiposNoticias()
        {
            return noticias.listaTipoNoticias();
        }


        public List<ImagenNoticia> listaImagenesNoticia(int idNoticia)
        {
            return noticias.listaImagenesNoticia(idNoticia);
        }


        public List<Noticia> ListaNoticiasAdmin(int idAdmin)
        {
            return noticias.ListaNoticiasAdmin(idAdmin);
        }

        public string EliminarNoticia(int idNoticia)
        {
            return noticias.EliminarNoticia(idNoticia);
        }

        public string ModificarNoticia(Noticia noticia)
        {
            string limImagen = Regex.Replace(noticia.imagen, @"^[~]", "");
            noticia.imagen = limImagen;
            return noticias.ModificarNoticia(noticia);
        }
    }
}
