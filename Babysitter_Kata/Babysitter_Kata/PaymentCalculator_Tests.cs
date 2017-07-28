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
            public void Pay_12_an_hour_between_start_and_bed_Time()
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

            [TestMethod]
            public void Pay_8_an_hour_between_bedTime_and_midnight()
            {
                var sut = new PaymentCalculator();
                var job = new JobDetails()
                {
                    start = new DateTime().AddHours(23),
                    bedTime = new DateTime().AddHours(23),
                    end = new DateTime().AddHours(24)
                };

                var actual = sut.GetAmountDue(job);

                Assert.AreEqual(8m, actual);
            }

            [TestMethod]
            public void Pay_16_an_hour_between_midnight_and_end()
            {
                var sut = new PaymentCalculator();
                var job = new JobDetails()
                {
                    start = new DateTime().AddHours(24),
                    bedTime = new DateTime().AddHours(24),
                    end = new DateTime().AddHours(25)
                };

                var actual = sut.GetAmountDue(job);

                Assert.AreEqual(16m, actual);
            }

            [TestMethod]
            public void Pay_for_full_hours_not_fractional()
            {
                var sut = new PaymentCalculator();
                var job = new JobDetails()
                {
                    start = new DateTime().AddHours(23).AddMinutes(30),
                    bedTime = new DateTime().AddHours(24),
                    end = new DateTime().AddHours(25).AddMinutes(30)
                };

                var actual = sut.GetAmountDue(job);
                var expected = 12m + 32m; // 1 hour before bed & 2 hours after midnight
                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void Accurately_Pay_for_mixed_hours()
            {
                var sut = new PaymentCalculator();
                var job = new JobDetails()
                {
                    start = new DateTime().AddHours(20),
                    bedTime = new DateTime().AddHours(22),
                    end = new DateTime().AddHours(26)
                };

                var actual = sut.GetAmountDue(job);
                var expected = 72m; // 2 hours pre bed time, 2 hours bed-midnight & 2 hours after midnight
                Assert.AreEqual(expected, actual);
            }

        }
    }
}