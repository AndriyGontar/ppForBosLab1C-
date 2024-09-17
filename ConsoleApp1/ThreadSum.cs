using System;
using System.Threading;

namespace ConsoleApp1
{
    internal class ThreadSum
    {
        private long sum;
        private readonly Object sumLock = new();
        private int collEndThreads=0;
        public ThreadSum()
        {
        }

        public int[] GenerateArray(int lenArray)
        {
            Random random = new Random();
            int[] array = new int[lenArray];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next();
            }
            return array;
        }

        private void AddSum(long sumElement)
        {
            lock (sumLock)
            {
                sum += sumElement;
                collEndThreads++;
            }

        }

        private void SumElement(int start, int stop, int[] array)
        {
            long sumElementAraay = 0;
            for (int i = start; i < stop; i++)
            {
                sumElementAraay += array[i];
            }
            AddSum(sumElementAraay);
        }

        public long GetSumArray(int[] array, int colThread)
        {
            collEndThreads = 0;
            sum = 0;
            int len = array.Length / colThread;
            for (int i = 0; i < colThread; i++)
            {
                int start = len * i;
                int stop = i != (colThread - 1) ? len * (i + 1) : array.Length;
                Thread thread = new Thread(() => SumElement(start, stop, array));
                thread.Start();
            }
            while (collEndThreads < colThread)
            {
            }
            return sum;
        }
    }
}
