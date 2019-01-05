using PetMeGenNHibernate.EN.PetMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetMeGenNHibernate.Enumerated.PetMe;


namespace PetMeUI.Models
{
    public class AssemblerUsuario
    {
        public UsuarioViewModel ConvertENToModelUI(UsuarioEN en)
        {
            UsuarioViewModel usu = new UsuarioViewModel();
            usu.AnunciosContratados_id = new List<int>();
            usu.AnunciosCreados_id = new List<int>();
            usu.ComentariosDetalles = new List<String>();
            usu.ComentariosValoraciones = new List<ValoracionEnum>();



            usu.Email = en.Email;
            usu.Nombre = en.Nombre;
            usu.Apellidos = en.Apellidos;
            usu.Nick = en.Nick;
            usu.Pass = en.Pass;
            usu.FNacimiento = en.Nacimiento.GetValueOrDefault();
            usu.Provincia = en.Provincia;
            usu.Localidad = en.Localidad;
            usu.Telefono = en.Telefono;
            usu.cartera = en.Cartera;
            usu.motivoEstado = en.MotivoEstado;
            usu.estado = en.Estado;


            foreach(var anuncio in en.Anuncios)
            {
                usu.AnunciosCreados_id.Add(anuncio.Id);
            }

            foreach (var anuncio in en.Anuncios_contratados)
            {
                usu.AnunciosContratados_id.Add(anuncio.Id);
            }

            foreach (var comentario in en.Comentarios_usuario)
            {
                usu.ComentariosDetalles.Add(comentario.Comentario);
                usu.ComentariosValoraciones.Add(comentario.Valoracion);

            }

            return usu;


        }
        public IList<UsuarioViewModel> ConvertListENToModel(IList<UsuarioEN> ens)
        {
            IList<UsuarioViewModel> usus = new List<UsuarioViewModel>();
            foreach (UsuarioEN en in ens)
            {
                usus.Add(ConvertENToModelUI(en));
            }
            return usus;
        }
    }
}