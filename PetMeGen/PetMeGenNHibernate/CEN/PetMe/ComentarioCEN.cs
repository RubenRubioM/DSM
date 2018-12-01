

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
 *      Definition of the class ComentarioCEN
 *
 */
public partial class ComentarioCEN
{
private IComentarioCAD _IComentarioCAD;

public ComentarioCEN()
{
        this._IComentarioCAD = new ComentarioCAD ();
}

public ComentarioCEN(IComentarioCAD _IComentarioCAD)
{
        this._IComentarioCAD = _IComentarioCAD;
}

public IComentarioCAD get_IComentarioCAD ()
{
        return this._IComentarioCAD;
}

public int New_ (string p_comentario, PetMeGenNHibernate.Enumerated.PetMe.ValoracionEnum p_valoracion, int p_anuncio, string p_usuario_comen)
{
        ComentarioEN comentarioEN = null;
        int oid;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Comentario = p_comentario;

        comentarioEN.Valoracion = p_valoracion;


        if (p_anuncio != -1) {
                // El argumento p_anuncio -> Property anuncio es oid = false
                // Lista de oids id
                comentarioEN.Anuncio = new PetMeGenNHibernate.EN.PetMe.AnuncioEN ();
                comentarioEN.Anuncio.Id = p_anuncio;
        }


        if (p_usuario_comen != null) {
                // El argumento p_usuario_comen -> Property usuario_comen es oid = false
                // Lista de oids id
                comentarioEN.Usuario_comen = new PetMeGenNHibernate.EN.PetMe.UsuarioEN ();
                comentarioEN.Usuario_comen.Email = p_usuario_comen;
        }

        //Call to ComentarioCAD

        oid = _IComentarioCAD.New_ (comentarioEN);
        return oid;
}

public void Modify (int p_Comentario_OID, string p_comentario, PetMeGenNHibernate.Enumerated.PetMe.ValoracionEnum p_valoracion)
{
        ComentarioEN comentarioEN = null;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Id = p_Comentario_OID;
        comentarioEN.Comentario = p_comentario;
        comentarioEN.Valoracion = p_valoracion;
        //Call to ComentarioCAD

        _IComentarioCAD.Modify (comentarioEN);
}

public void Destroy (int id
                     )
{
        _IComentarioCAD.Destroy (id);
}

public ComentarioEN ReadOID (int id
                             )
{
        ComentarioEN comentarioEN = null;

        comentarioEN = _IComentarioCAD.ReadOID (id);
        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> list = null;

        list = _IComentarioCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.ComentarioEN> BuscarPorValoracion (PetMeGenNHibernate.Enumerated.PetMe.ValoracionEnum ? p_valoracion)
{
        return _IComentarioCAD.BuscarPorValoracion (p_valoracion);
}
}
}
