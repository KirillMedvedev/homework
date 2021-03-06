﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bd.mstest;
using FluentAssertions;

namespace Catalog.Domain.Tests.Man.given_two_identical_men
{
    using Domain;

    [TestClass]
    public class when_doing_something : SUT
    {
        protected override void Arrange()
        {
            firstMan = new Man("Gamma", "Erich", "Male", "orange", new DateTime(1954, 3, 13));
            secondMan = new Man("Gamma", "Erich", "Male", "orange", new DateTime(1954, 3, 13));
        }

        protected override void Act()
        {
            areEqual = firstMan.Equals(secondMan);
        }

        [TestMethod]
        public void then_something_occurs()
        {
            areEqual.Should().BeTrue();
        }

        private Man firstMan;
        private Man secondMan;
        private bool areEqual;
    }
}