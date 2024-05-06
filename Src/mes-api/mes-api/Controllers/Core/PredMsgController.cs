using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("core/predmsg")]
    [EnableCors("AllowAnyOrigin")]
    public class PredMsgController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IPredMsgService _predMsgService;

        public PredMsgController(IPredMsgService predMsgService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(PredMsgController));
            _predMsgService = predMsgService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<PredMsg>> Get()
        {
            try
            { 
                var predMsgs = _predMsgService.GetAll();
                return Ok(predMsgs);
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
        public ActionResult<PredMsg> Get(int id)
        {
            try
            {
                var predMsg = _predMsgService.GetById(id);
                return Ok(predMsg);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // POST api/values
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        public IActionResult Post([FromBody] PredMsg predMsg)
        {
            try
            {
                if (predMsg == null)
                    return BadRequest();

                predMsg.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    predMsg.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _predMsgService.Create(predMsg);
                return Created();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        public IActionResult Put(int id, [FromBody] PredMsg predMsg)
        {
            try
            {
                if (id.ToString() != predMsg.Id)
                    return BadRequest("Id mismatch");

                var predMsgToUpdate = _predMsgService.GetById(id);

                if (predMsgToUpdate == null)
                    return NotFound($"PredMsg with Id = {id} not found");

                predMsg.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    predMsg.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _predMsgService.Update(predMsg);
                return Created();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                var predMsgToDelete = _predMsgService.GetById(id);

                if (predMsgToDelete == null)
                    return NotFound($"PredMsg with Id = {id} not found");

                _predMsgService.Delete(id);
                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }
    }
}

