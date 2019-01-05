using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetMeGenNHibernate.EN.PetMe;
using PetMeGenNHibernate.Enumerated.PetMe;


namespace PetMeUI.Models
{
    public class AssemblerComentario
    {
        public ComentarioViewModel ConvertENToModelUI(ComentarioEN en)
        {
            ComentarioViewModel comen = new ComentarioViewModel();
            comen.Usuario = new UsuarioEN();

            comen.Id = en.Id;
            comen.Comentario = en.Comentario;
            comen.Valoracion = en.Valoracion;
            comen.Usuario = en.Usuario_comen;
            comen.Anuncio = en.Anuncio.Id;
            

            return comen;


        }
        public IList<ComentarioViewModel> ConvertListENToModel(IList<ComentarioEN> ens)
        {
            IList<ComentarioViewModel> comens = new List<ComentarioViewModel>();
            foreach (ComentarioEN en in ens)
            {
                comens.Add(ConvertENToModelUI(en));
            }
            return comens;
        }
    }
}