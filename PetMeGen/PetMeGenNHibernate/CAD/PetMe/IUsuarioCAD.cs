
using System;
using PetMeGenNHibernate.EN.PetMe;

namespace PetMeGenNHibernate.CAD.PetMe
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (string email
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);



string Registrarse (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (string email
              );





void AsignarAnuncioContratado (string p_Usuario_OID, System.Collections.Generic.IList<int> p_anuncios_contratados_OIDs);

void QuitarAnuncioContratado (string p_Usuario_OID, System.Collections.Generic.IList<int> p_anuncios_contratados_OIDs);

void AsignarAnuncioCreado (string p_Usuario_OID, System.Collections.Generic.IList<int> p_anuncios_OIDs);

void QuitarAnuncioCreado (string p_Usuario_OID, System.Collections.Generic.IList<int> p_anuncios_OIDs);

void AsignarComentario (string p_Usuario_OID, System.Collections.Generic.IList<int> p_comentarios_usuario_OIDs);



void QuitarComentario (string p_Usuario_OID, System.Collections.Generic.IList<int> p_comentarios_usuario_OIDs);




UsuarioEN ReadOID (string email
                   );


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);



System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.UsuarioEN> BuscarPorNombre (string p_nombre);


System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.UsuarioEN> BuscarPorProvincia (string p_provincia);


System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.UsuarioEN> BuscarPorLocalidad (string arg0);
}
}
