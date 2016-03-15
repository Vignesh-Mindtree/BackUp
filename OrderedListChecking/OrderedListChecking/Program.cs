using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderedListChecking
{
    class Program
    {
        static void Main(string[] args)
        {
            var legNumbers = new List<int?>()
            {
                1,2,3,4
            };

            var orderedLegNumbers = legNumbers.OrderBy(x => x);
            foreach (var number in orderedLegNumbers)
            {
                Console.WriteLine(number);
            }

            if (legNumbers.SequenceEqual(orderedLegNumbers))
                Console.WriteLine("True");
            else
                Console.WriteLine("False");

            if(legNumbers.Select(x => x.Value).SequenceEqual(Enumerable.Range(1, legNumbers.Count)))
                Console.WriteLine("Sequence matched");
            else
                Console.WriteLine("Sequence not matched");
            Console.ReadKey();
        }
    }
}
