using PetMeGenNHibernate.CEN.PetMe;
using PetMeGenNHibernate.EN.PetMe;
using PetMeGenNHibernate.Enumerated.PetMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetMeUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            IList<UsuarioEN> usuarios = usuarioCEN.BuscarPorNick(collection.Get(0)); //Solo devolvera 1
            if(usuarios.Count() > 0)
            {
                if (usuarios[0].Estado == EstadoUsuarioEnum.suspendido && usuarios[0].Estado == EstadoUsuarioEnum.baneado)
                {
                    return RedirectToAction("NoActivo", "Error");
                }
            }
            

            string usuarioOID = usuarioCEN.Login(usuarios[0].Email, collection.Get(1));

            if (usuarioOID != null)
            {
                //Login con exito, vamos a comprobar si es administrador o usuario normal
                string[] data = usuarios[0].Email.Split('@');
                //if(data[1].Equals("petme.com"))
                //{
                //    //Es administrador
                //}
                //else
                //{
                //    //Usuario normal
                //}

                //Hasta arreglar el login vamos a suponer que todos son administradores
                //Guardamos en el TempData el oid del usuario logeado
                TempData.Keep("UsuarioId");
                TempData["UsuarioId"] = usuarios[0].Nick;
                ViewData["UsuarioNick"] = usuarios[0].Nick;
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }
            return RedirectToAction("MiPerfil", "Usuario/");
        }

        public ActionResult CerrarSesion()
        {
            TempData["UsuarioId"] = null;

            return RedirectToAction("Index", "Account");

        }
    }
}
