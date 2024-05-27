using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.KataExercises
{
    public class StringCalculator
    {
        public int Invoke(string inputVal)
        {
            if (string.IsNullOrEmpty(inputVal)) return 0;

            if (int.TryParse(inputVal, out var result)) { return result; }

            if (inputVal.Contains("\n"))
            {
                inputVal = inputVal.Replace("\n", ",");
            }

            var stringNumbers = inputVal.Split(',');

            result = 0;
            foreach (var number in stringNumbers)
            {
                result += Convert.ToInt32(number);
            }

            return result;
        }
    }
}