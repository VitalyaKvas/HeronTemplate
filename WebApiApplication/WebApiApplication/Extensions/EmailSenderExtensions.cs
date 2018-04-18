﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using WebApiApplication.Services.EmailSender;

namespace WebApiApplication.Extensions
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirm your email",
                $"Please confirm your account by clicking this link: <a href='{link}'>link</a>");
        }
    }
}