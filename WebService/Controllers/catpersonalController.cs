using Microsoft.AspNetCore.Mvc;
using WebService.DataAccess;
using WebService.Models;

namespace WebService.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class catpersonalController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public catpersonalController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        public ActionResult<IEnumerable<catpersonal>> Get()
        {
            return _dataAccessProvider.Getpersonal();
        }

        [HttpGet("{id}")]
        public ActionResult<catpersonal> Get(int id)
        {
            var personal = _dataAccessProvider.GetpersonaloById(id);

            if (personal == null)
            {
                return NotFound();
            }

            return Ok(personal);
        }

        public ActionResult<catpersonal> Post([FromBody] catpersonal personal)
        {
            if (personal == null || string.IsNullOrEmpty(personal.nombre))
            {
                return BadRequest("Nombre requerido.");
            }

            _dataAccessProvider.Agregarpersonal(personal);

            return CreatedAtAction(nameof(Get), new { id = personal.id }, personal);
        }
    }
}
