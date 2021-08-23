
using CuaHangBanMoHinh.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace CuaHangBanMoHinh.Common
{ 
    public class LienHe
    {
        public static bool SendMail(ContactViewModel model)
        {
            SmtpClient smtp = new SmtpClient();
            try
            {
                //ĐỊA CHỈ SMTP Server
                smtp.Host = "smtp.gmail.com";
                //Cổng SMTP
                smtp.Port = 587;
                //SMTP yêu cầu mã hóa dữ liệu theo SSL
                smtp.EnableSsl = true;
                //UserName và Password của mail
                smtp.Credentials = new NetworkCredential("khanhnhu270101@gmail.com", "27012701");
                String message = "Mail send from " + model.Name + "\n" +
                  "Phone: " + model.Phone + "\n" + model.Content;


                //Tham số lần lượt là địa chỉ người gửi, người nhận, tiêu đề và nội dung thư
                smtp.Send(model.Email, "nhuloveanime@gmail.com", "Contact from " + model.Name, message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}