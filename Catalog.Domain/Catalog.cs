using System.Collections.Generic;

namespace Catalog.Domain
{
    public class Catalog
    {
        public Catalog()
        {
            catalog = new List<Man>();
            sync = new object();

        }

        public IEnumerable<Man> GetAll()
        {
            lock (sync)
            {
                return catalog;
            }
        }

        public void Add(params Man[] men)
        {
            lock (sync)
            {
                foreach (var each in men)
                {
                    if (!catalog.Contains(each))
                        catalog.Add(each);
                }
            }
        }

        private List<Man> catalog;
        private object sync;
    }
}
