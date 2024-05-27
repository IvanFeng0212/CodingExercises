using _2.KataExercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _99.UnitTest.KataExercises
{
    [TestFixture]
    public class StringCalculatorTest
    {
        private StringCalculator _stringCalculator;

        [SetUp]
        public void Init()
        {
            _stringCalculator = new StringCalculator();
        }

        [TestCase("")]
        public void GivenEmptyString_WhenInvoke_ThenReturnZero(string inputVal)
        {
            ThenReturnZero(InvokeInputVal(inputVal));
        }

        [TestCase("")]
        [TestCase("1")]
        [TestCase("2")]
        [TestCase("3")]
        [TestCase("4")]
        [TestCase("5")]
        public void GivenStringNumber_WhenInvoke_ThenReturnIntegerNumber(string inputVal)
        {
            ThenReturnIntegerNumber(InvokeInputVal(inputVal), inputVal);
        }

        [TestCase("1,2", 3)]
        [TestCase("2,3", 5)]
        [TestCase("3,4", 7)]
        [TestCase("4,5", 9)]
        [TestCase("4,5\n6", 15)]
        public void GivenStringWithTwoNumbers_WhenInvoke_ThenReturnTheirSum(string inputVal, int expected)
        {
            ThenEqualToExpected(InvokeInputVal(inputVal), expected);
        }

        private int InvokeInputVal(string inputVal)
        {
            return _stringCalculator.Invoke(inputVal);
        }

        private static void ThenReturnZero(int result)
        {
            Assert.That(result, Is.EqualTo(0));
        }

        private void ThenReturnIntegerNumber(int result, string inputVal)
        {
            int.TryParse(inputVal, out int expected);

            Assert.That(result, Is.EqualTo(Convert.ToInt32(expected)));
        }

        private void ThenEqualToExpected(int result, int expected)
        {
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}