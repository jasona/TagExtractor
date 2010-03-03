using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AutoTagger
{
    public class AutoTagger
    {
        private static readonly List<string> NOISE_WORDS = new List<string>() 
        { 
            "all", "another", "any", "anbody", "anyone", "anything", "both",
            "each", "each other", "either", "everybody", "everyone", "everything",
            "few", "he", "her", "hers", "herself", "him", "himself", "his", "i",
            "it", "its", "itself", "little", "many", "me", "mine", "more", "most", 
            "much", "myself", "neither", "no one", "nobody", "none", "nothing",
            "one", "one another", "other", "others", "ours", "ourselves", "several",
            "she", "some", "somebody", "someone", "something", "that", "theirs", "them",
            "themselves", "these", "they", "this", "those", "us", "we", "what", 
            "whatever", "which", "whichever", "who", "whoever", "whom", "whomever",
            "you", "yours", "yourself", "yourselves", "about", "after", "all", "also", 
            "an", "and", "another", "any", "are", "as", "at", "be", "because", "been", 
            "before", "being", "between", "both", "but", "by", "came", "can", "come", 
            "could", "did", "do", "each", "for", "from", "get", "got", "has", "had", 
            "he", "have", "her", "here", "him", "himself", "his", "how", "if", "in", 
            "into", "is", "it", "like", "make", "many", "me", "might", "more", "most", 
            "much", "must", "my", "never", "now", "of", "on", "only", "or", "other",
            "our", "out", "over", "said", "same", "see", "should", "since", "some", 
            "still", "such", "take", "than", "that", "the", "their", "them", "then", 
            "there", "these", "they", "this", "those", "through", "to", "too", "under", "up",
            "very", "was", "way", "we", "well", "were", "what", "where", "which", "while", 
            "who", "with", "would", "you", "your", "a", "b", "c", "d", "e", "f", "g", "h", 
            "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", 
            "y", "z", "$", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", ""
        };

        private static string StripHTML(string inputString)
        {
            return Regex.Replace
              (inputString, "<.*?>", string.Empty);
        }

        private static string ScrubInput(string inputString)
        {
            return StripHTML(inputString)
                .Replace('.', ' ')
                .Replace(',', ' ')
                .ToLower()
                .Trim();
        }

        public static Dictionary<string, int> ExtractTags(string inputString)
        {
            var output = new Dictionary<string, int>();

            inputString = ScrubInput(inputString);
            
            foreach (string word in inputString.Split(' '))
            {
                if (NOISE_WORDS.Contains(word)) continue;

                if (output.Keys.Contains(word))
                    output[word]++;
                else
                    output[word] = 1;
            }

            output = output.OrderByDescending(d => d.Value).ToDictionary(k => k.Key, v => v.Value);
            return output;
        }

    }
}
