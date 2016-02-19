using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Domain.Tests.Catalog.given_two_identical_men
{
    using Domain;

    [TestClass]
    public class when_adding_them_to_catalog : TwoMenCatalog
    {
        protected override Man GetFirstMan()
        {
            return new Man("Cunningham", "Ward", "Male", "black", new DateTime(1949, 5, 26));
        }

        protected override Man GetSecondMan()
        {
            return new Man("Cunningham", "Ward", "Male", "black", new DateTime(1949, 5, 26));
        }

        [TestMethod]
        public void then_catalog_contains_1_man()
        {
            catalogContent.Should().HaveCount(1);
        }
    }
}