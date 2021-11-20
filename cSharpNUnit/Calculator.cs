using System;

namespace cSharpNUnit
{
    public class Calculator
    {
        public int Add(int x, int y)
        {
            int result = 0;
            try
            {
                result = x + y;
            }
            catch (Exception ex)
            {
                throw new Exception("Number is too big or too small in add method.");
            }
            return result;
        }

        public int Subtract(int x, int y)
        {
            int result = 0;
            try
            {
                result = x - y;
            }
            catch (Exception ex)
            {
                throw new Exception("Number is too big or too small in substract method.");
            }
            return result;
        }

        public double Divide(double x, double y)
        {
            return x / y;
        }

        public int Multiply(int x, int y)
        {
            int result = 0;
            try
            {
                result = x * y;
            }
            catch (Exception ex)
            {
                throw new Exception("Number is too big or too small in multiply method.");
            }
            return result;
        }

        public int Square(int x)
        {
            int result = 0;
            try
            {
                result = x * x;
            }
            catch (Exception ex)
            {
                throw new Exception("Number is too big or too small for square method.");
            }
            return result;
        }

        public double SquareRoot(double x)
        {
            return Math.Sqrt(x);
        }

        public double Exponentiation(int x, int y)
        {
            double resultExponentiation = 0;
            double z = 1;
            if (y > 0)
            {
                for (int i = 1; i <= y; i++)
                {
                    z = z * x;
                }
                resultExponentiation = z;
            }
            else if (y < 0 && x != 0)
            {
                for (int i = 1; i <= Math.Abs(y); i++)
                {
                    z = z * x;
                }
                resultExponentiation = 1 / z;
            }

            if (y == 0 && x != 0)
            {
                return resultExponentiation = 1;
            }
            else
            {
                return resultExponentiation;
            }
        }

        public double Percent(double x, double y)
        {
            return (x * Math.Abs(y)) / 100;
        }

        public int Factorial(int x)
        {
            try
            {
                if (x == 0 || x < 0)
                {
                    return 1;
                }
                else
                {
                    return x * Factorial(x - 1);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Number is too big or too small for factorial method.");
            }
        }
    }
}
