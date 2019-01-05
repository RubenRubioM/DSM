using PetMeGenNHibernate.CEN.PetMe;
using PetMeGenNHibernate.EN.PetMe;
using PetMeGenNHibernate.CAD.PetMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetMeUI.Models;
using PetMeGenNHibernate.Enumerated.PetMe;
using PetMeGenNHibernate.CP.PetMe;
using System.Globalization;

namespace PetMeUI.Controllers
{
    public class UsuarioController : BasicController
    {
        // GET: Usuario
        public ActionResult Index()
        {
            SessionInitialize();
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCen = new UsuarioCEN(usuCAD);
            IEnumerable<UsuarioEN> listaUsu = usuarioCen.ReadAll(0, -1).ToList();

            AnuncioCAD anuCAD = new AnuncioCAD(session);
            AnuncioCEN anuncioCen = new AnuncioCEN(anuCAD);
            IEnumerable<AnuncioEN> listaanu = anuncioCen.ReadAll(0, -1).ToList();

            SessionClose();
            return View(listaUsu);
        }

        public ActionResult MiPerfil()
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
            TempData.Keep("UsuarioId");
            string id2 = (string)TempData["UsuarioId"];

            return RedirectToAction("Details", new { id = id2 });
        }

        // GET: Usuario/Details/5
        public ActionResult Details(string id)
        {
            //Le pasamos por parametro el Nick y como es unico pues nos devuelve una lista con un solo resultado
            SessionInitialize();
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCen = new UsuarioCEN(usuCAD);
            AnuncioCAD anuCAD = new AnuncioCAD(session);
            AnuncioCEN anuncioCEN = new AnuncioCEN(anuCAD);
            ComentarioCAD comCAD = new ComentarioCAD(session);
            ComentarioCEN comentarioCEN = new ComentarioCEN(comCAD);
            Tipo_AnimalCAD tipCAD = new Tipo_AnimalCAD(session);
            Tipo_AnimalCEN tipCEN = new Tipo_AnimalCEN(tipCAD);

            IList<UsuarioEN> usuarios = usuarioCen.BuscarPorNick(id);

            if (!usuarios.Any())
            {
                return RedirectToAction("Index", "Account");
            }
            AssemblerUsuario usuAssembler = new AssemblerUsuario();
            UsuarioViewModel usuView = usuAssembler.ConvertENToModelUI(usuarios[0]);
            
            SessionClose();
            return View(usuView);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {

            UsuarioEN usuarioEN = new UsuarioEN();
            AssemblerUsuario asemusu = new AssemblerUsuario();
            UsuarioViewModel usu = asemusu.ConvertENToModelUI(usuarioEN);
            return View(usu);
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioViewModel usuEN)
        {
            try
            {
                
                // TODO: Add insert logic here
                SessionInitialize();
                UsuarioCAD usuCAD = new UsuarioCAD(session);
                UsuarioCEN usuCEN= new UsuarioCEN(usuCAD);
                AdministradorCAD adminCAD = new AdministradorCAD(session);
                AdministradorCEN adminCEN = new AdministradorCEN(adminCAD);
                string[] data = usuEN.Email.Split('@');

                if (data[1].Equals("petme.com"))
                {
                    //Se registra como administrador
                    adminCEN.New_(usuEN.Email, usuEN.Nombre, usuEN.Apellidos, usuEN.Nick, usuEN.FNacimiento, usuEN.Provincia, usuEN.Localidad, 1000f, usuEN.Telefono, EstadoUsuarioEnum.activo, usuEN.Pass, "Nuevo Administrador");
                }
                else
                {
                    usuCEN.Registrarse(usuEN.Email, usuEN.Pass, usuEN.Nombre, usuEN.Apellidos, usuEN.Nick, usuEN.FNacimiento, usuEN.Provincia, usuEN.Localidad, "Nuevo usuario", usuEN.Telefono);

                }

                this.SessionClose();


                return RedirectToAction("Index","Account");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/ElAlex
        public ActionResult Edit(string id)
        {
            //Le pasamos por parametro el Nick y como es unico pues nos devuelve una lista con un solo resultado
            SessionInitialize();
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCen = new UsuarioCEN(usuCAD);
            AnuncioCAD anuCAD = new AnuncioCAD(session);
            AnuncioCEN anuncioCEN = new AnuncioCEN(anuCAD);
            ComentarioCAD comCAD = new ComentarioCAD(session);
            ComentarioCEN comentarioCEN = new ComentarioCEN(comCAD);
            Tipo_AnimalCAD tipCAD = new Tipo_AnimalCAD(session);
            Tipo_AnimalCEN tipCEN = new Tipo_AnimalCEN(tipCAD);
            IList<UsuarioEN> usuarios =usuarioCen.BuscarPorNick(id);

            UsuarioCEN usuCEN = new UsuarioCEN();
            TempData.Keep("UsuarioId");
            string usuarioID = (string)TempData["UsuarioId"];
            IList<UsuarioEN> usuarioConectado = usuCEN.BuscarPorNick(usuarioID);
            if (usuarioConectado.Count() == 0)
            {
                //No hay usuario conectado
                return RedirectToAction("SinSesion", "Error");
            }

            AssemblerUsuario usuAssembler = new AssemblerUsuario();
            UsuarioViewModel usuView = usuAssembler.ConvertENToModelUI(usuarios[0]);
            return View(usuView);
        }

        // POST: Usuario/Edit/ElAlex
        [HttpPost]
        public ActionResult Edit(string id, UsuarioViewModel usuEN)
        {
            try
            {
                //Le pasamos por parametro el Nick y como es unico pues nos devuelve una lista con un solo resultado
                UsuarioCEN usuarioCen = new UsuarioCEN();
                IList<UsuarioEN> usuarios = usuarioCen.BuscarPorNick(id);
                string[] data = usuarios[0].Email.Split('@');

                if (data[1].Equals("petme.com"))
                {
                    //modificamos el administrador
                    AdministradorCEN adminCen = new AdministradorCEN();
                    adminCen.Modify(usuarios[0].Email, usuEN.Nombre, usuEN.Apellidos, usuEN.Nick, usuarios[0].Nacimiento, usuEN.Provincia, usuEN.Localidad, usuarios[0].Cartera, usuEN.Telefono, usuarios[0].Estado, usuEN.Pass, usuarios[0].MotivoEstado);
                }
                else
                {
                    //modificamos el usuario
                    usuarioCen.Modify(usuarios[0].Email, usuEN.Nombre, usuEN.Apellidos, usuEN.Nick, usuarios[0].Nacimiento, usuEN.Provincia, usuEN.Localidad, usuarios[0].Cartera, usuEN.Telefono, usuarios[0].Estado, usuEN.Pass, usuarios[0].MotivoEstado);

                }

                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(string id)
        {
            //Le pasamos por parametro el Nick y como es unico pues nos devuelve una lista con un solo resultado
            UsuarioCEN usuarioCen = new UsuarioCEN();
            IList<UsuarioEN> usuarios = usuarioCen.BuscarPorNick(id);
            usuarioCen.Destroy(usuarios[0].Email);
            return RedirectToAction("Index");
            
        }

       
        public ActionResult PasarelaPago()
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
            return View();
        }

        [HttpPost]
        public ActionResult IncrementarCartera(FormCollection collection)
        {
            UsuarioCEN usuCEN = new UsuarioCEN();
            float dinero = float.Parse(collection.Get("dinero"), CultureInfo.InvariantCulture.NumberFormat); 

            TempData.Keep("UsuarioId");
            string id = (string)TempData["UsuarioId"];
            IList<UsuarioEN> usuarios = usuCEN.BuscarPorNick(id);
            usuCEN.IncrementarCartera(usuarios[0].Email, dinero);
            return RedirectToAction("MiPerfil", "Usuario");
        }

        [HttpPost]
        public ActionResult PasarelaModificar(FormCollection collection)
        {
            UsuarioCEN usuCEN = new UsuarioCEN();
            IList<UsuarioEN> usuarios = usuCEN.BuscarPorNick(collection.Get("nick"));

            string[] data = usuarios[0].Email.Split('@');

            //TODO Solo puede banear si es admin
            //if (!data[1].Equals("petme.com"))
            //{
            //    return RedirectToAction("Index","Usuario");
            //}

            TempData.Keep("UsuarioId");
            IList<UsuarioEN> usuarioConectado = usuCEN.BuscarPorNick((string)TempData["UsuarioId"]);

            if (usuarioConectado.Count() == 0)
            {
                return RedirectToAction("SinSesion", "Error");
            }

            TempData.Keep("UsuarioModificar");
            TempData["UsuarioModificar"] = collection.Get("nick");
            return View();
        }

        public ActionResult ModificarEstado(FormCollection collection)
        {
            //Le pasamos por parametro el Nick y como es unico pues nos devuelve una lista con un solo resultado
            UsuarioCEN usuCEN = new UsuarioCEN();
            AdministradorCEN adminCEN = new AdministradorCEN();

            TempData.Keep("UsuarioModificar");
            string nick = (string)TempData["UsuarioModificar"];
            IList<UsuarioEN> usuarios = usuCEN.BuscarPorNick(nick);
            AdministradorCP adminCP = new AdministradorCP();

            TempData.Keep("UsuarioId");
            string id = (string)TempData["UsuarioId"];
            IList<UsuarioEN> usuarioConectado = usuCEN.BuscarPorNick(id);

            string motivo = collection.Get("motivo");
            EstadoUsuarioEnum estado = (EstadoUsuarioEnum)Enum.Parse(typeof(EstadoUsuarioEnum), collection.Get("accion"));

            adminCP.ModificarEstado(usuarioConectado[0].Email, usuarios[0].Email, estado, motivo);
            return RedirectToAction("Index", "Usuario");
        }
    }
}
