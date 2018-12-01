
using System;
using PetMeGenNHibernate.EN.PetMe;

namespace PetMeGenNHibernate.CAD.PetMe
{
public partial interface ITipo_AnimalCAD
{
Tipo_AnimalEN ReadOIDDefault (int id
                              );

void ModifyDefault (Tipo_AnimalEN tipo_Animal);

System.Collections.Generic.IList<Tipo_AnimalEN> ReadAllDefault (int first, int size);



int New_ (Tipo_AnimalEN tipo_Animal);

void Modify (Tipo_AnimalEN tipo_Animal);


void Destroy (int id
              );


Tipo_AnimalEN ReadOID (int id
                       );


System.Collections.Generic.IList<Tipo_AnimalEN> ReadAll (int first, int size);
}
}
