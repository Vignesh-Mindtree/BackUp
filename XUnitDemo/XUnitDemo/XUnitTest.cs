using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

[assembly: CLSCompliant(true)]
namespace XUnitDemo
{
    public static class XUnitTest
    {
//#pragma warning disable CS3016 // Arrays as attribute arguments is not CLS-compliant
//        [Theory, MemberData("InputDataSet")]
//#pragma warning restore CS3016 // Arrays as attribute arguments is not CLS-compliant
//        public static void TestAdd( int input1, int input2, int expectedOutput)
//        {
//            int actualOutput = 0;
//            //for (int i = 0; i < 2; i++)
//            //{
//                actualOutput = (input1 + input2);
//            //}
//            Assert.Equal(expectedOutput, actualOutput);
//        }


        //        [Theory]
        //#pragma warning disable CS3016 // Arrays as attribute arguments is not CLS-compliant
        //        [InlineData(10, 10, 20)]
        //#pragma warning restore CS3016 // Arrays as attribute arguments is not CLS-compliant
        //        [InlineData(10, 20, 30)]
        //        [InlineData(100, 10, 110)]
        //        public static void TestAdd1(int input1, int input2, int expectedOutput)
        //        {
        //            var actualOutput = add(input1, input2);
        //            Assert.Equal(expectedOutput, actualOutput);
        //        }

        //public static IEnumerable<object[]> InputDataSet
        //{
        //    get
        //    {
        //        return new[]
        //        {
        //        new object[] {new Sample[] {new Sample(), new Sample()}, 10, 10, 20 },
        //        new object[] {new Sample[] {new Sample(), new Sample()}, 10, 20, 30 }
        //        };
        //    }
        //}

#pragma warning disable CS3016 // Arrays as attribute arguments is not CLS-compliant
        [Theory, MemberData("InputDataSet")]
#pragma warning restore CS3016 // Arrays as attribute arguments is not CLS-compliant
        public static void TestFlightNumber(Sample sample, List<int> expected)
        {
            var actualOutput = Sample.Add(sample.arrTime);
            Assert.Equal(expected, actualOutput);
        }
        public static IEnumerable<object[]> InputDataSet
        {
            get
            {
                return new[]
                {
                    new object[] { new Sample() { arrTime = "02:00" }, new List<int>() },
                    new object[] { new Sample() { arrTime = "04:00" }, new List<int> { 1,2 } },
                    new object[] { new Sample() { arrTime = "qwe" }, null }
                };
            }
        }
    }
}
