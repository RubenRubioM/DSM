using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PetMeGenNHibernate.EN.PetMe;
using PetMeGenNHibernate.Enumerated.PetMe;

namespace PetMeUI.Models
{
    public class UsuarioViewModel
    {

        [ScaffoldColumn(false)]
        public float cartera { get; set; }

        [ScaffoldColumn(false)]
        public String motivoEstado { get; set; }

        [ScaffoldColumn(false)]
        public EstadoUsuarioEnum estado { get; set; }


        [ScaffoldColumn(false)]
        public IList<int> AnunciosCreados_id { get; set; }

        [ScaffoldColumn(false)]
        public IList<int> AnunciosContratados_id { get; set; }


        [ScaffoldColumn(false)]
        public IList<string> ComentariosDetalles { get; set; }

        [ScaffoldColumn(false)]
        public IList<ValoracionEnum> ComentariosValoraciones { get; set; }



        [Display(Prompt = "Email", Description = "correo electronico", Name = "Email ")]
        [Required(ErrorMessage = "Introduzca un email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Introduzca un email válido")]
        public string Email { get; set; }

        [Display(Prompt = "Nombre", Description = "Nombre", Name = "Nombre")]
        [Required(ErrorMessage = "Debes rellenar nombre")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")] 
        public string Nombre { get; set; }

        [Display(Prompt = "Apellidos", Description = "Apellidos", Name = "Apellidos")]
        [Required(ErrorMessage = "Debes rellenar los apellidos")]
        [StringLength(maximumLength: 200, ErrorMessage = "Los apellidos no puede tener más de 200 caracteres")]
        public string Apellidos { get; set; }

        [Display(Prompt = "Nick", Description = "nombre de usuario", Name = "Nick")]
        [Required(ErrorMessage = "Debes rellenar el nombre de usuario")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre de usuario no puede tener mas de 200 caracteres")]
        public string Nick { get; set; }

        [Display(Prompt = "Password", Description = "contraseña", Name = "Pass")]
        [Required(ErrorMessage = "Debes introducir una contraseña")]
        [DataType(DataType.Password,ErrorMessage ="Introduce una contraseña válida")]
        public string Pass { get; set; }

        [Display(Prompt = "Fecha de nacimiento", Description = "fecha de nacimiento", Name = "FNacimiento")]
        [Required(ErrorMessage = "Debes introducir fecha de nacimiento")]
        [DataType(DataType.Date,ErrorMessage = "Introduce una fecha de nacimiento valida")]
        public DateTime FNacimiento { get; set; }

        [Display(Prompt = "Provincia", Description = "Provincia", Name = "Provincia")]
        [Required(ErrorMessage = "Debes rellenar la provincia")]
        [StringLength(maximumLength: 200, ErrorMessage = "La provincia no puede tener más de 200 caracteres")]
        public string Provincia { get; set; }

        [Display(Prompt = "Localidad", Description = "Localidad", Name = "Localidad")]
        [Required(ErrorMessage = "Debes rellenar la localidad")]
        [StringLength(maximumLength: 200, ErrorMessage = "La localidad no puede tener más de 200 caracteres")]
        public string Localidad { get; set; }

        [Display(Prompt = "Telefono", Description = "Telefono", Name = "Telefono")]
        [Required(ErrorMessage = "Debes introducir un telefono")]
        [DataType(DataType.PhoneNumber,ErrorMessage ="Introduce un telefono válido")]
        public string Telefono { get; set; }

        


    }
}