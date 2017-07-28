using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Babysitter_Kata
{
    [TestClass]
    public class PaymentCalculator_Tests
    {
        [TestClass]
        public class GetAmountDue_Should
        {
            [TestMethod]
            public void Throw_Error_For_Start_Before_5()
            {
                var sut = new PaymentCalculator();

                var startTime = new DateTime().AddHours(16); // 4 PM

                var actual = sut.GetAmountDue(startTime);
            }
        }
    }
}