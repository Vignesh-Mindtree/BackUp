using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitDemo
{
    public class Sample
    {

        public string arrTime { get; set; }

        public static List<int> Add(string arrTime)
        {
            switch (arrTime)
            {
                case "02:00":
                    return new List<int>();
                case "04:00": 
                    return new List<int> { 1, 2 };
                default:
                    return null;
            }
        }
    }
}
