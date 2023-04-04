using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line;
            string inputFile = "C:\\Users\\Yardeus\\Desktop\\book.txt";
            string outputFile = "C:\\Users\\Yardeus\\Desktop\\result.txt";
            char[] chars = { ' ', '.', ',', ';', ':', '?', '\n', '\r', '(', ')', '!', '[', ']', '{', '}', '«', '»', '-', '—' };
            Dictionary<string, int> wordCount = new Dictionary<string, int >(StringComparer.OrdinalIgnoreCase);
            using (StreamReader reader = new StreamReader(inputFile))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(chars, StringSplitOptions.RemoveEmptyEntries);
                    
                    foreach (string word in words)
                    {
                        if (wordCount.ContainsKey(word))
                        {
                            wordCount[word]++;
                        }
                        else { wordCount.Add(word, 1); }
                    }
                }
            }

                
            var sortedWordCount = wordCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                foreach (var word in sortedWordCount)
                {
                    writer.WriteLine($"{word.Key, -20}  {word.Value,10}");
                }
                
            }


            
        }
    }
}
