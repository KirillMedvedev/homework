using System.IO;

namespace Catalog.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = args[0];

            var parser = new ManGrammarParser(File.ReadAllText(fileName));
            parser.Parse();

            foreach (var each in parser.GetMen())
            {
                System.Console.WriteLine(each);
            }
        }
    }
}
