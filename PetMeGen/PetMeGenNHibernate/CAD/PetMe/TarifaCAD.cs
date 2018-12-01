
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
 * Clase Tarifa:
 *
 */

namespace PetMeGenNHibernate.CAD.PetMe
{
public partial class TarifaCAD : BasicCAD, ITarifaCAD
{
public TarifaCAD() : base ()
{
}

public TarifaCAD(ISession sessionAux) : base (sessionAux)
{
}



public TarifaEN ReadOIDDefault (int id
                                )
{
        TarifaEN tarifaEN = null;

        try
        {
                SessionInitializeTransaction ();
                tarifaEN = (TarifaEN)session.Get (typeof(TarifaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in TarifaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tarifaEN;
}

public System.Collections.Generic.IList<TarifaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<TarifaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(TarifaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<TarifaEN>();
                        else
                                result = session.CreateCriteria (typeof(TarifaEN)).List<TarifaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in TarifaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (TarifaEN tarifa)
{
        try
        {
                SessionInitializeTransaction ();
                TarifaEN tarifaEN = (TarifaEN)session.Load (typeof(TarifaEN), tarifa.Id);

                tarifaEN.Precio = tarifa.Precio;


                session.Update (tarifaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in TarifaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (TarifaEN tarifa)
{
        try
        {
                SessionInitializeTransaction ();
                if (tarifa.Tipos_Animales != null) {
                        // Argumento OID y no colección.
                        tarifa.Tipos_Animales = (PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN)session.Load (typeof(PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN), tarifa.Tipos_Animales.Id);

                        tarifa.Tipos_Animales.Tarifa
                                = tarifa;
                }

                session.Save (tarifa);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in TarifaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tarifa.Id;
}

public void Modify (TarifaEN tarifa)
{
        try
        {
                SessionInitializeTransaction ();
                TarifaEN tarifaEN = (TarifaEN)session.Load (typeof(TarifaEN), tarifa.Id);

                tarifaEN.Precio = tarifa.Precio;

                session.Update (tarifaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in TarifaCAD.", ex);
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
                TarifaEN tarifaEN = (TarifaEN)session.Load (typeof(TarifaEN), id);
                session.Delete (tarifaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in TarifaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
