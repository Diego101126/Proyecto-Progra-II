namespace MyAPI.DTO
{
    public record PurchaseDetailDTO(int Amount , int Price, int Payment, double Iva, double Descount, double Total, int purchaseId, int productId);
}
