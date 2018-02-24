using System;
using System.Numerics;

namespace AddTheDigits
{
    class Program
    {
        static int stepsCount = 0;
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"../../Input.txt");

            if (lines.Length == 0)
            {
                Console.WriteLine("Input file is empty.\n\nPress [Enter] key to exit...");
                Console.Read();
                return;
            }

            int.TryParse(lines[0], out int numberOfInput);

            if (lines.Length < 100)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    stepsCount = 0;
                    BigInteger.TryParse(lines[i], out BigInteger input);

                    if (input <= BigInteger.Pow(10, 100))
                    {
                        DoCalculate(input);
                    }
                    else
                    {
                        Console.WriteLine("Number (N) is out of range. Input must be less then or equal 10^100.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Lines (T) must be less then 100.");
            }

            Console.WriteLine("\nPress [Enter] key to exit...");
            Console.Read();
        }

        static private void DoCalculate(BigInteger input)
        {
            BigInteger sum = DigitSum(input);
            Console.WriteLine("Number of steps required: {0}", stepsCount);
        }


        static private BigInteger DigitSum(BigInteger num)
        {
            stepsCount++;

            BigInteger sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            if (sum > 9)
            {
                sum = DigitSum(sum);
            }
            return sum;
        }
    }
}

