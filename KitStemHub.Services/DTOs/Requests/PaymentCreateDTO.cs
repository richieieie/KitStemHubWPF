using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Services.DTOs.Requests
{
    public class PaymentCreateDTO
    {
        public Guid Id { get; set; }

        public Guid? OrderId { get; set; }

        public int MethodId { get; set; }

        public DateTimeOffset? CreatedAt { get; set; }

        public bool? Status { get; set; }
    }
}
