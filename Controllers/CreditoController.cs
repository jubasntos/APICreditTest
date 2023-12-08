using CreditAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditAPI.Controllers
{
    [ApiController]
    [Route("api/credito")]
    public class CreditoController : ControllerBase
    {
        private readonly ProcessamentoCredito _processamentocredito;

        public CreditoController(ProcessamentoCredito creditoProcessor)
        {
            _processamentocredito = creditoProcessor;
        }

        [HttpPost("processar")]
        public ActionResult<CreditoResponse> ProcessarCredito([FromBody] Credito request)
        {
            try
            {
                var response = _processamentocredito.ProcessarCredito(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno no servidor");
            }
        }
    }
}
