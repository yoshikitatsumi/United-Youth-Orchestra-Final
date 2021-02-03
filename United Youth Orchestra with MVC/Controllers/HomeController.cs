using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using United_Youth_Orchestra_with_MVC.Models;
using System.Net;
using System.Net.Mail;

namespace United_Youth_Orchestra_with_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        // adding Policy page
        public IActionResult Policy()
        {
            return View();
        }

        // adding Policy page
        public IActionResult about()
        {
            return View();
        }

        // adding NextEvent page
        public IActionResult NextEvent()
        {
            return View();
        }
        // adding Gallery page
        public IActionResult Gallery()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Email(United_Youth_Orchestra_with_MVC.Models.Email em)
        {
            //string to = em.To;
            //string subject = em.Subject;
            //string body = em.Body;

            MailMessage mm = new MailMessage();
            mm.Subject = em.Subject;
            mm.Body = em.Body;
            mm.From = new System.Net.Mail.MailAddress("yoshiki.tatsumi@gmail.com");
            mm.To.Add("yoshiki.tatsumi3@gmail.com");
            mm.IsBodyHtml = false;

            //System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("mail.gmail.com", 155);
            //System.Net.NetworkCredential mycredentials = new System.Net.NetworkCredential("yoshiki.tatsumi@gmail.com", "pyoshi19561020");
            //client.UseDefaultCredentials = false;
            //client.Credentials = mycredentials;

            //var host = "mail-proxy.gmail.com";
            //var cred = new NetworkCredential("yoshiki.tatsumi@gmail.com", "pyoshi19561020");
            //var cache = new CredentialCache();
            //cache.Add(host, 25, "Basic", cred);
            //client.Credentials = cache;
            //client.Send(mm);

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;

            smtp.EnableSsl = true;

            smtp.Credentials = new System.Net.NetworkCredential("yoshiki.tatsumi@gmail.com", "pyoshi19561020");
            smtp.UseDefaultCredentials = false;

            smtp.Send(mm);
            ViewBag.Message = "Mail has been sent successfully!";
            return View();
        }

    }

}
