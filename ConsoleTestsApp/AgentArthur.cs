using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestsApp
{
    public class AgentArthur
    {
        private string[,] Grid { get; set; }
        private int N { get; set; }
        private List<int> Sums = new List<int>(); 

        public void CreateGrid()
        {
            Console.Write("Enter dimension of grid: ");
            N = int.Parse(Console.ReadLine());
            Console.WriteLine("Generating grid of {0}x{1}", N, N);
            Grid = new string[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i == 0 && j == 0)
                        Grid[i, j] = "e";
                    else if (i == N - 1 && j == N - 1)
                        Grid[i, j] = "s";
                    else
                    {
                        Console.Write("Enter number or 'x' for  ({0},{1}): ", i, j);
                        Grid[i, j] = Console.ReadLine();
                    }
                }
            }
            PrintGrid();
            Console.WriteLine();
            TracePath(0, 0, 0, new string[N + N - 1]);
            Console.WriteLine("\nHighest sum path concluded: {0}", MaxValue());
        } 

        private void PrintGrid()
        {
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < N; j++)
                {
                    Console.Write(" " + Grid[i, j]);
                }
            }
            Console.WriteLine();
        }

        private void TracePath(int i, int j, int k, string[] path)
        {
            path[k] = Grid[i, j];
            if (i == N - 1)
            {
                for(int a = j+1; a <= N - 1; a++)
                {
                    path[k + a - j] = Grid[i, a];
                }
                foreach(var item in path)
                {
                    Console.Write("{0} ", item);
                }
                SumPath(path);
                Console.WriteLine();
                return;
            }
            if(j == N - 1)
            {
                for (int a = i+1; a <= N - 1; a++)
                {
                    path[k + a - i] = Grid[a, j];
                }
                foreach (var item in path)
                {
                    Console.Write("{0} ", item);
                }
                SumPath(path);
                Console.WriteLine();
                return;
            }
            TracePath(i + 1, j, k + 1, path);
            TracePath(i, j + 1, k + 1, path);
        }

        private void SumPath(string[] array)
        {
            if (!array.Contains("x"))
            {
                int sum = 0;
                for(int x = 1; x < array.Length-1; x++)
                {
                    if(int.TryParse(array[x], out int value))
                        sum += value;
                }
                Sums.Add(sum);
            }
            else
            {
                Sums.Add(0);
            }
        }

        private int MaxValue()
        {
            int max = Sums[0];
            for(int i = 1; i < Sums.Count; i++)
            {
                if (Sums[i] > max)
                    max = Sums[i];
            }
            return max;
        }
    }
}
