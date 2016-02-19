using System.Diagnostics;
using bd.mstest;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Console.Tests.ConsoleClient.given_one_catalog_file
{
    [TestClass]
    public class when_running_application : SUT
    {
        protected override void Arrange()
        {
            catalogProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "Catalog.Console.exe",
                    Arguments = @"ConsoleClient\given_one_catalog_file\PipeDelimitedList.txt",
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
        public void then_application_prints_original_catalog()
        {
            var expected = "Martin Fowler, born in 1/10/1963, loves Blue color, is a Male" + "\r\n" +
                           "Beck Kent, born in 2/20/1961, loves Green color, is a Male" + "\r\n" +
                           "Robert Martin, born in 3/30/1952, loves Yellow color, is a Male" + "\r\n";

            output.Should().Be(expected);
        }

        private string output;
        private Process catalogProcess;
    }
}
