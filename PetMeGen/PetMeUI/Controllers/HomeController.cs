using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetMeGenNHibernate.CEN.PetMe;
using PetMeGenNHibernate.EN.PetMe;
using PetMeGenNHibernate.CAD.PetMe;

namespace PetMeUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AnuncioCEN anuncioCEN = new AnuncioCEN();
            IEnumerable<AnuncioEN> listaAnuncios = anuncioCEN.ReadAll(0, -1).ToList();
            return View(listaAnuncios);
        }

        
    }
}