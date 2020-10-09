using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OficinaTcc.MailService
{
    public interface IServicoEmail
    {
        public Task SendAsync(IdentityMessage message);
    }
    public class ServicoEmail : IIdentityMessageService, IServicoEmail
    {
        private readonly IConfiguration configuration;
        public ServicoEmail(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendAsync(IdentityMessage message)
        {
            using (var mensagemEmail = new MailMessage())
            {
                string email = configuration.GetConnectionString("Email");
                string emailSenha = configuration.GetConnectionString("EmailSenha");

                mensagemEmail.From = new MailAddress(email);

                mensagemEmail.Subject = message.Subject;
                mensagemEmail.To.Add(message.Destination);
                mensagemEmail.Body = message.Body;

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new NetworkCredential(email, emailSenha);

                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;

                    smtpClient.Timeout = 20000;

                    await smtpClient.SendMailAsync(mensagemEmail);
                }
            }
        }
    }

}
