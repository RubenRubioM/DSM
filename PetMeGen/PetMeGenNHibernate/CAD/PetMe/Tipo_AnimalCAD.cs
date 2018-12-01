
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
 * Clase Tipo_Animal:
 *
 */

namespace PetMeGenNHibernate.CAD.PetMe
{
public partial class Tipo_AnimalCAD : BasicCAD, ITipo_AnimalCAD
{
public Tipo_AnimalCAD() : base ()
{
}

public Tipo_AnimalCAD(ISession sessionAux) : base (sessionAux)
{
}



public Tipo_AnimalEN ReadOIDDefault (int id
                                     )
{
        Tipo_AnimalEN tipo_AnimalEN = null;

        try
        {
                SessionInitializeTransaction ();
                tipo_AnimalEN = (Tipo_AnimalEN)session.Get (typeof(Tipo_AnimalEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in Tipo_AnimalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tipo_AnimalEN;
}

public System.Collections.Generic.IList<Tipo_AnimalEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<Tipo_AnimalEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(Tipo_AnimalEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<Tipo_AnimalEN>();
                        else
                                result = session.CreateCriteria (typeof(Tipo_AnimalEN)).List<Tipo_AnimalEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in Tipo_AnimalCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (Tipo_AnimalEN tipo_Animal)
{
        try
        {
                SessionInitializeTransaction ();
                Tipo_AnimalEN tipo_AnimalEN = (Tipo_AnimalEN)session.Load (typeof(Tipo_AnimalEN), tipo_Animal.Id);

                tipo_AnimalEN.Tipo = tipo_Animal.Tipo;



                tipo_AnimalEN.Tarifa = tipo_Animal.Tarifa;

                session.Update (tipo_AnimalEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in Tipo_AnimalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (Tipo_AnimalEN tipo_Animal)
{
        try
        {
                SessionInitializeTransaction ();
                if (tipo_Animal.Anuncio != null) {
                        // Argumento OID y no colección.
                        tipo_Animal.Anuncio = (PetMeGenNHibernate.EN.PetMe.AnuncioEN)session.Load (typeof(PetMeGenNHibernate.EN.PetMe.AnuncioEN), tipo_Animal.Anuncio.Id);

                        tipo_Animal.Anuncio.Tipos_Animales
                        .Add (tipo_Animal);
                }

                session.Save (tipo_Animal);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in Tipo_AnimalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tipo_Animal.Id;
}

public void Modify (Tipo_AnimalEN tipo_Animal)
{
        try
        {
                SessionInitializeTransaction ();
                Tipo_AnimalEN tipo_AnimalEN = (Tipo_AnimalEN)session.Load (typeof(Tipo_AnimalEN), tipo_Animal.Id);

                tipo_AnimalEN.Tipo = tipo_Animal.Tipo;


                tipo_AnimalEN.Tarifa = tipo_Animal.Tarifa;

                session.Update (tipo_AnimalEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in Tipo_AnimalCAD.", ex);
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
                Tipo_AnimalEN tipo_AnimalEN = (Tipo_AnimalEN)session.Load (typeof(Tipo_AnimalEN), id);
                session.Delete (tipo_AnimalEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in Tipo_AnimalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: Tipo_AnimalEN
public Tipo_AnimalEN ReadOID (int id
                              )
{
        Tipo_AnimalEN tipo_AnimalEN = null;

        try
        {
                SessionInitializeTransaction ();
                tipo_AnimalEN = (Tipo_AnimalEN)session.Get (typeof(Tipo_AnimalEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in Tipo_AnimalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tipo_AnimalEN;
}

public System.Collections.Generic.IList<Tipo_AnimalEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<Tipo_AnimalEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(Tipo_AnimalEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<Tipo_AnimalEN>();
                else
                        result = session.CreateCriteria (typeof(Tipo_AnimalEN)).List<Tipo_AnimalEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in Tipo_AnimalCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
