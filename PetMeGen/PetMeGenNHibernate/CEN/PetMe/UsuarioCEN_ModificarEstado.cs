
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


/*PROTECTED REGION ID(usingPetMeGenNHibernate.CEN.PetMe_Usuario_modificarEstado) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PetMeGenNHibernate.CEN.PetMe
{
public partial class UsuarioCEN
{
public void ModificarEstado (string p_oid, PetMeGenNHibernate.Enumerated.PetMe.EstadoUsuarioEnum p_estado, string p_motivo)
{
        /*PROTECTED REGION ID(PetMeGenNHibernate.CEN.PetMe_Usuario_modificarEstado) ENABLED START*/

        UsuarioEN usuario = _IUsuarioCAD.ReadOIDDefault (p_oid);

        usuario.Estado = p_estado;
        usuario.MotivoEstado = p_motivo;

        _IUsuarioCAD.Modify (usuario);

        /*PROTECTED REGION END*/
}
}
}
