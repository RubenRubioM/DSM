
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


/*PROTECTED REGION ID(usingPetMeGenNHibernate.CEN.PetMe_Usuario_incrementarCartera) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PetMeGenNHibernate.CEN.PetMe
{
public partial class UsuarioCEN
{
public void IncrementarCartera (string p_oid, float p_cantidad)
{
        /*PROTECTED REGION ID(PetMeGenNHibernate.CEN.PetMe_Usuario_incrementarCartera) ENABLED START*/

        UsuarioEN usuario = _IUsuarioCAD.ReadOIDDefault (p_oid);

        usuario.Cartera += p_cantidad;

        _IUsuarioCAD.Modify (usuario);

        /*PROTECTED REGION END*/
}
}
}
