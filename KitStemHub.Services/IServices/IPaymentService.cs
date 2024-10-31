using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Services.IServices
{
    public interface IPaymentService
    {

        public bool UpdatePaymentStatus(bool status, Guid paymentId);
    }
}
