using PetMeGenNHibernate.CEN.PetMe;
using PetMeGenNHibernate.EN.PetMe;
using PetMeGenNHibernate.CAD.PetMe;
using PetMeUI.Models;
using PetMeGenNHibernate.CP.PetMe;
using PetMeGenNHibernate.Enumerated.PetMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetMeUI.Controllers
{
    public class ComentarioController : BasicController
    {
        // GET: Comentario
        public ActionResult Index(int id)
        {
            SessionInitialize();
            AnuncioCAD anuncioCAD = new AnuncioCAD(session);
            ComentarioCAD comentarioCAD = new ComentarioCAD(session);
            AnuncioCEN anuncioCen = new AnuncioCEN(anuncioCAD);
            AnuncioEN anuncioEn = anuncioCen.ReadOID(id);

            IList<ComentarioEN> comentarios = anuncioEn.Comentarios_anuncio;
            AssemblerComentario assemblerComentario = new AssemblerComentario();
            IList<ComentarioViewModel> comentariosView = assemblerComentario.ConvertListENToModel(comentarios);

            //Guardamos el id del anuncio al que hemos entrado para ver sus comentarios
            TempData["AnuncioId"] = id;
            SessionClose();
            return View(comentariosView);
        }

        // GET: Comentario/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            ComentarioCAD comCAD = new ComentarioCAD(session);
            ComentarioCEN comentarioCEN = new ComentarioCEN(comCAD);
            AnuncioCAD anuCAD = new AnuncioCAD(session);
            AnuncioCEN anuCEN = new AnuncioCEN(anuCAD);
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);
            ComentarioEN comentarioEN = comentarioCEN.ReadOID(id);
            AssemblerComentario assemblerComentario = new AssemblerComentario();
            ComentarioViewModel comenView = assemblerComentario.ConvertENToModelUI(comentarioEN);
            return View(comenView);
        }

        // GET: Comentario/Create
        public ActionResult Create(int id)
        {
            UsuarioCEN usuCEN = new UsuarioCEN();
            TempData.Keep("AnuncioId");
            TempData["AnuncioId"] = id;

            TempData.Keep("UsuarioId");
            string usuarioID = (string)TempData["UsuarioId"];
            IList<UsuarioEN> usuarioConectado = usuCEN.BuscarPorNick(usuarioID);
            if (usuarioConectado.Count() == 0)
            {
                //No hay usuario conectado
                return RedirectToAction("SinSesion", "Error");
            }
            return View();
        }

        // POST: Comentario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                string comentario = collection.Get(1);
                ValoracionEnum valoracion = (ValoracionEnum)Enum.Parse(typeof(ValoracionEnum), collection.Get("Valoracion"));
                UsuarioCP usuarioCP = new UsuarioCP();
                
                int anuncio = (int)TempData["AnuncioId"];

                //Esto es comun siempre para acceder a los datos del TempData
                UsuarioCEN usuCEN = new UsuarioCEN();
                TempData.Keep("UsuarioId");
                IList<UsuarioEN> usuarioConectado = usuCEN.BuscarPorNick((string)TempData["UsuarioId"]);

                //Introducimos nombre para probar pero cambiaremos por el viewData de usuario TODO
                usuarioCP.HacerComentario(usuarioConectado[0].Email, comentario, valoracion, anuncio);

                return RedirectToAction("Details","Anuncio",new { id=anuncio });
            }
            catch
            {
                return View();
            }
        }

        // GET: Comentario/Edit/5
        public ActionResult Edit(int id)
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
            ComentarioCEN comentarioCEN = new ComentarioCEN();
            ComentarioEN comentarioEN = comentarioCEN.ReadOID(id);
            AssemblerComentario assemblerComentario = new AssemblerComentario();
            ComentarioViewModel comenView = assemblerComentario.ConvertENToModelUI(comentarioEN);
            return View(comenView);
        }

        // POST: Comentario/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                int id2 = Int32.Parse(collection.Get(1));
                string comentarioTexto = collection.Get(2);
                ValoracionEnum valoracion = (ValoracionEnum)Enum.Parse(typeof(ValoracionEnum), collection.Get("Valoracion"));
                ComentarioCEN comentarioCEN = new ComentarioCEN();

                comentarioCEN.Modify(id2, comentarioTexto, valoracion);

                return RedirectToAction("Index", "Home");

            }
            catch
            {
                return View();
            }
        }

        // GET: Comentario/Delete/5
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
            ComentarioCEN comentarioCEN = new ComentarioCEN();

            comentarioCEN.Destroy(id);
            return RedirectToAction("Index", "Anuncio");
        }

    }
}
