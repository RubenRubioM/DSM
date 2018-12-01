

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
 *      Definition of the class Tarifa_CEN
 *
 */
public partial class Tarifa_CEN
{
private ITarifa_CAD _ITarifa_CAD;

public Tarifa_CEN()
{
        this._ITarifa_CAD = new Tarifa_CAD ();
}

public Tarifa_CEN(ITarifa_CAD _ITarifa_CAD)
{
        this._ITarifa_CAD = _ITarifa_CAD;
}

public ITarifa_CAD get_ITarifa_CAD ()
{
        return this._ITarifa_CAD;
}

public int New_ (float p_precio)
{
        Tarifa_EN tarifa_EN = null;
        int oid;

        //Initialized Tarifa_EN
        tarifa_EN = new Tarifa_EN ();
        tarifa_EN.Precio = p_precio;

        //Call to Tarifa_CAD

        oid = _ITarifa_CAD.New_ (tarifa_EN);
        return oid;
}

public void Modify (int p_Tarifa__OID, float p_precio)
{
        Tarifa_EN tarifa_EN = null;

        //Initialized Tarifa_EN
        tarifa_EN = new Tarifa_EN ();
        tarifa_EN.Id = p_Tarifa__OID;
        tarifa_EN.Precio = p_precio;
        //Call to Tarifa_CAD

        _ITarifa_CAD.Modify (tarifa_EN);
}

public void Destroy (int id
                     )
{
        _ITarifa_CAD.Destroy (id);
}

public void AsignarTipoAnimal (int p_Tarifa__OID, System.Collections.Generic.IList<int> p_tipo_Animal_OIDs)
{
        //Call to Tarifa_CAD

        _ITarifa_CAD.AsignarTipoAnimal (p_Tarifa__OID, p_tipo_Animal_OIDs);
}
public void QuitarTipoAnimal (int p_Tarifa__OID, System.Collections.Generic.IList<int> p_tipo_Animal_OIDs)
{
        //Call to Tarifa_CAD

        _ITarifa_CAD.QuitarTipoAnimal (p_Tarifa__OID, p_tipo_Animal_OIDs);
}
}
}
