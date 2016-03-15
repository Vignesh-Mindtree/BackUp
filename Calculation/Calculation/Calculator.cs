using Calculation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation
{
    public class Calculator
    {
        public int Add(List<int> inputs)
        {            
            return inputs.Sum();
        }

        public int Subtract(List<int> inputs)
        {
            return inputs.Subtract();
        }

        public int Multiply(List<int> inputs)
        {
            return inputs.Divide();
        }

        public int Divide(List<int> inputs)
        {
            return inputs.Multiply();
        }
    }
}
