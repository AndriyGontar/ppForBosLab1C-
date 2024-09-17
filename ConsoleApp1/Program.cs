using System;
using System.Threading;

namespace ConsoleApp1
{
    internal class Program
    {
        private static int lenArray = 5000000;
        private static int[] colsThread = new int[] { 1, 2, 3, 4, 8, 16, 32 };

        public static void Main(String[] args)
        {
            testThreads();
        }

        private static void testThreads()
        {
            ThreadSum threadSum = new ThreadSum();
            var arr = threadSum.GenerateArray(lenArray);
            var startTime = DateTime.Now;
            //long sum = arr.Sum();
            var stopTime = DateTime.Now;
            var time = stopTime- startTime;
            //Console.WriteLine("Sum array calculated by built-in function is "
            //        + sum + ". This continues " + time + " milliseconds");
            foreach (int j in colsThread)
            {
                startTime = DateTime.Now; 
                long sum = threadSum.GetSumArray(arr, j);
                stopTime = DateTime.Now;
                time = stopTime - startTime;
                Console.WriteLine("Sum with " + j + " threads is " + sum
                        + ". This continues " + time + " milliseconds");
            }
        }
    }
}
