
using System;
// Definición clase AnuncioEN
namespace PetMeGenNHibernate.EN.PetMe
{
public partial class AnuncioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo fechaIni
 */
private Nullable<DateTime> fechaIni;



/**
 *	Atributo fechaFin
 */
private Nullable<DateTime> fechaFin;



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo tipos_Animales
 */
private System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN> tipos_Animales;



/**
 *	Atributo cuidador
 */
private PetMeGenNHibernate.EN.PetMe.UsuarioEN cuidador;



/**
 *	Atributo contratante
 */
private PetMeGenNHibernate.EN.PetMe.UsuarioEN contratante;



/**
 *	Atributo detalle
 */
private string detalle;



/**
 *	Atributo estado
 */
private PetMeGenNHibernate.Enumerated.PetMe.EstadosEnum estado;



/**
 *	Atributo comentarios_anuncio
 */
private System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.ComentarioEN> comentarios_anuncio;



/**
 *	Atributo provincia
 */
private string provincia;



/**
 *	Atributo localidad
 */
private string localidad;



/**
 *	Atributo animalContratado
 */
private int animalContratado;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> FechaIni {
        get { return fechaIni; } set { fechaIni = value;  }
}



public virtual Nullable<DateTime> FechaFin {
        get { return fechaFin; } set { fechaFin = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN> Tipos_Animales {
        get { return tipos_Animales; } set { tipos_Animales = value;  }
}



public virtual PetMeGenNHibernate.EN.PetMe.UsuarioEN Cuidador {
        get { return cuidador; } set { cuidador = value;  }
}



public virtual PetMeGenNHibernate.EN.PetMe.UsuarioEN Contratante {
        get { return contratante; } set { contratante = value;  }
}



public virtual string Detalle {
        get { return detalle; } set { detalle = value;  }
}



public virtual PetMeGenNHibernate.Enumerated.PetMe.EstadosEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.ComentarioEN> Comentarios_anuncio {
        get { return comentarios_anuncio; } set { comentarios_anuncio = value;  }
}



public virtual string Provincia {
        get { return provincia; } set { provincia = value;  }
}



public virtual string Localidad {
        get { return localidad; } set { localidad = value;  }
}



public virtual int AnimalContratado {
        get { return animalContratado; } set { animalContratado = value;  }
}





public AnuncioEN()
{
        tipos_Animales = new System.Collections.Generic.List<PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN>();
        comentarios_anuncio = new System.Collections.Generic.List<PetMeGenNHibernate.EN.PetMe.ComentarioEN>();
}



public AnuncioEN(int id, Nullable<DateTime> fechaIni, Nullable<DateTime> fechaFin, string direccion, System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN> tipos_Animales, PetMeGenNHibernate.EN.PetMe.UsuarioEN cuidador, PetMeGenNHibernate.EN.PetMe.UsuarioEN contratante, string detalle, PetMeGenNHibernate.Enumerated.PetMe.EstadosEnum estado, System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.ComentarioEN> comentarios_anuncio, string provincia, string localidad, int animalContratado
                 )
{
        this.init (Id, fechaIni, fechaFin, direccion, tipos_Animales, cuidador, contratante, detalle, estado, comentarios_anuncio, provincia, localidad, animalContratado);
}


public AnuncioEN(AnuncioEN anuncio)
{
        this.init (Id, anuncio.FechaIni, anuncio.FechaFin, anuncio.Direccion, anuncio.Tipos_Animales, anuncio.Cuidador, anuncio.Contratante, anuncio.Detalle, anuncio.Estado, anuncio.Comentarios_anuncio, anuncio.Provincia, anuncio.Localidad, anuncio.AnimalContratado);
}

private void init (int id
                   , Nullable<DateTime> fechaIni, Nullable<DateTime> fechaFin, string direccion, System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.Tipo_AnimalEN> tipos_Animales, PetMeGenNHibernate.EN.PetMe.UsuarioEN cuidador, PetMeGenNHibernate.EN.PetMe.UsuarioEN contratante, string detalle, PetMeGenNHibernate.Enumerated.PetMe.EstadosEnum estado, System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.ComentarioEN> comentarios_anuncio, string provincia, string localidad, int animalContratado)
{
        this.Id = id;


        this.FechaIni = fechaIni;

        this.FechaFin = fechaFin;

        this.Direccion = direccion;

        this.Tipos_Animales = tipos_Animales;

        this.Cuidador = cuidador;

        this.Contratante = contratante;

        this.Detalle = detalle;

        this.Estado = estado;

        this.Comentarios_anuncio = comentarios_anuncio;

        this.Provincia = provincia;

        this.Localidad = localidad;

        this.AnimalContratado = animalContratado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AnuncioEN t = obj as AnuncioEN;
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
