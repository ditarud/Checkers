using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Tarea1;

namespace Tarea1.Test
{
    [TestFixture]
    public class UtilityTests
    {
        [TestCase(2, ExpectedResult = "C")]
        [TestCase(3, ExpectedResult = "D")]
        [TestCase(28, ExpectedResult = null)]
        [TestCase(25, ExpectedResult = "Z")]
        public string ConvertNumberToLetter_Numbers_ReturnLetter(int number)
        {           
            // Act
            string result = Utility.ConvertNumberToLetter(number);

            // Assert
            return result;
        }


        [TestCase('A',ExpectedResult = 0)]
        [TestCase('B', ExpectedResult = 1)]
        [TestCase('C', ExpectedResult = 2)]
        [TestCase('D', ExpectedResult = 3)]
        [TestCase('E', ExpectedResult = 4)]
        public int ConvertLetterToNumber_Letter_ReturnNumber(char letter)
        {
            // Act
            int result = Utility.ConvertLetterToNumber(letter);

            // Assert
            return result;
        }

        [TestCase('#', ExpectedResult = 0)]
        [TestCase('$', ExpectedResult = 0)]
        [TestCase('/', ExpectedResult = 0)]
        public int ConvertLetterToNumber_NotLetter_Return0(char notLetter)
        {
            // Act
            int result = Utility.ConvertLetterToNumber(notLetter);

            // Assert
            return result;
        }


        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        public void IsOdd_NumberOdd_ReturnTrue(int value)
        {
            // Act
            bool result = Utility.IsOdd(value);

            // Assert
            Assert.IsTrue(result, "El numero ingresado debe ser impar");
        }


        [TestCase(2)]
        [TestCase(12)]
        public void IsEven_NumberEven_ReturnTrue(int value)
        {
            // Act
            bool result = Utility.IsEven(value);

            // Assert
            Assert.IsTrue(result, "El numero ingresado debe ser par");
        }

    }
}
