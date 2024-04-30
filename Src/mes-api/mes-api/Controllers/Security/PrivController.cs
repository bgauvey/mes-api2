using BOL.API.Domain.Models.Security;
using BOL.API.Service.Interfaces.Security;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("security/priv")]
    [EnableCors("AllowAnyOrigin")]
    public class PrivController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IPrivService _privService;

        public PrivController(IPrivService privService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(PrivController));
            _privService = privService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Priv>> Get()
        {
            try
            { 
                var privs = _privService.GetAll();
                return Ok(privs);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Priv> Get(int id)
        {
            try
            {
                var priv = _privService.GetById(id);
                return Ok(priv);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

    }
}

