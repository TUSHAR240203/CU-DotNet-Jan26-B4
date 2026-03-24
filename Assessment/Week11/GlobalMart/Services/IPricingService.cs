namespace GlobalMart.Services
{
    public interface IPricingService
    {
        decimal CalculateFinalPrice(decimal basePrice, string promoCode);
    }
}
