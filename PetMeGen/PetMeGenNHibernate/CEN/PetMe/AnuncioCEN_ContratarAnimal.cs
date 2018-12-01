
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PetMeGenNHibernate.Exceptions;
using PetMeGenNHibernate.EN.PetMe;
using PetMeGenNHibernate.CAD.PetMe;


/*PROTECTED REGION ID(usingPetMeGenNHibernate.CEN.PetMe_Anuncio_contratarAnimal) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PetMeGenNHibernate.CEN.PetMe
{
public partial class AnuncioCEN
{
public void ContratarAnimal (int p_oid, int p_animal_OID)
{
        /*PROTECTED REGION ID(PetMeGenNHibernate.CEN.PetMe_Anuncio_contratarAnimal) ENABLED START*/

        AnuncioEN anuncioEN = _IAnuncioCAD.ReadOID (p_oid);

        anuncioEN.AnimalContratado = p_animal_OID;

        _IAnuncioCAD.Modify (anuncioEN);

        /*PROTECTED REGION END*/
}
}
}
