using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Casino
    {
        public static void MyMain(string[] args)
        {
            var nbTours = int.Parse(Console.ReadLine());
            var nbJetons = int.Parse(Console.ReadLine());
            var initial = nbJetons;
            var nbRachats = 0;
            for (var i = 0; i < nbTours; i++)
            {
                var line = Console.ReadLine().Split(' ');
                var mise = int.Parse(line[0]);
                var choix = line[1];
                var tire = int.Parse(line[2]);
                nbJetons -= mise;
                if (tire != 0)
                {
                    if (choix == "P")
                    {
                        if (tire % 2 == 0)
                        {
                            nbJetons += mise * 2;
                         }
                    }
                    else if (choix == "I")
                    {
                        if (tire % 2 == 1)
                        {
                            nbJetons += mise * 2;
                        }       
                    }
                    else if (tire == int.Parse(choix))
                    {
                        nbJetons += mise * 36;

                    }
                }

                if (nbJetons <= 0)
                {
                    nbJetons = initial;
                    nbRachats++;
                }
            }
            Console.WriteLine(nbRachats);
        }
    }
}