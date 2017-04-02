using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZenithWebSite.Data;
using ZenithWebSite.Models.ZenithModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ZenithWebSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            List<IdentityRole> roles = await _context.Roles.ToListAsync();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                var roleStore = new RoleStore<IdentityRole>(_context);
                await roleStore.CreateAsync(new IdentityRole { Name = role.Name, NormalizedName = role.Name });
                return RedirectToAction("Index");
            }
            return View(role);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roleStore = new RoleStore<IdentityRole>(_context);
            IdentityRole role = await roleStore.FindByIdAsync(id);
            
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var roleStore = new RoleStore<IdentityRole>(_context);
            IdentityRole role = await roleStore.FindByIdAsync(id);
            await roleStore.DeleteAsync(role);
            return RedirectToAction("Index");
        }

       
    }
}
