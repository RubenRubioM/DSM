

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PetMeGenNHibernate.Exceptions;

using PetMeGenNHibernate.EN.PetMe;
using PetMeGenNHibernate.CAD.PetMe;


namespace PetMeGenNHibernate.CEN.PetMe
{
/*
 *      Definition of the class AdministradorCEN
 *
 */
public partial class AdministradorCEN
{
private IAdministradorCAD _IAdministradorCAD;

public AdministradorCEN()
{
        this._IAdministradorCAD = new AdministradorCAD ();
}

public AdministradorCEN(IAdministradorCAD _IAdministradorCAD)
{
        this._IAdministradorCAD = _IAdministradorCAD;
}

public IAdministradorCAD get_IAdministradorCAD ()
{
        return this._IAdministradorCAD;
}

public string New_ (string p_email, string p_nombre, string p_apellidos, string p_nick, Nullable<DateTime> p_nacimiento, string p_provincia, string p_localidad, float p_cartera, PetMeGenNHibernate.Enumerated.PetMe.EstadoUsuarioEnum p_estado, String p_pass, string p_motivoEstado)
{
        AdministradorEN administradorEN = null;
        string oid;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.Email = p_email;

        administradorEN.Nombre = p_nombre;

        administradorEN.Apellidos = p_apellidos;

        administradorEN.Nick = p_nick;

        administradorEN.Nacimiento = p_nacimiento;

        administradorEN.Provincia = p_provincia;

        administradorEN.Localidad = p_localidad;

        administradorEN.Cartera = p_cartera;

        administradorEN.Estado = p_estado;

        administradorEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        administradorEN.MotivoEstado = p_motivoEstado;

        //Call to AdministradorCAD

        oid = _IAdministradorCAD.New_ (administradorEN);
        return oid;
}

public void Modify (string p_Administrador_OID, string p_nombre, string p_apellidos, string p_nick, Nullable<DateTime> p_nacimiento, string p_provincia, string p_localidad, float p_cartera, PetMeGenNHibernate.Enumerated.PetMe.EstadoUsuarioEnum p_estado, String p_pass, string p_motivoEstado)
{
        AdministradorEN administradorEN = null;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.Email = p_Administrador_OID;
        administradorEN.Nombre = p_nombre;
        administradorEN.Apellidos = p_apellidos;
        administradorEN.Nick = p_nick;
        administradorEN.Nacimiento = p_nacimiento;
        administradorEN.Provincia = p_provincia;
        administradorEN.Localidad = p_localidad;
        administradorEN.Cartera = p_cartera;
        administradorEN.Estado = p_estado;
        administradorEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        administradorEN.MotivoEstado = p_motivoEstado;
        //Call to AdministradorCAD

        _IAdministradorCAD.Modify (administradorEN);
}

public void Destroy (string email
                     )
{
        _IAdministradorCAD.Destroy (email);
}

public AdministradorEN ReadOID (string email
                                )
{
        AdministradorEN administradorEN = null;

        administradorEN = _IAdministradorCAD.ReadOID (email);
        return administradorEN;
}

public System.Collections.Generic.IList<AdministradorEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AdministradorEN> list = null;

        list = _IAdministradorCAD.ReadAll (first, size);
        return list;
}
}
}
