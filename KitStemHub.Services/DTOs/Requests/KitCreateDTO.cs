namespace KitStemHub.Services.DTOs.Requests
{
    public class KitCreateDTO
    {
        public int CategoryId { get; set; }

        public string? Name { get; set; }

        public string? Breif { get; set; }

        public string? Description { get; set; }

        public int PurchaseCost { get; set; }

        public int Price { get; set; }

        public string? ImageUrl { get; set; }

        public bool? Status { get; set; }
    }
}
