
using System;
using PetMeGenNHibernate.EN.PetMe;

namespace PetMeGenNHibernate.CAD.PetMe
{
public partial interface IComentarioCAD
{
ComentarioEN ReadOIDDefault (int id
                             );

void ModifyDefault (ComentarioEN comentario);

System.Collections.Generic.IList<ComentarioEN> ReadAllDefault (int first, int size);



int New_ (ComentarioEN comentario);

void Modify (ComentarioEN comentario);


void Destroy (int id
              );


ComentarioEN ReadOID (int id
                      );


System.Collections.Generic.IList<ComentarioEN> ReadAll (int first, int size);


System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.ComentarioEN> BuscarPorValoracion (PetMeGenNHibernate.Enumerated.PetMe.ValoracionEnum ? p_valoracion);
}
}
