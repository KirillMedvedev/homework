using System.Linq;
using System.Collections.Generic;

namespace Catalog.Console
{
    using Catalog.Domain;

    public class GenderLastnameReport : Report
    {
        public GenderLastnameReport(Catalog catalog) : base(catalog)
        {
        }

        protected override string GetCaption()
        {
            return "Catalog by gender, then last name:";
        }

        protected override IEnumerable<Man> GetOrdered()
        {
            return catalog.GetAll().OrderBy(x => x.Gender).ThenBy(x => x.LastName);
        } 
    }
}
