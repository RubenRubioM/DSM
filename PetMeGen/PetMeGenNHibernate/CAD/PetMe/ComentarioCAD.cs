
using System;
using System.Text;
using PetMeGenNHibernate.CEN.PetMe;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PetMeGenNHibernate.EN.PetMe;
using PetMeGenNHibernate.Exceptions;


/*
 * Clase Comentario:
 *
 */

namespace PetMeGenNHibernate.CAD.PetMe
{
public partial class ComentarioCAD : BasicCAD, IComentarioCAD
{
public ComentarioCAD() : base ()
{
}

public ComentarioCAD(ISession sessionAux) : base (sessionAux)
{
}



public ComentarioEN ReadOIDDefault (int id
                                    )
{
        ComentarioEN comentarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentarioEN = (ComentarioEN)session.Get (typeof(ComentarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ComentarioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ComentarioEN>();
                        else
                                result = session.CreateCriteria (typeof(ComentarioEN)).List<ComentarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ComentarioEN comentario)
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioEN comentarioEN = (ComentarioEN)session.Load (typeof(ComentarioEN), comentario.Id);

                comentarioEN.Comentario = comentario.Comentario;


                comentarioEN.Valoracion = comentario.Valoracion;



                session.Update (comentarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ComentarioEN comentario)
{
        try
        {
                SessionInitializeTransaction ();
                if (comentario.Anuncio != null) {
                        // Argumento OID y no colección.
                        comentario.Anuncio = (PetMeGenNHibernate.EN.PetMe.AnuncioEN)session.Load (typeof(PetMeGenNHibernate.EN.PetMe.AnuncioEN), comentario.Anuncio.Id);

                        comentario.Anuncio.Comentarios_anuncio
                        .Add (comentario);
                }
                if (comentario.Usuario_comen != null) {
                        // Argumento OID y no colección.
                        comentario.Usuario_comen = (PetMeGenNHibernate.EN.PetMe.UsuarioEN)session.Load (typeof(PetMeGenNHibernate.EN.PetMe.UsuarioEN), comentario.Usuario_comen.Email);

                        comentario.Usuario_comen.Comentarios_usuario
                        .Add (comentario);
                }

                session.Save (comentario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentario.Id;
}

public void Modify (ComentarioEN comentario)
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioEN comentarioEN = (ComentarioEN)session.Load (typeof(ComentarioEN), comentario.Id);

                comentarioEN.Comentario = comentario.Comentario;


                comentarioEN.Valoracion = comentario.Valoracion;

                session.Update (comentarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioEN comentarioEN = (ComentarioEN)session.Load (typeof(ComentarioEN), id);
                session.Delete (comentarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ComentarioEN
public ComentarioEN ReadOID (int id
                             )
{
        ComentarioEN comentarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentarioEN = (ComentarioEN)session.Get (typeof(ComentarioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ComentarioEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ComentarioEN>();
                else
                        result = session.CreateCriteria (typeof(ComentarioEN)).List<ComentarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.ComentarioEN> BuscarPorValoracion (PetMeGenNHibernate.Enumerated.PetMe.ValoracionEnum ? p_valoracion)
{
        System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.ComentarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ComentarioEN self where FROM ComentarioEN com WHERE com.Valoracion = :p_valoracion";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ComentarioENbuscarPorValoracionHQL");
                query.SetParameter ("p_valoracion", p_valoracion);

                result = query.List<PetMeGenNHibernate.EN.PetMe.ComentarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
