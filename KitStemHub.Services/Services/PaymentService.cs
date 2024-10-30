using KitStemHub.Repositories.IRepositories;
using KitStemHub.Repositories.Models;
using KitStemHub.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Services.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }



        public bool UpdatePaymentStatus(bool status,Guid paymentId)
        {
            Payment? payment = _paymentRepository.GetById(paymentId);
            if (payment != null)
            {
                payment.Status = status;
                return _paymentRepository.Update(payment);
            }
            else
            {
                return false;
            }
        }
    }
}
