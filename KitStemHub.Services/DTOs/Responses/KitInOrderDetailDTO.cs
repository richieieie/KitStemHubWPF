using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Services.DTOs.Responses
{
    public class KitInOrderDetailDTO
    {

        public string Name { get; set; }
        public string Package { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice => Price * Quantity;
        public string ImageUrl { get; set; }

    }
}
