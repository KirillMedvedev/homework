﻿using System;
using System.Collections.Generic;
using bd.mstest;
using FluentAssertions;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Domain.Tests.ManGrammarParser.given_pipe_delimited_script
{
    using Domain;

    [TestClass]
    public class when_parsing : SUT
    {
        protected override void Arrange()
        {
            script = "Fowler | Martin | Male | Blue | 1/10/1963" + Environment.NewLine +
                     "Kent | Beck | Male | Green | 2/20/1961" + Environment.NewLine +
                     "Martin | Robert | Male | Yellow | 3/30/1952";

            parser = new ManGrammarParser(script);
        }

        protected override void Act()
        {
            parser.Parse();
            actualMen = parser.GetMen();
        }

        [TestMethod]
        public void then_people_parpsed_correctly()
        {
            var expectedMen = new List<Man>
            {
                new Man("Fowler", "Martin", "Male", "Blue", new DateTime(1963, 1, 10)),
                new Man("Kent", "Beck", "Male", "Green", new DateTime(1961, 2, 20)),
                new Man("Martin", "Robert", "Male", "Yellow", new DateTime(1952, 3, 30))
            };

            var compareLogic = new CompareLogic();
            var comparisonResult = compareLogic.Compare(expectedMen, actualMen);

            comparisonResult.AreEqual.Should().BeTrue(comparisonResult.DifferencesString);
        }

        private string script;
        private ManGrammarParser parser;
        private IEnumerable<Man> actualMen;
    }
}
