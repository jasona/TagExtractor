using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoTagger
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = AutoTagger.ExtractTags("Now country is the time for all <b>good</b> men to come good good to the aid of their country.");

            foreach (var word in output)
            {
                Console.WriteLine(word.Key + " : " + word.Value + "\n");
            }
        }
    }
}
