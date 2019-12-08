using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestsApp
{
    class ArraySubsets
    {
        public int[] Numbers { get; set; }
        public void AddNumbers()
        {
            Console.Write("Enter Size: ");
            int N = int.Parse(Console.ReadLine());
            Numbers = new int[N];
            for (int i = 0; i < N; i++)
            {
                Console.Write("\nEnter value of {0}: ", i);
                Numbers[i] = int.Parse(Console.ReadLine());
            }
        }

        public void PrintSubsets()
        {
            for (int i = 0; i < (1<<Numbers.Length); i++)
            {
                for (int j = 0; j < Numbers.Length; j++)
                {
                    if ((i & (1 << j)) > 0)
                        Console.Write("{0}", Numbers[j]);
                }
                Console.Write("\n");
            }
        }
    }
}
