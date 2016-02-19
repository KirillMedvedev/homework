using System.Collections.Generic;
using System.Linq;
using Catalog.Domain;

namespace Catalog.Console
{
    public class LastNameReport : Report
    {
        public LastNameReport(Domain.Catalog catalog) : base(catalog)
        {
        }

        protected override string GetCaption()
        {
            return "Catalog by last name:";
        }

        protected override IEnumerable<Man> GetOrdered()
        {
            return catalog.GetAll().OrderByDescending(x => x.LastName);
        }
    }
}