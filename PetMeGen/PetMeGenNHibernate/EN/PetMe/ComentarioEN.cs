
using System;
// Definición clase ComentarioEN
namespace PetMeGenNHibernate.EN.PetMe
{
public partial class ComentarioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo comentario
 */
private string comentario;



/**
 *	Atributo valoracion
 */
private PetMeGenNHibernate.Enumerated.PetMe.ValoracionEnum valoracion;



/**
 *	Atributo anuncio
 */
private PetMeGenNHibernate.EN.PetMe.AnuncioEN anuncio;



/**
 *	Atributo usuario_comen
 */
private PetMeGenNHibernate.EN.PetMe.UsuarioEN usuario_comen;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual PetMeGenNHibernate.Enumerated.PetMe.ValoracionEnum Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual PetMeGenNHibernate.EN.PetMe.AnuncioEN Anuncio {
        get { return anuncio; } set { anuncio = value;  }
}



public virtual PetMeGenNHibernate.EN.PetMe.UsuarioEN Usuario_comen {
        get { return usuario_comen; } set { usuario_comen = value;  }
}





public ComentarioEN()
{
}



public ComentarioEN(int id, string comentario, PetMeGenNHibernate.Enumerated.PetMe.ValoracionEnum valoracion, PetMeGenNHibernate.EN.PetMe.AnuncioEN anuncio, PetMeGenNHibernate.EN.PetMe.UsuarioEN usuario_comen
                    )
{
        this.init (Id, comentario, valoracion, anuncio, usuario_comen);
}


public ComentarioEN(ComentarioEN comentario)
{
        this.init (Id, comentario.Comentario, comentario.Valoracion, comentario.Anuncio, comentario.Usuario_comen);
}

private void init (int id
                   , string comentario, PetMeGenNHibernate.Enumerated.PetMe.ValoracionEnum valoracion, PetMeGenNHibernate.EN.PetMe.AnuncioEN anuncio, PetMeGenNHibernate.EN.PetMe.UsuarioEN usuario_comen)
{
        this.Id = id;


        this.Comentario = comentario;

        this.Valoracion = valoracion;

        this.Anuncio = anuncio;

        this.Usuario_comen = usuario_comen;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComentarioEN t = obj as ComentarioEN;
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
