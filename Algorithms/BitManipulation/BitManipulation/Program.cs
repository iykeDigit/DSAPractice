using System;
using System.Numerics;

namespace BitManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            //and
            int n = 1 & 1;

            //or
            n = 1 | 0;

            //xor
            n = 0 ^ 1;

            //not(negation)
            n = ~n;

            
            Console.WriteLine();
        }

        public static uint ReverseBits(uint n)
        {
            uint result = 0;
            for(int i = 0; i < 32; i++)
            {
                uint temp = (n & 1);
                result = (result << 1) + temp;
                n >>= 1;
            }
            return result;
        }
    }
}
