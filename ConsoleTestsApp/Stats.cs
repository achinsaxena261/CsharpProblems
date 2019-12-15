using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestsApp
{
    public class Stats
    {
        // Total number of all words in the document
        public int NumberOfAllWords { get; set; }

        // Returns number of words that consist only from digits e.g. 13455, 98374
        public int NumberOfWordsThatContainOnlyDigits { get; set; }

        // Returns number of words that start with a lower letter e.g. a, d, z
        public int NumberOfWordsStartingWithSmallLetter { get; set; }

        // Returns number of words that start with a capital letter e.g. A, D, Z
        public int NumberOfWordsStartingWithCapitalLetter { get; set; }

        // Returns the first longest word in the document
        public string TheLongestWord { get; set; }

        // Returns the first shortest word in the document
        public string TheShortestWord { get; set; }

        public Stats Analyze(string document)
        {
            Stats stats = new Stats();
            try
            {
                string[] words = document.Split(' ');
                stats.NumberOfAllWords = words.Length;
                stats.NumberOfWordsThatContainOnlyDigits = 0;
                stats.NumberOfWordsStartingWithSmallLetter = 0;
                stats.NumberOfWordsStartingWithCapitalLetter = 0;
                stats.TheLongestWord = words[0];
                stats.TheShortestWord = words[0];

                foreach (string word in words)
                {
                    if (long.TryParse(word, out long num))
                    {
                        stats.NumberOfWordsThatContainOnlyDigits++;
                    }
                    else if (Char.IsLetter(word[0]))
                    {
                        if (Char.IsUpper(word[0]))
                        {
                            stats.NumberOfWordsStartingWithCapitalLetter++;
                        }
                        else
                        {
                            stats.NumberOfWordsStartingWithSmallLetter++;
                        }
                    }

                    if (stats.TheLongestWord.Length < word.Length)
                    {
                        stats.TheLongestWord = word;
                    }
                    if (stats.TheShortestWord.Length > word.Length)
                    {
                        stats.TheShortestWord = word;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return stats;
        }
    }

}
