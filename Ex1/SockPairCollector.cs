using System;
using Xunit;

namespace PreAssessmentCenter.Ex1
{
    public class SockPairCollector
    {
        public static string Collect(string socks)
        {
            // EXAMPLE 1: Implement this method, so that the tests below (and maybe some additional) pass


            //throw new System.NotImplementedException();
            return socks;
            
        }
    }

    public class SockPairCollectorTest
    {
        [Theory]
        [InlineData("Red Red", "Red Red")]
        //[InlineData("Red Red", "1 x Red")]
        //[InlineData("Red Red Black Black", "1 x Red, 1 x Black")]
        //[InlineData("R R B B B R B R B B", "2 x R, 3 x B")]
        //[InlineData("Red Red Red Red Red", "2 x Red and 1 single Red")]
        //[InlineData(
        //    "Y Y B Y R R R B R R G B R B R R B R G R",
        //    "1 x Y, 2 x B, 5 x R, 1 x G and 1 single Y, 1 single B"
        //)]

        public void Collect(string socks, string expected)
        {
            var result = SockPairCollector.Collect(socks);

            Assert.Equal(expected, result);
        }
    }
}