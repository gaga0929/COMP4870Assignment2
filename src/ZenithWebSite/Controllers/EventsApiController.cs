using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithWebSite.Data;
using ZenithWebSite.Models.ZenithModels;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenithWebSite.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
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
            return _context.Events.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Event Get(int id)
        {
            return _context.Events.FirstOrDefault(s => s.EventId == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Event value)
        {
            _context.Events.Add(value);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Event value)
        {
            _context.Events.Update(value);
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var value = _context.Events.FirstOrDefault(t => t.EventId == id);
            if (value != null)
            {
                _context.Events.Remove(value);
                _context.SaveChanges();
            }
        }
    }
}
