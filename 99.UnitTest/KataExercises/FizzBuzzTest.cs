using _2.KataExercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _99.UnitTest.KataExercises
{
    [TestFixture]
    public class FizzBuzzTest
    {
        private FizzBuzz _fizzBuzz;

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GivenFizzBuzz_WhenInputNumber_ThenReturnString(int number)
        {
            GivenFizzBuzz();

            ThenReturnString(WhenInputeNumber(number));
        }

        [TestCase(3)]
        [TestCase(6)]
        [TestCase(9)]
        public void GivenFizzBuzz_WhenInputNumberIsDivisibleBy3_ThenReturnFizz(int number)
        {
            GivenFizzBuzz();

            var result = _fizzBuzz.Invoke(number);

            Assert.That(result, Is.EqualTo("Fizz"));
        }

        private void GivenFizzBuzz()
        {
            _fizzBuzz = new FizzBuzz();
        }

        private string WhenInputeNumber(int number)
        {
            return _fizzBuzz.Invoke(number);
        }

        private void ThenReturnString(string fizzBuzzResult)
        {
            Assert.That(fizzBuzzResult.GetType(), Is.EqualTo(typeof(string)));
        }
    }
}