
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



/*PROTECTED REGION ID(usingPetMeGenNHibernate.CP.PetMe_Usuario_cancelarReservaAnuncio) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PetMeGenNHibernate.CP.PetMe
{
public partial class UsuarioCP : BasicCP
{
public void CancelarReservaAnuncio (string p_oid, int p_anuncio)
{
        /*PROTECTED REGION ID(PetMeGenNHibernate.CP.PetMe_Usuario_cancelarReservaAnuncio) ENABLED START*/

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

                AnuncioEN anuncio = anuncioCAD.ReadOIDDefault (p_anuncio);

                // modificamos el estado del anuncio, para decir que vuelve a estar libre para otros usuarios
                anuncio.Estado = Enumerated.PetMe.EstadosEnum.publicado;
                anuncioCAD.Modify (anuncio);

                // llamamos a los unrelationers para quitar las referencias
                IList<int> reserva = new List<int>(p_anuncio);
                usuarioCEN.QuitarAnuncioContratado (p_oid, reserva);
                anuncioCEN.QuitarContratante (p_anuncio, p_oid);

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
