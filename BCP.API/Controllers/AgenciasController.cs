using AutoMapper;
using BCP.META.Application.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BCP.Distributed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciasController : ControllerBase
    {
        protected readonly IAgenciaService AgenciaService;
        protected readonly IMapper Mapper;

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(AgenciasController));

        public AgenciasController(IAgenciaService agenciaService, IMapper mapper)
        {
            AgenciaService = agenciaService;
            Mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            Log.Info($"Init: run GetAll Agencias");
            var response = await AgenciaService.GetAllAgencias();
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
            var response = await AgenciaService.GetAgenciaById(id);
            return !response.IsValid
                ? StatusCode(response.AuditResponse.StatusCode, response)
                : Ok(response);
        }
    }
}
