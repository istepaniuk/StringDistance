using System;
using System.Collections.Generic;

namespace Istepaniuk.StringDistance
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: string1 string2");
                return;
            };
               
            var calculator = new DamerauLevenstheinDistanceCalculator();
            Console.WriteLine (calculator.Distance(args[0], args[1]));
        }
    }

}
