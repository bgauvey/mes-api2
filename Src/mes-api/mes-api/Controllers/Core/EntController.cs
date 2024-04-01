using System;
using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces;
using BOL.API.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("ent")]
    [EnableCors("AllowAnyOrigin")]
    public class EntController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IEntService _entService;

        public EntController(IEntService entService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(EntController));
            _entService = entService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<Ent>> Get()
        {
            try
            {
                var ents = _entService.GetAll();
                return Ok(ents);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // GET api/values/5
        [HttpGet("{entId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Ent> Get(int entId)
        {
            try
            {
                var ent = _entService.GetEntById(entId);
                return Ok(ent);

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
        [Authorize]
        public IActionResult Post([FromBody] Ent entity)
        {
            try
            {
                if (entity == null)
                    return BadRequest();

                entity.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    entity.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _entService.Create(entity);
                return Created();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // PUT api/values/5
        [HttpPut("{entId}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public IActionResult Put(int entId, [FromBody] Ent entity)
        {
            try
            {
                if (entId != entity.EntId)
                    return BadRequest("EntId mismatch");

                var entToUpdate =  _entService.GetEntById(entId);

                if (entToUpdate == null)
                    return NotFound($"Entity with EntId = {entId} not found");

                entity.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    entity.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _entService.Update(entity);
                return Created();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // DELETE api/values/5
        [HttpDelete("{entId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public IActionResult Delete(int entId)
        {
            try
            {
                var entToDelete = _entService.GetEntById(entId);

                if (entToDelete == null)
                    return NotFound($"Entity with EntId = {entId} not found");

                _entService.Delete(entId);
                return NoContent();
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // GET ent/files/5
        [HttpGet("files/{entId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<EntFile>> GetFiles(int entId)
        {
            try
            {
                var ent = _entService.GetEntById(entId);

                if (ent == null)
                    return NotFound($"Entity with EntId = {entId} not found");

                var files = _entService.GetFiles(entId);
                return Ok(files);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        // GET ent/attrs/5
        [HttpGet("attrs/{entId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<EntityAttribute>> GetAttrs(int entId)
        {
            try
            {
                var ent = _entService.GetEntById(entId);

                if (ent == null)
                    return NotFound($"Entity with EntId = {entId} not found");

                var attrs = _entService.GetAttrs(entId);
                return Ok(attrs);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpGet("GetAllTopLevel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllTopLevelAsync()
        {
            try
            {
                var data = await _entService.GetAllTopLevelAsync();

                return Ok(data);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpGet("GetShiftSchedEntities/{entId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetShiftSchedEntitiesAsync(int entId)
        {
            try
            {
                var data = await _entService.GetShiftSchedEntitiesAsync(entId);

                return Ok(data);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpGet("GetShiftTemplates")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetShiftTemplatesAsync(int entId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var data = await _entService.GetShiftTemplatesAsync(entId, startDate, endDate);

                return Ok(data);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpGet("GetStatusInfo/{entId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetStatusInfoAsync(int entId, int childLevels)
        {
            try
            {
                var data = await _entService.GetStatusInfoAsync(entId, childLevels);

                return Ok(data);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpGet("GetStatusInfoByUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetStatusInfoByUser(int sessionId, string userId)
        {
            try
            {
                var data = await _entService.GetStatusInfoByUserAsync(sessionId, userId);

                return Ok(data);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpPost("DoAutoShiftChanges/{entId}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DoAutoShiftChangesAsync(int entId)
        {
            try
            {
                await _entService.DoAutoShiftChangesAsync(entId);

                return NoContent();

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }
        
        [HttpPost("DoPastShiftChanges")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DoPastShiftChangesAsync()
        {
            try
            {
                var data = await _entService.DoPastShiftChangesAsync();

                return NoContent();

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpPost("StartShift")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> StartShiftAsync(int entId, int shiftId, DateTime shiftStart)
        {
            try
            {
                var data = await _entService.StartShiftAsync(entId, shiftId, shiftStart);

                return NoContent();

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpPost("RefreshShiftSched")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RefreshShiftSchedAsync(int entId, DateTime startTime, int daysAhead)
        {
            try
            {
                var data = await _entService.RefreshShiftSchedAsync(entId, startTime, daysAhead);

                return Ok(data);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpGet("GetRefreshShiftSched")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetRefreshShiftSchedAsync(int entId, DateTime startTime, int daysAhead)
        {
            try
            {
                var data = await _entService.GetRefreshShiftSchedAsync(entId, startTime, daysAhead);

                return Ok(data);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpGet("GetShiftSchedules")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetShiftSchedulesAsync(int entId, DateTime startTime, DateTime endTime)
        {
            try
            {
                var data = await _entService.GetShiftSchedulesAsync(entId, startTime, endTime);

                return Ok(data);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }

        [HttpPost("Clone")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Ent>> CloneAsync(int entId, string newEntName)
        {
            try
            {
                var data = await _entService.CloneAsync(entId, newEntName);

                return Created(Url.RouteUrl(data.EntId), data);

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new { Status = false, exp.Message });
            }
        }
    }
}