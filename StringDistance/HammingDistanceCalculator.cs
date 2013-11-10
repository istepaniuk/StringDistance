using System;

namespace Istepaniuk.StringDistance
{
    public class HammingDistanceCalculator
    {
        public int Calculate(string source, string target)
        {
            if (source.Length != target.Length)
                throw new ArgumentException("Both input strings must be of the same length.");

            int distance = 0;
            for (int i = 0, length = source.Length; i < length; i++)
            {
                if (source[i] != target[i])
                    distance++;
            }

            return distance;
        }
    }
}