using System;
using System.Collections.Generic;

namespace KnuthMorrisPratt
{
    class Program
    {
        // RUNNING TIME: O(n + m^2)
        // n = the length of the constitution
        // m = the length of the pattern
        static void Main(string[] args)
        {
            // output list to hold the starting indices created
            List<int> output = new List<int>();

            // initial text string to hold the constitution string
            string text = "";
            char[] letters;
            // foreach() loop reads in the characters from the constitution and adds them to text, line by line and char by char
            foreach (string line in System.IO.File.ReadLines("constitution.txt"))
            {
                letters = line.ToLower().ToCharArray();
                foreach (char letter in letters)
                {
                    text += letter;
                }
            }

            // while loop ensure pattern length is greater than 0
            string pattern;
            while (true)
            {
                // prompts the user to input a pattern
                Console.WriteLine("\nPlease input a pattern: ");
                pattern = Console.ReadLine().ToLower();

                if (pattern.Length > 0) break;
            }

            // a zArray variable is created to hold the zArray for the pattern
            int[] zArray = new int[pattern.Length];
            // the following nested loops run in O(n^2) time, with n being the length of the pattern
            // this is essentially a brute force method since the pattern should never be very long
            int shift = 0;
            for (int i = 0; i < pattern.Length; i++)
            {
                zArray[i] = shift = 0;
                while (i + shift < pattern.Length && pattern[i + shift] == pattern[shift])
                {
                    zArray[i]++;
                    shift++;
                }
            }
            // the first value in the array is set to 0, as per the definition of a z array
            zArray[0] = 0;

            // pattern is padded on the left with a zero in order to increase its size by 1
            pattern = pattern.PadLeft(pattern.Length + 1);
            // integers a & b are used to iterate through the text as well as the pattern/zArray respectively & simultaneously
            int a, b;
            for (a = b = 0; a < text.Length;)
            {
                // the value at text[a] is compared to the next value in pattern, and if they are the same then a and b are incremented
                if (text[a] == pattern[b+1])
                {
                    a++;
                    b++;
                    // if b is equal to the actual length of the pattern (diregarding the padding), then the a value is added to the output
                    if (b == pattern.Length - 1)
                    {
                        // if statement ensures that the characters before and after the word are not letters
                        if (((a -pattern.Length <= 0) || !Char.IsLetter(text[a-pattern.Length])) && !Char.IsLetter(text[a]))
                            output.Add(a - pattern.Length + 1);
                        // b is reset to 0
                        b = 0;
                    }
                }
                // if b is equal to zero, then b is pointing to the padded 0 in the zArray, so a is incremented & b remains 0
                else if (b == 0)
                {
                    a++;
                }
                // if b is not zero, then the zArray is used to set b equal to the zArray value for that b value, which is zArray[b-1] since
                // the index systems for zArray and pattern are off by one
                else
                {
                    b = zArray[b-1];
                }
            }

            // at this point, output will contain the beginning index for all instances of the pattern in the text
            Console.WriteLine("\nPattern has " + output.Count + " instances: ");
            // for each loop is used to generate an output string and then print
            foreach (int element in output)
            {
                string str = "   Index " + element + " -> ";
                // context is provided for each instance of the pattern in the text
                for (int i = element - 30; i < element + 30 + pattern.Length && i < text.Length; i++)
                {
                    if (i < 0) continue;
                    str += text[i];
                }
                Console.WriteLine(str);
            }
            Console.WriteLine("\nTotal instances found: " + output.Count + "\n");

            // user is prompted to run the program again
            Console.WriteLine("\nWould you like to run the program again? (y/n)");
            try
            {
                // user input read from the console
                char toggle = Char.Parse(Console.ReadLine());
                // input must be 'y' or 'Y' to run again
                if (toggle == 'y' || toggle == 'Y')
                {
                    Console.WriteLine();
                    Main(args);
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}
