using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SAT.UI.MVC.Models;
using System.Net.Mail;
using System.Net;

namespace SAT.UI.MVC.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return View(cvm);
            }
            string body = $"{cvm.Name} has sent you the following message: <br />" + $"{cvm.Message} <strong>from the email address:</strong> {cvm.Email}";

            MailMessage m = new MailMessage("info@devem.com", "dplackard@outlook.com", cvm.Subject, body);
            MailAddress copy = new MailAddress("emma_lintz@outlook.com");
            m.CC.Add(copy);

            m.IsBodyHtml = true;

            m.Priority = MailPriority.High;

            m.ReplyToList.Add(cvm.Email);

            SmtpClient client = new SmtpClient("mail.devonplackard.com");

            //client.Credentials = new NetworkCredential()

            try
            {
                client.Send(m);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.StackTrace;
                return View(cvm);
            }

            return View("EmailConfirmation", cvm);
        }

    }


}