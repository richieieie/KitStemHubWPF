using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Services.DTOs.Requests
{
    public class KitOrderCreateDTO
    {
        public int KitId { get; set; }

        public Guid OrderId { get; set; }

        public int? KitQuantity { get; set; }
    }
}
