
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using PetMeGenNHibernate.EN.PetMe;
using PetMeGenNHibernate.CAD.PetMe;
using PetMeGenNHibernate.CEN.PetMe;



/*PROTECTED REGION ID(usingPetMeGenNHibernate.CP.PetMe_Anuncio_reservarAnuncio) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PetMeGenNHibernate.CP.PetMe
{
public partial class AnuncioCP : BasicCP
{
public void ReservarAnuncio (int p_oid)
{
        /*PROTECTED REGION ID(PetMeGenNHibernate.CP.PetMe_Anuncio_reservarAnuncio) ENABLED START*/

        IAnuncioCAD anuncioCAD = null;
        AnuncioCEN anuncioCEN = null;



        try
        {
                SessionInitializeTransaction ();
                anuncioCAD = new AnuncioCAD (session);
                anuncioCEN = new  AnuncioCEN (anuncioCAD);





                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
