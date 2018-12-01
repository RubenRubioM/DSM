

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
 *      Definition of the class Tipo_AnimalCEN
 *
 */
public partial class Tipo_AnimalCEN
{
private ITipo_AnimalCAD _ITipo_AnimalCAD;

public Tipo_AnimalCEN()
{
        this._ITipo_AnimalCAD = new Tipo_AnimalCAD ();
}

public Tipo_AnimalCEN(ITipo_AnimalCAD _ITipo_AnimalCAD)
{
        this._ITipo_AnimalCAD = _ITipo_AnimalCAD;
}

public ITipo_AnimalCAD get_ITipo_AnimalCAD ()
{
        return this._ITipo_AnimalCAD;
}

public int New_ (string p_tipo, int p_anuncio, double p_tarifa)
{
        Tipo_AnimalEN tipo_AnimalEN = null;
        int oid;

        //Initialized Tipo_AnimalEN
        tipo_AnimalEN = new Tipo_AnimalEN ();
        tipo_AnimalEN.Tipo = p_tipo;


        if (p_anuncio != -1) {
                // El argumento p_anuncio -> Property anuncio es oid = false
                // Lista de oids id
                tipo_AnimalEN.Anuncio = new PetMeGenNHibernate.EN.PetMe.AnuncioEN ();
                tipo_AnimalEN.Anuncio.Id = p_anuncio;
        }

        tipo_AnimalEN.Tarifa = p_tarifa;

        //Call to Tipo_AnimalCAD

        oid = _ITipo_AnimalCAD.New_ (tipo_AnimalEN);
        return oid;
}

public void Modify (int p_Tipo_Animal_OID, string p_tipo, double p_tarifa)
{
        Tipo_AnimalEN tipo_AnimalEN = null;

        //Initialized Tipo_AnimalEN
        tipo_AnimalEN = new Tipo_AnimalEN ();
        tipo_AnimalEN.Id = p_Tipo_Animal_OID;
        tipo_AnimalEN.Tipo = p_tipo;
        tipo_AnimalEN.Tarifa = p_tarifa;
        //Call to Tipo_AnimalCAD

        _ITipo_AnimalCAD.Modify (tipo_AnimalEN);
}

public void Destroy (int id
                     )
{
        _ITipo_AnimalCAD.Destroy (id);
}

public Tipo_AnimalEN ReadOID (int id
                              )
{
        Tipo_AnimalEN tipo_AnimalEN = null;

        tipo_AnimalEN = _ITipo_AnimalCAD.ReadOID (id);
        return tipo_AnimalEN;
}

public System.Collections.Generic.IList<Tipo_AnimalEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<Tipo_AnimalEN> list = null;

        list = _ITipo_AnimalCAD.ReadAll (first, size);
        return list;
}
}
}
