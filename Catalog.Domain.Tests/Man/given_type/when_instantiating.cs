﻿using System;
using bd.mstest;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Domain.Tests.Man.given_type
{
    using Domain;

    [TestClass]
    public class when_instantiating : SUT
    {
        protected override void Arrange()
        {
            man = new Man("surname", "name", "male", "red", new DateTime(2000, 1, 1));
        }

        [TestMethod]
        public void then_name_is_set()
        {
            man.Name.Should().Be("name");
        }

        [TestMethod]
        public void then_lastname_is_set()
        {
            man.LastName.Should().Be("surname");
        }

        [TestMethod]
        public void then_gender_is_set()
        {
            man.Gender.Should().Be("male");
        }

        [TestMethod]
        public void then_birthday_is_set()
        {
            man.Birthdate.Should().Be(new DateTime(2000, 1, 1));
        }

        [TestMethod]
        public void then_favorite_color_is_set()
        {
            man.FavoriteColor.Should().Be("red");
        }

        private Man man;
    }
}