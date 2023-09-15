using AutoMapper;
using BCP.META.Application.DTO;
using BCP.META.Application.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BCP.Distributed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        protected readonly IClienteService ClienteService;
        protected readonly IMapper Mapper;

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(ClientesController));

        public ClientesController(IClienteService clienteService, IMapper mapper)
        {
            ClienteService = clienteService;
            Mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            Log.Info($"Init: run GetAll Clientes");
            var response = await ClienteService.GetAllClientes();
            return !response.IsValid
                ? StatusCode(response.AuditResponse.StatusCode, response)
                : Ok(response);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            Log.Info($"Init: run GetById Clientes");
            var response = await ClienteService.GetClienteById(id);
            return !response.IsValid
                ? StatusCode(response.AuditResponse.StatusCode, response)
                : Ok(response);
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCliente([FromBody] ClienteCreateRequest cliente)
        {
            Log.Info($"Init: run CreateCliente Clientes");
            var response = await ClienteService.Post(cliente);
            return !response.IsValid
                ? StatusCode(response.AuditResponse.StatusCode, response)
                : Ok(response);
        }
    }
}
