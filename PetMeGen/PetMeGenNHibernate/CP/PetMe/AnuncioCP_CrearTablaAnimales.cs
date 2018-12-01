
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



/*PROTECTED REGION ID(usingPetMeGenNHibernate.CP.PetMe_Anuncio_crearTablaAnimales) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PetMeGenNHibernate.CP.PetMe
{
public partial class AnuncioCP : BasicCP
{
public void CrearTablaAnimales (int p_oid, System.Collections.Generic.IList<string> p_animales, System.Collections.Generic.IList<double> p_tarifas)
{
        /*PROTECTED REGION ID(PetMeGenNHibernate.CP.PetMe_Anuncio_crearTablaAnimales) ENABLED START*/

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

                // creamos la lista animales que vamos a asignar a dicho anuncio
                IList<int> animalENs = new List<int>();

                // creamos los animales en la base de datos
                for (int i = 0; i < p_animales.Count; i++) {
                        if (i < p_tarifas.Count) {
                                int p_animal = tipo_AnimalCEN.New_ (p_animales [i], p_oid, p_tarifas [i]);
                                animalENs.Add (p_animal);
                        }
                }

                // por ultimo se los asignamos al anuncio correspondiente
                anuncioCEN.AsignarAnimales (p_oid, animalENs);

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
