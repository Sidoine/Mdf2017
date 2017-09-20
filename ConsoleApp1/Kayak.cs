using System;
using System.Linq;

namespace ConsoleApp1
{
    public class Kayak
    {
        private static int _height;
        private static int _width;

        public static char[][] Cases { get; set; }
        public static int[][] Value { get; set; }

        public static void MyMain(string[] args)
        {

            _height = int.Parse(Console.ReadLine());
            _width = _height;
            Cases = new char[_height][];
            Value = new int[_height][];

            for (var y =  0; y < _height; y++)
            {
                var line = Console.ReadLine();
                Cases[y] = line.ToArray();
                Value[y] = new int[_width];
            }
            
            for (var y = 0; y < _height; y++)
            {
                for (var x = 0; x < _width; x++)
                {
                    Paint(x, y);
                }
            }
            Console.Write(GetValue(_width- 1, _height-1));
        }

        private static void Paint(int x, int y)
        {
            var v = Math.Max(GetValue(x - 1, y), GetValue(x, y - 1));
            if (IsPorte(x, y))
            {
                v++;
            }
            Value[y][x] = v;
        }

        private static int GetValue(int x, int y)
        {
            if (x < 0 || y < 0 || x >= _width || y >= _height) return 0;
            return Value[y][x];
        }
        
        private static bool IsPorte(int x, int y)
        {
            return x >= 0 && x < _width && y >= 0 && y < _height &&
                   Cases[y][x] == 'X';
        }
    }
}