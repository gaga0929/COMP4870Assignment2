using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithWebSite.Data;
using ZenithWebSite.Models.ZenithModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenithWebSite.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("CorsPolicy")]
    [Authorize]
    public class ActivitiesApiController : Controller
    {
        private ApplicationDbContext _context;

        public ActivitiesApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Activity> Get()
        {
            return _context.Activities.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Activity Get(int id)
        {
            return _context.Activities.FirstOrDefault(s => s.ActivityId == id); 
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Activity activity)
        {
            if (ModelState.IsValid)
            {
                _context.Activities.Add(activity);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Activity activity)
        {
            if (ModelState.IsValid)
            {
                _context.Activities.Update(activity);
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
                var activity = _context.Activities.FirstOrDefault(t => t.ActivityId == id);
                if (activity != null)
                {
                    _context.Activities.Remove(activity);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
