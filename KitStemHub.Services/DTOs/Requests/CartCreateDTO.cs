namespace KitStemHub.Services.DTOs.Requests
{
    public class CartCreateDTO
    {
        public Guid UserId { get; set; }
        public int KitId { get; set; }
        public int Quantity {  get; set; }
    }
}
