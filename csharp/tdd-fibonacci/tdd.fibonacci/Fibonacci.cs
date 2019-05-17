using System;

namespace tdd.fibonacci
{
    public static class Fibonacci
    {
        public static ulong GetFibonacci(int b)
        {
            if (b < 0 || b > 93)
            {
                throw new ArgumentException();
            }
            if (b < 2)
            {
                return (uint) b;
            }

            ulong f0 = 0;
            ulong f1 = 1;

            for (var i = 0; i < b; i++)
            {
                var temp = f1;
                f1 = f0 + f1;
                f0 = temp;
            }

            return f0;

        }
    }
}
