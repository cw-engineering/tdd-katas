using System;
using System.Linq;
using tdd.magic_square.lib;

namespace tdd.magic_square.app
{
    internal static class Program
    {

        static void Main(string[] args)
        {
            var numbers = args?.Select(arg =>
            {
                if (!int.TryParse(arg, out var result))
                {
                    return -1;
                }
                return result;
            }).ToArray() ?? new int[0];
            var size = (int)Math.Sqrt(numbers.Length);
            var square = new int[size, size];
            for (var i = 0; i < numbers.Length; i++)
            {
                var x = i % size;
                var y = i / size;
                square[y, x] = numbers[i];
            }

            RenderSquare(square);

            var magicSquare = new MagicSquare();

            try
            {
                var isValid = magicSquare.IsValid(square);
                if (isValid)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Input is valid magic square.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input is not valid magic square.");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Error.WriteLine("Unable to process input data.");
                Console.Error.WriteLine(ex.Message);
            }

            Console.WriteLine();
        }

        static void RenderSquare(int[,] arranged)
        {
            var flat = arranged.Cast<int>().ToArray();
            var pad = flat.Max().ToString().Length;
            var xMax = arranged.GetLength(0);
            var yMax = arranged.GetLength(1);

            Console.WriteLine();
            for (var y = 0; y < yMax; y++)
            {
                Console.Write(" ");

                for (var x = 0; x < xMax; x++)
                {
                    var n = arranged[y, x].ToString().PadRight(pad);
                    Console.Write(n);
                    Console.Write(" ");
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
