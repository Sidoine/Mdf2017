﻿using System;

namespace ConsoleApp1
{
    public class Kayak
    {
        private static Libs.CharMatrix cases { get; set; } = new Libs.CharMatrix();
        private static Libs.IntMatrix values { get; set; } = new Libs.IntMatrix();

        public static void MyMain(string[] args)
        {
            cases.ReadSquareSize();
            values.SetSize(cases.Width, cases.Height);
            cases.ReadValues();
            values.Empty();
            for (var y = 0; y < cases.Height; y++)
            {
                for (var x = 0; x < cases.Width; x++)
                {
                    Paint(x, y);
                }
            }

            Console.WriteLine(values.Get(values.Width- 1, values.Height-1));
        }

        private static void Paint(int x, int y)
        {
            var v = Math.Max(values.Get(x - 1, y), values.Get(x, y - 1));
            if (IsPorte(x, y))
            {
                v++;
            }
            values.Set(x, y, v);
        }

        private static bool IsPorte(int x, int y)
        {
            return cases.Get(x, y) == 'X';
        }
    }
}