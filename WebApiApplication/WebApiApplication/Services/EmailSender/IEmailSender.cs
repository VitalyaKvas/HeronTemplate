using System.Threading.Tasks;

namespace WebApiApplication.Services.EmailSender
{
    /// <summary>
    /// This interface is used by the application to send email for account confirmation and password reset.
    /// For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Sends email to the user
        /// </summary>
        /// <param name="emailTo">Email address</param>
        /// <param name="subject">Subject</param>
        /// <param name="body">Body</param>
        /// <returns>Task</returns>
        Task SendEmailAsync(string emailTo, string subject, string body);
    }
}
