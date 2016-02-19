using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Catalog.Api.Controllers
{
    using Domain;

    public class RecordsController : ApiController
    {
        static RecordsController()
        {
            catalog = new Catalog();

            PopulateCatalogWithSamples();
        }

        private static void PopulateCatalogWithSamples()
        {
            var script = "Fowler | Martin | Male | Blue | 1963\r\n" +
                         "Kent | Beck | Male | Green | 1961";

            var parser = new ManGrammarParser(script);
            parser.Parse();

            var list = parser.GetMen();

            catalog.Add(list.ToArray());
        }

        [Route("records/{mode:alpha}")]
        public IEnumerable<Man> Get(string mode)
        {
            if (mode == "all")
            {
                return catalog.GetAll();
            }

            return new[] { new Man("empty", "empty", "empty", "empty", "empty")  };
        }

        // POST: api/Records
        public void Post([FromBody]string value)
        {
        }

        static Catalog catalog;
    }
}
