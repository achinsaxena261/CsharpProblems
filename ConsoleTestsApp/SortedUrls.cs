using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestsApp
{
    public class SortedUrls
    {
        public static void Test()
        {
            int N = int.Parse(Console.ReadLine());
            Website site = new Website();
            site.Urls = new string[N];
            for (int i = 0; i < N; i++)
            {
                site.Urls[i] = Console.ReadLine();
            }
            string[] arr = site.getMostVisitedPages();
            Console.WriteLine(site.sites.Keys.Count);
            Console.WriteLine(string.Join("\n", arr));
        }

        class Website
        {
            public string[] Urls { get; set; }
            public Dictionary<string, int> sites { get; set; }
            public string[] getMostVisitedPages()
            {
                sites = new Dictionary<string, int>();
                Array.Sort(Urls);
                foreach (var site in Urls)
                {
                    if (sites.ContainsKey(site))
                    {
                        sites[site] = sites[site] + 1;
                    }
                    else
                    {
                        sites.Add(site, 1);
                    }
                }
                return sites.OrderByDescending(x => x.Value).Select(x => x.Key).ToArray();
            }
        }

    }
}
