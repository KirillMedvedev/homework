using System.Collections.Generic;
using System.IO;
using Catalog.Domain;

namespace Catalog.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var script = File.ReadAllText(args[0]);

            var catalog = ParseMen(script);

            foreach (var each in catalog)
            {
                System.Console.WriteLine(each);
            }
        }

        static IEnumerable<Man> ParseMen(string script)
        {
            var parser = new ManGrammarParser(script);
            parser.Parse();

            return parser.GetMen();
        }
    }
}
