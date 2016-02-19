using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Catalog.Console.Tests.Reprots
{
    [TestClass]
    public class when_composing_gender_last_name_report : ReportWith3Men<GenderLastnameReport>
    {
        [TestMethod]
        public void then_report_is_as_exampled()
        {
            var expected = "Catalog by gender, then last name:\r\n" +
                           "Glenda Eoyang, born in 1/1/1960, loves Yellow color, is a Female\r\n" +
                           "Martin Fowler, born in 1/10/1963, loves Blue color, is a Male\r\n" +
                           "Beck Kent, born in 2/20/1961, loves Green color, is a Male\r\n";

            base.composedReport.Should().Be(expected);
        }
    }
}