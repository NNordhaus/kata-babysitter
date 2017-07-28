using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babysitter_Kata
{
    public class PaymentCalculator
    {
        public decimal GetAmountDue(JobDetails job)
        {
            if(job.start.Hour < 17)
            {
                throw new ArgumentException("Cannot start before 5 PM", nameof(job.start));
            }

            if (job.end > new DateTime().AddHours(28))
            {
                throw new ArgumentException("Cannot end after 4 AM", nameof(job.end));
            }

            return 0m;
        }
    }

    public class JobDetails
    {
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }
}