using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Catalog.Domain.Tests.Catalog.given_two_different_men
{
    using Domain;

    [TestClass]
    public class when_adding_them_to_catalog : TwoMenCatalog
    {
        protected override Man GetFirstMan()
        {
            return new Man("Cunningham", "Ward", "Male", "black", "5/26/1949");
        }

        protected override Man GetSecondMan()
        {
            return new Man("McCartney", "Jim", "Male", "white", "1/1/1950");
        }

        [TestMethod]
        public void then_catalog_contains_2_men()
        {
            catalogContent.Should().HaveCount(2);
        }

        [TestMethod]
        public void then_first_man_is_correct()
        {
            catalogContent.First().Should().Be(firstMan);
        }

        [TestMethod]
        public void then_last_man_is_correct()
        {
            catalogContent.Last().Should().Be(secondMan);
        }
    }
}