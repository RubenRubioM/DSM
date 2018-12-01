
using System;
using PetMeGenNHibernate.EN.PetMe;

namespace PetMeGenNHibernate.CAD.PetMe
{
public partial interface ITarifa_CAD
{
Tarifa_EN ReadOIDDefault (int id
                          );

void ModifyDefault (Tarifa_EN tarifa_);

System.Collections.Generic.IList<Tarifa_EN> ReadAllDefault (int first, int size);



int New_ (Tarifa_EN tarifa_);

void Modify (Tarifa_EN tarifa_);


void Destroy (int id
              );


void AsignarTipoAnimal (int p_Tarifa__OID, System.Collections.Generic.IList<int> p_tipo_Animal_OIDs);

void QuitarTipoAnimal (int p_Tarifa__OID, System.Collections.Generic.IList<int> p_tipo_Animal_OIDs);
}
}
