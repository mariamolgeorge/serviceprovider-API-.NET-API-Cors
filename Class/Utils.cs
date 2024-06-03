using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net;
using System.IO;
using SendGrid;
using SendGrid.Helpers.Mail;
namespace InIT.API.GMMEP.Class
{
    public class Utils
    {
        public static string CreateOTP(int length)
        {
            const string valid = "1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
        public static string CreateAlphaNumeric(int length)
        {
            const string valid = "";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        public static bool SaveImage(string path, string base64string)
        {
            try
            {
                string filePath = HttpContext.Current.Server.MapPath(path);
                File.WriteAllBytes(filePath, Convert.FromBase64String(base64string.Split(',')[1]));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool SendMailotp(string toMail, string otp)
        {
            try
            {

                var Recipient = toMail;
                var apiKey = ""; 
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("", "BlueSky");
                var subject = "BlueSky Account -" + otp + " is your Password for secure access";
                var to = new EmailAddress(Recipient, "");
                var plainTextContent = "Hi,<br> Greetings! <br> You are just a step away from accessing your BlueSky account. <br> We are sharing a Password to access your account.<br> Your Password : <b>" + otp + "</b><br>Best Regards, <br> BlueSky App";
                var htmlContent = "Hi,<br> Greetings! <br> You are just a step away from accessing your BlueSky account. <br> We are sharing a Password to access your account.<br> Your Password : <b>" + otp + "</b><br>Best Regards, <br> BlueSky App";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = client.SendEmailAsync(msg);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}