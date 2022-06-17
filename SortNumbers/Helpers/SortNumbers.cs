using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SortNumbers.Helpers
{
    public static class SortNumbersHelper
    {
        //Returns true if numbers are valid
        public static bool ValidateNumbers(string numbers)
        {
            //Make sure there are numbers to validate
            if(numbers == null) return false;

            foreach (string number in numbers.Split(","))
            {
                if (!Int32.TryParse(number, out int num)) // This makes sure all numbers are integers
                {
                    // you know that the parsing attempt was unsuccessful
                    return false;
                }
                continue;
            }

            //If all numbers pass then return true
            return true;
        }

        public static string SortNumbers(string order, string numbers)
        {
            // List<string> numbersArray = numbers.Split(",").ToList();
            List<int> numbersList = new List<int>();

            foreach (string number in numbers.Split(","))
            {
                numbersList.Add(Int32.Parse(number));
            }

            List<int> orderdNumbers = new List<int>();
            if (order == "ascending")
            {
                orderdNumbers = numbersList.OrderBy(x => x).ToList();
            }
            else
            {
                orderdNumbers = numbersList.OrderByDescending(x => x).ToList();
            }

            string output = "";
            foreach(int number in orderdNumbers)
            {
                output += number + ",";
            }

            return output.Remove(output.Length - 1, 1);
        }
    }
}
