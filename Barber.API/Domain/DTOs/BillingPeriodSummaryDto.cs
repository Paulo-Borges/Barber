namespace Barber.API.Domain.DTOs
{
    public record BillingPeriodSummaryDto(
        int TotalCount,
        decimal TotalAmount
     );
    
}
