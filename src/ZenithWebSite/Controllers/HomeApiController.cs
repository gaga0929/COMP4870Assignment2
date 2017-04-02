using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithWebSite.Models.ZenithModels;
using ZenithWebSite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenithWebSite.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("CorsPolicy")]
    public class HomeApiController : Controller
    {
        private ApplicationDbContext _context;

        public HomeApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            DateTime startOfWeek = DateTime.Today;
            while (startOfWeek.DayOfWeek != DayOfWeek.Monday) startOfWeek = startOfWeek.AddDays(-1);
            DateTime endOfWeek = DateTime.Today;
            while (endOfWeek.DayOfWeek != DayOfWeek.Sunday) endOfWeek = endOfWeek.AddDays(1);
            endOfWeek = endOfWeek.AddHours(23).AddMinutes(59);
            var events = _context.Events.Where(p => (p.EventStart >= startOfWeek && p.EventStart <= endOfWeek) && p.IsActive).Include(p => p.ActivityDetails);
            return events.ToList();
        }
    }
}
