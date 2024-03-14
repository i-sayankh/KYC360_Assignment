using KYC360_Assignment.Data;
using KYC360_Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace KYC360_Assignment.Controllers
{
    [Route("api/EntityAPI")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EntityController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Entity>> GetRecords()
        {
            return Ok(_context.Entities);
        }

        [HttpGet("{id}", Name = "GetRecord")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Entity> GetRecord(string id)
        {
            var record = _context.Entities.FirstOrDefault(e => e.Id == id);
            if (record == null)
            {
                return NotFound();
            }

            return Ok(record);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Entity> CreateRecord([FromBody] Entity entity)
        {
            if (entity == null)
            {
                return BadRequest(entity);
            }

            if (_context.Entities.FirstOrDefault(u => u.Id == entity.Id) != null)
            {
                ModelState.AddModelError("CustomError", "Record already exists!!!");
                return BadRequest(entity);
            }

            foreach (var address in entity.Addresses)
            {
                address.Id = 0;
            }
            foreach (var date in entity.Dates)
            {
                date.Id = 0;
            }
            foreach (var name in entity.Names)
            {
                name.Id = 0;
            }

            Entity model = new Entity
            {
                Id = entity.Id,
                Names = entity.Names,
                Addresses = entity.Addresses,
                Dates = entity.Dates,
                Gender = entity.Gender,
                Deceased = entity.Deceased
            };

            _context.Entities.Add(model);
            _context.SaveChanges();

            return CreatedAtRoute("GetRecord", new { id = entity.Id }, entity);
        }

        [HttpDelete("{id}", Name = "DeleteRecord")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteRecord(string id)
        {
            if (id == "0") return BadRequest();

            var record = _context.Entities.FirstOrDefault(e => e.Id == id);
            if (record == null) return NotFound();

            _context.Entities.Remove(record);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}", Name = "UpdateRecord")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateRecord(string id, [FromBody] Entity entity)
        {
            if(id == "0" || id != entity.Id) return BadRequest();

            foreach (var address in entity.Addresses)
            {
                address.Id = 0;
            }
            foreach (var date in entity.Dates)
            {
                date.Id = 0;
            }
            foreach (var name in entity.Names)
            {
                name.Id = 0;
            }

            Entity model = new Entity
            {
                Id = entity.Id,
                Names = entity.Names,
                Addresses = entity.Addresses,
                Dates = entity.Dates,
                Gender = entity.Gender,
                Deceased = entity.Deceased
            };

            _context.Entities.Update(model);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
