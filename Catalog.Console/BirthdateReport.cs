using System.Collections.Generic;
using System.Linq;
using Catalog.Domain;

namespace Catalog.Console
{
    public class BirthdateReport : Report
    {
        public BirthdateReport(Domain.Catalog catalog) : base(catalog)
        {
        }

        protected override string GetCaption()
        {
            return "Catalog by birthdate:";
        }

        protected override IEnumerable<Man> GetOrdered()
        {
            return catalog.GetAll().OrderBy(x => x.Birthdate);
        }
    }
}