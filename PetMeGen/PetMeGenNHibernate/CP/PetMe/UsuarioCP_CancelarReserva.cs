
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



/*PROTECTED REGION ID(usingPetMeGenNHibernate.CP.PetMe_Usuario_cancelarReserva) ENABLED START*/
using PetMeGenNHibernate.Enumerated.PetMe;
/*PROTECTED REGION END*/

namespace PetMeGenNHibernate.CP.PetMe
{
public partial class UsuarioCP : BasicCP
{
public void CancelarReserva (string p_oid, int p_anuncio)
{
        /*PROTECTED REGION ID(PetMeGenNHibernate.CP.PetMe_Usuario_cancelarReserva) ENABLED START*/

        IUsuarioCAD usuarioCAD = null;
        UsuarioCEN usuarioCEN = null;
        IAnuncioCAD anuncioCAD = null;
        AnuncioCEN anuncioCEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioCAD = new UsuarioCAD (session);
                usuarioCEN = new UsuarioCEN (usuarioCAD);
                anuncioCAD = new AnuncioCAD (session);
                anuncioCEN = new AnuncioCEN (anuncioCAD);

                // quitamos las referencias entre anuncio y usuario
                IList<int> anuncioCont = new List<int>(p_anuncio);
                anuncioCEN.QuitarContratante (p_anuncio, p_oid);
                usuarioCEN.QuitarAnuncioContratado (p_oid, anuncioCont);

                // setteamos su estado a disponible nuevamente, y el id del animalContratado a 0
                AnuncioEN anuncio = anuncioCAD.ReadOIDDefault (p_anuncio);
                anuncioCEN.Modify (p_anuncio, anuncio.FechaIni, anuncio.FechaFin, anuncio.Direccion, anuncio.Detalle, EstadosEnum.publicado, anuncio.Provincia, anuncio.Localidad);
                anuncioCEN.CancelarContrato(p_anuncio);

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
