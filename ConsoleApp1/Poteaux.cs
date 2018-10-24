using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Poteaux
    {
        public static void MyMain(string[] args)
        {
            var nbPoteaux = int.Parse(Console.ReadLine());
            var poteaux = new List<int>();
            for (var i = 0; i< nbPoteaux; i++)
            {
                var height = int.Parse(Console.ReadLine());
                poteaux.Add(height);
            }
            poteaux = poteaux.OrderBy(x => x).ToList();
            var solution = new List<int>();
            while (poteaux.Any())
            {
                var first = poteaux[0];
                poteaux.Remove(first);
                var last = poteaux.Last();
                poteaux.Remove(last);
                solution.Add(first);
                solution.Add(last);
            }
            Console.WriteLine(string.Join("\n",solution.Select(x => x.ToString())));
        }
    }
}