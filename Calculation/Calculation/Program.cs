using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation
{
    public static class Program
    {
        static void Main()
        {
            int result = 0;
            Console.WriteLine("Enter the numbers you want to perform calculation\n");
            List<int> inputs = new List<int>();
            int newInput = 0;
            do
            {
                try
                {
                    inputs.Add(Convert.ToInt16((Console.ReadLine())));
                }
                catch(Exception)
                {
                    continue;
                }
            } while (int.TryParse(inputs.Last().ToString(), out newInput));

                Console.WriteLine("Enter the corresponding mathematical operation symbol you want\n");
            string operationSymbol = Console.ReadLine();
            Calculator calculator = new Calculator();
            switch (operationSymbol)
            {
                case "+":
                    result = calculator.Add(inputs);
                    break;
                case "-":
                    result = calculator.Subtract(inputs);
                    break;
                case "*":
                    result = calculator.Multiply(inputs);
                    break;
                case "/":
                    result = calculator.Divide(inputs);
                    break;
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
