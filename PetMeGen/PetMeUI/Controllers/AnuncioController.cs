using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetMeGenNHibernate.CEN.PetMe;
using PetMeGenNHibernate.EN.PetMe;
using PetMeGenNHibernate.CAD.PetMe;
using PetMeUI.Models;
using PetMeGenNHibernate.CP.PetMe;
using PetMeGenNHibernate.Enumerated.PetMe;

namespace PetMeUI.Controllers
{
    public class AnuncioController : BasicController
    {
        // GET: Anuncio
        public ActionResult Index()
        {
            SessionInitialize();
            AnuncioCEN anuncioCEN = new AnuncioCEN();
            IEnumerable<AnuncioEN> listaAnuncios = anuncioCEN.ReadAll(0, -1).ToList();

            SessionClose();
            return View(listaAnuncios);
        }

        // GET: Anuncio/Details/5
        public ActionResult Details(int id)
        {

            
            SessionInitialize();

            AnuncioCAD anuCAD = new AnuncioCAD(session);
            AnuncioCEN anuCEN = new AnuncioCEN(anuCAD);
            IList<AnuncioEN> anuncioIni = anuCEN.ReadAll(0, -1).ToList();
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);
            IList<UsuarioEN> usuarioIni = usuCEN.ReadAll(0, -1).ToList();
            ComentarioCAD comCAD = new ComentarioCAD(session);
            ComentarioCEN comCEN = new ComentarioCEN(comCAD);
            IList<ComentarioEN> comIni = comCEN.ReadAll(0, -1).ToList();
            Tipo_AnimalCAD tipCAD = new Tipo_AnimalCAD(session);
            Tipo_AnimalCEN tipCEN = new Tipo_AnimalCEN(tipCAD);
            IList<Tipo_AnimalEN> tipIni = tipCEN.ReadAll(0, -1).ToList();

            AnuncioEN anuncioEN = anuCEN.ReadOID(id);
            AssemblerAnuncio assemblerAnuncio = new AssemblerAnuncio();
            AnuncioViewModel anun = assemblerAnuncio.ConvertENToModelUI(anuncioEN);

            SessionClose();
            return View(anun);
        }

        // GET: Anuncio/Create
        public ActionResult Create()
        {
            //Comprobacion general de que está logeado
            UsuarioCEN usuCEN = new UsuarioCEN();
            TempData.Keep("UsuarioId");
            string usuarioID = (string)TempData["UsuarioId"];
            IList<UsuarioEN> usuarioConectado = usuCEN.BuscarPorNick(usuarioID);
            if (usuarioConectado.Count() == 0)
            {
                //No hay usuario conectado
                return RedirectToAction("SinSesion", "Error");
            }
            AnuncioEN anuncioEN = new AnuncioEN();
            AssemblerAnuncio asemAnu = new AssemblerAnuncio();
            AnuncioViewModel anu = asemAnu.ConvertENToModelUI(anuncioEN);
            return View(anu);
        }

        // POST: Anuncio/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                //Vamos a usar un usuario estatico pero tendremos que cambiarlo por el de la sesion TODO
                IList<string> animales = new List<string>();
                IList<double> precios = new List<double>();
                //En teoria los animales nos vienen separados por comas
                string[] data = collection.Get("Animales").Split(',');
                string[] data2 = collection.Get("Precios").Split(',');
                string fecha = collection.Get("FechaIni");
                DateTime fechaIni = DateTime.Parse(collection.Get("FechaIni"));
                DateTime fechaFin = DateTime.Parse(collection.Get("FechaFin"));
                foreach (string animal in data)
                {
                    animales.Add(animal);
                }

                foreach(string precio in data2)
                {
                    precios.Add(Convert.ToDouble(precio));
                }
                UsuarioCP usuCP = new UsuarioCP();
                UsuarioCEN usuCEN = new UsuarioCEN();

                TempData.Keep("UsuarioId");
                string usuarioID = (string)TempData["UsuarioId"];
                IList<UsuarioEN> usuarioConectado = usuCEN.BuscarPorNick(usuarioID);
               
                usuCP.CrearAnuncio(usuarioConectado[0].Email,fechaIni,fechaFin, collection.Get("Direccion"), collection.Get("Detalle"), collection.Get("Provincia"), collection.Get("Localidad"),animales,precios);

                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Anuncio/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);

            TempData.Keep("UsuarioId");
            string usuarioID = (string)TempData["UsuarioId"];
            IList<UsuarioEN> usuarioConectado = usuCEN.BuscarPorNick(usuarioID);
            if (usuarioConectado.Count() == 0)
            {
                //No hay usuario conectado
                return RedirectToAction("SinSesion", "Error");
            }

            AnuncioCAD anuCAD = new AnuncioCAD(session);
            AnuncioCEN anuCEN = new AnuncioCEN(anuCAD);
            IList<AnuncioEN> anuncioIni = anuCEN.ReadAll(0, -1).ToList();     
            IList<UsuarioEN> usuarioIni = usuCEN.ReadAll(0, -1).ToList();
            ComentarioCAD comCAD = new ComentarioCAD(session);
            ComentarioCEN comCEN = new ComentarioCEN(comCAD);
            IList<ComentarioEN> comIni = comCEN.ReadAll(0, -1).ToList();
            Tipo_AnimalCAD tipCAD = new Tipo_AnimalCAD(session);
            Tipo_AnimalCEN tipCEN = new Tipo_AnimalCEN(tipCAD);
            IList<Tipo_AnimalEN> tipIni = tipCEN.ReadAll(0, -1).ToList();

            AnuncioEN anuncioEN = anuCEN.ReadOID(id);
            AssemblerAnuncio assemblerAnuncio = new AssemblerAnuncio();
            AnuncioViewModel anun = assemblerAnuncio.ConvertENToModelUI(anuncioEN);

            

            SessionClose();
            return View(anun);
        }

        // POST: Anuncio/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                AnuncioCEN anuncioCEN = new AnuncioCEN();
                int id = Int32.Parse(collection.Get("Id"));
                DateTime fechaIni = DateTime.Parse(collection.Get("FechaIni"));
                DateTime fechaFin = DateTime.Parse(collection.Get("FechaFin"));
                string direccion = collection.Get("Direccion");
                string detalle = collection.Get("Detalle");
                string localidad = collection.Get("Localidad");
                string provincia = collection.Get("provincia");

                UsuarioCEN usuCEN = new UsuarioCEN();
                TempData.Keep("UsuarioId");
                string usuarioID = (string)TempData["UsuarioId"];
                IList<UsuarioEN> usuarioConectado = usuCEN.BuscarPorNick(usuarioID);
                if (usuarioConectado.Count() == 0)
                {
                    //No hay usuario conectado
                    return RedirectToAction("SinSesion", "Error");
                }

                //1-> contratado 
                //2-> finalizado
                //3-> publicado

                EstadosEnum estado = (EstadosEnum)Enum.Parse(typeof(EstadosEnum), collection.Get("Motivo"));

                anuncioCEN.Modify(id, fechaIni, fechaFin, direccion, detalle, estado, provincia, localidad);

                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Anuncio/Delete/5
        public ActionResult Delete(int id)
        {

            UsuarioCEN usuCEN = new UsuarioCEN();
            TempData.Keep("UsuarioId");
            string usuarioID = (string)TempData["UsuarioId"];
            IList<UsuarioEN> usuarioConectado = usuCEN.BuscarPorNick(usuarioID);
            if (usuarioConectado.Count() == 0)
            {
                //No hay usuario conectado
                return RedirectToAction("SinSesion", "Error");
            }
            AnuncioCEN anuncioCEN = new AnuncioCEN();
            anuncioCEN.Destroy(id);
            return RedirectToAction("Index/");
            
        }

        [HttpPost]
        public ActionResult Contratar(FormCollection collection)
        {
            SessionInitialize();
            AnuncioCAD anuCAD = new AnuncioCAD(session);
            AnuncioCEN anuCEN = new AnuncioCEN(anuCAD);

            //Comprobacion general de que está logeado
            UsuarioCEN usuCEN = new UsuarioCEN();
            TempData.Keep("UsuarioId");
            IList<UsuarioEN> usuarioConectado = usuCEN.BuscarPorNick((string)TempData["UsuarioId"]);
            if (usuarioConectado.Count() == 0)
            {
                //No hay usuario conectado
                return RedirectToAction("SinSesion", "Error");
            }

            
            int TA_id = Int32.Parse(collection.Get("TipoAnimal"));
            int Anuncio_id = Int32.Parse(collection.Get("Id"));
            UsuarioCP usuCP = new UsuarioCP();
            usuCP.ReservarAnuncio(usuarioConectado[0].Email,Anuncio_id,TA_id);

            return RedirectToAction("Index", "Home");
        }

        

    }
}
