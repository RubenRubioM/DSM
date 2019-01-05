
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
 * Clase Anuncio:
 *
 */

namespace PetMeGenNHibernate.CAD.PetMe
{
public partial class AnuncioCAD : BasicCAD, IAnuncioCAD
{
public AnuncioCAD() : base ()
{
}

public AnuncioCAD(ISession sessionAux) : base (sessionAux)
{
}



public AnuncioEN ReadOIDDefault (int id
                                 )
{
        AnuncioEN anuncioEN = null;

        try
        {
                SessionInitializeTransaction ();
                anuncioEN = (AnuncioEN)session.Get (typeof(AnuncioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return anuncioEN;
}

public System.Collections.Generic.IList<AnuncioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AnuncioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AnuncioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<AnuncioEN>();
                        else
                                result = session.CreateCriteria (typeof(AnuncioEN)).List<AnuncioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AnuncioEN anuncio)
{
        try
        {
                SessionInitializeTransaction ();
                AnuncioEN anuncioEN = (AnuncioEN)session.Load (typeof(AnuncioEN), anuncio.Id);

                anuncioEN.FechaIni = anuncio.FechaIni;


                anuncioEN.FechaFin = anuncio.FechaFin;


                anuncioEN.Direccion = anuncio.Direccion;





                anuncioEN.Detalle = anuncio.Detalle;


                anuncioEN.Estado = anuncio.Estado;



                anuncioEN.Provincia = anuncio.Provincia;


                anuncioEN.Localidad = anuncio.Localidad;


                anuncioEN.AnimalContratado = anuncio.AnimalContratado;

                session.Update (anuncioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (AnuncioEN anuncio)
{
        try
        {
                SessionInitializeTransaction ();
                if (anuncio.Cuidador != null) {
                        // Argumento OID y no colección.
                        anuncio.Cuidador = (PetMeGenNHibernate.EN.PetMe.UsuarioEN)session.Load (typeof(PetMeGenNHibernate.EN.PetMe.UsuarioEN), anuncio.Cuidador.Email);

                        anuncio.Cuidador.Anuncios
                        .Add (anuncio);
                }

                session.Save (anuncio);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return anuncio.Id;
}

public void Modify (AnuncioEN anuncio)
{
        try
        {
                SessionInitializeTransaction ();
                AnuncioEN anuncioEN = (AnuncioEN)session.Load (typeof(AnuncioEN), anuncio.Id);

                anuncioEN.FechaIni = anuncio.FechaIni;


                anuncioEN.FechaFin = anuncio.FechaFin;


                anuncioEN.Direccion = anuncio.Direccion;


                anuncioEN.Detalle = anuncio.Detalle;


                anuncioEN.Estado = anuncio.Estado;


                anuncioEN.Provincia = anuncio.Provincia;


                anuncioEN.Localidad = anuncio.Localidad;

                session.Update (anuncioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
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
                AnuncioEN anuncioEN = (AnuncioEN)session.Load (typeof(AnuncioEN), id);
                session.Delete (anuncioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AsignarContratante (int p_Anuncio_OID, string p_contratante_OID)
{
        PetMeGenNHibernate.EN.PetMe.AnuncioEN anuncioEN = null;
        try
        {
                SessionInitializeTransaction ();
                anuncioEN = (AnuncioEN)session.Load (typeof(AnuncioEN), p_Anuncio_OID);
                anuncioEN.Contratante = (PetMeGenNHibernate.EN.PetMe.UsuarioEN)session.Load (typeof(PetMeGenNHibernate.EN.PetMe.UsuarioEN), p_contratante_OID);

                anuncioEN.Contratante.Anuncios_contratados.Add (anuncioEN);



                session.Update (anuncioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void QuitarContratante (int p_Anuncio_OID, string p_contratante_OID)
{
        try
        {
                SessionInitializeTransaction ();
                PetMeGenNHibernate.EN.PetMe.AnuncioEN anuncioEN = null;
                anuncioEN = (AnuncioEN)session.Load (typeof(AnuncioEN), p_Anuncio_OID);

                if (anuncioEN.Contratante.Email == p_contratante_OID) {
                        anuncioEN.Contratante = null;
                }
                else
                        throw new ModelException ("The identifier " + p_contratante_OID + " in p_contratante_OID you are trying to unrelationer, doesn't exist in AnuncioEN");

                session.Update (anuncioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AsignarComentario (int p_Anuncio_OID, System.Collections.Generic.IList<int> p_comentarios_anuncio_OIDs)
{
        PetMeGenNHibernate.EN.PetMe.AnuncioEN anuncioEN = null;
        try
        {
                SessionInitializeTransaction ();
                anuncioEN = (AnuncioEN)session.Load (typeof(AnuncioEN), p_Anuncio_OID);
                PetMeGenNHibernate.EN.PetMe.ComentarioEN comentarios_anuncioENAux = null;
                if (anuncioEN.Comentarios_anuncio == null) {
                        anuncioEN.Comentarios_anuncio = new System.Collections.Generic.List<PetMeGenNHibernate.EN.PetMe.ComentarioEN>();
                }

                foreach (int item in p_comentarios_anuncio_OIDs) {
                        comentarios_anuncioENAux = new PetMeGenNHibernate.EN.PetMe.ComentarioEN ();
                        comentarios_anuncioENAux = (PetMeGenNHibernate.EN.PetMe.ComentarioEN)session.Load (typeof(PetMeGenNHibernate.EN.PetMe.ComentarioEN), item);
                        comentarios_anuncioENAux.Anuncio = anuncioEN;

                        anuncioEN.Comentarios_anuncio.Add (comentarios_anuncioENAux);
                }


                session.Update (anuncioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void QuitarComentario (int p_Anuncio_OID, System.Collections.Generic.IList<int> p_comentarios_anuncio_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                PetMeGenNHibernate.EN.PetMe.AnuncioEN anuncioEN = null;
                anuncioEN = (AnuncioEN)session.Load (typeof(AnuncioEN), p_Anuncio_OID);

                PetMeGenNHibernate.EN.PetMe.ComentarioEN comentarios_anuncioENAux = null;
                if (anuncioEN.Comentarios_anuncio != null) {
                        foreach (int item in p_comentarios_anuncio_OIDs) {
                                comentarios_anuncioENAux = (PetMeGenNHibernate.EN.PetMe.ComentarioEN)session.Load (typeof(PetMeGenNHibernate.EN.PetMe.ComentarioEN), item);
                                if (anuncioEN.Comentarios_anuncio.Contains (comentarios_anuncioENAux) == true) {
                                        anuncioEN.Comentarios_anuncio.Remove (comentarios_anuncioENAux);
                                        comentarios_anuncioENAux.Anuncio = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_comentarios_anuncio_OIDs you are trying to unrelationer, doesn't exist in AnuncioEN");
                        }
                }

                session.Update (anuncioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
//Sin e: ReadOID
//Con e: AnuncioEN
public AnuncioEN ReadOID (int id
                          )
{
        AnuncioEN anuncioEN = null;

        try
        {
                SessionInitializeTransaction ();
                anuncioEN = (AnuncioEN)session.Get (typeof(AnuncioEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return anuncioEN;
}

public System.Collections.Generic.IList<AnuncioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AnuncioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AnuncioEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AnuncioEN>();
                else
                        result = session.CreateCriteria (typeof(AnuncioEN)).List<AnuncioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AsignarAnimales (int p_Anuncio_OID, System.Collections.Generic.IList<int> p_tipos_Animales_OIDs)
{
        PetMeGenNHibernate.EN.PetMe.AnuncioEN anuncioEN = null;
        try
        {
                SessionInitializeTransaction ();
                anuncioEN = (AnuncioEN)session.Load (typeof(AnuncioEN), p_Anuncio_OID);
                PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN tipos_AnimalesENAux = null;
                if (anuncioEN.Tipos_Animales == null) {
                        anuncioEN.Tipos_Animales = new System.Collections.Generic.List<PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN>();
                }

                foreach (int item in p_tipos_Animales_OIDs) {
                        tipos_AnimalesENAux = new PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN ();
                        tipos_AnimalesENAux = (PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN)session.Load (typeof(PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN), item);
                        tipos_AnimalesENAux.Anuncio = anuncioEN;

                        anuncioEN.Tipos_Animales.Add (tipos_AnimalesENAux);
                }


                session.Update (anuncioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void QuitarAnimales (int p_Anuncio_OID, System.Collections.Generic.IList<int> p_tipos_Animales_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                PetMeGenNHibernate.EN.PetMe.AnuncioEN anuncioEN = null;
                anuncioEN = (AnuncioEN)session.Load (typeof(AnuncioEN), p_Anuncio_OID);

                PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN tipos_AnimalesENAux = null;
                if (anuncioEN.Tipos_Animales != null) {
                        foreach (int item in p_tipos_Animales_OIDs) {
                                tipos_AnimalesENAux = (PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN)session.Load (typeof(PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN), item);
                                if (anuncioEN.Tipos_Animales.Contains (tipos_AnimalesENAux) == true) {
                                        anuncioEN.Tipos_Animales.Remove (tipos_AnimalesENAux);
                                        tipos_AnimalesENAux.Anuncio = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_tipos_Animales_OIDs you are trying to unrelationer, doesn't exist in AnuncioEN");
                        }
                }

                session.Update (anuncioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> BuscarPorFechaFin (Nullable<DateTime> p_fechaFin)
{
        System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AnuncioEN self where FROM AnuncioEN anu WHERE anu.FechaFin <= :p_fechaFin";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AnuncioENbuscarPorFechaFinHQL");
                query.SetParameter ("p_fechaFin", p_fechaFin);

                result = query.List<PetMeGenNHibernate.EN.PetMe.AnuncioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> BuscarPorEstado (PetMeGenNHibernate.Enumerated.PetMe.EstadosEnum ? p_estado)
{
        System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AnuncioEN self where FROM AnuncioEN anu WHERE anu.Estado = :p_estado";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AnuncioENbuscarPorEstadoHQL");
                query.SetParameter ("p_estado", p_estado);

                result = query.List<PetMeGenNHibernate.EN.PetMe.AnuncioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> BuscarPorNoContratado ()
{
        System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AnuncioEN self where FROM AnuncioEN anu WHERE anu.AnimalContratado=0";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AnuncioENbuscarPorNoContratadoHQL");

                result = query.List<PetMeGenNHibernate.EN.PetMe.AnuncioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> BuscarPorProvincia (string p_provincia)
{
        System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AnuncioEN self where FROM AnuncioEN anu WHERE anu.Provincia = :p_provincia";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AnuncioENbuscarPorProvinciaHQL");
                query.SetParameter ("p_provincia", p_provincia);

                result = query.List<PetMeGenNHibernate.EN.PetMe.AnuncioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> BuscarPorLocalidad (string p_localidad)
{
        System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AnuncioEN self where FROM AnuncioEN anu WHERE anu.Localidad = :p_localidad";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AnuncioENbuscarPorLocalidadHQL");
                query.SetParameter ("p_localidad", p_localidad);

                result = query.List<PetMeGenNHibernate.EN.PetMe.AnuncioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> BuscarPorDireccion (string p_direccion)
{
        System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AnuncioEN self where FROM AnuncioEN anu WHERE anu.Direccion = :p_direccion";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AnuncioENbuscarPorDireccionHQL");
                query.SetParameter ("p_direccion", p_direccion);

                result = query.List<PetMeGenNHibernate.EN.PetMe.AnuncioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> BuscarPorFechaIni (Nullable<DateTime> p_fechaIni)
{
        System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AnuncioEN self where FROM AnuncioEN anu WHERE anu.FechaIni > :p_fechaIni";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AnuncioENbuscarPorFechaIniHQL");
                query.SetParameter ("p_fechaIni", p_fechaIni);

                result = query.List<PetMeGenNHibernate.EN.PetMe.AnuncioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AnuncioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
