
using System;
using PetMeGenNHibernate.EN.PetMe;

namespace PetMeGenNHibernate.CAD.PetMe
{
public partial interface ITarifaCAD
{
TarifaEN ReadOIDDefault (int id
                         );

void ModifyDefault (TarifaEN tarifa);

System.Collections.Generic.IList<TarifaEN> ReadAllDefault (int first, int size);



int New_ (TarifaEN tarifa);

void Modify (TarifaEN tarifa);


void Destroy (int id
              );
}
}
