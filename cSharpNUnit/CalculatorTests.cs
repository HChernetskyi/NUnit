using NUnit.Framework;
using System;

namespace cSharpNUnit
{
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TestCase(0, 1, 1, Description = "Simple add test.")]
        [TestCase(-5, -1, -6)]
        [TestCase(100, -100, 0)]
        public void CalculatorAdd(int x, int y, int expectedSumm)
        {
            Assert.AreEqual(expectedSumm, calculator.Add(x, y),
                "Incorrect summ.");
        }

        [TestCase(-2147483648, 0, -2147483648, Description = "Test on boundary.")]
        [TestCase(-2147483648, 1, -2147483647)]
        [TestCase(2147483647, -1, 2147483646)]
        [TestCase(2147483647, 0, 2147483647)]
        public void CalculatorAddBoundary(int x, int y, int expectedAdd)
        {
            Assert.AreEqual(expectedAdd, calculator.Add(x, y), $"Incorrect summ for {x} and {y}.");
        }

        [TestCase(2147483647, 1, Description = "Test out of boundary")]
        [TestCase(-2147483648, -1)]
        public void CalculatorAddException(int x, int y)
        {
            try
            {
                calculator.Add(x, y);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Number is too big or too small in add method.", ex.Message);
            }
        }

        [TestCase(-1, 0, -1)]
        [TestCase(-1, 1, -2)]
        [TestCase(-1, -1, 0)]
        public void CalculatorSubtractOrdinary(int x, int y, int expectedSubtract)
        {
            var actualSubtract = calculator.Subtract(x, y);
            Assert.AreEqual(expectedSubtract, actualSubtract, $"Incorrect subtract {y} from {x}.");
        }

        [TestCase(-2147483648, -1, -2147483647)]
        [TestCase(-2147483648, 0, -2147483648)]
        [TestCase(2147483647, 0, 2147483647)]
        [TestCase(2147483647, 1, 2147483646)]
        [TestCase(-1, 2147483647, -2147483648)]
        public void CalculatorSubtractBoundary(int x, int y, int expectedSubtract)
        {
            var actualSubtract = calculator.Subtract(x, y);
            Assert.AreEqual(expectedSubtract, actualSubtract, $"Incorrect substract {y} from {x}.");
        }

        [TestCase(-2147483648, 1, Description = "Test out of boundary")]
        [TestCase(2147483647, -1)]
        [TestCase(1, -2147483648)]
        public void CalculatorSubtractException(int x, int y)
        {
            try
            {
                calculator.Subtract(x, y);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Number is too big or too small in substract method.", ex.Message);
            }
        }

        [TestCase(-1, 0, 0)]
        [TestCase(-1, 1, -1)]
        [TestCase(-1, -1, 1)]
        [TestCase(2, 2, 4)]
        public void CalculatorMultiplyOrdinary(int x, int y, int expectedMultiply)
        {
            Assert.AreEqual(expectedMultiply, calculator.Multiply(x, y), $"Incorrect multiply {x} by {y}.");
        }

        [TestCase(2147483647, 1, 2147483647)]
        [TestCase(-2147483648, 1, -2147483648)]
        [TestCase(-2147483648, 0, 0)]
        [TestCase(2147483647, 0, 0)]

        public void CalculatorMultiplyBoundary(int x, int y, int expectedMultiply)
        {
            Assert.AreEqual(expectedMultiply, calculator.Multiply(x, y), $"Incorrect multiply {x} by {y}.");
        }

        [TestCase(46341, 46341, Description = "Test out of boundary")]
        [TestCase(-2147483648, 2)]
        [TestCase(2147483647, 2)]
        public void CalculatorMultiplyException(int x, int y)
        {
            try
            {
                calculator.Multiply(x, y);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Number is too big or too small in multiply method.", ex.Message);
            }
        }

        [TestCase(0, 1, 0)]
        [TestCase(256, 2, 128)]
        [TestCase(-20.25, -2.5, 8.1)]
        public void CalculatorDivideOrdinary(double x, double y, double expectedDivide)
        {
            Assert.AreEqual(expectedDivide, calculator.Divide(x, y), $"Incorrect divide {x} by {y}.");
        }

        [TestCase(1, 0)]
        [TestCase(0, 0)]
        [TestCase(-123.456, 0)]
        public void CalculatorDivideByZero(double x, double y)
        {
            Assert.IsNaN(calculator.Divide(x, y), $"Incorrect divide {x} by {y}.");
        }

        [TestCase(1, 1)]
        [TestCase(0, 0)]
        [TestCase(-3, 9)]
        public void CalculatorSquareOrdinary(int x, int expectedSquare)
        {
            Assert.AreEqual(expectedSquare, calculator.Square(x), $"Incorrect square of {x}.");
        }

        [TestCase(46341, Description = "result is out of boundary")]
        [TestCase(-46341)]
        public void CalculatorSquareException(int x)
        {
            try
            {
                calculator.Square(x);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Number is too big or too small for square method.", ex.Message);
            }
        }

        [TestCase(0, 0)]
        [TestCase(5.76, 2.4)]
        [TestCase(81, 9)]
        public void CalculatorSquareRoot(double x, double expectedSquareRoot)
        {
            Assert.AreEqual(expectedSquareRoot, calculator.SquareRoot(x), $"Incorrect square root of {x}.");
        }

        [TestCase(-4)]
        [TestCase(-0.09)]
        public void CalculatorSquareRootNegative(double x)
        {
            Assert.IsNaN(calculator.SquareRoot(x), $"Square root of {x} is incorrect!");
        }

        [TestCase(2, 2, 4)]
        [TestCase(2, 1, 2)]
        [TestCase(1, 0, 1)]
        [TestCase(2, 3, 8)]
        [TestCase(2, -3, 0.125)]
        [TestCase(2, -1, 0.5)]
        public void CalculatorExponentiationPositiveBase(int x, int y, double expectedExp)
        {
            Assert.AreEqual(expectedExp, calculator.Exponentiation(x, y), $"Incorrect raising of {x} to the power of {y}.");
        }

        [TestCase(0, 1, 0)]
        [TestCase(0, 10, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(0, -1, 0)]
        public void CalculatorExponentiationZeroBase(int x, int y, double expectedExp)
        {
            Assert.AreEqual(expectedExp, calculator.Exponentiation(x, y), $"Incorrect raising of {x} to the power of {y}.");
        }

        [TestCase(-1, -1, -1)]
        [TestCase(-1, 0, 1)]
        [TestCase(-1, 1, -1)]
        [TestCase(-4, -2, 0.0625)]
        public void CalculatorExponentiationNegativeBase(int x, int y, double expectedExp)
        {
            Assert.AreEqual(expectedExp, calculator.Exponentiation(x, y), $"Incorrect raising of {x} to the power of {y}.");
        }

        [TestCase(0, 0, 0)]
        [TestCase(1, 0, 0)]
        [TestCase(1, 1, 0.01)]
        [TestCase(-10, 2, -0.2)]
        [TestCase(25, -4, 1)]
        public void Percent(double x, double y, double expectedPercent)
        {
            Assert.AreEqual(expectedPercent, calculator.Percent(x, y), $"Incorrect percent {y} from {x}.");
        }

        [TestCase(0, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 6)]
        [TestCase(4, 24)]
        [TestCase(5, 120)]
        public void Factorial(int x, int expectedFactorial)
        {
            Assert.AreEqual(expectedFactorial, calculator.Factorial(x), $"Incorrect factorial of {x}.");
        }

        [TestCase(13)]
        [TestCase(-1)]
        public void FactorialException(int x)
        {
            try
            {
                calculator.Factorial(x);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Number is too big or too small for factorial method.", ex.Message);
            }
        }
    }
}