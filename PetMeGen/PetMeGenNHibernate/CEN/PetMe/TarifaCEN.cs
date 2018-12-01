

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
 *      Definition of the class TarifaCEN
 *
 */
public partial class TarifaCEN
{
private ITarifaCAD _ITarifaCAD;

public TarifaCEN()
{
        this._ITarifaCAD = new TarifaCAD ();
}

public TarifaCEN(ITarifaCAD _ITarifaCAD)
{
        this._ITarifaCAD = _ITarifaCAD;
}

public ITarifaCAD get_ITarifaCAD ()
{
        return this._ITarifaCAD;
}

public int New_ (double p_precio, int p_tipos_Animales)
{
        TarifaEN tarifaEN = null;
        int oid;

        //Initialized TarifaEN
        tarifaEN = new TarifaEN ();
        tarifaEN.Precio = p_precio;


        if (p_tipos_Animales != -1) {
                // El argumento p_tipos_Animales -> Property tipos_Animales es oid = false
                // Lista de oids id
                tarifaEN.Tipos_Animales = new PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN ();
                tarifaEN.Tipos_Animales.Id = p_tipos_Animales;
        }

        //Call to TarifaCAD

        oid = _ITarifaCAD.New_ (tarifaEN);
        return oid;
}

public void Modify (int p_Tarifa_OID, double p_precio)
{
        TarifaEN tarifaEN = null;

        //Initialized TarifaEN
        tarifaEN = new TarifaEN ();
        tarifaEN.Id = p_Tarifa_OID;
        tarifaEN.Precio = p_precio;
        //Call to TarifaCAD

        _ITarifaCAD.Modify (tarifaEN);
}

public void Destroy (int id
                     )
{
        _ITarifaCAD.Destroy (id);
}
}
}
