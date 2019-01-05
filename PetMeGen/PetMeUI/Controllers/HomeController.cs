using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetMeGenNHibernate.CEN.PetMe;
using PetMeGenNHibernate.EN.PetMe;
using PetMeGenNHibernate.CAD.PetMe;
using PetMeUI.Models;

namespace PetMeUI.Controllers
{
    public class HomeController : BasicController
    {
        public ActionResult Index()
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

            IList<AnuncioEN> listaAnuncios = anuCEN.BuscarPorNoContratado();
            AssemblerAnuncio assemblerAnuncio = new AssemblerAnuncio();
            IList<AnuncioViewModel> anunView = assemblerAnuncio.ConvertListENToModel(listaAnuncios);


            SessionClose();
            return View(anunView);
        }

        public ActionResult PaginaBuscar()
        {
            SessionInitialize();
            AnuncioCAD anuCAD = new AnuncioCAD(session);
            AnuncioCEN anuncioCEN = new AnuncioCEN(anuCAD);
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);
            ComentarioCAD comCAD = new ComentarioCAD(session);
            ComentarioCEN comCEN = new ComentarioCEN(comCAD);
            Tipo_AnimalCAD tipCAD = new Tipo_AnimalCAD(session);
            Tipo_AnimalCEN tipCEN = new Tipo_AnimalCEN(tipCAD);

            AssemblerAnuncio assemblerAnuncio = new AssemblerAnuncio();
            AnuncioViewModel anuncio = new AnuncioViewModel();

            SessionClose();

            return View(anuncio);
        }

        public ActionResult Buscar(FormCollection collection)
        {

            SessionInitialize();
            AnuncioCAD anuCAD = new AnuncioCAD(session);
            AnuncioCEN anuncioCEN = new AnuncioCEN(anuCAD);
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);
            ComentarioCAD comCAD = new ComentarioCAD(session);
            ComentarioCEN comCEN = new ComentarioCEN(comCAD);
            Tipo_AnimalCAD tipCAD = new Tipo_AnimalCAD(session);
            Tipo_AnimalCEN tipCEN = new Tipo_AnimalCEN(tipCAD);

            AssemblerAnuncio assemblerAnuncio = new AssemblerAnuncio();

            IList<AnuncioViewModel> anunciosDevolucion;

            //Aqui leemos el Form y vemos que tipo de filtro hay que hacer
            string tipoBusqueda = collection.Get("TipoFiltro");
            string datos = collection.Get("Datos");
            DateTime fechaIni = DateTime.Parse(collection.Get("fini"));
            DateTime fechaFin = DateTime.Parse(collection.Get("ffin"));

            IList<AnuncioEN> resFiltro = new List<AnuncioEN>();
            IList<AnuncioEN> resultadosFechaIni = new List<AnuncioEN>();
            IList<AnuncioEN> resultadosFechaFin = new List<AnuncioEN>();
            IList<AnuncioEN> resultadosAmbasFechas = new List<AnuncioEN>();
            IList<AnuncioEN> resultadosFinales = new List<AnuncioEN>();



            resultadosFechaIni = anuncioCEN.BuscarPorFechaIni(fechaIni);
            resultadosFechaFin = anuncioCEN.BuscarPorFechaFin(fechaFin);


            //Comparamos cuales coinciden entre ambas fechas

            foreach(var anu1 in resultadosFechaIni)
            {
                foreach(var anu2 in resultadosFechaFin)
                {
                    if(anu1.Id == anu2.Id)
                    {
                        //Son el mismo
                        resultadosAmbasFechas.Add(anu1);
                    }
                }
            }

            if (tipoBusqueda.Equals("id"))
            {
                //Busqueda por ID
                resFiltro.Add(anuncioCEN.ReadOID(Int32.Parse(datos)));
                
            }
            else if (tipoBusqueda.Equals("provincia"))
            {
                //Busqueda por PROVINCIA
                resFiltro = anuncioCEN.BuscarPorProvincia(datos);
            }else if (tipoBusqueda.Equals("localidad"))
            {
                //Busqueda por LOCALIDAD
                resFiltro = anuncioCEN.BuscarPorLocalidad(datos);

            }
            else if (tipoBusqueda.Equals("direccion"))
            {
                //Busqueda por DIRECCION
                resFiltro = anuncioCEN.BuscarPorDireccion(datos);

            }
            else
            {
                //Sin filtro, todos los datos
                resFiltro = anuncioCEN.BuscarPorNoContratado();
            }
            

            //Comparamos los que estan entre esas fechas y los del filtro
            foreach(var anu1 in resFiltro)
            {
                foreach(var anu2 in resultadosAmbasFechas)
                {
                    if(anu1.Id == anu2.Id)
                    {
                        //Son el mismo
                        resultadosFinales.Add(anu1);
                    }
                }
            }

            

            IList<AnuncioEN> resultadosFinales2 = new List<AnuncioEN>();

            foreach(var anuncio in resultadosFinales)
            {
                if (anuncio.AnimalContratado == 0)
                {
                    resultadosFinales2.Add(anuncio);
                }
            }

            //Comprobamos que al menos haya un dato
            if (!resultadosFinales2.Any())
            {
                SessionClose();
                return RedirectToAction("SinResultados");
            }
            //Pasamos la lista de AnuncioEN a AnuncioViewModel
            anunciosDevolucion = assemblerAnuncio.ConvertListENToModel(resultadosFinales2);

            SessionClose();

            return View(anunciosDevolucion);
        }

        public ActionResult SinResultados()
        {
            return View();
        }
        

        
    }
}