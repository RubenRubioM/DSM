
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
 * Clase Administrador:
 *
 */

namespace PetMeGenNHibernate.CAD.PetMe
{
public partial class AdministradorCAD : BasicCAD, IAdministradorCAD
{
public AdministradorCAD() : base ()
{
}

public AdministradorCAD(ISession sessionAux) : base (sessionAux)
{
}



public AdministradorEN ReadOIDDefault (string email
                                       )
{
        AdministradorEN administradorEN = null;

        try
        {
                SessionInitializeTransaction ();
                administradorEN = (AdministradorEN)session.Get (typeof(AdministradorEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AdministradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return administradorEN;
}

public System.Collections.Generic.IList<AdministradorEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AdministradorEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AdministradorEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<AdministradorEN>();
                        else
                                result = session.CreateCriteria (typeof(AdministradorEN)).List<AdministradorEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AdministradorCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AdministradorEN administrador)
{
        try
        {
                SessionInitializeTransaction ();
                AdministradorEN administradorEN = (AdministradorEN)session.Load (typeof(AdministradorEN), administrador.Email);
                session.Update (administradorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AdministradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string New_ (AdministradorEN administrador)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (administrador);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AdministradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return administrador.Email;
}

public void Modify (AdministradorEN administrador)
{
        try
        {
                SessionInitializeTransaction ();
                AdministradorEN administradorEN = (AdministradorEN)session.Load (typeof(AdministradorEN), administrador.Email);

                administradorEN.Nombre = administrador.Nombre;


                administradorEN.Apellidos = administrador.Apellidos;


                administradorEN.Nick = administrador.Nick;


                administradorEN.Nacimiento = administrador.Nacimiento;


                administradorEN.Provincia = administrador.Provincia;


                administradorEN.Localidad = administrador.Localidad;


                administradorEN.Cartera = administrador.Cartera;


                administradorEN.Telefono = administrador.Telefono;


                administradorEN.Estado = administrador.Estado;


                administradorEN.Pass = administrador.Pass;


                administradorEN.MotivoEstado = administrador.MotivoEstado;

                session.Update (administradorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AdministradorCAD.", ex);
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
                AdministradorEN administradorEN = (AdministradorEN)session.Load (typeof(AdministradorEN), email);
                session.Delete (administradorEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AdministradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: AdministradorEN
public AdministradorEN ReadOID (string email
                                )
{
        AdministradorEN administradorEN = null;

        try
        {
                SessionInitializeTransaction ();
                administradorEN = (AdministradorEN)session.Get (typeof(AdministradorEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AdministradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return administradorEN;
}

public System.Collections.Generic.IList<AdministradorEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AdministradorEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AdministradorEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<AdministradorEN>();
                else
                        result = session.CreateCriteria (typeof(AdministradorEN)).List<AdministradorEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PetMeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PetMeGenNHibernate.Exceptions.DataLayerException ("Error in AdministradorCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
