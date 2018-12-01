
using System;
// Definición clase UsuarioEN
namespace PetMeGenNHibernate.EN.PetMe
{
public partial class UsuarioEN
{
/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo nick
 */
private string nick;



/**
 *	Atributo nacimiento
 */
private Nullable<DateTime> nacimiento;



/**
 *	Atributo provincia
 */
private string provincia;



/**
 *	Atributo localidad
 */
private string localidad;



/**
 *	Atributo foto
 */
private string foto;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo cartera
 */
private float cartera;



/**
 *	Atributo anuncios
 */
private System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> anuncios;



/**
 *	Atributo anuncios_contratados
 */
private System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> anuncios_contratados;



/**
 *	Atributo telefono
 */
private string telefono;



/**
 *	Atributo comentarios_usuario
 */
private System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.ComentarioEN> comentarios_usuario;



/**
 *	Atributo estado
 */
private PetMeGenNHibernate.Enumerated.PetMe.EstadoUsuarioEnum estado;



/**
 *	Atributo pass
 */
private String pass;



/**
 *	Atributo motivoEstado
 */
private string motivoEstado;






public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual string Nick {
        get { return nick; } set { nick = value;  }
}



public virtual Nullable<DateTime> Nacimiento {
        get { return nacimiento; } set { nacimiento = value;  }
}



public virtual string Provincia {
        get { return provincia; } set { provincia = value;  }
}



public virtual string Localidad {
        get { return localidad; } set { localidad = value;  }
}



public virtual string Foto {
        get { return foto; } set { foto = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual float Cartera {
        get { return cartera; } set { cartera = value;  }
}



public virtual System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> Anuncios {
        get { return anuncios; } set { anuncios = value;  }
}



public virtual System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> Anuncios_contratados {
        get { return anuncios_contratados; } set { anuncios_contratados = value;  }
}



public virtual string Telefono {
        get { return telefono; } set { telefono = value;  }
}



public virtual System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.ComentarioEN> Comentarios_usuario {
        get { return comentarios_usuario; } set { comentarios_usuario = value;  }
}



public virtual PetMeGenNHibernate.Enumerated.PetMe.EstadoUsuarioEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual string MotivoEstado {
        get { return motivoEstado; } set { motivoEstado = value;  }
}





public UsuarioEN()
{
        anuncios = new System.Collections.Generic.List<PetMeGenNHibernate.EN.PetMe.AnuncioEN>();
        anuncios_contratados = new System.Collections.Generic.List<PetMeGenNHibernate.EN.PetMe.AnuncioEN>();
        comentarios_usuario = new System.Collections.Generic.List<PetMeGenNHibernate.EN.PetMe.ComentarioEN>();
}



public UsuarioEN(string email, string nombre, string apellidos, string nick, Nullable<DateTime> nacimiento, string provincia, string localidad, string foto, string descripcion, float cartera, System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> anuncios, System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> anuncios_contratados, string telefono, System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.ComentarioEN> comentarios_usuario, PetMeGenNHibernate.Enumerated.PetMe.EstadoUsuarioEnum estado, String pass, string motivoEstado
                 )
{
        this.init (Email, nombre, apellidos, nick, nacimiento, provincia, localidad, foto, descripcion, cartera, anuncios, anuncios_contratados, telefono, comentarios_usuario, estado, pass, motivoEstado);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (Email, usuario.Nombre, usuario.Apellidos, usuario.Nick, usuario.Nacimiento, usuario.Provincia, usuario.Localidad, usuario.Foto, usuario.Descripcion, usuario.Cartera, usuario.Anuncios, usuario.Anuncios_contratados, usuario.Telefono, usuario.Comentarios_usuario, usuario.Estado, usuario.Pass, usuario.MotivoEstado);
}

private void init (string email
                   , string nombre, string apellidos, string nick, Nullable<DateTime> nacimiento, string provincia, string localidad, string foto, string descripcion, float cartera, System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> anuncios, System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> anuncios_contratados, string telefono, System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.ComentarioEN> comentarios_usuario, PetMeGenNHibernate.Enumerated.PetMe.EstadoUsuarioEnum estado, String pass, string motivoEstado)
{
        this.Email = email;


        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Nick = nick;

        this.Nacimiento = nacimiento;

        this.Provincia = provincia;

        this.Localidad = localidad;

        this.Foto = foto;

        this.Descripcion = descripcion;

        this.Cartera = cartera;

        this.Anuncios = anuncios;

        this.Anuncios_contratados = anuncios_contratados;

        this.Telefono = telefono;

        this.Comentarios_usuario = comentarios_usuario;

        this.Estado = estado;

        this.Pass = pass;

        this.MotivoEstado = motivoEstado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
        if (t == null)
                return false;
        if (Email.Equals (t.Email))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Email.GetHashCode ();
        return hash;
}
}
}
