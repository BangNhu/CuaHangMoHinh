using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace CuaHangBanMoHinh.Models
{
    public class MailHelper
    {
        public void SendMail(string toEmailAddress, string subject, string content)
        {
            var mail = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("khanhnhu270101@gmail.com", "27012701"),

                EnableSsl = true
            };
            //Tạo email
            string body = content;

            var message = new MailMessage();
            message.From = new MailAddress("khanhnhu270101@gmail.com");
            message.ReplyToList.Add("khanhnhu270101@gmail.com");
            message.To.Add(new MailAddress(toEmailAddress));
            message.Body = body;
            message.Subject = subject;
            message.IsBodyHtml = true;
            mail.Send(message);
        }

    }
}

