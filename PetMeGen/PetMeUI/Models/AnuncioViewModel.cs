using PetMeGenNHibernate.EN.PetMe;
using PetMeGenNHibernate.Enumerated.PetMe;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetMeUI.Models
{
    public class AnuncioViewModel
    {
        [Display(Prompt = "FechaIni", Description = "fecha inicial", Name = "fechaIni ")]
        [Required(ErrorMessage = "Introduzca la fecha de inicio")]
        [DataType(DataType.Date, ErrorMessage = "Introduzca una fecha válida")]
        public DateTime FechaIni { get; set; }

        [Display(Prompt = "FechaFin", Description = "fecha final", Name = "fechaFin")]
        [Required(ErrorMessage = "Introduzca la fecha final")]
        [DataType(DataType.Date, ErrorMessage = "Introduzca una fecha válida")]
        public DateTime FechaFin { get; set; }

        [Display(Prompt = "Direccion", Description = "Dirección de cuidado de las mascotas", Name = "Direccion")]
        [Required(ErrorMessage = "Debes rellenar la dirección")]
        [StringLength(maximumLength: 200, ErrorMessage = "La dirección no puede tener más de 200 caracteres")]
        public string Direccion { get; set; }

        [Display(Prompt = "Detalle", Description = "Detalle del cuidado", Name = "Detalle")]
        [Required(ErrorMessage = "Debes rellenar el detalle")]
        [StringLength(maximumLength: 200, ErrorMessage = "el detalle no puede tener más de 200 caracteres")]
        public string Detalle { get; set; }

        [Display(Prompt = "Localidad", Description = "Localidad", Name = "Localidad")]
        [Required(ErrorMessage = "Debes rellenar la localidad")]
        [StringLength(maximumLength: 200, ErrorMessage = "La localidad no puede tener más de 200 caracteres")]
        public string Localidad { get; set; }

        [Display(Prompt = "Provincia", Description = "Provincia", Name = "Provincia")]
        [Required(ErrorMessage = "Debes rellenar la provincia")]
        [StringLength(maximumLength: 200, ErrorMessage = "La provincia no puede tener más de 200 caracteres")]
        public string Provincia { get; set; }

        [Display(Prompt = "Lista de animales", Description = "Animales separados por comas", Name = "Animales")]
        [Required(ErrorMessage = "Debes introducir al menos un animal")]        
        public IList<string> Animales { get; set; }

        [Display(Prompt = "Lista de precios", Description = "Precios separados por comas", Name = "Precios")]
        [Required(ErrorMessage = "Debes introducir al menos un animal")]
        public IList<string> Precios { get; set; }


        [ScaffoldColumn(false)]
        public IList<String> TA_tipo { get; set; }

        [ScaffoldColumn(false)]
        public IList<Double> TA_tarifa { get; set; }

        [ScaffoldColumn(false)]
        public IList<int> TA_id { get; set; }

        [ScaffoldColumn(false)]
        public string TA_animalFinal { get; set; }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public int AnimalContratado { get; set; }

        [ScaffoldColumn(false)]
        public IList<ComentarioEN> Comentarios { get; set; }

        [ScaffoldColumn(false)]
        public UsuarioEN Cuidador { get; set; }

        [ScaffoldColumn(false)]
        public string CuidadorNick { get; set; }

        [ScaffoldColumn(false)]
        public string CuidadorNombre { get; set; }

        [ScaffoldColumn(false)]
        public string CuidadorApellidos { get; set; }

        [ScaffoldColumn(false)]
        public IList<string> ComentariosDetalles { get; set; }

        [ScaffoldColumn(false)]
        public IList<ValoracionEnum> ComentariosValoraciones { get; set; }

        [ScaffoldColumn(false)]
        public UsuarioEN Contratante { get; set; }

        [ScaffoldColumn(false)]
        public EstadosEnum Estado { get; set; }
    }
}