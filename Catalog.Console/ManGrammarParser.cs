using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Catalog.Domain;

namespace Catalog.Console
{
    public class ManGrammarParser
    {
        public ManGrammarParser(string script)
        {
            this.script = script;
            this.men = new List<Man>();
        }

        public IEnumerable<Man> GetMen()
        {
            return men;
        }

        public void Parse()
        {
            var humanRecords = script.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            men = humanRecords.Select(ParseHuman).ToList();
        }

        private Man ParseHuman(string humanRecord)
        {
            var attributes = humanRecord.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

            return new Man(lastName: attributes[0], name: attributes[1], gender: attributes[2], favoriteColor: attributes[3], birthdate: DateTime.ParseExact(attributes[4], "M/d/yyyy", CultureInfo.InvariantCulture));
        }

        private string script;
        private List<Man> men;
    }
}
