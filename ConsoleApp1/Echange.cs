using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ConsoleApp1
{
    public class Echange
    {
        private static double[][] conversion;
        private static double[][] bests;
        public static void MyMain(string[] args)
        {
            var line = Console.ReadLine().Split(' ');
            var nbDevises = int.Parse(line[0]);
            var maxEchanges = int.Parse(line[1]);
            conversion = new double[nbDevises][];
            for (var i = 0; i < nbDevises; i++)
            {
                var readLine = Console.ReadLine();
                var l = readLine.Split(' ').Select(x => double.Parse(x, CultureInfo.InvariantCulture.NumberFormat)).ToArray();
                conversion[i] = l;
            }

            var value = 10000;
            var devise = 0;
            bests = new double[nbDevises][];
            for (var i = 0; i < bests.Length; i++)
            {
                bests[i] = new double[maxEchanges + 1];
            }
            var best = GetEchange(devise, value, maxEchanges);
            Console.WriteLine(best.ToString(CultureInfo.InvariantCulture.NumberFormat));
        }

        public static double GetEchange(int devise, double value, int maxEchanges)
        {
            if (bests[devise][maxEchanges] > value) return 0;
            bests[devise][maxEchanges] = value;
            if (maxEchanges == 1)
            {
                var result = value * conversion[devise][0];
                return result;
            }
            var best = 0.0;
            for (var i = 0; i < conversion.Length; i++)
            {
                var newValue = value * conversion[devise][i];
                
                var result = GetEchange(i, newValue, maxEchanges - 1);
                if (result > best)
                {
                    best = result;
                }
            }

            return best;
        }
    }
}