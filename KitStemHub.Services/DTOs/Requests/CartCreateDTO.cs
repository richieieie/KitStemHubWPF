using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Services.DTOs.Requests
{
    public class CartCreateDTO
    {
        public Guid UserId { get; set; }
        public int KitId { get; set; }
        public int Quantity {  get; set; }
    }
}
