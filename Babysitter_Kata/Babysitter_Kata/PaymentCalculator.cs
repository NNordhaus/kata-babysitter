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
            var midnight = new DateTime().AddHours(24);

            if(job.start < new DateTime().AddHours(17))
            {
                throw new ArgumentException("Cannot start before 5 PM", nameof(job.start));
            }

            if (job.end > new DateTime().AddHours(28))
            {
                throw new ArgumentException("Cannot end after 4 AM", nameof(job.end));
            }

            decimal pay = 12m * job.bedTime.Subtract(job.start).Hours;

            if (job.end > job.bedTime)
            {
                pay += 8m * midnight.Subtract(job.bedTime).Hours;
            }

            if (job.end > midnight)
            {
                pay += 16m * job.end.Subtract(midnight).Hours;
            }

            return pay;
        }
    }

    public class JobDetails
    {
        public DateTime start { get; set; }
        public DateTime bedTime { get; set; }
        public DateTime end { get; set; }
    }
}