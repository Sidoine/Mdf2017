using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject1
{
    public class CerclesTest
    {
        private readonly ITestOutputHelper testOutputHelper;

        public CerclesTest(ITestOutputHelper testOutputHelper)
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
            Cercles.MyMain(null);
        
            var expected = File.ReadAllText(output).Replace("\r\n", "\n");
            if (!expected.EndsWith("\n")) expected = expected + "\n";
            var actual = textWriter.ToString().Replace("\r\n", "\n");
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetFileNames()
        {
            var directory = Directory.EnumerateFiles(@"..\..\..\files\cercles", "input*.*");
            foreach (var dir in directory)
            {
                yield return new object[] { dir, dir.Replace("input", "output") };
            }
        }
    }
}
