using System.Net.Mime;
using System.Security.Claims;
using BOL.API.Domain.Models.Prod;
using BOL.API.Service.Interfaces.Prod;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace bol.api.Controllers.Core
{
    [Route("core/itemgrade")]
    [EnableCors("AllowAnyOrigin")]
    public class ItemGradeController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IItemGradeService _itemGradeService;

        public ItemGradeController(IItemGradeService itemGradeService, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger(nameof(ItemGradeController));
            _itemGradeService = itemGradeService;
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<ItemGrade>> Get()
        {
            try
            { 
                var itemGrades = _itemGradeService.GetAll();
                return Ok(itemGrades);
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
        public ActionResult<ItemGrade> Get(int id)
        {
            try
            {
                var itemGrade = _itemGradeService.GetById(id);
                return Ok(itemGrade);

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
        public IActionResult Post([FromBody] ItemGrade itemGrade)
        {
            try
            {
                if (itemGrade == null)
                    return BadRequest();

                itemGrade.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    itemGrade.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _itemGradeService.Create(itemGrade);
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
        public IActionResult Put(int id, [FromBody] ItemGrade itemGrade)
        {
            try
            {
                if (id != itemGrade.ItemGradeCd)
                    return BadRequest("ItemGradeCd mismatch");

                var itemGradeToUpdate = _itemGradeService.GetById(id);

                if (itemGradeToUpdate == null)
                    return NotFound($"ItemGrade with ItemGradeCd = {id} not found");

                itemGrade.LastEditAt = DateTime.Now.ToUniversalTime();
                if (ClaimsPrincipal.Current != null)
                    itemGrade.LastEditBy = ClaimsPrincipal.Current.Identity.Name;

                _itemGradeService.Update(itemGrade);
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
                var itemGradeToDelete = _itemGradeService.GetById(id);

                if (itemGradeToDelete == null)
                    return NotFound($"ItemGrade with ItemGradeCd = {id} not found");

                _itemGradeService.Delete(id);
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

