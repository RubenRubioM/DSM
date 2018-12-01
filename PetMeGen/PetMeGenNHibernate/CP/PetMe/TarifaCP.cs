
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
public partial class TarifaCP : BasicCP
{
public TarifaCP() : base ()
{
}

public TarifaCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
