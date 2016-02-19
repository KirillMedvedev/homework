using System.Collections.Generic;
using System.Linq;

namespace Catalog.Domain
{
    public class Catalog
    {
        public Catalog()
        {
            catalog = new List<Man>();
        }

        public IEnumerable<Man> GetAll()
        {
            return catalog;
        }

        //TODO: Make collection thread safe for rest service!
        public void Add(params Man[] men)
        {
            catalog = men.ToList();
        }

        private List<Man> catalog;
    }
}
