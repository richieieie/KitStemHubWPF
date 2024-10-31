using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Services.Constants
{
    public class OrderFulfillmentConstants
    {
        public const bool PaymentSuccess = true;
        public const bool PaymentFail = false;
        public const string OrderVerifyingStatus = "WAITING FOR ACCEPT";
        public const string OrderVerifiedStatus = "ACCEPTED";
        public const string OrderDeliveringStatus = "DELIVERING";
        public const string OrderSuccessStatus = "DELIVERY SUCCESSFUL";
        public const string OrderFailStatus = "DELIVERY FAILED";
        public const int PaymentCash = 1;
    }
}
