using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Croissance
    {
        public static int GetMaxDecroissant(int[] releves, int picValeur, int pos)
        {
            if (pos == releves.Length) return 0;
            var next = releves[pos];
            var b = GetMaxDecroissant(releves, picValeur, pos + 1);
            if (next < picValeur)
            {
                var a = 1 + GetMaxDecroissant(releves, next, pos + 1);
                return Math.Max(a, b);
            }

            return b;
        }

        public static int GetMaxCroissant(int[] releves, int picValeur, int pos)
        {
            if (pos == releves.Length) return 0;
            var next = releves[pos];
            var a = GetMaxCroissant(releves, picValeur, pos + 1);
            if (next > picValeur)
            {
                var b = 1 + GetMaxCroissant(releves, next, pos + 1);
                return Math.Max(a, b);
            }
            else if (next < picValeur)
            {
                var b = GetMaxDecroissant(releves, picValeur, pos);
                return Math.Max(a, b);
            }

            return a;

        }
        


        public static void MyMain(string[] args)
        {
            var nbReleves = int.Parse(Console.ReadLine());
            var releves = new int[nbReleves];
            for (var i = 0; i < nbReleves; i++)
            {
                var chomeurs = int.Parse(Console.ReadLine());
                releves[i] = chomeurs;
            }

            //var result = GetMaxCroissant(releves, 0, 0);
            var max = 0;
            for (var i = 1; i < releves.Length - 1; i++)
            {
                ////var a = BestCroissant(releves, releves[i], i - 1, 0);
                ////var b = BestDecroissant(releves, releves[i], i + 1, 0);
                //if (a + b + 1 > max) max = a + b + 1;

            }
            Console.WriteLine(max);
        }

        public static int BestCroissant(int[] values, int valeurPic, int pos, int min)
        {
            if (pos < min) return 0;
            var value = values[pos];
            var a = BestCroissant(values, valeurPic, pos - 1, min);
            if (value < valeurPic)
            {
                var b = 1 + BestCroissant(values, value, pos - 1, Math.Max(min, a));
                return Math.Max(a, b);
            }

            return a;
        }

        public static int BestDecroissant(int[] values, int valeurPic, int pos, int min)
        {
            if (pos >= values.Length - min) return 0;
            var value = values[pos];
            var a = BestDecroissant(values, valeurPic, pos + 1, min);
            if (value < valeurPic)
            {
                var b = 1 + BestDecroissant(values, value, pos + 1, Math.Max(min, a));
                return Math.Max(a, b);
            }

            return a;
        }
    }
}