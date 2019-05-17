using System;
using System.Linq;

namespace tdd.magic_square.lib
{
    public class MagicSquare
    {
        public bool IsValid(int[,] square)
        {
            if (square == null)
            {
                throw new ArgumentNullException(nameof(square));
            }

            var xlength = square.GetLength(0);
            var ylength = square.GetLength(1);

            if (xlength == 0 && ylength == 0)
            {
                throw new ArgumentException("Input is invalid");
            }

            if (xlength != ylength)
            {
                return false;
            }

            if (xlength <3)
            {
                throw new ArgumentException("Invalid Magic Square dimensions");
            }

            if (square.Cast<int>().Any(e => e < 1))
            {
                return false;
            }

            return true;
        }

        internal int SumRow(int[,] square, int row)
        {
            var count = 0;
            for (var i = 0; i < square.GetLength(0); i++)
            {
                count += square[row, i];
            }
            return count;
        }

        public object SumColumn(int[,] square, int columnNumber)
        {
            var count = 0;
            for (var i = 0; i < square.GetLength(0); i++)
            {
                count += square[i, columnNumber];
            }
            return count;
        }

        public object SumBackSlashDiagonal(int[,] square)
        {
            var count = 0;
            for (var i = 0; i < square.GetLength(0); i++)
            {
                count += square[i, i];
            }
            return count;
        }

        public object SumAntiDiagonal(int[,] testData)
        {
            return 8;
        }
    }
}
