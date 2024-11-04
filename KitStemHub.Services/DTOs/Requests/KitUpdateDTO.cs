using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Services.DTOs.Requests
{
    public class KitUpdateDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }

        public string? Name { get; set; }

        public string? Breif { get; set; }

        public string? Description { get; set; }

        public int PurchaseCost { get; set; }

        public int Price { get; set; }

        public string? ImageUrl { get; set; }
    }
}
