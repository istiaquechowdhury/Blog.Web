﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Blog.Web.Models
{
    public interface IEmailSender
    {
        public void SendEmail(string email,string subject,string body);
    }
}
