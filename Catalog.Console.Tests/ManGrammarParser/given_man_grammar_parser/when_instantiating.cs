using bd.mstest;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Console.Tests.ManGrammarParser.given_man_grammar_parser
{
    using Console;

    [TestClass]
    public class when_instantiating : SUT
    {
        protected override void Arrange()
        {
            manGrammarParser = new ManGrammarParser("script");
        }

        [TestMethod]
        public void then_no_parsed_men()
        {
            manGrammarParser.GetMen().Should().BeEmpty();
        }

        private ManGrammarParser manGrammarParser;
    }
}
