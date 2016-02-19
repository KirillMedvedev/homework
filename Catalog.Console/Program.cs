using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Catalog.Console
{
    using System;
    using Domain;

    class Program
    {
        static void Main(string[] inputFiles)
        {
            var catalog = ReadCatalog(inputFiles);

            ShowReports(catalog);
        }

        private static void ShowReports(Catalog catalog)
        {
            Console.WriteLine(new GenderLastnameReport(catalog).Compose());
            Console.WriteLine(new BirthdateReport(catalog).Compose());
            Console.WriteLine(new LastNameReport(catalog).Compose());
        }

        private static Catalog ReadCatalog(string[] inputFiles)
        {
            var catalog = new Catalog();

            foreach (var eachInputFile in inputFiles)
            {
                var script = File.ReadAllText(eachInputFile);
                var men = ParseMen(script);
                catalog.Add(men.ToArray());
            }

            return catalog;
        }

        private static IEnumerable<Man> ParseMen(string script)
        {
            var parser = new ManGrammarParser(script);
            parser.Parse();

            return parser.GetMen();
        }
    }
}
