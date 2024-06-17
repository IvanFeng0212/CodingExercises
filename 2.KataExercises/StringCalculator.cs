using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _2.KataExercises
{
    public class StringCalculator
    {
        public int Invoke(string inputVal)
        {
            if (string.IsNullOrEmpty(inputVal)) return 0;

            var onlyNumberPattern = new Regex(@"^[\d]+$");
            if (onlyNumberPattern.IsMatch(inputVal))
            {
                return HandleOnlyOneNumber(inputVal);
            }

            var separator = ",";
            var containSeparatorPattern = new Regex(@"//(.*)\\n.*");
            if (containSeparatorPattern.IsMatch(inputVal))
            {
                separator = ExtractSeparator(containSeparatorPattern, inputVal);
                inputVal = inputVal.Replace(@$"//{separator}\n", "");
            }

            if (inputVal.EndsWith(separator) || inputVal.EndsWith(","))
            {
                throw new ArgumentException("Input Error!!");
            }

            if (inputVal.Contains(@"\n"))
            {
                inputVal = inputVal.Replace(@"\n", separator);
            }

            var stringNumbers = inputVal.Split(separator);

            var result = 0;
            int currentValue = 0;
            foreach (var number in stringNumbers)
            {
                if (int.TryParse(number, out currentValue))
                {
                    result += currentValue;
                }
                else
                {
                    ThrowErrorException(inputVal, separator, number);
                }
            }

            return result;
        }

        private int HandleOnlyOneNumber(string inputVal)
        {
            return Convert.ToInt32(inputVal);
        }

        private string ExtractSeparator(Regex containSeparatorPattern, string inputVal)
        {
            return containSeparatorPattern.Match(inputVal).Groups[1].Value;
        }

        private void ThrowErrorException(string inputVal, string separator, string number)
        {
            var nonNumberValue = ExtractNonNumberValue(number);

            var nonNumberIndex = inputVal.IndexOf(nonNumberValue);

            throw new ArgumentException($"{separator} expected but {nonNumberValue} found at position {nonNumberIndex}");
        }

        private string ExtractNonNumberValue(string inputVal)
        {
            foreach (var val in inputVal)
            {
                if (!int.TryParse($"{val}", out int currentValue)) return $"{val}";
            }

            return string.Empty;
        }
    }
}