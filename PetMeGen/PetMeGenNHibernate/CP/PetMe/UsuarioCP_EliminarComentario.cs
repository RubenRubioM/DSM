
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



/*PROTECTED REGION ID(usingPetMeGenNHibernate.CP.PetMe_Usuario_eliminarComentario) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PetMeGenNHibernate.CP.PetMe
{
public partial class UsuarioCP : BasicCP
{
public void EliminarComentario (string p_usuario, int p_comentario, int p_anuncio)
{
        /*PROTECTED REGION ID(PetMeGenNHibernate.CP.PetMe_Usuario_eliminarComentario) ENABLED START*/


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
                usuarioCEN = new UsuarioCEN (usuarioCAD);
                anuncioCAD = new AnuncioCAD (session);
                anuncioCEN = new AnuncioCEN (anuncioCAD);
                comentarioCAD = new ComentarioCAD (session);
                comentarioCEN = new ComentarioCEN (comentarioCAD);

                // Especificamos el comentario a eliminar
                IList<int> comentario = new List<int>(p_comentario);

                // llamamos a los unrelationers para quitar las referencias
                anuncioCEN.QuitarComentario (p_anuncio, comentario);
                usuarioCEN.QuitarComentario (p_usuario, comentario);

                // por ultimo, deleteamos el comentario de la BD
                comentarioCEN.Destroy (p_comentario);

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
