
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


/*PROTECTED REGION ID(usingPetMeGenNHibernate.CEN.PetMe_Anuncio_cancelarContrato) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PetMeGenNHibernate.CEN.PetMe
{
public partial class AnuncioCEN
{
public void CancelarContrato (int p_oid)
{
            /*PROTECTED REGION ID(PetMeGenNHibernate.CEN.PetMe_Anuncio_cancelarContrato) ENABLED START*/

            // RECORDATORIO: el id del animal contratado por defecto es 0, por eso lo devolvemos a su valor inicial

            AnuncioEN anuncioEN = _IAnuncioCAD.ReadOID(p_oid);

            anuncioEN.AnimalContratado = 0;

            _IAnuncioCAD.Modify(anuncioEN);

        /*PROTECTED REGION END*/
}
}
}
