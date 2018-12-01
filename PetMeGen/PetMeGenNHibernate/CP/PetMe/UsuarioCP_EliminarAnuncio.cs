
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



/*PROTECTED REGION ID(usingPetMeGenNHibernate.CP.PetMe_Usuario_eliminarAnuncio) ENABLED START*/
using PetMeGenNHibernate.CP.PetMe;
/*PROTECTED REGION END*/

namespace PetMeGenNHibernate.CP.PetMe
{
public partial class UsuarioCP : BasicCP
{
public void EliminarAnuncio (string p_oid, int p_anuncio, System.Collections.Generic.IList<int> p_animales)
{
        /*PROTECTED REGION ID(PetMeGenNHibernate.CP.PetMe_Usuario_eliminarAnuncio) ENABLED START*/

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

                // primero debemos quitar la referencia que tiene el usuario
                IList<int> anuncios = new List<int>(p_anuncio);
                usuarioCEN.QuitarAnuncioCreado (p_oid, anuncios);

                // ahora borramos todo lo referente a los animales de dicho anuncio
                anuncioCP.BorrarTablaAnimales (p_anuncio, p_animales);

                // ahora lo destruimos
                anuncioCEN.Destroy (p_anuncio);

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
