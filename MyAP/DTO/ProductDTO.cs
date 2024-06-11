using Entities.Models;

namespace MyAPI.DTO
{
    public record ProductDTO(int ProductId, string Name, string Provieder, int Inventory, string Amount, int idCategory);

}
