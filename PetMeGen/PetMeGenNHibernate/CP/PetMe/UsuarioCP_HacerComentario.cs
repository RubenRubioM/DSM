
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



/*PROTECTED REGION ID(usingPetMeGenNHibernate.CP.PetMe_Usuario_hacerComentario) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PetMeGenNHibernate.CP.PetMe
{
public partial class UsuarioCP : BasicCP
{
public void HacerComentario (string p_oid, string p_comentario, PetMeGenNHibernate.Enumerated.PetMe.ValoracionEnum p_valoracion, int p_anuncio)
{
        /*PROTECTED REGION ID(PetMeGenNHibernate.CP.PetMe_Usuario_hacerComentario) ENABLED START*/

        IUsuarioCAD usuarioCAD = null;
        UsuarioCEN usuarioCEN = null;
        IComentarioCAD comentarioCAD = null;
        ComentarioCEN comentarioCEN = null;
        IAnuncioCAD anuncioCAD = null;
        AnuncioCEN anuncioCEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioCAD = new UsuarioCAD (session);
                usuarioCEN = new  UsuarioCEN (usuarioCAD);
                anuncioCAD = new AnuncioCAD (session);
                anuncioCEN = new AnuncioCEN (anuncioCAD);
                comentarioCAD = new ComentarioCAD (session);
                comentarioCEN = new ComentarioCEN (comentarioCAD);

                // creamos dicho comentario
                int p_comentario_oid = comentarioCEN.New_ (p_comentario, p_valoracion, p_anuncio, p_oid);

                // los asignamos al anuncio y usuario que corresponden
                IList<int> comentario = new List<int>(p_comentario_oid);
                anuncioCEN.AsignarComentario (p_anuncio, comentario);
                usuarioCEN.AsignarComentario (p_oid, comentario);

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
