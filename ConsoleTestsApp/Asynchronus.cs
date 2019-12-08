using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestsApp
{
    public class Asynchronus
    {
        private int Items = 0;
        private async Task<int> DoWork1()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Preparing Omlettle");
                Items++;
            });
            return Items;
        }

        private async Task<int> DoWork2()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Prparing Toasts");
                Items++;
            });
            return Items;
        }

        public async void Execute()
        {
            int itemCount = await DoWork1();
            Console.WriteLine("Omlettle ready - {0}/2", itemCount);
            itemCount = await DoWork2();
            Console.WriteLine("Toasts ready - {0}/2", itemCount);
        }
    }
}
