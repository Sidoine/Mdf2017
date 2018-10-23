using System;
using System.Linq;

namespace ConsoleApp1
{
    public static class Libs
    {
        public abstract class Matrix<T>
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public T[][] Values { get; set; }

            public void ReadSize()
            {
                Width = int.Parse(Console.ReadLine());
                Height = int.Parse(Console.ReadLine());
            }

            public void ReadSquareSize()
            {
                Width = int.Parse(Console.ReadLine());
                Height = Width;
            }

            public void SetSize(int width, int height)
            {
                Width = width;
                Height = height;
            }

            public void Empty()
            {
                Values = new T[Height][];
                for (var i = 0; i < Height; i++)
                {
                    Values[i] = new T[Width];
                }
            }

            public void ReadValues()
            {
                Values = new T[Height][];
                for (var i = 0; i < Height; i++)
                {
                    Values[i] = Read(Console.ReadLine().TrimEnd());
                }
            }

            public abstract T[] Read(string s);


            public T Get(int x, int y)
            {
                if (x < 0 || y < 0 || x >= Width || y >= Height) return default(T);
                return Values[y][x];
            }

            public void Set(int x, int y, T value)
            {
                if (x < 0 || y < 0 || x >= Width || y >= Height) return;
                Values[y][x] = value;
            }
        }

        public class IntMatrix : Matrix<int>
        {
            public override int[] Read(string s)
            {
                return s.Split(' ').Select(int.Parse).ToArray();
            }
        }

        public class CharMatrix : Matrix<char>
        {
            public override char[] Read(string s)
            {
                return s.ToCharArray();
            }
        }
    }
}
