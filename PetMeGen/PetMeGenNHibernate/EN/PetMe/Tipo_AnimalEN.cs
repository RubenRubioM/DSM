
using System;
// Definición clase Tipo_AnimalEN
namespace PetMeGenNHibernate.EN.PetMe
{
public partial class Tipo_AnimalEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo tipo
 */
private string tipo;



/**
 *	Atributo anuncio
 */
private PetMeGenNHibernate.EN.PetMe.AnuncioEN anuncio;



/**
 *	Atributo tarifa
 */
private double tarifa;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual PetMeGenNHibernate.EN.PetMe.AnuncioEN Anuncio {
        get { return anuncio; } set { anuncio = value;  }
}



public virtual double Tarifa {
        get { return tarifa; } set { tarifa = value;  }
}





public Tipo_AnimalEN()
{
}



public Tipo_AnimalEN(int id, string tipo, PetMeGenNHibernate.EN.PetMe.AnuncioEN anuncio, double tarifa
                     )
{
        this.init (Id, tipo, anuncio, tarifa);
}


public Tipo_AnimalEN(Tipo_AnimalEN tipo_Animal)
{
        this.init (Id, tipo_Animal.Tipo, tipo_Animal.Anuncio, tipo_Animal.Tarifa);
}

private void init (int id
                   , string tipo, PetMeGenNHibernate.EN.PetMe.AnuncioEN anuncio, double tarifa)
{
        this.Id = id;


        this.Tipo = tipo;

        this.Anuncio = anuncio;

        this.Tarifa = tarifa;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        Tipo_AnimalEN t = obj as Tipo_AnimalEN;
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
