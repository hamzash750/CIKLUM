using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Check Anagrams");
            CheckStringAnagrams();
            Console.Write("Enter Palindrome string");
            CheckPalindromeString();
        }
        static void CheckStringAnagrams()
        {
            string val1, val2;
            Console.Write("Enter first string: ");
            val1 = Console.ReadLine();
            Console.Write("Enter second string: ");
            val2 = Console.ReadLine();
            if (Sorting(val1) == Sorting(val2)) Console.WriteLine("Strings are anagram.");
            else Console.WriteLine("Strings are not anagram.");
            //Console.WriteLine("Try Again");
            //CheckStringAnagrams();
        }
        static string Sorting(string name)
        {
            List<int> list = new List<int>();
            foreach (char item in name)
            {
                list.Add((short)item);
            }
           return IntArrayBubbleSort(list);
           
        }
         static string IntArrayBubbleSort(List<int> data)
        {
            int t;
            for (int p = 0; p <= data.Count - 2; p++)
            {
                for (int i = 0; i <= data.Count - 2; i++)
                {
                    if (data[i] > data[i + 1])
                    {
                        t = data[i + 1];
                        data[i + 1] = data[i];
                        data[i] = t;
                    }
                }
            }
            string value = "";
            foreach (int i in data)
            {
                value= value+((char)i);
            }
            return value;
        }
        static void CheckPalindromeString()
        {
            string Ustring;
            Console.WriteLine(" Enter string");
            Ustring = Console.ReadLine();
           string revValue = reverseString(Ustring, "");
            if (revValue == Ustring)
            {
                Console.WriteLine("String is Palindrome");
            }
            else
            {
                Console.WriteLine("String is not Palindrome");
            }
            Console.ReadKey();
        }

        private static string reverseString(string Ustring, string revs)
        {
            for (int i = Ustring.Length - 1; i >= 0; i--)
            {
                revs += Ustring[i].ToString();
            }

            return revs;
        }
    }
}
