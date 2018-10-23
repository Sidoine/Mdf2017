using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject1
{
    public class PoteauxTest
    {
        private readonly ITestOutputHelper testOutputHelper;

        public PoteauxTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Theory]
        [MemberData(nameof(GetFileNames))]

        public void Test1(string input, string output)
        {
            var textWriter = new StringWriter();
            Console.SetOut(textWriter);
            var file = File.ReadAllText(input);
            Console.SetIn(new StringReader(file));
            Poteaux.MyMain(null);
        
            var expected = File.ReadAllText(output);
            if (!expected.EndsWith("\r\n")) expected = expected + "\r\n";
            Assert.Equal(expected, textWriter.ToString());
        }

        public static IEnumerable<object[]> GetFileNames()
        {
            var directory = Directory.EnumerateFiles(@"..\..\..\files\poteaux", "input*.*");
            foreach (var dir in directory)
            {
                yield return new object[] { dir, dir.Replace("input", "output") };
            }
        }
    }
}
