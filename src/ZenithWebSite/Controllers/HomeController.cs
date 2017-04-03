﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ZenithWebSite.Data;
using Microsoft.EntityFrameworkCore;

namespace ZenithWebSite.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            DateTime startOfWeek = DateTime.Today;
            while (startOfWeek.DayOfWeek != DayOfWeek.Monday) startOfWeek = startOfWeek.AddDays(-1);
            DateTime endOfWeek = DateTime.Today;
            while (endOfWeek.DayOfWeek != DayOfWeek.Sunday) endOfWeek = endOfWeek.AddDays(1);
            endOfWeek = endOfWeek.AddHours(23).AddMinutes(59);
            var events = _context.Events.Where(p => (p.EventStart >= startOfWeek && p.EventStart <= endOfWeek) && p.IsActive).Include(p => p.ActivityDetails);
            return View(events.ToList());
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
