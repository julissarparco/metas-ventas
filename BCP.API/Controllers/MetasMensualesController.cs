using AutoMapper;
using BCP.META.Application.DTO;
using BCP.META.Application.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BCP.Distributed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetasMensualesController : ControllerBase
    {
        protected readonly IMetaMensualService MetaMensualService;
        protected readonly IMapper Mapper;

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(MetasMensualesController));

        public MetasMensualesController(IMetaMensualService metaMensualService, IMapper mapper)
        {
            MetaMensualService = metaMensualService;
            Mapper = mapper;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateMetaMensual([FromBody] MetaMensualCreateRequest metaMensual)
        {
            Log.Info($"Init: run CreateMetaMensual MetaMensual");
            var response = await MetaMensualService.Post(metaMensual);
            return !response.IsValid
                ? StatusCode(response.AuditResponse.StatusCode, response)
                : Ok(response);
        }
    }
}
