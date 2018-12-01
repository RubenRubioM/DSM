
using System;
// Definición clase Tarifa_EN
namespace PetMeGenNHibernate.EN.PetMe
{
public partial class Tarifa_EN
{
/**
 *	Atributo precio
 */
private float precio;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo tipo_Animal
 */
private System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN> tipo_Animal;






public virtual float Precio {
        get { return precio; } set { precio = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN> Tipo_Animal {
        get { return tipo_Animal; } set { tipo_Animal = value;  }
}





public Tarifa_EN()
{
        tipo_Animal = new System.Collections.Generic.List<PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN>();
}



public Tarifa_EN(int id, float precio, System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN> tipo_Animal
                 )
{
        this.init (Id, precio, tipo_Animal);
}


public Tarifa_EN(Tarifa_EN tarifa_)
{
        this.init (Id, tarifa_.Precio, tarifa_.Tipo_Animal);
}

private void init (int id
                   , float precio, System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN> tipo_Animal)
{
        this.Id = id;


        this.Precio = precio;

        this.Tipo_Animal = tipo_Animal;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        Tarifa_EN t = obj as Tarifa_EN;
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
