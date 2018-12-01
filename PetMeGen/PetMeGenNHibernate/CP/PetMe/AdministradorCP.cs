
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using PetMeGenNHibernate.Exceptions;
using PetMeGenNHibernate.EN.PetMe;
using PetMeGenNHibernate.CAD.PetMe;
using PetMeGenNHibernate.CEN.PetMe;



namespace PetMeGenNHibernate.CP.PetMe
{
public partial class AdministradorCP : BasicCP
{
public AdministradorCP() : base ()
{
}

public AdministradorCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
