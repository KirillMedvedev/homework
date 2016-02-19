using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bd.mstest;
using Catalog.Api.Controllers;
using Catalog.Domain;
using FluentAssertions;

namespace Catalog.Api.Tests.given_running_catalog_api_service
{
    [TestClass]
    public class when_retrieving_catalog : SUT
    {
        protected override void Arrange()
        {
            controller = new RecordsController();
        }

        protected override void Act()
        {
            allMen = controller.Get("all");
        }

        [TestMethod]
        public void then_all_2_sample_men_are_returned()
        {
            allMen.Should().HaveCount(2);
        }

        private RecordsController controller;
        private IEnumerable<Man> allMen;
    }
}