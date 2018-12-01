
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
 * Clase Tarifa_:
 *
 */

namespace PetMeGenNHibernate.CAD.PetMe
{
public partial class Tarifa_CAD : BasicCAD, ITarifa_CAD
{
public Tarifa_CAD() : base ()
{
}

public Tarifa_CAD(ISession sessionAux) : base (sessionAux)
{
}



public Tarifa_EN ReadOIDDefault (int id
                                 )
{
        Tarifa_EN tarifa_EN = null;

        try
        {
                SessionInitializeTransaction ();
                tarifa_EN = (Tarifa_EN)session.Get (typeof(Tarifa_EN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in Tarifa_CAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tarifa_EN;
}

public System.Collections.Generic.IList<Tarifa_EN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<Tarifa_EN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(Tarifa_EN)).
                                         SetFirstResult (first).SetMaxResults (size).List<Tarifa_EN>();
                        else
                                result = session.CreateCriteria (typeof(Tarifa_EN)).List<Tarifa_EN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in Tarifa_CAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (Tarifa_EN tarifa_)
{
        try
        {
                SessionInitializeTransaction ();
                Tarifa_EN tarifa_EN = (Tarifa_EN)session.Load (typeof(Tarifa_EN), tarifa_.Id);

                tarifa_EN.Precio = tarifa_.Precio;


                session.Update (tarifa_EN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in Tarifa_CAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (Tarifa_EN tarifa_)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (tarifa_);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in Tarifa_CAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tarifa_.Id;
}

public void Modify (Tarifa_EN tarifa_)
{
        try
        {
                SessionInitializeTransaction ();
                Tarifa_EN tarifa_EN = (Tarifa_EN)session.Load (typeof(Tarifa_EN), tarifa_.Id);

                tarifa_EN.Precio = tarifa_.Precio;

                session.Update (tarifa_EN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in Tarifa_CAD.", ex);
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
                Tarifa_EN tarifa_EN = (Tarifa_EN)session.Load (typeof(Tarifa_EN), id);
                session.Delete (tarifa_EN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in Tarifa_CAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AsignarTipoAnimal (int p_Tarifa__OID, System.Collections.Generic.IList<int> p_tipo_Animal_OIDs)
{
        PetMeGenNHibernate.EN.PetMe.Tarifa_EN tarifa_EN = null;
        try
        {
                SessionInitializeTransaction ();
                tarifa_EN = (Tarifa_EN)session.Load (typeof(Tarifa_EN), p_Tarifa__OID);
                PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN tipo_AnimalENAux = null;
                if (tarifa_EN.Tipo_Animal == null) {
                        tarifa_EN.Tipo_Animal = new System.Collections.Generic.List<PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN>();
                }

                foreach (int item in p_tipo_Animal_OIDs) {
                        tipo_AnimalENAux = new PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN ();
                        tipo_AnimalENAux = (PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN)session.Load (typeof(PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN), item);
                        tipo_AnimalENAux.Tarifa = tarifa_EN;

                        tarifa_EN.Tipo_Animal.Add (tipo_AnimalENAux);
                }


                session.Update (tarifa_EN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in Tarifa_CAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void QuitarTipoAnimal (int p_Tarifa__OID, System.Collections.Generic.IList<int> p_tipo_Animal_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                PetMeGenNHibernate.EN.PetMe.Tarifa_EN tarifa_EN = null;
                tarifa_EN = (Tarifa_EN)session.Load (typeof(Tarifa_EN), p_Tarifa__OID);

                PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN tipo_AnimalENAux = null;
                if (tarifa_EN.Tipo_Animal != null) {
                        foreach (int item in p_tipo_Animal_OIDs) {
                                tipo_AnimalENAux = (PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN)session.Load (typeof(PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN), item);
                                if (tarifa_EN.Tipo_Animal.Contains (tipo_AnimalENAux) == true) {
                                        tarifa_EN.Tipo_Animal.Remove (tipo_AnimalENAux);
                                        tipo_AnimalENAux.Tarifa = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_tipo_Animal_OIDs you are trying to unrelationer, doesn't exist in Tarifa_EN");
                        }
                }

                session.Update (tarifa_EN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in Tarifa_CAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
