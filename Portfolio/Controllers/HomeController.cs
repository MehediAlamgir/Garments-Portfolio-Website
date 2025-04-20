using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;
using Portfolio.Services;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CompanyProfile()
        {
            return View();
        }

        public async Task<IActionResult> Products()
        {
            var images = await _context.ProductImages.ToListAsync();
            return View(images);
        }

        public IActionResult Quality()
        {
            return View();
        }

        public IActionResult Inquiry()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inquiry(Inquiry inquiry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inquiry);
                await _context.SaveChangesAsync();

                // Send email notification
                var emailService = HttpContext.RequestServices.GetService<IEmailService>();
                var emailBody = $"New inquiry from: {inquiry.CompanyName}<br>Contact: {inquiry.FirstName} {inquiry.LastName}<br>Email: {inquiry.Email}<br>Phone: {inquiry.PhoneNumber}<br><br>Details:<br>{inquiry.InquiryDetails}";
                
                await emailService.SendEmailAsync(
                    "misuk32@gmail.com", // Your email address
                    $"New Inquiry from {inquiry.CompanyName}",
                    emailBody);

                return RedirectToAction(nameof(InquiryConfirmation));
            }
            return View(inquiry);
        }

        public IActionResult InquiryConfirmation()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
