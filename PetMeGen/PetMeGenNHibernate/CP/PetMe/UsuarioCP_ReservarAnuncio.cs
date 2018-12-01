
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



/*PROTECTED REGION ID(usingPetMeGenNHibernate.CP.PetMe_Usuario_reservarAnuncio) ENABLED START*/
using PetMeGenNHibernate.Enumerated.PetMe;
/*PROTECTED REGION END*/

namespace PetMeGenNHibernate.CP.PetMe
{
public partial class UsuarioCP : BasicCP
{
public void ReservarAnuncio (string p_oid, int p_anuncio_OID, int p_animal_OID)
{
        /*PROTECTED REGION ID(PetMeGenNHibernate.CP.PetMe_Usuario_reservarAnuncio) ENABLED START*/

        IUsuarioCAD usuarioCAD = null;
        UsuarioCEN usuarioCEN = null;
        IAnuncioCAD anuncioCAD = null;
        AnuncioCEN anuncioCEN = null;


        try
        {
                SessionInitializeTransaction ();
                usuarioCAD = new UsuarioCAD (session);
                usuarioCEN = new  UsuarioCEN (usuarioCAD);
                anuncioCAD = new AnuncioCAD (session);
                anuncioCEN = new AnuncioCEN (anuncioCAD);

                // modificamos estado a contratado, junto al animal escogido, y lo reflejamos en la base de datos
                AnuncioEN anuncio = anuncioCEN.ReadOID (p_anuncio_OID);
                anuncioCEN.Modify (p_anuncio_OID, anuncio.FechaIni, anuncio.FechaFin, anuncio.Direccion, anuncio.Detalle, EstadosEnum.contratado, anuncio.Provincia, anuncio.Localidad);
                anuncioCEN.ContratarAnimal (p_anuncio_OID, p_animal_OID);

                // llamamos al relationer para meter dicho anuncio
                IList<int> contratado = new List<int>(p_anuncio_OID);
                usuarioCEN.AsignarAnuncioContratado (p_oid, contratado);

                // luego llamamos al relationer de anuncio para reflejar su contratante
                anuncioCEN.AsignarContratante (p_anuncio_OID, p_oid);

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
