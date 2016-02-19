using bd.mstest;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Domain.Tests.Man.given_man
{
    using Domain;

    [TestClass]
    public class when_representing_as_string : SUT
    {
        protected override void Arrange()
        {
            man = new Man("Cohn", "Mike", "Male", "Pink", "1960");
        }

        protected override void Act()
        {
            manAsString = man.ToString();
        }

        [TestMethod]
        public void then_string_representation_is_correct()
        {
            manAsString.Should().Be("Mike Cohn, born in 1960, loves Pink color, is a Male");
        }

        private Man man;
        private string manAsString;
    }
}
