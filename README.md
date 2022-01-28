# knuth-morris-pratt-algorithm
I would suggest using the Visual Studio Community 2019 IDE to open and run the project using the .sln file or the .csproj file.

Detailed explanation of the Knuth Morris Pratt Algorithm: https://youtu.be/V5-7GzOfADQ

The Knuth-Morris-Pratt (KMP) Algorithm is used to find instances of a pattern in a string of text. The algorithm uses a z-array for the pattern in addition to incrementor variables for both the piece of text (a) and the pattern/z-array (b). The value at text[a] is compared to pattern[b+1]. If they are equal, both values a and b are incremented and compared again. If they are not, b is set equal to the value in the z-array for location b. However, if b is equal to zero, it has nowhere to go, so a is incremented instead, and another comparison is performed. By utilizing this technique, at any given time the value of b will tell how many letters are currently matched.

In this implementation of the KMP Algorithm, the pattern's z-array is found using brute-force in order to simplify the code. This technically causes the algorithm to perform is O(m + n^2) time with m being the length of the text and n being the length of the pattern. However, the quadratic nature of this is not important since pattern should always be relatively small, expecially compared to the text, which by definition has to be bigger than the pattern. Therefore, this implementation runs in O(m + n^2) expected time, but with a piece of text like the U.S. Constitution and a pattern like a 5-letter word, the program would run in time very close to linearly.
