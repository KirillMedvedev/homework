using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Domain.Tests.ManGrammarParser.given_man_grammar_parser
{
    [TestClass]
    public class when_parsing_pipe_delimited_script : ParserUnderTest
    {
        protected override string Script()
        {
            return "Fowler | Martin | Male | Blue | 1/10/1963" + Environment.NewLine +
                   "Kent | Beck | Male | Green | 2/20/1961" + Environment.NewLine +
                   "Martin | Robert | Male | Yellow | 3/30/1952";
        }

        protected override IEnumerable<Domain.Man> Entities()
        {
            return new List<Domain.Man>
            {
                new Domain.Man("Fowler", "Martin", "Male", "Blue", new DateTime(1963, 1, 10)),
                new Domain.Man("Kent", "Beck", "Male", "Green", new DateTime(1961, 2, 20)),
                new Domain.Man("Martin", "Robert", "Male", "Yellow", new DateTime(1952, 3, 30))
            };
        }

        [TestMethod]
        public void then_people_parsed_correctly()
        {
            DoAssertion();
        }
    }
}
