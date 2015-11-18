namespace DigiAeon.Core
{
    using System;

    /// <summary>
    /// The math helper.
    /// </summary>
    public static class MathHelper
    {
        /// <summary>
        /// Get the nth fibonacci number.
        /// </summary>
        /// <param name="n">
        /// The n.
        /// </param>
        /// <returns>
        /// The <see cref="long"/>.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// n less than -92 or greater than 92 will cause a 64-bit integer overflow.
        /// </exception>
        /// <!--
        /// https://en.wikipedia.org/wiki/Generalizations_of_Fibonacci_numbers#Extension_to_negative_integers
        /// -->
        public static long GetNthFibonacciNumber(this long n)
        {
            if (n < -92)
            {
                throw new ArgumentOutOfRangeException("n", "Fib(<92) will cause a 64-bit integer overflow.");
            }

            if (n > 92)
            {
                throw new ArgumentOutOfRangeException("n", "Fib(>92) will cause a 64-bit integer overflow.");
            }

            var absN = Math.Abs(n);
            var result = absN.GetNthNonNegativeFibonacciNumber();

            return n < 0 && absN % 2 == 0 ? -result : result;
        }

        /// <summary>
        /// The get nth non negative fibonacci number.
        /// </summary>
        /// <param name="n">
        /// The n.
        /// </param>
        /// <returns>
        /// The <see cref="long"/>.
        /// </returns>
        private static long GetNthNonNegativeFibonacciNumber(this long n)
        {
            if (n < 0)
            {
                throw new ArgumentException("n must not be negative.");
            }

            if (n == 0)
            {
                return 0;
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            // fn = f(n-2) + f(n-1)
            long fibNMinus2 = 1; // f(1)
            long fibNMinus1 = 1; // f(2)
            long fibN = 0; // f(n)

            // Start the iteration from f(3)
            for (long i = 3; i <= n; i++)
            {
                fibN = fibNMinus2 + fibNMinus1;
                fibNMinus2 = fibNMinus1;
                fibNMinus1 = fibN;
            }

            return fibN;
        }
    }
}
