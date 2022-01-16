using System;
using System.Collections.Generic;
using System.Linq;
// TO DO:
// Add support for decimals
namespace NumberNames
{
    class Program
    {
        public static string[] names0to19 = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        public static string[] names20to90 = new string[] { "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        public static string[] namesMagnitude = new string[] {"thousand", "million", "billion", "trillion", "quadrillion", "quintillion" };

        static void Main(string[] args)
        {
            
            long input = long.Parse(Console.ReadLine());
            long absoluteVal = Math.Abs(input);
            string output = "";

            if (absoluteVal < 1000)
            {
                output = LessThan1000(absoluteVal);
            }
            else if (absoluteVal < 100000000000000000)
            {               
                int leadingMagnitude = ((absoluteVal.ToString().Length - 1) % 3) + 1;
                int currentMagnitude = ((absoluteVal.ToString().Length - leadingMagnitude) / 3) - 1;
                string selectedString = absoluteVal.ToString().Substring(0, leadingMagnitude);
                // There might be a better way of finding the leading magnitude

                while (currentMagnitude >= 0)
                {                    
                    output += LessThan1000(long.Parse(selectedString)) + " " + namesMagnitude[currentMagnitude];
                    if (absoluteVal < 1000000)
                    {
                        output += " ";
                    }
                    else
                    {
                        output += ", ";
                    }                   
                    selectedString = absoluteVal.ToString().Substring(leadingMagnitude, 3);

                    leadingMagnitude += 3;
                    currentMagnitude--;
                }
                selectedString = absoluteVal.ToString().Substring(leadingMagnitude - 3, 3);
                output += LessThan1000(long.Parse(selectedString));
            }

            if (input < 0)
            {
                output = "negative " + output;
            }

            Console.WriteLine(output);
        }

        static string LessThan1000(long input)
        {
            string output = "";
            if (input < 20)
            {
                output = names0to19[input];
            }
            else if (input < 100)
            {
                if (input % 10 == 0)
                {
                    output = names20to90[(input / 10) - 2];
                }
                else
                {
                    output = names20to90[(input / 10) - 2] + " " + names0to19[input % 10];
                }
            }
            else if (input < 1000)
            {
                if (input - ((input / 100) * 100) == 0)
                {
                    output = names0to19[input / 100] + " hundred";
                }
                else
                {
                    output = names0to19[input / 100] + " hundred and " + LessThan1000(input - ((input / 100) * 100));
                }
            }
            else
            {
                output = "Error, n > 999";
            }
            
            return output;
        }
    }
}