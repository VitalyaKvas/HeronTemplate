using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebApiApplication.Services.EmailSender
{
    /// <summary>
    /// This class is used by the application to send email for account confirmation and password reset.
    /// For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    /// </summary>
    public class EmailSender : IEmailSender
    {
        /// <summary>
        /// This property stores configuration for email settings.
        /// </summary>
        private readonly EmailSettings emailSettings;

        /// <summary>
        /// Creates a new instance with the given value.
        /// </summary>
        /// <param name="emailSettings">EmailSettings</param>
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            this.emailSettings = emailSettings.Value;
        }

        /// <summary>
        /// Sends email to the user
        /// </summary>
        /// <param name="emailTo">Email address</param>
        /// <param name="subject">Subject</param>
        /// <param name="body">Body</param>
        /// <returns>Task</returns>
        public Task SendEmailAsync(string emailTo, string subject, string body)
        {
            return Task.Run(() =>
            {
                var smtpClient = new SmtpClient
                {
                    Host = emailSettings.SmtpHost,
                    Port = emailSettings.SmtpPort,
                    EnableSsl = emailSettings.Ssl,
                    UseDefaultCredentials = emailSettings.Credentials,
                    Credentials = new NetworkCredential()
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(emailSettings.EmailFrom)
                };
                mailMessage.To.Add(emailTo);
                mailMessage.Body = body;
                mailMessage.Subject = subject;

                smtpClient.Send(mailMessage);
            });
        }
    }
}
