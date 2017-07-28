using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babysitter_Kata
{
    public class PaymentCalculator
    {
        public decimal GetAmountDue(DateTime start)
        {
            if(start.Hour < 17)
            {
                throw new ArgumentException("Cannot start before 5 PM", nameof(start));
            }

            return 0m;
        }
    }
}