using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace VoipProjectEntities.Identity.Services
{
    public class SendEmail
    {
        public void SendEmailTo(string Email, string Body)
        {
            MailMessage mm = new MailMessage("krunalrane.98@gmail.com", Email);
            mm.Subject = "Reset Your password";
            mm.IsBodyHtml = true;
            //mm.Body = "Click link below to Reset Password \n\n https://localhost:44397/Customer/ResetPassword";
            mm.Body = Body;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            //SmtpClient smtpClient = new SmtpClient("smtp", 587);
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("t.anagha8@gmail.com", "fxzvubrlltfgniwk");
            smtpClient.EnableSsl = true;

            //smtpClient.UseDefaultCredentials = true;
            smtpClient.Send(mm);
        }
    }
}
