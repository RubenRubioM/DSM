
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using PetMeGenNHibernate.EN.PetMe;
using PetMeGenNHibernate.CAD.PetMe;
using PetMeGenNHibernate.CEN.PetMe;



/*PROTECTED REGION ID(usingPetMeGenNHibernate.CP.PetMe_Usuario_crearAnuncio) ENABLED START*/

using PetMeGenNHibernate.CP.PetMe;

/*PROTECTED REGION END*/

namespace PetMeGenNHibernate.CP.PetMe
{
public partial class UsuarioCP : BasicCP
{
public void CrearAnuncio (string p_oid, Nullable<DateTime> p_fechaIni, Nullable<DateTime> p_fechaFin, string p_direccion, string p_detalle, string p_provincia, string p_localidad, System.Collections.Generic.IList<string> p_animales, System.Collections.Generic.IList<double> p_tarifas)
{
        /*PROTECTED REGION ID(PetMeGenNHibernate.CP.PetMe_Usuario_crearAnuncio) ENABLED START*/

        IUsuarioCAD usuarioCAD = null;
        UsuarioCEN usuarioCEN = null;
        IAnuncioCAD anuncioCAD = null;
        AnuncioCEN anuncioCEN = null;
        AnuncioCP anuncioCP = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioCAD = new UsuarioCAD (session);
                usuarioCEN = new  UsuarioCEN (usuarioCAD);
                anuncioCAD = new AnuncioCAD (session);
                anuncioCEN = new AnuncioCEN (anuncioCAD);
                anuncioCP = new AnuncioCP (session);

                // creamos el anuncio que quiere publicar
                int id_anuncio = anuncioCEN.New_ (p_fechaIni, p_fechaFin, p_direccion, p_oid, p_detalle, p_localidad, p_provincia);
                anuncioCP.CrearTablaAnimales (id_anuncio, p_animales, p_tarifas);

                // setteamos su estado a publicado
                anuncioCEN.Modify (id_anuncio, p_fechaIni, p_fechaFin, p_direccion, p_detalle, Enumerated.PetMe.EstadosEnum.publicado, p_provincia, p_localidad);

                // despues metemos el anuncio en la lista de anuncios creados por dicho usuario
                IList<int> lista = new List<int>(id_anuncio);
                usuarioCEN.AsignarAnuncioCreado (p_oid, lista);

                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
