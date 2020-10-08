using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaTcc.MailService
{
    public class Envio
    {
        private readonly SendGridClient client;
        public Envio()
        {
            client = new SendGridClient("");
        }
        public async void send()
        {
            var emailMessage = new SendGridMessage()
            {
                Subject = "o tinker é viado",
                HtmlContent = "<h1>estágiario de merda</h1>"
            };
            emailMessage.AddTo(new EmailAddress("patrick.campos55@gmail.com"));
            var response = await client.SendEmailAsync(emailMessage);
        }
    }

}
