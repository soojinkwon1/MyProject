using Microsoft.AspNetCore.Mvc;
using MyWebSite.Models;
using MyWebSite.Data;


namespace MyWebSite.Controllers
{
    public class ContactController : Controller
    {
        private readonly MyWebSiteContext _context;
        public ContactController(MyWebSiteContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        /*[Route("/contact-test")]*/
        [HttpPost]
        public IActionResult LeaveMessage(string fullName, string email, string message)
        {

            _context.Message.Add(new Message()
                {
                    FullName = fullName,
                    Email = email,
                    Body = message,
                    CreatedAt = DateTime.Now
                }
            );
            try
            {
                _context.SaveChanges();
                ViewData["msg"] = $"A message from {fullName}, {email} has been sent successfully. <br /> Message Body: {message}";
            }
            catch (Exception ex)
            {

                ViewData["msg"] = $"Some thing went wrong.{ex.Message}";
            }


            return View();

        }
    }
}
