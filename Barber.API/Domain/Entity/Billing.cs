using Barber.API.Domain.Enums;

namespace Barber.API.Domain.Entity
{
    public class Billing
    {
        public Guid Id { get; private set; }
        public DateOnly Date { get; private set; }
        public string BarberName { get; private set; } = string.Empty;
        public string ClientName { get; private set; } = string.Empty;
        public string ServiceName { get; private set; } = string.Empty;
        public decimal Amount { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public BillingStatus Status { get; private set; }
        public string? Notes { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        // Construtor protegido/vazio para ORMs (como Entity Framework)
        protected Billing() { }

        // Construtor principal para criação
        public Billing(
            DateOnly date,
            string barberName,
            string clientName,
            string serviceName,
            decimal amount,
            PaymentMethod paymentMethod,
            BillingStatus status,
            string? notes = null)
        {
            Id = Guid.NewGuid();
            Date = date;
            BarberName = barberName;
            ClientName = clientName;
            ServiceName = serviceName;
            PaymentMethod = paymentMethod;
            Status = status;
            Notes = notes;

            // Regra de Negócio: Se o status for Cancelado, o valor deve ser 0
            Amount = status == BillingStatus.Canceled ? 0m : amount;

            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        // Método para atualizar o faturamento mantendo a regra do Amount
        public void Update(
            DateOnly date,
            string barberName,
            string clientName,
            string serviceName,
            decimal amount,
            PaymentMethod paymentMethod,
            BillingStatus status,
            string? notes)
        {
            Date = date;
            BarberName = barberName;
            ClientName = clientName;
            ServiceName = serviceName;
            PaymentMethod = paymentMethod;
            Status = status;
            Notes = notes;

            // Regra de Negócio: Se o status for Cancelado, o valor deve ser 0
            Amount = status == BillingStatus.Canceled ? 0m : amount;

            UpdatedAt = DateTime.UtcNow;
        }
    }
}
