#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWebSite.Data;
using MyWebSite.Models;

namespace MyWebSite.Controllers
{
   /* [Route("/admin/[controller]/[action]")] */
    public class ExperiencesController : Controller
    {
        private readonly MyWebSiteContext _context;

        public ExperiencesController(MyWebSiteContext context)
        {
            _context = context;
        }

        // GET: Experiences
        public async Task<IActionResult> Index()
        {
            return View(await _context.Experience.ToListAsync());
        }

        // GET: Experiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience = await _context.Experience
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);
        }

        private bool ExperienceExists(int id)
        {
            return _context.Experience.Any(e => e.Id == id);
        }
    }
}
