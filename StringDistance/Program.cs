using System;
using Istepaniuk.StringDistance;

namespace Istepaniuk.StringDistance.ConsoleStringDistance
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: string1 string2");
                return;
            }
               
            var calculator = new DamerauLevenshteinDistanceCalculator();
            Console.WriteLine (calculator.Distance(args[0], args[1]));
        }
    }

}
