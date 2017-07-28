using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babysitter_Kata
{
    public class PaymentCalculator
    {
        public decimal GetAmountDue(DateTime start, DateTime end)
        {
            if(start.Hour < 17)
            {
                throw new ArgumentException("Cannot start before 5 PM", nameof(start));
            }

            if (end > new DateTime().AddHours(28))
            {
                throw new ArgumentException("Cannot end after 4 AM", nameof(end));
            }

            return 0m;
        }
    }
}