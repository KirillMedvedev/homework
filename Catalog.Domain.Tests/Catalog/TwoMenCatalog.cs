using System.Collections.Generic;
using bd.mstest;

namespace Catalog.Domain.Tests.Catalog
{
    using Domain;

    public abstract class TwoMenCatalog : SUT
    {
        protected override void Arrange()
        {
            firstMan = GetFirstMan();
            secondMan = GetSecondMan();

            catalog = new Catalog();
        }

        protected override void Act()
        {
            catalog.Add(firstMan, secondMan);

            catalogContent = catalog.GetAll();
        }

        protected abstract Man GetFirstMan();
        protected abstract Man GetSecondMan();

        protected Man firstMan;
        protected Man secondMan;
        protected IEnumerable<Man> catalogContent;
        private Catalog catalog;
    }
}