using Entities.Models;

namespace MyAPI.DTO
{
    public record PurchesDTO(string DatePurchese, int ClientId, int ProductId, string Amount);
}
