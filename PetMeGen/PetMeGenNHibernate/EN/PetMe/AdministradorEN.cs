
using System;
// Definición clase AdministradorEN
namespace PetMeGenNHibernate.EN.PetMe
{
public partial class AdministradorEN                                                                        : PetMeGenNHibernate.EN.PetMe.UsuarioEN


{
public AdministradorEN() : base ()
{
}



public AdministradorEN(string email,
                       string nombre, string apellidos, string nick, Nullable<DateTime> nacimiento, string provincia, string localidad, string foto, string descripcion, float cartera, System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> anuncios, System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> anuncios_contratados, string telefono, System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.ComentarioEN> comentarios_usuario, PetMeGenNHibernate.Enumerated.PetMe.EstadoUsuarioEnum estado, String pass, string motivoEstado
                       )
{
        this.init (Email, nombre, apellidos, nick, nacimiento, provincia, localidad, foto, descripcion, cartera, anuncios, anuncios_contratados, telefono, comentarios_usuario, estado, pass, motivoEstado);
}


public AdministradorEN(AdministradorEN administrador)
{
        this.init (Email, administrador.Nombre, administrador.Apellidos, administrador.Nick, administrador.Nacimiento, administrador.Provincia, administrador.Localidad, administrador.Foto, administrador.Descripcion, administrador.Cartera, administrador.Anuncios, administrador.Anuncios_contratados, administrador.Telefono, administrador.Comentarios_usuario, administrador.Estado, administrador.Pass, administrador.MotivoEstado);
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
        AdministradorEN t = obj as AdministradorEN;
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
