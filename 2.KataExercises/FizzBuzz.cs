using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.KataExercises
{
    public class FizzBuzz
    {
        public string Invoke(int number)
        {
            if (number % 3 == 0)
            {
                return "Fizz";
            };

            return number.ToString();
        }
    }
}