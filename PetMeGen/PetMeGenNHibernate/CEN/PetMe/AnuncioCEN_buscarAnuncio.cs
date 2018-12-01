
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


/*PROTECTED REGION ID(usingPetMeGenNHibernate.CEN.PetMe_Anuncio_buscarAnuncio) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PetMeGenNHibernate.CEN.PetMe
{
public partial class AnuncioCEN
{
public System.Collections.Generic.IList<PetMeGenNHibernate.EN.PetMe.AnuncioEN> BuscarAnuncio (Nullable<DateTime> p_fIni, Nullable<DateTime> p_fFin, string p_prov, string p_loc, string p_tipo)
{
        /*PROTECTED REGION ID(PetMeGenNHibernate.CEN.PetMe_Anuncio_buscarAnuncio_customized) START*/

        return _IAnuncioCAD.BuscarAnuncio (p_fIni, p_fFin, p_prov, p_loc, p_tipo);
        /*PROTECTED REGION END*/
}
}
}
