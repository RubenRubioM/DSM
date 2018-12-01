
using System;
using PetMeGenNHibernate.EN.PetMe;

namespace PetMeGenNHibernate.CAD.PetMe
{
public partial interface IAdministradorCAD
{
AdministradorEN ReadOIDDefault (string email
                                );

void ModifyDefault (AdministradorEN administrador);

System.Collections.Generic.IList<AdministradorEN> ReadAllDefault (int first, int size);



string New_ (AdministradorEN administrador);

void Modify (AdministradorEN administrador);


void Destroy (string email
              );


AdministradorEN ReadOID (string email
                         );


System.Collections.Generic.IList<AdministradorEN> ReadAll (int first, int size);
}
}
