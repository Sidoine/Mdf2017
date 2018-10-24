using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Wifi
    {
        public static void MyMain(string[] args)
        {
            var nbParticipants = int.Parse(Console.ReadLine());
            var meet = new bool[nbParticipants][];
            for (var i = 0; i < nbParticipants; i++)
            {
                var m = Console.ReadLine().Split(' ');
                meet[i] = m.Select(x => x == "1").ToArray();
            }

            var rencontres = new List<int>();
            for (var i = 0; i < nbParticipants; i++)
            {
                for (var j = 0; j < nbParticipants; j++)
                {

                }
            }
            Console.WriteLine(rencontres.OrderByDescending(x => x).First());
        }

        public static int NbMet(int[] already)
        {
            for (var i = 0; i < nbParticipants; i++)
            {
            }
        }
    }
}