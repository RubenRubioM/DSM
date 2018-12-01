
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


/*PROTECTED REGION ID(usingPetMeGenNHibernate.CEN.PetMe_Usuario_darDeAlta) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PetMeGenNHibernate.CEN.PetMe
{
public partial class UsuarioCEN
{
public void DarDeAlta (string p_oid, string p_motivo)
{
        /*PROTECTED REGION ID(PetMeGenNHibernate.CEN.PetMe_Usuario_darDeAlta) ENABLED START*/

        UsuarioEN usuario = _IUsuarioCAD.ReadOIDDefault (p_oid);

        usuario.MotivoEstado = p_motivo;
        usuario.Estado = Enumerated.PetMe.EstadoUsuarioEnum.activo;

        _IUsuarioCAD.Modify (usuario);

        /*PROTECTED REGION END*/
}
}
}
