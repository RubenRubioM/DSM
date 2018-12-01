

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
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public string Registrarse (string p_email, string p_pass, string p_nombre, string p_apellidos, string p_nick, Nullable<DateTime> p_nacimiento, string p_provincia, string p_localidad, string p_motivoEstado)
{
        UsuarioEN usuarioEN = null;
        string oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_email;

        usuarioEN.Pass = p_pass;

        usuarioEN.Nombre = p_nombre;

        usuarioEN.Apellidos = p_apellidos;

        usuarioEN.Nick = p_nick;

        usuarioEN.Nacimiento = p_nacimiento;

        usuarioEN.Provincia = p_provincia;

        usuarioEN.Localidad = p_localidad;

        usuarioEN.MotivoEstado = p_motivoEstado;

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.Registrarse (usuarioEN);
        return oid;
}

public void Modify (string p_Usuario_OID, string p_nombre, string p_apellidos, string p_nick, Nullable<DateTime> p_nacimiento, string p_provincia, string p_localidad, float p_cartera, PetMeGenNHibernate.Enumerated.PetMe.EstadoUsuarioEnum p_estado, String p_pass, string p_motivoEstado)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_Usuario_OID;
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Apellidos = p_apellidos;
        usuarioEN.Nick = p_nick;
        usuarioEN.Nacimiento = p_nacimiento;
        usuarioEN.Provincia = p_provincia;
        usuarioEN.Localidad = p_localidad;
        usuarioEN.Cartera = p_cartera;
        usuarioEN.Estado = p_estado;
        usuarioEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        usuarioEN.MotivoEstado = p_motivoEstado;
        //Call to UsuarioCAD

        _IUsuarioCAD.Modify (usuarioEN);
}

public void Destroy (string email
                     )
{
        _IUsuarioCAD.Destroy (email);
}

public string Login (string p_Usuario_OID, string p_pass)
{
        string result = null;
        UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (p_Usuario_OID);

        if (en != null && en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.Email);

        return result;
}

public void AsignarAnuncioContratado (string p_Usuario_OID, System.Collections.Generic.IList<int> p_anuncios_contratados_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.AsignarAnuncioContratado (p_Usuario_OID, p_anuncios_contratados_OIDs);
}
public void QuitarAnuncioContratado (string p_Usuario_OID, System.Collections.Generic.IList<int> p_anuncios_contratados_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.QuitarAnuncioContratado (p_Usuario_OID, p_anuncios_contratados_OIDs);
}
public void AsignarAnuncioCreado (string p_Usuario_OID, System.Collections.Generic.IList<int> p_anuncios_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.AsignarAnuncioCreado (p_Usuario_OID, p_anuncios_OIDs);
}
public void QuitarAnuncioCreado (string p_Usuario_OID, System.Collections.Generic.IList<int> p_anuncios_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.QuitarAnuncioCreado (p_Usuario_OID, p_anuncios_OIDs);
}
public void AsignarComentario (string p_Usuario_OID, System.Collections.Generic.IList<int> p_comentarios_usuario_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.AsignarComentario (p_Usuario_OID, p_comentarios_usuario_OIDs);
}
public void QuitarComentario (string p_Usuario_OID, System.Collections.Generic.IList<int> p_comentarios_usuario_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.QuitarComentario (p_Usuario_OID, p_comentarios_usuario_OIDs);
}
public UsuarioEN ReadOID (string email
                          )
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioCAD.ReadOID (email);
        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.UsuarioEN> BuscarPorNombre (string p_nombre)
{
        return _IUsuarioCAD.BuscarPorNombre (p_nombre);
}
public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.UsuarioEN> BuscarPorProvincia (string p_provincia)
{
        return _IUsuarioCAD.BuscarPorProvincia (p_provincia);
}
public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.UsuarioEN> BuscarPorLocalidad (string arg0)
{
        return _IUsuarioCAD.BuscarPorLocalidad (arg0);
}



private string Encode (string email)
{
        var payload = new Dictionary<string, object>(){
                { "email", email }
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (string email)
{
        UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (email);
        string token = Encode (en.Email);

        return token;
}
public string CheckToken (string token)
{
        string result = null;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                string id = (string)ObtenerEMAIL (decodedToken);

                UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (id);

                if (en != null && ((string)en.Email).Equals (ObtenerEMAIL (decodedToken))
                    ) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception e)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}


public string ObtenerEMAIL (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                string email = (string)results ["email"];
                return email;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}
}
}
