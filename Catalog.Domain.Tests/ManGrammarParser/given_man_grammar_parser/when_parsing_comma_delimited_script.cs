using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Domain.Tests.ManGrammarParser.given_man_grammar_parser
{
    using Domain;

    [TestClass]
    public class when_parsing_comma_delimited_script : ParserUnderTest
    {
        protected override string Script()
        {
            return "Fowler, Martin, Male, Blue, 1/10/1963" + Environment.NewLine +
                   "Martin, Robert, Male, Yellow, 3/30/1952";
        }

        protected override IEnumerable<Man> Entities()
        {
            return new List<Man>
            {
                new Man("Fowler", "Martin", "Male", "Blue", new DateTime(1963, 1, 10)),
                new Man("Martin", "Robert", "Male", "Yellow", new DateTime(1952, 3, 30))
            };
        }

        [TestMethod]
        public void then_people_parsed_correctly()
        {
            DoAssertion();
        }
    }
}