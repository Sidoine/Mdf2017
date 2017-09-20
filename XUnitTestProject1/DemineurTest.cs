using System;
using System.Collections.Generic;
using System.IO;
using ConsoleApp1;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject1
{
    public class DemineurTest
    {
        private readonly ITestOutputHelper outputHelper;

        public DemineurTest(ITestOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
        }

        [Theory]
        [MemberData(nameof(GetFileNames))]

        public void Test1(string input, string output)
        {
            var textWriter = new StringWriter();
            Console.SetOut(textWriter);
            var file = File.ReadAllText(input);
            Console.SetIn(new StringReader(file));
            Demineur.MyMain(null);
            
            var expected = File.ReadAllText(output);
            outputHelper.WriteLine(TestTools.OutputGrid(Demineur.Mines));
            Assert.Equal(expected, textWriter.ToString());
        }

        public static IEnumerable<object[]> GetFileNames()
        {
            var directory = Directory.EnumerateFiles(@"..\..\..\files\demineur", "input*.*");
            foreach (var dir in directory)
            {
                yield return new object[] { dir, dir.Replace("input", "output") };
            }
        }
    }
}
