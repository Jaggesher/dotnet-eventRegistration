using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace dotnet_eventRegistration.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("7a55c64e47cd6a", "02697fee8787b9"),
                EnableSsl = true
            };

            client.Send("Jaggesher14@gmail.com", email, subject, message);
            
            return Task.CompletedTask;
            
        }
    }
}
