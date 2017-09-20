using System;
using System.Linq;

namespace ConsoleApp1
{
    public class Demineur
    {
        public static char[][] Mines { get; set; }
        private static int _height;
        private static int _width;

        public static void MyMain(string[] args)
        {
            _height = int.Parse(Console.ReadLine());
            _width = int.Parse(Console.ReadLine());
            Mines = new char[_height][];

            var mineX = 0;
            var mineY = 0;
              for (var y =  0; y < _height; y++)
            {
                var line = Console.ReadLine();
                Mines[y] = line.ToArray();
                for (var x = 0; x < _width; x++)
                {
                    if (Mines[y][x] == 'x')
                    {
                        mineX = x;
                        mineY = y;
                    }
                }
            }

            int count = Devoiler(mineX, mineY);
            Console.Write(count);
        }

        private static int Devoiler(int mineX, int mineY)
        {
            if (mineX < 0 || mineY < 0 || mineX >= _width || mineY >= _height) return 0;
            var value = Mines[mineY][mineX];
            if (value != '.' && value != 'x') return 0;
            var b = Count(mineX, mineY);
            if (b > 0)
            {
                Mines[mineY][mineX] = (char)('0' + b);
                return 1;
            }
            Mines[mineY][mineX] = '?';
            var result = 1;
            for (var i = -1; i < 2; i++)
            {
                for (var j = -1; j < 2; j++)
                {
                    if (i == 0 && j == 0) continue;
                    result += Devoiler(mineX + i, mineY + j);
                }
            }
            return result;
        }

        private static int IsMine(int mineX, int mineY)
        {
            return mineX >= 0 && mineX < _width && mineY >= 0 && mineY < _height &&
                Mines[mineY][mineX] == '*' ? 1 :0;
        }

        private static int Count(int mineX, int mineY)
        {
            var result = 0;
            for (var i = - 1; i < 2; i++)
            {
                for (var j = -1; j  < 2; j++)
                {
                    if (i == 0 && j == 0) continue;
                    result += IsMine(mineX + i, mineY + j);
                }
            }
            return result;
        }
    }
}