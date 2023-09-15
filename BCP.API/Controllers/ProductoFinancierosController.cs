using AutoMapper;
using BCP.META.Application.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BCP.Distributed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoFinancierosController : ControllerBase
    {
        protected readonly IProductoComercialService ProductoComercialService;
        protected readonly IMapper Mapper;

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(AgenciasController));

        public ProductoFinancierosController(IProductoComercialService productoComercialService, IMapper mapper)
        {
            ProductoComercialService = productoComercialService;
            Mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            Log.Info($"Init: run GetAll Agencias");
            var response = await ProductoComercialService.GetAllProductos();
            return !response.IsValid
                ? StatusCode(response.AuditResponse.StatusCode, response)
                : Ok(response);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            Log.Info($"Init: run GetById Agencias");
            var response = await ProductoComercialService.GetProductoById(id);
            return !response.IsValid
                ? StatusCode(response.AuditResponse.StatusCode, response)
                : Ok(response);
        }
    }
}
