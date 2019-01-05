using PetMeGenNHibernate.CEN.PetMe;
using PetMeGenNHibernate.EN.PetMe;
using PetMeGenNHibernate.Enumerated.PetMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetMeUI.Models
{
    public class AssemblerAnuncio
    {
        public AnuncioViewModel ConvertENToModelUI(AnuncioEN en)
        {
            AnuncioViewModel anu = new AnuncioViewModel();
            anu.Comentarios = new List<ComentarioEN>();
            anu.Cuidador = new UsuarioEN();
            anu.Contratante = new UsuarioEN();
            anu.TA_id = new List<int>();
            anu.TA_tarifa = new List<Double>();
            anu.TA_tipo = new List<String>();
            anu.ComentariosDetalles = new List<String>();
            anu.ComentariosValoraciones = new List<ValoracionEnum>();



            anu.FechaIni = en.FechaIni.GetValueOrDefault();
            anu.FechaFin = en.FechaFin.GetValueOrDefault();
            anu.Direccion = en.Direccion;
            anu.Detalle = en.Detalle;
            anu.Localidad = en.Localidad;
            anu.Provincia = en.Provincia;
            anu.Id = en.Id;
            anu.AnimalContratado = en.AnimalContratado;
            anu.Comentarios = en.Comentarios_anuncio;
            anu.Cuidador = en.Cuidador;
            anu.Contratante = en.Contratante;
            anu.Estado = en.Estado;

            if (anu.Cuidador != null)
            {
                anu.CuidadorNick = en.Cuidador.Nick;
                anu.CuidadorNombre = en.Cuidador.Nombre;
                anu.CuidadorApellidos = en.Cuidador.Apellidos;
            }
            

            if (en.AnimalContratado != 0)
            {
                Tipo_AnimalCEN tipoCEN = new Tipo_AnimalCEN();
                anu.TA_animalFinal = tipoCEN.ReadOID(en.AnimalContratado).Tipo;
            }

            foreach(var animal in en.Tipos_Animales)
            {
                anu.TA_id.Add(animal.Id);
                anu.TA_tarifa.Add(animal.Tarifa);
                anu.TA_tipo.Add(animal.Tipo);
            }

            foreach(var comentario in en.Comentarios_anuncio)
            {
                anu.ComentariosDetalles.Add(comentario.Comentario);
                anu.ComentariosValoraciones.Add(comentario.Valoracion);

            }

            return anu;
        }
        public IList<AnuncioViewModel> ConvertListENToModel(IList<AnuncioEN> ens)
        {
            IList<AnuncioViewModel> anun = new List<AnuncioViewModel>();
            foreach (AnuncioEN en in ens)
            {
                anun.Add(ConvertENToModelUI(en));
            }
            return anun;
        }
    }
}