using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bd.mstest;
using FluentAssertions;

namespace Catalog.Domain.Tests.Catalog.given_type
{
    using Domain;

    [TestClass]
    public class when_instantiating : SUT
    {
        protected override void Arrange()
        {
            catalog = new Catalog();
        }

        protected override void Act()
        {
            allMen = catalog.GetAll();
        }

        [TestMethod]
        public void then_catalog_is_empty()
        {
            allMen.Should().BeEmpty();
        }

        private Catalog catalog;
        private IEnumerable<Man> allMen;
    }
}