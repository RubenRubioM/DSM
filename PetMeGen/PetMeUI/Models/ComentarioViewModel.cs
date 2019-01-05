using PetMeGenNHibernate.EN.PetMe;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PetMeGenNHibernate.Enumerated.PetMe;

namespace PetMeUI.Models
{
    public class ComentarioViewModel
    {

        [Display(Prompt = "Valoracion", Description = "Valoracion del anuncio", Name = "Valoracion ")]
        [Required(ErrorMessage = "Debe introducir una valoracion")]
        public ValoracionEnum Valoracion { get; set; }

        [Display(Prompt = "Comentario", Description = "Comentario del anuncio", Name = "Comentario ")]
        [Required(ErrorMessage = "Debe introducir un comentario")]
        public string Comentario { get; set; }

        [ScaffoldColumn(false)]
        public UsuarioEN Usuario { get; set; }

        [ScaffoldColumn(false)]
        public int Anuncio { get; set; }


        [ScaffoldColumn(false)]
        public int Id { get; set; }
    }
}