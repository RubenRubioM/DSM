
using System;
using PetMeGenNHibernate.EN.PetMe;

namespace PetMeGenNHibernate.CAD.PetMe
{
public partial interface IAnuncioCAD
{
AnuncioEN ReadOIDDefault (int id
                          );

void ModifyDefault (AnuncioEN anuncio);

System.Collections.Generic.IList<AnuncioEN> ReadAllDefault (int first, int size);



int New_ (AnuncioEN anuncio);

void Modify (AnuncioEN anuncio);


void Destroy (int id
              );


void AsignarContratante (int p_Anuncio_OID, string p_contratante_OID);

void QuitarContratante (int p_Anuncio_OID, string p_contratante_OID);

void AsignarComentario (int p_Anuncio_OID, System.Collections.Generic.IList<int> p_comentarios_anuncio_OIDs);

void QuitarComentario (int p_Anuncio_OID, System.Collections.Generic.IList<int> p_comentarios_anuncio_OIDs);

AnuncioEN ReadOID (int id
                   );


System.Collections.Generic.IList<AnuncioEN> ReadAll (int first, int size);


void AsignarAnimales (int p_Anuncio_OID, System.Collections.Generic.IList<int> p_tipos_Animales_OIDs);

void QuitarAnimales (int p_Anuncio_OID, System.Collections.Generic.IList<int> p_tipos_Animales_OIDs);




System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> BuscarPorFechaFin (Nullable<DateTime> p_fechaFin);


System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> BuscarPorEstado (PetMeGenNHibernate.Enumerated.PetMe.EstadosEnum ? p_estado);



System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> BuscarPorNoContratado ();


System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> BuscarPorProvincia (string p_provincia);


System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> BuscarPorLocalidad (string p_localidad);


System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> BuscarPorDireccion (string p_direccion);


System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> BuscarPorFechaIni (Nullable<DateTime> p_fechaIni);
}
}
