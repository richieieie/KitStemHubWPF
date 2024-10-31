using KitStemHub.Repositories.Models;

namespace KitStemHub.Services.DTOs.Responses
{
    public class KitResponseDTO
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string? Name { get; set; }

        public string? Breif { get; set; }

        public string? Description { get; set; }

        public int PurchaseCost { get; set; }

        public int Price { get; set; }

        public string? ImageUrl { get; set; }

        public bool? Status { get; set; }

        public Category? Category { get; set; }
    }
}
