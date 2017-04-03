using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithWebSite.Data;
using ZenithWebSite.Models.ZenithModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenithWebSite.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("CorsPolicy")]
    //[Authorize]
    public class EventsApiController : Controller
    {
        private ApplicationDbContext _context;

        public EventsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            var events = _context.Events.Include(p => p.ActivityDetails);
            return events.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Event Get(int id)
        {
            var events = _context.Events.Include(p => p.ActivityDetails);
            return events.FirstOrDefault(s => s.EventId == id);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Event value)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(value);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Event value)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Update(value);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var value = _context.Events.FirstOrDefault(t => t.EventId == id);
                if (value != null)
                {
                    _context.Events.Remove(value);
                    _context.SaveChanges();
                }
                return Ok();
            }
            return BadRequest();
        }
    }
}
