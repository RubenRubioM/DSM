
using System;
// Definición clase TarifaEN
namespace PetMeGenNHibernate.EN.PetMe
{
public partial class TarifaEN
{
/**
 *	Atributo precio
 */
private double precio;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo tipos_Animales
 */
private PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN tipos_Animales;






public virtual double Precio {
        get { return precio; } set { precio = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN Tipos_Animales {
        get { return tipos_Animales; } set { tipos_Animales = value;  }
}





public TarifaEN()
{
}



public TarifaEN(int id, double precio, PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN tipos_Animales
                )
{
        this.init (Id, precio, tipos_Animales);
}


public TarifaEN(TarifaEN tarifa)
{
        this.init (Id, tarifa.Precio, tarifa.Tipos_Animales);
}

private void init (int id
                   , double precio, PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN tipos_Animales)
{
        this.Id = id;


        this.Precio = precio;

        this.Tipos_Animales = tipos_Animales;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TarifaEN t = obj as TarifaEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
