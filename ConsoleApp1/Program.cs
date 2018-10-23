using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    public static class Program
    {
        public static void Main()
        {
            var rootCode = @"..\..\..";
            var rootUnitTests = $@"{rootCode}\..\XUnitTestProject1";
            var rootUnitTestsCases = $@"{rootUnitTests}\files";
            foreach (var directory in Directory.EnumerateDirectories(rootUnitTestsCases).Select(x => Path.GetFileName(x)))
            {
                var className = $"{directory[0].ToString().ToUpperInvariant()}{directory.Substring(1)}";
                var content = $@"using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject1
{{
    public class {className}Test
    {{
        private readonly ITestOutputHelper testOutputHelper;

        public {className}Test(ITestOutputHelper testOutputHelper)
        {{
            this.testOutputHelper = testOutputHelper;
        }}

        [Theory]
        [MemberData(nameof(GetFileNames))]

        public void Test1(string input, string output)
        {{
            var textWriter = new StringWriter();
            Console.SetOut(textWriter);
            var file = File.ReadAllText(input);
            Console.SetIn(new StringReader(file));
            {className}.MyMain(null);
        
            var expected = File.ReadAllText(output);
            if (!expected.EndsWith(""\r\n"")) expected = expected + ""\r\n"";
            Assert.Equal(expected, textWriter.ToString());
        }}

        public static IEnumerable<object[]> GetFileNames()
        {{
            var directory = Directory.EnumerateFiles(@""..\..\..\files\{directory}"", ""input*.*"");
            foreach (var dir in directory)
            {{
                yield return new object[] {{ dir, dir.Replace(""input"", ""output"") }};
            }}
        }}
    }}
}}
";
                File.WriteAllText($@"{rootUnitTests}\{className}Test.cs", content);

                var mainPath = $@"{rootCode}\{className}.cs";
                if (!File.Exists(mainPath))
                {
                    var output = $@"using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{{
    public class {className}
    {{
        public static void MyMain(string[] args)
        {{
        }}
    }}
}}";
                    File.WriteAllText(mainPath, output);
                }
                else
                {
                    var input = File.ReadAllText(mainPath);
                    var output = input.Replace("MyMain", "Main");
                    output = output.Replace(className, "Program");
                    File.WriteAllText($@"{rootCode}\Output\{className}.txt", output);
                }
            }
        }
    }
}
