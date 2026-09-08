using Barber.API.DataContext;
using Barber.API.Domain.DTOs;
using Barber.API.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Barber.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingsController : ControllerBase
    {
        private readonly AppDbContext _context;

           public BillingsController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        [ProducesResponseType(typeof(BillingResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateBillingDto dto)
        {
            // 1.1 Transformar os dados recebidos (DTO) no objeto da nossa tabela/entidade (Billing)
            var billing = new Billing
            (
              dto.Date,
              dto.BarberName,
              dto.ClientName,
              dto.ServiceName,
              dto.Amount,
              dto.PaymentMethod,
              dto.Status,
              dto.Notes
            );

            _context.Billings.Add( billing );
            await _context.SaveChangesAsync();

            var response = new BillingResponseDto(
                billing.Id, billing.Date, billing.BarberName, billing.ClientName,
                billing.ServiceName, billing.Amount,
                billing.PaymentMethod, billing.Status, billing.Notes, billing.CreatedAt, billing.UpdatedAt
            );

            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

   
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BillingResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetBillingsQueryParameters parameters)
        {
            var billingsFromDb = await _context.Billings.ToListAsync();

            // 2.2 Converter os itens do banco para o formato de DTO que a API precisa devolver
            var responseList = billingsFromDb.Select(b => new BillingResponseDto(
                b.Id, b.Date, b.BarberName, b.ClientName,
                b.ServiceName, b.Amount, b.PaymentMethod,
                b.Status, b.Notes, b.CreatedAt, b.UpdatedAt
            ));

            return Ok(responseList);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(BillingResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {

            var billing = await _context.Billings.FindAsync(id);

            if (billing == null)
            {
                return NotFound();
            }

            var response = new BillingResponseDto(
                billing.Id, billing.Date, billing.BarberName, billing.ClientName,
                billing.ServiceName, billing.Amount, billing.PaymentMethod,
                billing.Status, billing.Notes, billing.CreatedAt, billing.UpdatedAt
            );

            return Ok(response);
        }

        [HttpGet("summary")]
        [ProducesResponseType(typeof(BillingPeriodSummaryDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPeriodSummary([FromQuery] DateOnly? startDate, [FromQuery] DateOnly? endDate)
        {
            // var summary = await _billingService.GetPeriodSummaryAsync(startDate, endDate);
            var summary = new BillingPeriodSummaryDto(TotalCount: 0, TotalAmount: 0m);
            return Ok(summary);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBillingDto dto)
        {

            return NoContent();
        }

    
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            
            return NoContent();
        }
    }
}
