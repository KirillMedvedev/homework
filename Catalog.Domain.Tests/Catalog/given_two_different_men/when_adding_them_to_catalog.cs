using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bd.mstest;
using FluentAssertions;

namespace Catalog.Domain.Tests.Catalog.given_two_different_men
{
    using Domain;

    [TestClass]
    public class when_adding_them_to_catalog : SUT
    {
        protected override void Arrange()
        {
            firstMan = new Man("Cunningham", "Ward", "Male", "black", "5/26/1949");
            secondMan = new Man("McCartney", "Jim", "Male", "white", "1/1/1950");

            catalog = new Catalog();
        }

        protected override void Act()
        {
            catalog.Add(firstMan, secondMan);
            catalogContent = catalog.GetAll();
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

        private Man firstMan;
        private Man secondMan;
        private Catalog catalog;
        private IEnumerable<Man> catalogContent;
    }
}