using System;
using System.Collections.Generic;
using System.IO;
using ConsoleApp1;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject1
{
    public class KayakTest
    {
        private readonly ITestOutputHelper testOutputHelper;

        public KayakTest(ITestOutputHelper testOutputHelper)
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
            Kayak.MyMain(null);
            
            testOutputHelper.WriteLine(TestTools.OutputGrid(Kayak.Cases));
            testOutputHelper.WriteLine(TestTools.OutputGrid(Kayak.Value));

            var expected = File.ReadAllText(output);
            Assert.Equal(expected, textWriter.ToString());
        }

        public static IEnumerable<object[]> GetFileNames()
        {
            var directory = Directory.EnumerateFiles(@"..\..\..\files\kayak", "input*.*");
            foreach (var dir in directory)
            {
                yield return new object[] { dir, dir.Replace("input", "output") };
            }
        }

    }
}
