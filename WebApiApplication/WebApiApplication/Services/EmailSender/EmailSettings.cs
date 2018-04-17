namespace WebApiApplication.Services.EmailSender
{
    /// <summary>
    /// Model for email seting
    /// </summary>
    public class EmailSettings
    {
        /// <summary>
        /// Name or IP address of the host used for SMTP transactions.
        /// </summary>
        public string SmtpHost { get; set; }

        /// <summary>
        /// Port used for SMTP transactions.
        /// </summary>
        public int SmtpPort { get; set; }

        /// <summary>
        /// The user name associated with the credentials.
        /// </summary>
        public string SmtpUser { get; set; }

        /// <summary>
        ///  The password for the user name associated with the credentials.
        /// </summary>
        public string SmtpPass { get; set; }

        /// <summary>
        /// The email address use for send email from.
        /// </summary>
        public string EmailFrom { get; set; }

        /// <summary>
        /// The credentials used to authenticate the sender.
        /// </summary>
        public bool Credentials { get; set; }

        /// <summary>
        /// Specify whether uses Secure Sockets Layer (SSL) to encrypt the connection.
        /// </summary>
        public bool Ssl { get; set; }
    }
}
