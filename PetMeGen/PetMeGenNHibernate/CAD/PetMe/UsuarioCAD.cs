
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
 * Clase Usuario:
 *
 */

namespace PetMeGenNHibernate.CAD.PetMe
{
public partial class UsuarioCAD : BasicCAD, IUsuarioCAD
{
public UsuarioCAD() : base ()
{
}

public UsuarioCAD(ISession sessionAux) : base (sessionAux)
{
}



public UsuarioEN ReadOIDDefault (string email
                                 )
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UsuarioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                        else
                                result = session.CreateCriteria (typeof(UsuarioEN)).List<UsuarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), usuario.Email);

                usuarioEN.Nombre = usuario.Nombre;


                usuarioEN.Apellidos = usuario.Apellidos;


                usuarioEN.Nick = usuario.Nick;


                usuarioEN.Nacimiento = usuario.Nacimiento;


                usuarioEN.Provincia = usuario.Provincia;


                usuarioEN.Localidad = usuario.Localidad;


                usuarioEN.Foto = usuario.Foto;


                usuarioEN.Descripcion = usuario.Descripcion;


                usuarioEN.Cartera = usuario.Cartera;




                usuarioEN.Telefono = usuario.Telefono;



                usuarioEN.Estado = usuario.Estado;


                usuarioEN.Pass = usuario.Pass;


                usuarioEN.MotivoEstado = usuario.MotivoEstado;

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string Registrarse (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (usuario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuario.Email;
}

public void Modify (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), usuario.Email);

                usuarioEN.Nombre = usuario.Nombre;


                usuarioEN.Apellidos = usuario.Apellidos;


                usuarioEN.Nick = usuario.Nick;


                usuarioEN.Nacimiento = usuario.Nacimiento;


                usuarioEN.Provincia = usuario.Provincia;


                usuarioEN.Localidad = usuario.Localidad;


                usuarioEN.Cartera = usuario.Cartera;


                usuarioEN.Estado = usuario.Estado;


                usuarioEN.Pass = usuario.Pass;


                usuarioEN.MotivoEstado = usuario.MotivoEstado;

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string email
                     )
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), email);
                session.Delete (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AsignarAnuncioContratado (string p_Usuario_OID, System.Collections.Generic.IList<int> p_anuncios_contratados_OIDs)
{
        PetMeGenNHibernate.EN.PetMe.UsuarioEN usuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);
                PetMeGenNHibernate.EN.PetMe.AnuncioEN anuncios_contratadosENAux = null;
                if (usuarioEN.Anuncios_contratados == null) {
                        usuarioEN.Anuncios_contratados = new System.Collections.Generic.List<PetMeGenNHibernate.EN.PetMe.AnuncioEN>();
                }

                foreach (int item in p_anuncios_contratados_OIDs) {
                        anuncios_contratadosENAux = new PetMeGenNHibernate.EN.PetMe.AnuncioEN ();
                        anuncios_contratadosENAux = (PetMeGenNHibernate.EN.PetMe.AnuncioEN)session.Load (typeof(PetMeGenNHibernate.EN.PetMe.AnuncioEN), item);
                        anuncios_contratadosENAux.Contratante = usuarioEN;

                        usuarioEN.Anuncios_contratados.Add (anuncios_contratadosENAux);
                }


                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void QuitarAnuncioContratado (string p_Usuario_OID, System.Collections.Generic.IList<int> p_anuncios_contratados_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                PetMeGenNHibernate.EN.PetMe.UsuarioEN usuarioEN = null;
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);

                PetMeGenNHibernate.EN.PetMe.AnuncioEN anuncios_contratadosENAux = null;
                if (usuarioEN.Anuncios_contratados != null) {
                        foreach (int item in p_anuncios_contratados_OIDs) {
                                anuncios_contratadosENAux = (PetMeGenNHibernate.EN.PetMe.AnuncioEN)session.Load (typeof(PetMeGenNHibernate.EN.PetMe.AnuncioEN), item);
                                if (usuarioEN.Anuncios_contratados.Contains (anuncios_contratadosENAux) == true) {
                                        usuarioEN.Anuncios_contratados.Remove (anuncios_contratadosENAux);
                                        anuncios_contratadosENAux.Contratante = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_anuncios_contratados_OIDs you are trying to unrelationer, doesn't exist in UsuarioEN");
                        }
                }

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AsignarAnuncioCreado (string p_Usuario_OID, System.Collections.Generic.IList<int> p_anuncios_OIDs)
{
        PetMeGenNHibernate.EN.PetMe.UsuarioEN usuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);
                PetMeGenNHibernate.EN.PetMe.AnuncioEN anunciosENAux = null;
                if (usuarioEN.Anuncios == null) {
                        usuarioEN.Anuncios = new System.Collections.Generic.List<PetMeGenNHibernate.EN.PetMe.AnuncioEN>();
                }

                foreach (int item in p_anuncios_OIDs) {
                        anunciosENAux = new PetMeGenNHibernate.EN.PetMe.AnuncioEN ();
                        anunciosENAux = (PetMeGenNHibernate.EN.PetMe.AnuncioEN)session.Load (typeof(PetMeGenNHibernate.EN.PetMe.AnuncioEN), item);
                        anunciosENAux.Cuidador = usuarioEN;

                        usuarioEN.Anuncios.Add (anunciosENAux);
                }


                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void QuitarAnuncioCreado (string p_Usuario_OID, System.Collections.Generic.IList<int> p_anuncios_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                PetMeGenNHibernate.EN.PetMe.UsuarioEN usuarioEN = null;
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);

                PetMeGenNHibernate.EN.PetMe.AnuncioEN anunciosENAux = null;
                if (usuarioEN.Anuncios != null) {
                        foreach (int item in p_anuncios_OIDs) {
                                anunciosENAux = (PetMeGenNHibernate.EN.PetMe.AnuncioEN)session.Load (typeof(PetMeGenNHibernate.EN.PetMe.AnuncioEN), item);
                                if (usuarioEN.Anuncios.Contains (anunciosENAux) == true) {
                                        usuarioEN.Anuncios.Remove (anunciosENAux);
                                        anunciosENAux.Cuidador = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_anuncios_OIDs you are trying to unrelationer, doesn't exist in UsuarioEN");
                        }
                }

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AsignarComentario (string p_Usuario_OID, System.Collections.Generic.IList<int> p_comentarios_usuario_OIDs)
{
        PetMeGenNHibernate.EN.PetMe.UsuarioEN usuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);
                PetMeGenNHibernate.EN.PetMe.ComentarioEN comentarios_usuarioENAux = null;
                if (usuarioEN.Comentarios_usuario == null) {
                        usuarioEN.Comentarios_usuario = new System.Collections.Generic.List<PetMeGenNHibernate.EN.PetMe.ComentarioEN>();
                }

                foreach (int item in p_comentarios_usuario_OIDs) {
                        comentarios_usuarioENAux = new PetMeGenNHibernate.EN.PetMe.ComentarioEN ();
                        comentarios_usuarioENAux = (PetMeGenNHibernate.EN.PetMe.ComentarioEN)session.Load (typeof(PetMeGenNHibernate.EN.PetMe.ComentarioEN), item);
                        comentarios_usuarioENAux.Usuario_comen = usuarioEN;

                        usuarioEN.Comentarios_usuario.Add (comentarios_usuarioENAux);
                }


                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void QuitarComentario (string p_Usuario_OID, System.Collections.Generic.IList<int> p_comentarios_usuario_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                PetMeGenNHibernate.EN.PetMe.UsuarioEN usuarioEN = null;
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);

                PetMeGenNHibernate.EN.PetMe.ComentarioEN comentarios_usuarioENAux = null;
                if (usuarioEN.Comentarios_usuario != null) {
                        foreach (int item in p_comentarios_usuario_OIDs) {
                                comentarios_usuarioENAux = (PetMeGenNHibernate.EN.PetMe.ComentarioEN)session.Load (typeof(PetMeGenNHibernate.EN.PetMe.ComentarioEN), item);
                                if (usuarioEN.Comentarios_usuario.Contains (comentarios_usuarioENAux) == true) {
                                        usuarioEN.Comentarios_usuario.Remove (comentarios_usuarioENAux);
                                        comentarios_usuarioENAux.Usuario_comen = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_comentarios_usuario_OIDs you are trying to unrelationer, doesn't exist in UsuarioEN");
                        }
                }

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
//Sin e: ReadOID
//Con e: UsuarioEN
public UsuarioEN ReadOID (string email
                          )
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(UsuarioEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                else
                        result = session.CreateCriteria (typeof(UsuarioEN)).List<UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.UsuarioEN> BuscarPorNombre (string p_nombre)
{
        System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN usu WHERE usu.Nombre = :p_nombre";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENbuscarPorNombreHQL");
                query.SetParameter ("p_nombre", p_nombre);

                result = query.List<PetMeGenNHibernate.EN.PetMe.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.UsuarioEN> BuscarPorProvincia (string p_provincia)
{
        System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN usu WHERE usu.Provincia = :p_provincia";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENbuscarPorProvinciaHQL");
                query.SetParameter ("p_provincia", p_provincia);

                result = query.List<PetMeGenNHibernate.EN.PetMe.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.UsuarioEN> BuscarPorLocalidad (string arg0)
{
        System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN usu WHERE usu.Localidad = :p_localidad";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENbuscarPorLocalidadHQL");
                query.SetParameter ("arg0", arg0);

                result = query.List<PetMeGenNHibernate.EN.PetMe.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
