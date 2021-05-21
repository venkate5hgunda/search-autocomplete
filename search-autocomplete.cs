using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        public static SearchTrie searchTrie { get; set; }
        public static void Main(string[] args)
        {
            searchTrie = new SearchTrie {Char = ' '}; // assuming we have only abc
            List<string> insertions = new List<string>{"the", "a", "aba", "abc", "restrict", "hi", "hello" };
            foreach (var insertion in insertions)
            {
                Insert(insertion);
            }
            List<string> findMatches = new List<string> {"t","a","resto","b", ""};
            foreach (var word in findMatches)
            {
                Console.Write($"Suggestions for {word} are: ");
                Search(word).ForEach(x => Console.Write(" " + x + " "));
                Console.WriteLine(" ");
            }
        }

        public static void Insert(string subject)
        {
            SearchTrie tempTrie = searchTrie;
            for (int i = 0; i < subject.Length; i++)
            {
                tempTrie.NextChar[subject[i] - 'a'] = tempTrie.NextChar[subject[i] - 'a'] ?? new SearchTrie(subject[i]);
                tempTrie = tempTrie.NextChar[subject[i] - 'a'];
            }
            tempTrie.WordEnd = true;
        }

        public static List<string> Search(string subject)
        {
            SearchTrie tempTrie = searchTrie;
            List<string> suggestions = new List<string>();
            for (int i = 0; i < subject.Length; i++)
            {
                if (tempTrie.NextChar[subject[i] - 'a']==null) return suggestions;
                tempTrie = tempTrie.NextChar[subject[i] - 'a'];
            }
            GetWords(tempTrie,string.Empty,suggestions);
            return suggestions;
        }

        public static void GetWords(SearchTrie matchedTrie, string matchedString, List<string> matches)
        {
            if (matchedTrie == null) return;
            if(matchedTrie.WordEnd) matches.Add(matchedString + matchedTrie.Char);
            for (int i = 0; i < 26; i++)
            {
                GetWords(matchedTrie.NextChar[i],matchedString+matchedTrie.Char,matches);
            }
        }

        public class SearchTrie
        {
            public SearchTrie()
            {
                NextChar = new SearchTrie[26];
            }
            public SearchTrie(char consChar)
            {
                NextChar = new SearchTrie[26];
                Char = consChar;
            }
            public char Char { get; set; }
            public bool WordEnd { get; set; }
            public SearchTrie[] NextChar { get; set; }
        }
    }
}
