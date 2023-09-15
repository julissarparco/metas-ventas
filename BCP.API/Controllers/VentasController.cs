using AutoMapper;
using BCP.META.Application.DTO;
using BCP.META.Application.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BCP.Distributed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        protected readonly IVentaService VentaService;
        protected readonly IMapper Mapper;

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(VentasController));

        public VentasController(IVentaService ventaService, IMapper mapper)
        {
            VentaService = ventaService;
            Mapper = mapper;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateVenta([FromBody] VentaCreateRequest venta)
        {
            Log.Info($"Init: run CreateVenta Venta");
            var response = await VentaService.Post(venta);
            return !response.IsValid
                ? StatusCode(response.AuditResponse.StatusCode, response)
                : Ok(response);
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetVentas()
        {
            Log.Info($"Init: run GetVentas Venta");
            var response = await VentaService.GetAllVentas();
            return !response.IsValid
                ? StatusCode(response.AuditResponse.StatusCode, response)
                : Ok(response);
        }
    } 
}
