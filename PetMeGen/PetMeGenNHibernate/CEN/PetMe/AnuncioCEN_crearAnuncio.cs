
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


/*PROTECTED REGION ID(usingPetMeGenNHibernate.CEN.PetMe_Anuncio_crearAnuncio) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PetMeGenNHibernate.CEN.PetMe
{
public partial class AnuncioCEN
{
public int CrearAnuncio (Nullable<DateTime> p_fechaIni, Nullable<DateTime> p_fechaFin, string p_direccion, string p_cuidador, string p_detalle, string p_localidad, string p_provincia)
{
        /*PROTECTED REGION ID(PetMeGenNHibernate.CEN.PetMe_Anuncio_crearAnuncio_customized) START*/

        AnuncioEN anuncioEN = null;

        int oid;

        //Initialized AnuncioEN
        anuncioEN = new AnuncioEN ();
        anuncioEN.FechaIni = p_fechaIni;

        anuncioEN.FechaFin = p_fechaFin;

        anuncioEN.Direccion = p_direccion;


        if (p_cuidador != null) {
                anuncioEN.Cuidador = new PetMeGenNHibernate.EN.PetMe.UsuarioEN ();
                anuncioEN.Cuidador.Email = p_cuidador;
        }

        anuncioEN.Detalle = p_detalle;

        anuncioEN.Localidad = p_localidad;

        anuncioEN.Provincia = p_provincia;

        //Call to AnuncioCAD

        oid = _IAnuncioCAD.CrearAnuncio (anuncioEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
