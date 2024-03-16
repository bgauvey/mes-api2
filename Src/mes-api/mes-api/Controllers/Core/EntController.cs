using BOL.API.Domain.Models.Core;
using BOL.API.Service.Interfaces;
using BOL.API.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core;

[Route("ent")]
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
    public IEnumerable<Ent> Get()
    {
        return _entService.GetAll();
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public Ent Get(int id)
    {
        return _entService.GetEntById(id);
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody]Ent entity)
    {
        _entService.Create(entity);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]Ent entity)
    {
        _entService.Update(entity);
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _entService.Delete(id);
    }

    // GET ent/files/5
    [HttpGet("files/{id}")]
    public IEnumerable<EntFile> GetFiles(int id)
    {
        return _entService.GetFiles(id);
    }


    // GET ent/attrs/5
    [HttpGet("attrs/{id}")]
    public IEnumerable<EntityAttribute> GetAttrs(int id)
    {
        return _entService.GetAttrs(id);
    }
}

