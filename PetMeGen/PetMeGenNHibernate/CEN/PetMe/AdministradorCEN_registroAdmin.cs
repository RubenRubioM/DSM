
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PetMeGenNHibernate.Exceptions;
using PetMeGenNHibernate.EN.PetMe;
using PetMeGenNHibernate.CAD.PetMe;


/*PROTECTED REGION ID(usingPetMeGenNHibernate.CEN.PetMe_Administrador_registroAdmin) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PetMeGenNHibernate.CEN.PetMe
{
public partial class AdministradorCEN
{
public string RegistroAdmin (string p_email, String p_pass, string p_nombre, string p_apellidos, string p_nick, Nullable<DateTime> p_nacimiento, string p_provincia, string p_localidad, string p_validador)
{
        /*PROTECTED REGION ID(PetMeGenNHibernate.CEN.PetMe_Administrador_registroAdmin_customized) START*/

        AdministradorEN administradorEN = null;

        string oid;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.Email = p_email;

        administradorEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        administradorEN.Nombre = p_nombre;

        administradorEN.Apellidos = p_apellidos;

        administradorEN.Nick = p_nick;

        administradorEN.Nacimiento = p_nacimiento;

        administradorEN.Provincia = p_provincia;

        administradorEN.Localidad = p_localidad;

        administradorEN.Validador = p_validador;

        //Call to AdministradorCAD

        oid = _IAdministradorCAD.RegistroAdmin (administradorEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
