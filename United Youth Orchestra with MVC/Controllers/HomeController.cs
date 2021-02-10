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
using SendGrid;
using SendGrid.Helpers.Mail;

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
            //Execute().Wait();
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        static async Task Execute()
        {
            /*var apiKey = Environment.GetEnvironmentVariable("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");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("yoshiki.tatsumi@gmail", "pyoshi19561020");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("yoshiki.tatsumi3@gmail.com", "pyoshi19561020");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);*/

            var apiKey = System.Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            Console.WriteLine(apiKey);
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("yoshiki.tatsumi@gmail", "DX Team"),
                Subject = "Hello World from the SendGrid CSharp SDK!",
                PlainTextContent = "Hello, Email!",
                HtmlContent = "<strong>Hello, Email!</strong>"
            };
            msg.AddTo(new EmailAddress("yoshiki.tatsumi3@gmail", "Test User"));
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
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

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,

                EnableSsl = true,

                Credentials = new System.Net.NetworkCredential("yoshiki.tatsumi@gmail.com", "pyoshi19561020"),
                UseDefaultCredentials = false
            };

         //   smtp.Send(mm);
            ViewBag.Message = "Mail has been sent successfully!";

             


            return View();


        }



    }

    



}
