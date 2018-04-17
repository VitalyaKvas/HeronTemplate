using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace WebApiApplication.Services.EmailSender
{
    /// <summary>
    /// This class is used by the application to send email for account confirmation and password reset.
    /// For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    /// </summary>
    public class FakeEmailSender : IEmailSender
    {
        /// <summary>
        /// This property stores configuration for email settings.
        /// </summary>
        private readonly EmailSettings emailSettings;

        /// <summary>
        /// Property used to perform logging.
        /// </summary>
        private ILogger logger { get; set; }

        /// <summary>
        /// Creates a new instance with the given value.
        /// </summary>
        /// <param name="emailSettings">EmailSettings</param>
        /// <param name="logger">ILogger</param>
        public FakeEmailSender(IOptions<EmailSettings> emailSettings, ILogger<FakeEmailSender> logger)
        {
            this.emailSettings = emailSettings.Value;
            this.logger = logger;
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
                logger.LogWarning(
                    $"FakeEmailSender: {Environment.NewLine}" +
                    $"From: {emailSettings.EmailFrom} {Environment.NewLine}" +
                    $"To: {emailTo} {Environment.NewLine}" +
                    $"Subject: {subject} {Environment.NewLine}" +
                    $"Body: {body} {Environment.NewLine}");
            });
        }
    }
}
