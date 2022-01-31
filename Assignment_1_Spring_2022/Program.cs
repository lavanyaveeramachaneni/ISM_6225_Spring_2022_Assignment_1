using System;
using System.Collections.Generic;
using System.Linq;

namespace DIS_Assignmnet1_SPRING_2022
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1: Enter the string:");
            string s = Console.ReadLine();
            string final_string = RemoveVowels(s);
            Console.WriteLine("Final string after removing the Vowels: {0}",final_string);
            Console.WriteLine();

            //Question 2:
            string[] bulls_string1 = new string[]{"Marshall", "Student","Center"};
            string[] bulls_string2 = new string[]{"MarshallStudent", "Center"};
            bool flag = ArrayStringsAreEqual(bulls_string1, bulls_string2);
            Console.WriteLine("Q2");
            if (flag)
            {
                Console.WriteLine("Yes, Both the array’s represent the same string");
            }
            else
            {
                Console.WriteLine("No, Both the array’s don’t represent the same string ");
            }
            Console.WriteLine();

            //Question 3:
            int[] bull_bucks = new int[] { 1, 2, 3, 2 };
            int unique_sum = SumOfUnique(bull_bucks);
            Console.WriteLine("Q3:");
            Console.WriteLine("Sum of Unique Elements in the array are :{0}", unique_sum);
            Console.WriteLine();


            //Question 4:
            int[,] bulls_grid = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Console.WriteLine("Q4:");
            int diagSum = DiagonalSum(bulls_grid);
            Console.WriteLine("The sum of diagonal elements in the bulls grid is {0}:", diagSum);
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            String bulls_string = "aiohn";
            int[] indices = { 3, 1, 4, 2, 0 };
            String rotated_string = RestoreString(bulls_string, indices);
            Console.WriteLine("The  Final string after rotation is {0} ", rotated_string);
            Console.WriteLine();

            //Quesiton 6:
            string bulls_string6 = "mumacollegeofbusiness";
            char ch ='c';
            string reversed_string = ReversePrefix(bulls_string6, ch);
            Console.WriteLine("Q6:");
            Console.WriteLine("Resultant string are reversing the prefix:{0}", reversed_string);
            Console.WriteLine();

        }

        /*Timespent = 25min, learned differnet list operations avaiualble
         * https://www.tutorialsteacher.com/csharp/csharp-list 
         https://csharp.net-tutorials.com/collections/lists/ */
        private static string RemoveVowels(string s)
        {
            if (s.Length > 0 & s.Length < 10000)//given string length should be >0
            {
                try
                {
                    String final_string = "";
                    //Character list of vowels
                    var vowels = new List<char>() { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };
                    //Iterating over the given string and checking if it has any vowels, if character is not vowel adding to the final_string 
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (!vowels.Contains(s[i]))
                            final_string = final_string + s[i];
                    }//end of for loop
                    return final_string;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                    throw;
                }
            }
            else//if string is not in the given length, we are pritnting messgae in console and returning input string
            {
                Console.WriteLine("Input string is not in the expected range of length");
                return s;
            }
        }


        /*Timespent =30min, Learned more about different string operations
         * https://www.completecsharptutorial.com/csharp-articles/csharp-string-function.php
         */
        private static bool ArrayStringsAreEqual(string[] bulls_string1, string[] bulls_string2)
        {
            try
            {
                string finalstring1 = string.Empty;
                string finalstring2 = string.Empty;
                //Adding 2 string arrays to 2 stirng varaibles i.e finalstring1,finalstring2
                for (int i = 0; i < bulls_string1.Length; i++)
                    finalstring1 = finalstring1 + bulls_string1[i];
                for (int i = 0; i < bulls_string2.Length; i++)
                    finalstring2 = finalstring2 + bulls_string2[i];
                //Comparing lengths of 2 strings and checking strings are equal or not with Equal function and returning True,if condition true else retruning False
                if (finalstring1.Length.Equals(finalstring2.Length) && string.Equals(finalstring1, finalstring2))
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                throw;
            }
        }


        /*Timespent =40min, learned about different list operations available
         * https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-6.0
         */
        private static int SumOfUnique(int[] bull_bucks)
        {
            try
            {
                List<int> input1 = new List<int>(bull_bucks);
                List<int> input2 = new List<int>();
                List<int> input3 = new List<int>();
                int sum = 0;
                if (input1.Count > 0 && input1.Count < 100)
                {
                    //Adding unique elements to input2 list and repeated elements(repeated from 2nd time) to input3 list
                    foreach (int ch in input1)
                    {
                        if (!input2.Contains(ch))
                            input2.Add(ch);
                        else
                            input3.Add(ch);
                    }
                    //removing repated element from input2 list
                    List<int> nonRepeatedElements = input2.Except(input3).ToList();
                    //Adding sum of unique elements sum if they are any and returning sum, else returning 0
                    if (nonRepeatedElements.Count >= 1)
                    {
                        foreach (int ch in nonRepeatedElements)
                            sum = sum + ch;
                    }
                }//if ends here              
                return sum;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                throw;
            }
        }

        /*TimeSpent = 60min, learned about square arrays,
         * https://www.geeksforgeeks.org/how-to-find-the-length-of-an-array-in-c-sharp/
         */
        private static int DiagonalSum(int[,] bulls_grid)
        {
            try
            {
                int arraySize = 0, sum = 0;
                //finding the dimension of an input array
                for (int i = bulls_grid.Length / 2; i > 0; i--)
                {
                    if (i * i == bulls_grid.Length)
                    {
                        arraySize = i;
                        break;
                    }
                }//for loop ends here
                //Iterating on array and adding diagonal elements and returning sum
                for (int i = 0; i < arraySize; i++)
                {
                    for (int j = 0; j < arraySize; j++)
                    {
                        if ((i == j) || ((i + j) == (arraySize - 1)))
                            sum += bulls_grid[i, j];
                    }
                }
                return sum;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.Message.ToString());
                throw;
            }
        }



        /* TimeSpent = 80Min, Learned more about Linq quiries, 
         * https://www.tutorialsteacher.com/linq/linq-sorting-operators-orderby-orderbydescending, 
         * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/sorting-data */

        private static string RestoreString(string bulls_string, int[] indices)
        {

            try
            {
                string restoreString = string.Empty;
                //checking both given inpjut string and indices lengths are same not and input string length should be 
                if (bulls_string.Length == indices.Length && indices.Length <= 100)
                {
                    Dictionary<int, char> replaceString = new Dictionary<int, char>();
                    char[] inputCharArray = bulls_string.ToCharArray();
                    //Manipulating the given input as per the indices
                    for (int i = 0; i < inputCharArray.Length; i++)
                        replaceString.Add(indices[i], inputCharArray[i]);
                    //sorting the manipulated string in ascending oredr with Linq Query
                    var outputChar = from entry in replaceString orderby entry.Key ascending select entry.Value;
                    //Adding each charcater to the string
                    foreach (var ch in outputChar)
                        restoreString += ch.ToString();
                }//if ends here
                return restoreString;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                throw;
            }
        }


        /* Timespent =25min, learned different operations */

        private static string ReversePrefix(string bulls_string6, char ch)
        {
            try
            {
                String prefix_string = "";
                char charToFind = char.ToLower(ch);
                //Checking given character is available in string or not and input string length should be 250
                if (bulls_string6.ToLower().Contains(charToFind) && bulls_string6.Length <= 250)
                {
                    //storing the index of given character
                    int specifiedCharIndex = bulls_string6.IndexOf(charToFind);
                    //Reversing and adding the each character to string from the given character position
                    for (int i = specifiedCharIndex; i >= 0; i--)
                        prefix_string += bulls_string6[i];//for loop end here
                    //Adding the remaining portion of string from the given character index
                    for (int j = specifiedCharIndex + 1; j < bulls_string6.Length; j++)
                        prefix_string += bulls_string6[j];
                    return prefix_string;
                }//if ends here
                return bulls_string6;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                throw;
            }

        }
    }
}
