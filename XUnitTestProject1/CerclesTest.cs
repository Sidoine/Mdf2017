using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace XUnitTestProject1
{
    public class CerclesTest
    {
        [Theory]
        [MemberData(nameof(GetFileNames))]

        public void Test1(string input, string output)
        {
            var textWriter = new StringWriter();
            Console.SetOut(textWriter);
            var file = File.ReadAllText(input);
            Console.SetIn(new StringReader(file));
            ConsoleApp1.Cercles.MyMain(null);
            
            var expected = File.ReadAllText(output);
            Assert.Equal(expected, textWriter.ToString());
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
