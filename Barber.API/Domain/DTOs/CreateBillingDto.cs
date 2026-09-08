using Barber.API.Domain.Enums;

namespace Barber.API.Domain.DTOs
{
    public record CreateBillingDto(
    DateOnly Date,
    string BarberName,
    string ClientName,
    string ServiceName,
    decimal Amount,
    PaymentMethod PaymentMethod,
    BillingStatus Status,
    string? Notes
    );
}
