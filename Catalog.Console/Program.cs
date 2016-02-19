using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Catalog.Console
{
    using System;
    using Domain;

    class Program
    {
        static void Main(string[] args)
        {
            var script = File.ReadAllText(args[0]);

            var men = ParseMen(script);
            var catalog = new Catalog();
            catalog.Add(men.ToArray());

            Console.WriteLine(new GenderLastnameReport(catalog).Compose());
            Console.WriteLine(new BirthdateReport(catalog).Compose());
            Console.WriteLine(new LastNameReport(catalog).Compose());
        }

        static IEnumerable<Man> ParseMen(string script)
        {
            var parser = new ManGrammarParser(script);
            parser.Parse();

            return parser.GetMen();
        }
    }
}
