using System.Collections.Generic;
using Catalog.Domain;

namespace Catalog.Console
{
    public abstract class Report
    {
        public Report(Domain.Catalog catalog)
        {
            this.catalog = catalog;
        }

        public string Compose()
        {
            return string.Format("{0}\r\n{1}\r\n", GetCaption(), string.Join("\r\n", GetOrdered()));
        }

        protected abstract string GetCaption();
        protected abstract IEnumerable<Man> GetOrdered();

        protected Domain.Catalog catalog;
    }
}