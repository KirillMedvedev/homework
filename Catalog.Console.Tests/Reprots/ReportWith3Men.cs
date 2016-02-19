using System;
using bd.mstest;

namespace Catalog.Console.Tests.Reprots
{
    using Domain;

    public class ReportWith3Men<T> : SUT where T : Report
    {
        protected override void Arrange()
        {
            CreateCatalog();

            CreateReport();
        }

        protected override void Act()
        {
            composedReport = report.Compose();
        }

        private void CreateReport()
        {
            report = (Report)Activator.CreateInstance(typeof (T), catalog);
        }

        private void CreateCatalog()
        {
            catalog = new Catalog();

            catalog.Add(new Man("Fowler", "Martin", "Male", "Blue", new DateTime(1963, 1, 10)));
            catalog.Add(new Man("Kent", "Beck", "Male", "Green", new DateTime(1961, 2, 20)));
            catalog.Add(new Man("Eoyang", "Glenda", "Female", "Yellow", new DateTime(1960, 1, 1)));
        }

        Report report;
        Catalog catalog;

        protected string composedReport;
    }
}
