using System;
using NUnit.Framework;
using Shouldly;
using tdd.magic_square.lib;

namespace tdd.magic_square.tests
{
    [TestFixture]
    public class MagicSquareTests
    {
        [Test]
        public void WhenInputNull_ThrowsException()
        {
            var magicSquare = new MagicSquare();

            Should.Throw<ArgumentNullException>(() => magicSquare.IsValid(null));
        }

        [Test]
        public void WhenInputEmpty_ThrowsException()
        {
            var magicSquare = new MagicSquare();

            Should.Throw<ArgumentException>(() => magicSquare.IsValid(new int[0, 0]))
                .Message.ShouldBe("Input is invalid");
        }

        [Test]
        public void WhenInputIsNotASquare_ThrowsException()
        {
            var magicSquare = new MagicSquare();

            var result = magicSquare.IsValid(new int[2, 0]);

            result.ShouldBe(false);
        }

        [TestCase(1), TestCase(2)]
        public void WhenInvalidSquareDimension_ThrowsException(int dimension)
        {
            var magicSquare = new MagicSquare();
            Should.Throw<ArgumentException>(() => magicSquare.IsValid(new int[dimension, dimension]))
                .Message.ShouldBe("Invalid Magic Square dimensions");
        }

        [Test]
        public void WhenAnyValueInSquareIsNegative_ReturnFalse()
        {
            var testData = new[,] {{0, 0, -1}, {0, -1, 0}, {-1, 0, 0}};

            var magicSquare = new MagicSquare();

            magicSquare.IsValid(testData).ShouldBe(false);
        }

        [Test]
        public void WhenAnyValueInSquareIsZero_ReturnFalse()
        {
            var testData = new[,] {{0, 0, 1}, {0, 1, 0}, {1, 0, 0}};

            var magicSquare = new MagicSquare();

            magicSquare.IsValid(testData).ShouldBe(false);
        }

        [Test]
        [TestCase(3, 4, 7)]
        [TestCase(4, 4, 4)]
        public void WhenSumRow_CalculatesFirstRowSum(int a, int b, int c)
        {
            var testData = new[,]
            {
                {a, b, c}, // 0
                {0, 1, 0}, // 1
                {1, 0, 0} // 2
            };

            var magicSquare = new MagicSquare();

            var result = magicSquare.SumRow(testData, 0);

            result.ShouldBe(a + b + c);
        }

        [Test]
        [TestCase(1)]
        public void WhenSumRow_CalculatesRowSum(int rowNumber)
        {
            var testData = new[,]
            {
                {1, 2, 4}, // 0
                {0, 1, 0}, // 1
                {1, 0, 0} // 2
            };

            var magicSquare = new MagicSquare();

            var result = magicSquare.SumRow(testData, rowNumber);

            result.ShouldBe(0 + 1 + 0);
        }

        [Test]
        [TestCase(0)]
        public void WhenColumnSum_CalculateColumnSum(int columnNumber)
        {
            var testData = new[,]
            {
                {1, 2, 4}, // 0
                {0, 1, 0}, // 1
                {1, 0, 0} // 2
            };

            var magicSquare = new MagicSquare();

            var result = magicSquare.SumColumn(testData, columnNumber);

            result.ShouldBe(1 + 0 + 1);
        }

        [Test]
        [TestCase(3, 4, 7)]
        public void WhenSumColumn_CalculatesSecondColumnSum(int a, int b, int c)
        {
            var testData = new[,]
            {
                {1, a, 0}, // 0
                {0, b, 0}, // 1
                {1, c, 0} // 2
            };

            var magicSquare = new MagicSquare();

            var result = magicSquare.SumColumn(testData, 1);

            result.ShouldBe(a + b + c);
        }

        [Test]
        [TestCase(3, 4, 7)]
        public void WhenBackSlash_SumBackslash(int a, int b, int c)
        {
            var testData = new[,]
            {
                {a, 2, 0}, // 0
                {0, b, 0}, // 1
                {1, 4, c} // 2
            };

            var magicSquare = new MagicSquare();

            var result = magicSquare.SumBackSlashDiagonal(testData);

            result.ShouldBe(a + b + c);
        }

        [Test]
        public void WhenSumRowFourDimensions_CalculatesRowSum()
        {
            var testData = new[,]
            {
                {1, 2, 4, 7}, // 0
                {0, 1, 0, 1}, // 1
                {1, 0, 0, 2}, // 2
                {1, 5, 8, 2} // 3
            };

            var magicSquare = new MagicSquare();

            var result = magicSquare.SumRow(testData, 3);

            result.ShouldBe(1 + 5 + 8 + 2);
        }

        [Test]
        public void WhenSumColumnFourDimensions_CalculatesColumnSum()
        {
            var testData = new[,]
            {
                {1, 2, 4, 7}, // 0
                {0, 1, 0, 1}, // 1
                {1, 0, 0, 2}, // 2
                {1, 5, 8, 2} // 3
            };

            var magicSquare = new MagicSquare();

            var result = magicSquare.SumColumn(testData, 0);

            result.ShouldBe(1 + 0 + 1 + 1);
        }

        [Test]
        public void WhenSumMainDiagonal_SumBackSlashDiagonal()
        {
            var testData = new[,]
            {
                {1, 2, 4, 7}, // 0
                {0, 1, 0, 1}, // 1
                {1, 0, 0, 2}, // 2
                {1, 5, 8, 2} // 3
            };

            var magicSquare = new MagicSquare();

            var result = magicSquare.SumBackSlashDiagonal(testData);

            result.ShouldBe(1 + 1 + 0 + 2);
        }

        [Test]
        public void WhenSumAntiDiagonal_SumAntiDiagonal()
        {
            var testData = new[,]
            {
                {1, 2, 4, 7}, // 0
                {0, 1, 0, 1}, // 1
                {1, 0, 0, 2}, // 2
                {1, 5, 8, 2} // 3
            };

            var magicSquare = new MagicSquare();

            var result = magicSquare.SumAntiDiagonal(testData);

            result.ShouldBe(7 + 0 + 0 + 1);
        }


        [Test]
        [TestCase(3, 4, 7, 9)]
        public void WhenSumAntiDiagonal_SumAntiDiagonalAnyValue(int a, int b, int c, int d)
        {
            var testData = new[,]
            {
                {1, 2, 4, a}, // 0
                {0, 1, b, 1}, // 1
                {1, c, 0, 2}, // 2
                {d, 5, 8, 2} // 3
            };

            var magicSquare = new MagicSquare();

            var result = magicSquare.SumAntiDiagonal(testData);

            result.ShouldBe(a + b + c + d);
        }
    }
}
