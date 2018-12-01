
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



/*PROTECTED REGION ID(usingPetMeGenNHibernate.CP.PetMe_Anuncio_borrarTablaAnimales) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PetMeGenNHibernate.CP.PetMe
{
public partial class AnuncioCP : BasicCP
{
public void BorrarTablaAnimales (int p_oid, System.Collections.Generic.IList<int> p_animales)
{
        /*PROTECTED REGION ID(PetMeGenNHibernate.CP.PetMe_Anuncio_borrarTablaAnimales) ENABLED START*/

        IAnuncioCAD anuncioCAD = null;
        AnuncioCEN anuncioCEN = null;
        ITipo_AnimalCAD tipo_AnimalCAD = null;
        Tipo_AnimalCEN tipo_AnimalCEN = null;

        try
        {
                SessionInitializeTransaction ();
                anuncioCAD = new AnuncioCAD (session);
                anuncioCEN = new  AnuncioCEN (anuncioCAD);
                tipo_AnimalCAD = new Tipo_AnimalCAD (session);
                tipo_AnimalCEN = new Tipo_AnimalCEN (tipo_AnimalCAD);

                // quitamos las referencias a los animales
                anuncioCEN.QuitarAnimales (p_oid, p_animales);

                // los borramos de la base de datos
                for (int i = 0; i < p_animales.Count; i++) {
                        tipo_AnimalCEN.Destroy (p_animales [i]);
                }

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
