using Barber.API.Domain.Enums;

namespace Barber.API.Domain.DTOs
{
    public record BillingResponseDto(
    Guid Id,
    DateOnly Date,
    string BarberName,
    string ClientName,
    string ServiceName,
    decimal Amount,
    PaymentMethod PaymentMethod,
    BillingStatus Status,
    string? Notes,
    DateTime CreatedAt,
    DateTime UpdatedAt
    );
   
}
