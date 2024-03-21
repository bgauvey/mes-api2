using System.Net.Mime;
using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces;
using BOL.API.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core;

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
            return BadRequest(new { Status = false, Message = exp.Message });
        }
    }

    // GET api/values/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Ent> Get(int id)
    {
        
        try
        {
            var ent = _entService.GetEntById(id);
            return Ok(ent);

        }
        catch (Exception exp)
        {
            _logger.LogError(exp.Message);
            return BadRequest(new { Status = false, Message = exp.Message });
        }
    }

    // POST api/values
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize]
    public IActionResult Post([FromBody]Ent entity)
    {
        try
        {
            _entService.Create(entity);
            return Created();
        }
        catch (Exception exp)
        {
            _logger.LogError(exp.Message);
            return BadRequest(new { Status = false, Message = exp.Message});
        }
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize]
    public IActionResult Put(int id, [FromBody]Ent entity)
    {
        try
        {
            _entService.Update(entity);
            return Created();
        }
        catch (Exception exp)
        {
            _logger.LogError(exp.Message);
            return BadRequest(new { Status = false, Message = exp.Message });
        }
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Authorize]
    public IActionResult Delete(int id)
    {
        try
        {
            _entService.Delete(id);
            return NoContent();
        }
        catch (Exception exp)
        {
            _logger.LogError(exp.Message);
            return BadRequest(new { Status = false, Message = exp.Message });
        }
    }

    // GET ent/files/5
    [HttpGet("files/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IEnumerable<EntFile>> GetFiles(int id)
    {
        try
        {
            var files = _entService.GetFiles(id);
            return Ok(files);
        }
        catch (Exception exp)
        {
            _logger.LogError(exp.Message);
            return BadRequest(new { Status = false, Message = exp.Message });
        }
    }


    // GET ent/attrs/5
    [HttpGet("attrs/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<IEnumerable<EntityAttribute>> GetAttrs(int id)
    {
        try
        {
            var attrs = _entService.GetAttrs(id);
            return Ok(attrs);
        }
        catch (Exception exp)
        {
            _logger.LogError(exp.Message);
            return BadRequest(new { Status = false, Message = exp.Message });
        }
    }
}

