using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiApplication.Services.EmailSender
{
    public class EmailSettings
    {
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPass { get; set; }
        public string EmailFrom { get; set; }
        public bool Credentials { get; set; }
        public bool Ssl { get; set; }
    }
}
