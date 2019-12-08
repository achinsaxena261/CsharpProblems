using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTestsApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            //CardGame cardGame = new CardGame();
            //cardGame.CreateDeck();
            //cardGame.ShuffleCards();
            //cardGame.PrintDeck();
            //cardGame.ResetDeck();
            //cardGame.PrintDeck();
            ArraySubsets asb = new ArraySubsets();
            asb.AddNumbers();
            asb.PrintSubsets();
            Console.Read();
        }
    }
}
