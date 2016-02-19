using System;
using System.Collections.Generic;
using bd.mstest;
using Catalog.Domain;

namespace Catalog.Api.Tests.RecordsController.given_3_men
{
    using Controllers;

    public abstract class ControllerWith3Men : SUT
    {
        protected override void Arrange()
        {
            controller = new RecordsController();

            var menString = "Fowler | Martin | Male | Blue | 1/1/1963" + Environment.NewLine +
                            "Kent | Beck | Male | Green | 1/1/1961" + Environment.NewLine +
                            "Liskova | Barbara | Female | Yellow | 1/1/1952";

            controller.Post(menString);
        }

        protected override void Act()
        {
            returnedCatalog = controller.Get(GetBy());
        }

        protected abstract string GetBy();

        protected IEnumerable<Man> initialCatalog; 
        protected IEnumerable<Man> returnedCatalog;
        private RecordsController controller;
    }
}