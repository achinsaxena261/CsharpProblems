using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestsApp
{
    public static class MergeSortAlgorithm
    {
        public static void MergeSort(this int[] numbers)
        {
            DivideArray(0, numbers.Length - 1, numbers);
        }

        private static void DivideArray(int min, int max, int[] numbers)
        {
            if (min < max)
            {
                int mid = (min + max) / 2;
                DivideArray(min, mid, numbers);
                DivideArray(mid + 1, max, numbers);
                SortArray(min, mid, max, numbers);
            }
        }

        private static void SortArray(int min, int mid, int max, int[] numbers)
        {
            List<int> LeftArray = new List<int>();
            List<int> RightArray = new List<int>();

            for (int i = min; i <= mid; i++)
            {
                LeftArray.Add(numbers[i]);
            }

            for (int i = mid + 1; i <= max; i++)
            {
                RightArray.Add(numbers[i]);
            }
            int n1 = 0, n2 = 0, counter = min;
            while (n1 < LeftArray.Count && n2 < RightArray.Count)
            {
                if (LeftArray[n1] <= RightArray[n2])
                    numbers[counter++] = LeftArray[n1++];
                else
                    numbers[counter++] = RightArray[n2++];
            }

            while (n1 < LeftArray.Count)
            {
                numbers[counter++] = LeftArray[n1++];
            }
            while (n1 < RightArray.Count)
            {
                numbers[counter++] = RightArray[n1++];
            }
        }
    }
}
