
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using PetMeGenNHibernate.EN.PetMe;
using PetMeGenNHibernate.CAD.PetMe;
using PetMeGenNHibernate.CEN.PetMe;



/*PROTECTED REGION ID(usingPetMeGenNHibernate.CP.PetMe_Administrador_modificarEstado) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PetMeGenNHibernate.CP.PetMe
{
public partial class AdministradorCP : BasicCP
{
public void ModificarEstado (string p_oid, string p_usuario, PetMeGenNHibernate.Enumerated.PetMe.EstadoUsuarioEnum p_estado, string p_motivo_estado)
{
        /*PROTECTED REGION ID(PetMeGenNHibernate.CP.PetMe_Administrador_modificarEstado) ENABLED START*/

        IAdministradorCAD administradorCAD = null;
        AdministradorCEN administradorCEN = null;
        IUsuarioCAD usuarioCAD = null;
        UsuarioCEN usuarioCEN = null;

        try
        {
                SessionInitializeTransaction ();
                administradorCAD = new AdministradorCAD (session);
                administradorCEN = new  AdministradorCEN (administradorCAD);
                usuarioCAD = new UsuarioCAD (session);
                usuarioCEN = new UsuarioCEN (usuarioCAD);

                usuarioCEN.ModificarEstado (p_usuario, p_estado, p_motivo_estado);

                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
