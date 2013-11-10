#String Distance

These are C# implementations of the different 'edit distance' or fuzzy string comparision algorithms.

## Levenshtein Distance
The Levenshtein distance between two words is the minimum number of single-character edits (insertion, deletion, substitution) required to change one word into the other. The phrase edit distance is often used to refer specifically to Levenshtein distance. It is named after Vladimir Levenshtein, who considered this distance in 1965.

    var calc = new LevenshteinDistanceCalculator();
    var distance = calc.Distance("Hello, world!" "Hello, Arnold!"); // 4
        
`distance` is 4:
- 1 Deletion (`r`)
- 1 Substitution (`w` -> `n`)
- 2 Addition (`A`, `r`)

## Damerau-Levenshtein Distance
The Damerau–Levenshtein distance (named after Frederick J. Damerau and Vladimir I. Levenshtein) is a "distance" (string metric) between two strings, i.e., finite sequence of symbols, given by counting the minimum number of operations needed to transform one string into the other, where an operation is defined as an insertion, deletion, or substitution of a single character, or a transposition of two adjacent characters.

    var calc = new DamerauLevenshteinDistanceCalculator();
    var distance = calc.Distance("Hello, world!" "Hello, Arnold!"); // 3
        
`distance` is 3:
- 1 Substitution (`w` -> `A`)
- 1 Transposition (`or` -> `ro`)
- 1 Addition (`n`)


## Hamming Distance
The Hamming distance between two strings of equal length is the number of positions at which the corresponding symbols are different. In another way, it measures the minimum number of substitutions required to change one string into the other, or the minimum number of errors that could have transformed one string into the other.

    var calc = new HammingDistanceCalculator();
    var distance = calc.Distance("Hello, world!" "Adios, world!"); // 4
        
`distance` is 4:
- 4 Differences/Substitutions (`Hello` -> `Adios`)
