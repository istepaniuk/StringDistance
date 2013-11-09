using System;
using System.Linq;
using System.Collections.Generic;

namespace Istepaniuk.StringDistance
{
    public class DamerauLevenshteinDistanceCalculator
    {
        public int Distance (string source, string target)
        {
            if (AnyStringIsNullOrEmpty (source, target))
                return LengthOfTheLongestString (source, target);

            var score = PrepareScoreMatrix (source, target);
            var sd = GetSortedDictionaryWithAllLettersFrom (source, target);

            for (var i = 1; i <= source.Length; i++) {
                var DB = 0;
                for (var j = 1; j <= target.Length; j++) {
                    var i1 = sd [target [j - 1]];
                    var j1 = DB;

                    if (source [i - 1] == target [j - 1]) {
                        score [i + 1, j + 1] = score [i, j];
                        DB = j;
                    } else {
                        score [i + 1, j + 1] = Math.Min (score [i, j], Math.Min (score [i + 1, j], score [i, j + 1])) + 1;
                    }

                    score [i + 1, j + 1] = Math.Min (score [i + 1, j + 1], score [i1, j1] + (i - i1 - 1) + 1 + (j - j1 - 1));
                }

                sd [source [i - 1]] = i;
            }

            return score [source.Length + 1, target.Length + 1];
        }

        private int[,] PrepareScoreMatrix (string source, string  target)
        {
            var score = new int[source.Length + 2, target.Length + 2];

            var INF = source.Length + target.Length;
            score [0, 0] = INF;
            for (var i = 0; i <= source.Length; i++) {
                score [i + 1, 1] = i;
                score [i + 1, 0] = INF;
            }
            for (var j = 0; j <= target.Length; j++) {
                score [1, j + 1] = j;
                score [0, j + 1] = INF;
            }

            return score;
        }

        private bool AnyStringIsNullOrEmpty (string string1, string string2)
        {
            return String.IsNullOrEmpty (string1)
                || String.IsNullOrEmpty (string2);
        }

        private int LengthOfTheLongestString (params string[] strings)
        {
            return strings
                .Select (word => word ?? string.Empty)
                .Max (word => word.Length);
        }

        private  SortedDictionary<char, int> GetSortedDictionaryWithAllLettersFrom (params string[] words)
        {
            var letterDictionary = words
                .SelectMany (letter => letter)
                .Distinct ()
                .ToDictionary (key => key, value => 0);

            return new SortedDictionary<char, int> (letterDictionary);
        }
    }
}

