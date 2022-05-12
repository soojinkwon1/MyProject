#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MyWebSite.Data;
using MyWebSite.Models;
using PagedList;


namespace MyWebSite.Controllers
{
   /* [Route("/admin/[controller]/[action]")] */
    public class AdminController : Controller
    {
        private readonly MyWebSiteContext _context;

        private PagedList<Message> messages;

        public AdminController(MyWebSiteContext context)
        {
            _context = context;
        }

        // GET: Admin/Messages
        [Authorize]
        public async Task<IActionResult> Messages(int page=1)
        {
            int pageIndex = page;
            int pageSize = 10;


            IQueryable<Message> messageIQ = from m in _context.Message select m;

            int count = await messageIQ.CountAsync();


            messageIQ = messageIQ.OrderByDescending(m => m.CreatedAt);

            messages = await PagedList<Message>.CreateAsync(messageIQ.AsNoTracking(),pageIndex, pageSize);

            return View(messages);
        }

    }
}
