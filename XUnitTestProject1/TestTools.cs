using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestProject1
{
    public static class TestTools
    {
        public static string OutputGrid<T>(T[][] array)
        {
            var output = new StringBuilder();
            foreach (T[] row in array)
            {
                foreach (T cell in row)
                {
                    output.Append(cell);
                }
                output.AppendLine();
            }
            return output.ToString();
        }
    }
}
