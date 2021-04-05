using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding_Challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare variables
            int[] numArray;
            int[] numArray2;
            int[] numbers;
            int[] numbers2;
            Random rng;

            // Initialize variables
            numArray = new int[] { 3, 8, 10, 1, 9, 14, -3, 0, 14, 207, 56, 98 };
            numArray2 = new int[] { 17, 42, 3, 5, 5, 5, 8, 2, 4, 6, 1, 19 };
            numbers = new int[] { 2, 2, 4, 10, 10, 10, 10, 4, 2, 2, 2, 4 };
            numbers2 = new int[] { 5, 2, 4, 4, 6, 6, 6, 7, 7, 7, 1, 2 };
            rng = new Random();

            // Run problem one
            Console.WriteLine("============Running Problem 1============");
            DiceSum(rng);

            // Run problem two
            Console.WriteLine("\n\n============Running Problem 2============");
            Console.WriteLine($"LastFirst: {LastFirst("Roger Rabbit")}");

            // Run problem three
            Console.WriteLine("\n\n============Running Problem 3============");
            if (IsPalindrome("Pop"))
            {
                Console.WriteLine("Pop is palindrome");
            }
            else
            {
                Console.WriteLine("Pop is not a palindrome");
            }

            if (IsPalindrome("snow"))
            {
                Console.WriteLine("snow is palindrome");
            }
            else
            {
                Console.WriteLine("snow is not a palindrome");
            }

            // Run problem four
            Console.WriteLine("\n\n============Running Problem 4============");
            Console.Write("The array ");
            for (int i = 0; i < numArray.Length; i++)
            {
                if (i != numArray.Length - 1)
                {
                    Console.Write(numArray[i] + ", ");
                }
                else
                {
                    Console.Write(numArray[i] + " ");
                }
            }
            Console.WriteLine($"has the longest sorted sequence of {LongestSortedSequence(numArray)}");

            Console.Write("The array ");
            for (int i = 0; i < numArray2.Length; i++)
            {
                if (i != numArray2.Length - 1)
                {
                    Console.Write(numArray2[i] + ", ");
                }
                else
                {
                    Console.Write(numArray2[i] + " ");
                }
            }
            Console.WriteLine($"has the longest sorted sequence of {LongestSortedSequence(numArray2)}");

            // Run problem five
            Console.WriteLine("\n\n============Running Problem 5============");
            Console.Write("The array ");
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i != numbers.Length - 1)
                {
                    Console.Write(numbers[i] + ", ");
                }
                else
                {
                    Console.Write(numbers[i] + " ");
                }
            }
            Console.WriteLine($"has a duplicate chain of {GetLongestDuplicate(numbers)}");

            Console.Write("The array ");
            for (int i = 0; i < numbers2.Length; i++)
            {
                if (i != numbers2.Length - 1)
                {
                    Console.Write(numbers2[i] + ", ");
                }
                else
                {
                    Console.Write(numbers2[i] + " ");
                }
            }
            Console.WriteLine($"has a duplicate chain of {GetLongestDuplicate(numbers2)}");

            // Keep the window open
            Console.WriteLine("\n\n\nPress any key to continue . . .");
            Console.ReadKey();
        }

        /// <summary>
        /// Problem #1 - Rolls two six sided die until reaching
        /// user's desired sum.
        /// </summary>
        /// <param name="rng">A random number generator.</param>
        public static void DiceSum(Random rng)
        {
            // Declare variables
            ConsoleColor inputColor;
            int desiredSum;
            int sum;
            string userInput;

            // Initialize variables
            inputColor = ConsoleColor.Blue;
            sum = -1;

            // Prompt user for desired sum
            Console.Write("Desired dice sum: ");
            Console.ForegroundColor = inputColor;
            userInput = Console.ReadLine();
            int.TryParse(userInput, out desiredSum);
            Console.ResetColor();

            // If invalid, prompt until desired sum is valid
            while (desiredSum < 2 || desiredSum > 12)
            {
                Console.Write("Invalid sum\n\nDesired dice sum: ");
                Console.ForegroundColor = inputColor;
                userInput = Console.ReadLine();
                int.TryParse(userInput, out desiredSum);
                Console.ResetColor();
            }

            // Roll dice until desired sum is achieved
            while (desiredSum != sum)
            {
                int roll1 = rng.Next(1, 7);
                int roll2 = rng.Next(1, 7);
                sum = roll1 + roll2;
                Console.WriteLine($"{roll1} and {roll2} = {sum}");
            }
        }

        /// <summary>
        /// Problem #2 - Receives a name and places their last
        /// name followed by their first initial.
        /// </summary>
        /// <param name="name">Name to put in LastFirst order.</param>
        /// <returns>Returns the person's last name followed by their first initial.</returns>
        public static string LastFirst(string name)
        {
            // Declare variables
            string lastFirst;
            string[] names;

            // Initialize variables
            lastFirst = "";
            names = name.Split(' ');

            // Check for number of names
            if (names.Length < 2 || names.Length > 2)
            {
                throw new IndexOutOfRangeException("Error: Invalid number of names entered.");
            }

            // Add last name to first spot
            lastFirst += names[1];

            // Add separating comma
            lastFirst += ", ";

            // Add first initial
            lastFirst += names[0][0];

            // Add closing period
            lastFirst += ".";

            return lastFirst;
        }

        /// <summary>
        /// Problem #3 - Checks if a word is a palindrome.
        /// </summary>
        /// <param name="word">The word to check.</param>
        /// <returns>Returns if the word is or is not a palindrome.</returns>
        public static bool IsPalindrome(string word)
        {
            // Declare variables
            string reversedWord;

            // Initialize variables
            reversedWord = "";

            // Created reversed word
            for (int i = word.Length - 1; i > -1; i--)
            {
                reversedWord += word[i].ToString();
            }

            // Check if palindrome
            return (reversedWord.ToLower() == word.ToLower());
        }

        /// <summary>
        /// Problem #4 - Checks the longest sorted sequence in an
        /// array of numbers.
        /// </summary>
        /// <param name="numArray">The array of numbers to check.</param>
        /// <returns>The longest sequence of in-order numbers in the array.</returns>
        public static int LongestSortedSequence(int[] numArray)
        {
            // Make sure the array is valid
            if (numArray.Length < 1)
            {
                return 0;
            }

            // Declare variables
            int longestSequence;
            int sequence;

            // Initialize variables
            longestSequence = 1;
            sequence = 1;

            // Loop through array to find longest sequence
            for (int i = 1; i < numArray.Length; i++)
            {
                if (numArray[i] >= numArray[i - 1])
                {
                    // Increment current sequence length
                    sequence += 1;
                }
                else
                {
                    // If the current sequence is longer than the
                    // previous longest sequence, set the new longest sequence
                    // to the current sequence length
                    if (sequence > longestSequence)
                    {
                        longestSequence = sequence;
                    }

                    // Reset current sequence length
                    sequence = 1;
                }
            }

            return longestSequence;
        }

        /// <summary>
        /// Problem #5 - Get the integer with the longest duplicate chain.
        /// </summary>
        /// <param name="numArray">The array of numbers.</param>
        /// <returns>Returns the number with the longest duplicate chain.</returns>
        public static int GetLongestDuplicate(int[] numArray)
        {
            // Make sure the array is valid
            if (numArray.Length < 1)
            {
                return 0;
            }

            // Declare variables
            int chain;
            int longestChain;
            int longestChainNumber;

            // Initialize variables
            chain = 1;
            longestChain = 1;
            longestChainNumber = -1;

            // Loop through array to find longest chain
            for (int i = 1; i < numArray.Length; i++)
            {
                if (numArray[i] == numArray[i - 1])
                {
                    // Increment current chain length
                    chain += 1;
                }
                else
                {
                    // If the current chain is longer than the
                    // previous longest chain, set the new longest chain
                    // to the current chain length
                    if (chain >= longestChain)
                    {
                        longestChain = chain;
                        longestChainNumber = numArray[i - 1];
                    }

                    // Reset current chain length
                    chain = 1;
                }
            }

            return longestChainNumber;
        }
    }
}
