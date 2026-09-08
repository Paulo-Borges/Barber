using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barber.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        // private readonly IReportService _reportService;
        // public ReportsController(IReportService reportService) => _reportService = reportService;

        /// <summary>
        /// Gerar relatório semanal de faturamento em formato PDF.
        /// </summary>
        /// <param name="startDate">Data inicial da semana (Opcional - padrão: início da semana atual).</param>
        /// <returns>Arquivo PDF baixável.</returns>
        [HttpGet("pdf")]
        [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPdfReport([FromQuery] DateOnly? startDate)
        {
            // byte[] pdfBytes = await _reportService.GenerateWeeklyPdfAsync(startDate);
            byte[] pdfBytes = Array.Empty<byte>(); // Substituir pelo retorno da biblioteca (ex: QuestPDF / iTextSharp)

            string fileName = $"faturamento_semanal_{DateTime.Now:yyyyMMdd}.pdf";
            return File(pdfBytes, "application/pdf", fileName);
        }

        /// <summary>
        /// Gerar relatório semanal de faturamento em formato Excel (.xlsx).
        /// </summary>
        /// <param name="startDate">Data inicial da semana (Opcional - padrão: início da semana atual).</param>
        /// <returns>Arquivo Excel baixável.</returns>
        [HttpGet("excel")]
        [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetExcelReport([FromQuery] DateOnly? startDate)
        {
            // byte[] excelBytes = await _reportService.GenerateWeeklyExcelAsync(startDate);
            byte[] excelBytes = Array.Empty<byte>(); // Substituir pelo retorno da biblioteca (ex: ClosedXML / EPPlus)

            string fileName = $"faturamento_semanal_{DateTime.Now:yyyyMMdd}.xlsx";
            return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}
