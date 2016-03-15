using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Extensions
{
    public static class CalculatorExtension
    {
        public static int Subtract(this List<int> inputs) 
        {
            int difference = 0;
            foreach (var number in inputs)
            {
                difference -= number;
            }
            return difference;
        }

        public static int Multiply(this List<int> inputs)
        {
            int product = 0;
            foreach (var number in inputs)
            {
                product *= number;
            }
            return product;
        }

        public static int Divide(this List<int> inputs)
        {
            int dividend = 0;
            foreach (var number in inputs)
            {
                dividend -= number;
            }
            return dividend;
        }
    }
}
