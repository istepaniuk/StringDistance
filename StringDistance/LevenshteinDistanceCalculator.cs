using System;
using System.Linq;

namespace Istepaniuk.StringDistance
{
    public class LevenshteinDistanceCalculator
    {
        public int Distance(string source, string target)
        {
            if (AnyStringIsNullOrEmpty(source, target))
                return LengthOfTheLongestString(source, target);

            var score = PrepareScoreMatrix(source, target);

            for (var i = 1; i <= source.Length; i++)
            {
                for (var j = 1; j <= target.Length; j++)
                {
                    var cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    var delete = score[i - 1, j] + 1;
                    var insert = score[i, j - 1] + 1;
                    var replace = score[i - 1, j - 1] + cost;

                    score[i, j] = Minimum(delete, insert, replace);
                }
            }

            return score[source.Length, target.Length];
        }

        private int[,] PrepareScoreMatrix(string source, string target)
        {
            var sourceLength = source.Length;
            var targetLength = target.Length;
            var score = new int[sourceLength + 1, targetLength + 1];

            for (var i = 0; i <= sourceLength; score[i, 0] = i++)
            {
            }
            for (var j = 0; j <= targetLength; score[0, j] = j++)
            {
            }

            return score;
        }

        private int Minimum(int int1, int int2, int int3)
        {
            return Math.Min(Math.Min(int1, int2), int3);
        }

        private bool AnyStringIsNullOrEmpty(string string1, string string2)
        {
            return String.IsNullOrEmpty(string1)
                || String.IsNullOrEmpty(string2);
        }

        private int LengthOfTheLongestString(params string[] strings)
        {
            return strings
                .Select(word => word ?? string.Empty)
                .Max(word => word.Length);
        }
    }
}