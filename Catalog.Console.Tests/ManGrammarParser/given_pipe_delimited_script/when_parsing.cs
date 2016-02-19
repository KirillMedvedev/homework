using System;
using System.Collections.Generic;
using bd.mstest;
using FluentAssertions;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Console.Tests.ManGrammarParser.given_pipe_delimited_script
{
    [TestClass]
    public class when_parsing : SUT
    {
        protected override void Arrange()
        {
            script = "Fowler | Martin | Male | Blue | 1963" + Environment.NewLine +
                     "Kent | Beck | Male | Green | 1961" + Environment.NewLine +
                     "Martin | Robert | Male | Yellow | 1952";

            parser = new Console.ManGrammarParser(script);
        }

        protected override void Act()
        {
            parser.Parse();
            actualMen = parser.GetMen();
        }

        [TestMethod]
        public void then_people_parpsed_correctly()
        {
            var expectedMen = new List<Console.Man>
            {
                new Console.Man("Fowler", "Martin", "Male", "Blue", "1963"),
                new Console.Man("Kent", "Beck", "Male", "Green", "1961"),
                new Console.Man("Martin", "Robert", "Male", "Yellow", "1952"),
            };

            var compareLogic = new CompareLogic();
            var comparisonResult = compareLogic.Compare(expectedMen, actualMen);

            comparisonResult.AreEqual.Should().BeTrue(comparisonResult.DifferencesString);
        }

        private string script;
        private Console.ManGrammarParser parser;
        private IEnumerable<Console.Man> actualMen;
    }
}
