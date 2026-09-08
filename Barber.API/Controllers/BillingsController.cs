using Barber.API.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barber.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingsController : ControllerBase
    {
        // Injeção de dependência do seu serviço de aplicação ou mediatr
        // private readonly IBillingService _billingService;
        // public BillingsController(IBillingService billingService) => _billingService = billingService;

        /// <summary>
        /// Criar um novo faturamento.
        /// </summary>
        /// <param name="dto">Dados do faturamento a ser criado.</param>
        /// <returns>O faturamento recém-criado.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(BillingResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateBillingDto dto)
        {
            // Exemplo fictício de chamada do serviço:
            // var response = await _billingService.CreateAsync(dto);

            var response = new BillingResponseDto(
                Guid.NewGuid(), dto.Date, dto.BarberName, dto.ClientName,
                dto.ServiceName, dto.Status == Domain.Enums.BillingStatus.Canceled ? 0m : dto.Amount,
                dto.PaymentMethod, dto.Status, dto.Notes, DateTime.UtcNow, DateTime.UtcNow
            );

            return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
        }

        /// <summary>
        /// Listar faturamentos com filtros, paginação e ordenação.
        /// </summary>
        /// <param name="parameters">Parâmetros de filtro e paginação.</param>
        /// <returns>Lista paginada de faturamentos.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BillingResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetBillingsQueryParameters parameters)
        {
            // var result = await _billingService.GetAllAsync(parameters);
            return Ok(new List<BillingResponseDto>());
        }

        /// <summary>
        /// Obter um faturamento pelo ID.
        /// </summary>
        /// <param name="id">ID (GUID) do faturamento.</param>
        /// <returns>Os dados do faturamento.</returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(BillingResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // var result = await _billingService.GetByIdAsync(id);
            // if (result is null) return NotFound(new { Message = "Faturamento não encontrado." });

            return Ok();
        }

        /// <summary>
        /// Ver o total do período (somando apenas os lançamentos com status Pago).
        /// </summary>
        /// <param name="startDate">Data inicial opcional.</param>
        /// <param name="endDate">Data final opcional.</param>
        /// <returns>O valor acumulado e a contagem de faturamentos pagos.</returns>
        [HttpGet("summary")]
        [ProducesResponseType(typeof(BillingPeriodSummaryDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPeriodSummary([FromQuery] DateOnly? startDate, [FromQuery] DateOnly? endDate)
        {
            // var summary = await _billingService.GetPeriodSummaryAsync(startDate, endDate);
            var summary = new BillingPeriodSummaryDto(TotalCount: 0, TotalAmount: 0m);
            return Ok(summary);
        }

        /// <summary>
        /// Atualizar um faturamento existente.
        /// </summary>
        /// <param name="id">ID (GUID) do faturamento a ser atualizado.</param>
        /// <param name="dto">Novos dados do faturamento.</param>
        /// <returns>Sem conteúdo em caso de sucesso.</returns>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBillingDto dto)
        {
            // var success = await _billingService.UpdateAsync(id, dto);
            // if (!success) return NotFound(new { Message = "Faturamento não encontrado para atualização." });

            return NoContent();
        }

        /// <summary>
        /// Excluir um faturamento pelo ID.
        /// </summary>
        /// <param name="id">ID (GUID) do faturamento.</param>
        /// <returns>Sem conteúdo em caso de sucesso.</returns>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // var success = await _billingService.DeleteAsync(id);
            // if (!success) return NotFound(new { Message = "Faturamento não encontrado." });

            return NoContent();
        }
    }
}
