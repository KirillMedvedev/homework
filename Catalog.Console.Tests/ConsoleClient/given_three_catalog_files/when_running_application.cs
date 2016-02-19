using System.Diagnostics;
using System.IO;
using System.Linq;
using bd.mstest;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Console.Tests.ConsoleClient.given_three_catalog_files
{
    [TestClass]
    public class when_running_application : SUT
    {
        protected override void Arrange()
        {
            var fileNames = new[] { "PipeDelimitedList.txt", "CommaDelimitedList.txt", "SpaceDelimitedList.txt" };

            catalogProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "Catalog.Console.exe",
                    Arguments = string.Join(" ", fileNames.Select(x=> Path.Combine("ConsoleClient\\given_three_catalog_files", x))),
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };
        }

        protected override void Act()
        {
            catalogProcess.Start();

            output = catalogProcess.StandardOutput.ReadToEnd();

            catalogProcess.WaitForExit();
        }

        [TestMethod]
        public void then_application_prints_all_reports()
        {
            var expected = "Catalog by gender, then last name:\r\n" +
                           "Connirae Andreas, born in 1/11/1960, loves Blue color, is a Female\r\n" +
                           "Liskov Barbara, born in 7/11/1939, loves Yellow color, is a Female\r\n" +
                           "Glenda Eoyang, born in 1/1/1960, loves Yellow color, is a Female\r\n" +
                           "Martin Fowler, born in 1/10/1963, loves Blue color, is a Male\r\n" +
                           "Beck Kent, born in 2/20/1961, loves Green color, is a Male\r\n" +
                           "\r\n" +
                           "Catalog by birthdate:\r\n" +
                           "Liskov Barbara, born in 7/11/1939, loves Yellow color, is a Female\r\n" +
                           "Glenda Eoyang, born in 1/1/1960, loves Yellow color, is a Female\r\n" +
                           "Connirae Andreas, born in 1/11/1960, loves Blue color, is a Female\r\n" +
                           "Beck Kent, born in 2/20/1961, loves Green color, is a Male\r\n" +
                           "Martin Fowler, born in 1/10/1963, loves Blue color, is a Male\r\n" +
                           "\r\n" +
                           "Catalog by last name:\r\n" +
                           "Beck Kent, born in 2/20/1961, loves Green color, is a Male\r\n" +
                           "Martin Fowler, born in 1/10/1963, loves Blue color, is a Male\r\n" +
                           "Glenda Eoyang, born in 1/1/1960, loves Yellow color, is a Female\r\n" +
                           "Liskov Barbara, born in 7/11/1939, loves Yellow color, is a Female\r\n" +
                           "Connirae Andreas, born in 1/11/1960, loves Blue color, is a Female\r\n\r\n";

            output.Should().Be(expected);
        }

        private string output;
        private Process catalogProcess;
    }
}
