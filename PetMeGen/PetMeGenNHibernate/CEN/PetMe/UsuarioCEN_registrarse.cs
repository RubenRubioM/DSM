
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


/*PROTECTED REGION ID(usingPetMeGenNHibernate.CEN.PetMe_Usuario_registrarse) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PetMeGenNHibernate.CEN.PetMe
{
public partial class UsuarioCEN
{
public string Registrarse (string p_email, String p_pass, string p_nombre, string p_apellidos, string p_nick, Nullable<DateTime> p_nacimiento, string p_provincia, string p_localidad)
{
        /*PROTECTED REGION ID(PetMeGenNHibernate.CEN.PetMe_Usuario_registrarse_customized) START*/

        UsuarioEN usuarioEN = null;

        string oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_email;

        usuarioEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        usuarioEN.Nombre = p_nombre;

        usuarioEN.Apellidos = p_apellidos;

        usuarioEN.Nick = p_nick;

        usuarioEN.Nacimiento = p_nacimiento;

        usuarioEN.Provincia = p_provincia;

        usuarioEN.Localidad = p_localidad;

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.Registrarse (usuarioEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
