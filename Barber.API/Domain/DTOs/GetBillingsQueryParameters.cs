using Barber.API.Domain.Enums;

namespace Barber.API.Domain.DTOs
{
    public class GetBillingsQueryParameters(
    DateOnly? StartDate,
    DateOnly? EndDate,
    string? BarberName,
    BillingStatus? Status,
    int PageNumber = 1,
    int PageSize = 10,
    string? SortBy = "Date",
    bool IsDescending = true
    );
    
}
