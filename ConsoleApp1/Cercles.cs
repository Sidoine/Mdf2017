using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Cercles
    {
        public static void MyMain(string[] args)
        {

            var taille = int.Parse(Console.ReadLine());
            var output = new byte[taille * taille];

            for (var t = taille; t > 0; t-= 2)
            {
                var py = (taille - t) / 2;
                for (var y = 0; y < t; y++)
                {
                    var px = (taille - t) / 2;
                    for (var x = 0; x < t; x++)
                    {
                        if (x == 0 && y == 0) continue;
                        if (x == 0 && y == t - 1) continue;
                        if (x == t- 1 && y == 0) continue;
                        if (x == t- 1 && y == t - 1) continue;
                        //  if ((x != 0 || y != 0) && ( x != t * 2 - 1 || y != t * 2 - 1))
                        output[(y + py) * taille + x + px] = (byte)((t / 2) % 2 + 1);
                    }
                }
            }

            for (var y =  0; y < taille; y++)
            {
                for (var x =  0; x < taille; x ++)
                {
                    switch (output[y * taille + x])
                    {
                        case 0:
                            Console.Write('.');
                            break;
                        case 1:
                            Console.Write('*');
                            break;
                        case 2:
                            Console.Write('#');
                            break;
                    }                    
                }
                Console.Write("\n");
            }
        }
    }
}