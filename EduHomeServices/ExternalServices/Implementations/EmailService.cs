using EduHomeServices.ExternalServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EduHomeServices.ExternalServices.Implementations
{
    public class EmailService : IEmailService
    {
        public async Task SendEmail(string to, string subject, string body)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("pm4283719@gmail.com", "ddzrblqxpzyxysdu");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("pm4283719@gmail.com", "Karma App");
            mailMessage.To.Add(to);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;
            client.Send(mailMessage);
        }


        //public async Task SendEmail(string to, string subject, string body)
        //{
        //    try
        //    {
        //        // Your existing code for sending emails

        //        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
        //        // ... (rest of your code)

        //        client.Send(mailMessage);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log or handle the exception appropriately
        //        Console.WriteLine($"Error sending email: {ex.Message}");
        //        throw; // Rethrow the exception after logging or handling
        //    }
        //}
    }
}


