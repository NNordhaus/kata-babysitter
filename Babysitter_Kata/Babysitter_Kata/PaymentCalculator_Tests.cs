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
            [ExpectedException(typeof(ArgumentException), "Start time before 5PM should throw exception")]
            public void Throw_Error_For_Start_Before_5()
            {
                var sut = new PaymentCalculator();

                var job = new JobDetails()
                {
                    start = new DateTime().AddHours(16) // 4 PM
                };

                var actual = sut.GetAmountDue(job);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException), "End time After 4AM should throw exception")]
            public void Throw_Error_For_End_After_4AM()
            {
                var sut = new PaymentCalculator();

                var startTime = new DateTime().AddHours(17); // 5 PM
                var endTime = new DateTime().AddHours(29); // 5 AM next day

                var job = new JobDetails()
                {
                    start = new DateTime().AddHours(17), // 5 PM
                    end = new DateTime().AddHours(29) // 5 AM next day
                };

                var actual = sut.GetAmountDue(job);
            }

            [TestMethod]
            public void Pay_12_an_hour_when_end_time_matches_bed_Time()
            {
                var sut = new PaymentCalculator();
                var job = new JobDetails()
                {
                    start = new DateTime().AddHours(17),
                    end = new DateTime().AddHours(18),
                    bedTime = new DateTime().AddHours(18)
                };

                var actual = sut.GetAmountDue(job);

                Assert.AreEqual(12m, actual);
            }
        }
    }
}