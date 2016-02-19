using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Api.Tests.RecordsController.given_3_men
{
    [TestClass]
    public class when_populating_and_retrieving_by_name : ControllerWith3Men
    {
        protected override string GetBy()
        {
            return "name";
        }

        [TestMethod]
        public void then_returned_catalog_is_ordered_by_name()
        {
            returnedCatalog.Should().BeInAscendingOrder(x => x.Name);
        }

        [TestMethod]
        public void then_all_three_men_are_returned()
        {
            returnedCatalog.Should().HaveCount(3);
        }
    }
}