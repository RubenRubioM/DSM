

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
 *      Definition of the class AnuncioCEN
 *
 */
public partial class AnuncioCEN
{
private IAnuncioCAD _IAnuncioCAD;

public AnuncioCEN()
{
        this._IAnuncioCAD = new AnuncioCAD ();
}

public AnuncioCEN(IAnuncioCAD _IAnuncioCAD)
{
        this._IAnuncioCAD = _IAnuncioCAD;
}

public IAnuncioCAD get_IAnuncioCAD ()
{
        return this._IAnuncioCAD;
}

public int New_ (Nullable<DateTime> p_fechaIni, Nullable<DateTime> p_fechaFin, string p_direccion, string p_cuidador, string p_detalle, string p_localidad, string p_provincia)
{
        AnuncioEN anuncioEN = null;
        int oid;

        //Initialized AnuncioEN
        anuncioEN = new AnuncioEN ();
        anuncioEN.FechaIni = p_fechaIni;

        anuncioEN.FechaFin = p_fechaFin;

        anuncioEN.Direccion = p_direccion;


        if (p_cuidador != null) {
                // El argumento p_cuidador -> Property cuidador es oid = false
                // Lista de oids id
                anuncioEN.Cuidador = new PetMeGenNHibernate.EN.PetMe.UsuarioEN ();
                anuncioEN.Cuidador.Email = p_cuidador;
        }

        anuncioEN.Detalle = p_detalle;

        anuncioEN.Localidad = p_localidad;

        anuncioEN.Provincia = p_provincia;

        //Call to AnuncioCAD

        oid = _IAnuncioCAD.New_ (anuncioEN);
        return oid;
}

public void Modify (int p_Anuncio_OID, Nullable<DateTime> p_fechaIni, Nullable<DateTime> p_fechaFin, string p_direccion, string p_detalle, PetMeGenNHibernate.Enumerated.PetMe.EstadosEnum p_estado, string p_provincia, string p_localidad)
{
        AnuncioEN anuncioEN = null;

        //Initialized AnuncioEN
        anuncioEN = new AnuncioEN ();
        anuncioEN.Id = p_Anuncio_OID;
        anuncioEN.FechaIni = p_fechaIni;
        anuncioEN.FechaFin = p_fechaFin;
        anuncioEN.Direccion = p_direccion;
        anuncioEN.Detalle = p_detalle;
        anuncioEN.Estado = p_estado;
        anuncioEN.Provincia = p_provincia;
        anuncioEN.Localidad = p_localidad;
        //Call to AnuncioCAD

        _IAnuncioCAD.Modify (anuncioEN);
}

public void Destroy (int id
                     )
{
        _IAnuncioCAD.Destroy (id);
}

public void AsignarContratante (int p_Anuncio_OID, string p_contratante_OID)
{
        //Call to AnuncioCAD

        _IAnuncioCAD.AsignarContratante (p_Anuncio_OID, p_contratante_OID);
}
public void QuitarContratante (int p_Anuncio_OID, string p_contratante_OID)
{
        //Call to AnuncioCAD

        _IAnuncioCAD.QuitarContratante (p_Anuncio_OID, p_contratante_OID);
}
public void AsignarComentario (int p_Anuncio_OID, System.Collections.Generic.IList<int> p_comentarios_anuncio_OIDs)
{
        //Call to AnuncioCAD

        _IAnuncioCAD.AsignarComentario (p_Anuncio_OID, p_comentarios_anuncio_OIDs);
}
public void QuitarComentario (int p_Anuncio_OID, System.Collections.Generic.IList<int> p_comentarios_anuncio_OIDs)
{
        //Call to AnuncioCAD

        _IAnuncioCAD.QuitarComentario (p_Anuncio_OID, p_comentarios_anuncio_OIDs);
}
public AnuncioEN ReadOID (int id
                          )
{
        AnuncioEN anuncioEN = null;

        anuncioEN = _IAnuncioCAD.ReadOID (id);
        return anuncioEN;
}

public System.Collections.Generic.IList<AnuncioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AnuncioEN> list = null;

        list = _IAnuncioCAD.ReadAll (first, size);
        return list;
}
public void AsignarAnimales (int p_Anuncio_OID, System.Collections.Generic.IList<int> p_tipos_Animales_OIDs)
{
        //Call to AnuncioCAD

        _IAnuncioCAD.AsignarAnimales (p_Anuncio_OID, p_tipos_Animales_OIDs);
}
public void QuitarAnimales (int p_Anuncio_OID, System.Collections.Generic.IList<int> p_tipos_Animales_OIDs)
{
        //Call to AnuncioCAD

        _IAnuncioCAD.QuitarAnimales (p_Anuncio_OID, p_tipos_Animales_OIDs);
}
public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> BuscarPorFechaFin (Nullable<DateTime> p_fechaFin)
{
        return _IAnuncioCAD.BuscarPorFechaFin (p_fechaFin);
}
public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> BuscarPorEstado (PetMeGenNHibernate.Enumerated.PetMe.EstadosEnum ? p_estado)
{
        return _IAnuncioCAD.BuscarPorEstado (p_estado);
}
public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> BuscarPorNoContratado ()
{
        return _IAnuncioCAD.BuscarPorNoContratado ();
}
public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> BuscarPorProvincia (string p_provincia)
{
        return _IAnuncioCAD.BuscarPorProvincia (p_provincia);
}
public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> BuscarPorLocalidad (string p_localidad)
{
        return _IAnuncioCAD.BuscarPorLocalidad (p_localidad);
}
public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> BuscarPorDireccion (string p_direccion)
{
        return _IAnuncioCAD.BuscarPorDireccion (p_direccion);
}
public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> BuscarPorFechaIni (Nullable<DateTime> p_fechaIni)
{
        return _IAnuncioCAD.BuscarPorFechaIni (p_fechaIni);
}
}
}
