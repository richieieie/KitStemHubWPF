using KitStemHub.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitStemHub.Services.DTOs.Responses
{
    public class CartResponseDTO
    {
        public Guid UserId { get; set; }
        public int KitId { get; set; }
        public int? Quantity { get; set; }
        public int Total {  get; set; }
        public virtual KitResponseDTO Kit { get; set; } = null!;
    }
}
