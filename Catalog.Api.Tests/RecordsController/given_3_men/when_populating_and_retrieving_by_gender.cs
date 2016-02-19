using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Api.Tests.RecordsController.given_3_men
{
    [TestClass]
    public class when_populating_and_retrieving_by_gender : ControllerWith3Men
    {
        protected override string GetBy()
        {
            return "gender";
        }

        [TestMethod]
        public void then_returned_catalog_is_ordered_by_gender()
        {
            returnedCatalog.Should().BeInAscendingOrder(x=>x.Gender);
        }

        [TestMethod]
        public void then_all_three_men_are_returned()
        {
            returnedCatalog.Should().HaveCount(3);
        }

        [TestMethod]
        public void then_females_go_first()
        {
            returnedCatalog.First().Gender.Should().Be("Female");
        }
    }
}