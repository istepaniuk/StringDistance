using System;
using System.Linq;

namespace Istepaniuk.StringDistance
{
    public class LevenshteinDistanceCalculator
    {
        public int Distance (string source, string target)
        {
            if (AnyStringIsNullOrEmpty (source, target))
                return LengthOfTheLongestString (source, target);

            var n = source.Length;
            var m = target.Length;
            var score = new int[n + 1, m + 1];

            for (var i = 0; i <= n; score[i, 0] = i++) {
            }
            for (var j = 0; j <= m; score[0, j] = j++) {
            }
            for (var i = 1; i <= n; i++) {
                for (var j = 1; j <= m; j++) {
                    var cost = (target [j - 1] == source [i - 1]) ? 0 : 1;
                    score [i, j] = Math.Min (Math.Min (score [i - 1, j] + 1, score [i, j - 1] + 1), score [i - 1, j - 1] + cost);
                }
            }

            return score [n, m];
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
    }
}