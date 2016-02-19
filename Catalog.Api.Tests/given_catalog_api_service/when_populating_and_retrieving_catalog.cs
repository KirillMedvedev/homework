using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bd.mstest;
using Catalog.Api.Controllers;
using Catalog.Domain;
using FluentAssertions;

namespace Catalog.Api.Tests.given_catalog_api_service
{
    [TestClass]
    public class when_populating_and_retrieving_catalog : SUT
    {
        protected override void Arrange()
        {
            controller = new RecordsController();

            manString = "Fowler | Martin | Male | Blue | 1963\r\n";
            man = new Man("Fowler", "Martin", "Male", "Blue", "1963");
        }

        protected override void Act()
        {
            controller.Post(manString);
            allMen = controller.Get("all");
        }

        [TestMethod]
        public void then_catalog_returned_contains_one_man()
        {
            allMen.Should().HaveCount(1);
        }

        [TestMethod]
        public void then_man_is_correct()
        {
            allMen.First().Should().Be(man);
        }

        private RecordsController controller;
        private IEnumerable<Man> allMen;
        private Man man;
        private string manString;
    }
}