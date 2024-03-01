using Microsoft.AspNetCore.Mvc;
using EntityCRUD.Models;
using EntityCRUD.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EntityCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        // GET: api/<EntityController>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Entity>))]
        public IActionResult Get([FromQuery] string? search,
            [FromQuery] string? gender,
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] List<string>? countries,
            [FromQuery] int? pageNumber = 0,
            [FromQuery] int? pageSize = 5,
            [FromQuery] string? sortBy = "FirstName")
        {
            IEnumerable<Entity> selectedEntities = DataContext.entities.Where(entity =>
            {
                return IsFiltered(entity, gender, startDate, endDate, countries) && SearchMatch(search,entity);
            });
            IEnumerable<Entity> sortedEntities = new List<Entity>();
            if (sortBy == "FirstName")
            {
                sortedEntities = selectedEntities.OrderBy(entity => entity.Names[0].FirstName);
            }
            else if (sortBy == "Surname")
            {
                sortedEntities = selectedEntities.OrderBy(entity => entity.Names[0].Surname);
            }

            pageSize = Math.Min(100, pageSize.Value);
            return Ok(sortedEntities.Skip((pageNumber.Value -1) * pageSize.Value).Take(pageSize.Value));
        }

        private bool IsFiltered(Entity entity, string? gender, DateTime? startDate, DateTime? endDate, List<string>? countries)
        {
            if (countries != null && countries.Count == 0 && endDate == null && startDate == null && gender == null) return true;

            if (gender != null && entity.Gender == gender.Trim())
            {
                return true;
            }
            if(startDate != null || endDate != null)
            {
                if (startDate == null) startDate = DateTime.MinValue;
                if(endDate == null) endDate = DateTime.MaxValue;
                if(entity.Dates[0].Date >= startDate && entity.Dates[1].Date <= endDate)
                {
                    return true;
                }
            }
            if(countries.Count > 0)
            {
                if (entity.Addresses == null) return false;

                string concatCountries = "";
                foreach(var address in entity.Addresses)
                {
                    if (address.Country == null) continue;
                    concatCountries += address.Country + " ";
                }
                if(concatCountries == "") return false;
                foreach(var country in countries)
                {
                    if(concatCountries.Contains(country))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
        private bool SearchMatch(string? search, Entity entity)
        {
            if (search != null)
            {
                string concatString = "";
                foreach (var name in entity.Names)
                {
                    concatString += name.FirstName + " " + name.Surname + " " + name.MiddleName + " ";
                }
                if (entity.Addresses != null)
                {
                    foreach (var address in entity.Addresses)
                    {
                        concatString += address.AddressLine + " " + address.City + " ";
                    }
                }

                string[] searchWords = search.Split();
                foreach (string word in searchWords)
                {
                    if (concatString.Contains(word))
                    {
                        return true;
                    }
                }
                return false;
            }
            return true;
        }

        // GET api/<EntityController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Entity))]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            var entity = DataContext.entities.FirstOrDefault(x => x.Id == id.ToString());
            if (entity == null) NotFound(new {message = "Id does not exist"} );
            return Ok(entity);
        }

        // POST api/<EntityController>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Entity))]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] Entity entity)
        {
            if (entity == null) return BadRequest(new { message = " Object to be added is empty" });
            var existingEntity = DataContext.entities.FirstOrDefault(x => x.Id == entity.Id);
            if(existingEntity != null)
            {
                return BadRequest(new {message = " Entity with given id exists"});
            }
            DataContext.entities.Add(entity);
            return Ok(entity);
        }

        // PUT api/<EntityController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(Entity))]
        [ProducesResponseType(404)]
        public IActionResult Put(int id, [FromBody] Entity updatedEntity)
        {
            
            int index = DataContext.entities.FindIndex( entity => entity.Id == id.ToString());
            if(index == -1)
            {
                return NotFound(new { message = "Id does not exist" });
            }
            DataContext.entities[index] = updatedEntity;
            return Ok(updatedEntity);
        }

        // DELETE api/<EntityController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(Entity))]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            int index = DataContext.entities.FindIndex(entity => entity.Id == id.ToString());
            if (index == -1)
            {
                return NotFound(new { message = "Id does not exist" });
            }
            DataContext.entities.RemoveAt(index);
            return Ok(new {message ="Entity Removed"});
        }
    }
}
