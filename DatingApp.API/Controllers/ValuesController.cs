using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext Context;

        public ValuesController(DataContext context)
        {
            Context = context;
        }

        // GET: api/Values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await Context.Values.ToListAsync();
            return Ok(values);
        }

        // GET: api/Values/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await Context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }

        // POST: api/Values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
