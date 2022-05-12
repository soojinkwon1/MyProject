using Microsoft.AspNetCore.Mvc;
using MyWebSite.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MyWebSite.Data;

namespace MyWebSite.Controllers
{
    public class HomeController : Controller
    {

        private readonly MyWebSiteContext _context;

        public HomeController(MyWebSiteContext context)
        {

            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new ListModel();
            model.SkillModel = await _context.Skill.ToListAsync();
            model.ArticleModel = await _context.Article.ToListAsync();
            model.ExperienceModel = await _context.Experience.ToListAsync();
            model.PortfolioModel = await _context.Portfolio.ToListAsync();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}