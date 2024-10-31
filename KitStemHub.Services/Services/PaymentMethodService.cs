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
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _repository;
        public PaymentMethodService(IPaymentMethodRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<Method> GetPaymentMethods()
        {
            return _repository.GetAll();
        }

        public bool InsertPaymentMethod(Method method)
        {
            if (method != null)
            {
                return _repository.Create(method);
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePaymentMethod(Method method)
        {
            Method? updatedMethod = _repository.GetById(method.Id);
            if (updatedMethod != null) { 
                updatedMethod.Name = method.Name;
                updatedMethod.Status = method.Status;
                return _repository.Update(updatedMethod);
            }
            else
            {
                return false;
            }
        }
    }
}
