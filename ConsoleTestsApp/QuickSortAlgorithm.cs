using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestsApp
{
    public static class QuickSortAlgorithm
    {
        public static void QuickSort(this int[] numbers)
        {
            Sort(0, numbers.Length - 1, numbers);
        }

        private static int PartitionArray(int start, int end, int[] numbers)
        {
            int pivot = numbers[end];
            int i = start - 1;
            for(int j = start; j < end; j++)
            {
                if(numbers[j] < pivot)
                {
                    i++;

                    int temp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = temp;
                }
            }
            int temp1 = numbers[end];
            numbers[end] = numbers[i+1];
            numbers[i+1] = temp1;
            return i + 1;
        }

        private static void Sort(int start, int end, int[] numbers)
        {
            if (end > start)
            {
                int pi = PartitionArray(start, end, numbers);

                Sort(start, pi - 1, numbers);
                Sort(pi + 1, end, numbers);
            }
        }
    }
}
