using System;
using System.Collections.Generic;

namespace Istepaniuk.StringDistance
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            Console.WriteLine (new LevenstheinDistanceCalculator().Distance("Hello", "hello"));
        }
    }

}
