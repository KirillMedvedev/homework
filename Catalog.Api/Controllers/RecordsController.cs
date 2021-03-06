﻿using System;
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
        }

        [Route("records/{mode:alpha}")]
        public IEnumerable<Man> Get(string mode)
        {
            if (mode == "gender")
                return catalog.GetAll().OrderBy(x => x.Gender);
            
            if (mode == "birthdate")
                return catalog.GetAll().OrderBy(x => x.Birthdate);

            if (mode == "name")
                return catalog.GetAll().OrderBy(x => x.Name);

            return catalog.GetAll();
        }

        public void Post([FromBody]string value)
        {
            var parser = new ManGrammarParser(value);
            parser.Parse();

            var men = parser.GetMen();
            catalog.Add(men.ToArray());
        }

        static Catalog catalog;
    }
}
