using System.Collections.Generic;
using bd.mstest;
using FluentAssertions;
using KellermanSoftware.CompareNetObjects;

namespace Catalog.Domain.Tests.ManGrammarParser.given_man_grammar_parser
{
    using Domain;

    public abstract class ParserUnderTest : SUT
    {
        protected override void Arrange()
        {
            parser = new ManGrammarParser(Script());
        }

        protected override void Act()
        {
            parser.Parse();
            actualMen = parser.GetMen();
        }

        protected void DoAssertion()
        {
            var compareLogic = new CompareLogic();
            var comparisonResult = compareLogic.Compare(Entities(), actualMen);

            comparisonResult.AreEqual.Should().BeTrue(comparisonResult.DifferencesString);
        }

        protected abstract string Script();
        protected abstract IEnumerable<Man> Entities();

        private ManGrammarParser parser;
        private IEnumerable<Man> actualMen;
    }
}