using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography; 
using System.Text;
using Microsoft.Extensions.Configuration;
using Rs_71.Data.Models;

namespace Rs_71.BusinessLogic
{ 
        public enum eventzz 
        { 
        SUCCESSFUL_AUTHENTICATE_USER_ADD = 1,
FAILED_AUTHENTICATE_USER_ADD = 2,
ERROR_AUTHENTICATE_USER_ADD = 3,
SUCCESSFUL_AUTHENTICATE_USER_GET = 4,
FAILED_AUTHENTICATE_USER_GET = 5,
ERROR_AUTHENTICATE_USER_GET = 6,
SUCCESSFUL_AUTHENTICATE_USER_UPDATE = 7,
FAILED_AUTHENTICATE_USER_UPDATE = 8,
ERROR_AUTHENTICATE_USER_UPDATE = 9,
SUCCESSFUL_LISTING_SITE_ADD = 10,
FAILED_LISTING_SITE_ADD = 11,
ERROR_LISTING_SITE_ADD = 12,
SUCCESSFUL_LISTING_SITE_GET = 13,
FAILED_LISTING_SITE_GET = 14,
ERROR_LISTING_SITE_GET = 15,
SUCCESSFUL_LISTING_SITE_UPDATE = 16,
FAILED_LISTING_SITE_UPDATE = 17,
ERROR_LISTING_SITE_UPDATE = 18,
SUCCESSFUL_SKILL_ADD = 19,
FAILED_SKILL_ADD = 20,
ERROR_SKILL_ADD = 21,
SUCCESSFUL_SKILL_GET = 22,
FAILED_SKILL_GET = 23,
ERROR_SKILL_GET = 24,
SUCCESSFUL_SKILL_UPDATE = 25,
FAILED_SKILL_UPDATE = 26,
ERROR_SKILL_UPDATE = 27 
        } 
    public class Audit 
    {  
        public static void InsertAudit(EventLog newEvent, string callerFormName)
        {
            var context = Rs_71.Data.Models.Rs_71.GetInstance();
            try
            {
                context.Insert<EventLog>(newEvent);
            }
            catch (Exception ex)
            {
            
            }
        }
        public static void InsertAudit(int eventId, string eventDetails, long userId, bool userevent)
        { 
            EventLog audit = new EventLog();
            audit.Description =  eventDetails;
            audit.Eventid = eventId;
            audit.Userid = userId;
            audit.Userevent = userevent;
            audit.Eventdate = DateTime.Now;
            InsertAudit(audit, "");
        }
        public static string GetEncodedHash(string password, string salt)
        {
           MD5 md5 = new MD5CryptoServiceProvider();
           byte [] digest = md5.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
           string base64digest = Convert.ToBase64String(digest, 0, digest.Length);
           return base64digest.Substring(0, base64digest.Length-2);
        }

    public static  void protocol()

    {

        ServicePointManager.SecurityProtocol |= (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;

    }

        public static string SendMail(string email, string mailSubject, string mailBody, string callerFormName)
        {
            bool iSBodyHtml = false;
            string result = "";
            try
            {
                  MailMessage mail = new MailMessage();
                  mail.From = new MailAddress(ConfigurationManager.AppSettings["email"]);
                  mail.To.Add(email);
                  mail.Subject = mailSubject;
                  mail.IsBodyHtml = true;
                  mail.Body = mailBody;
                  SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["client"]);
                  smtp.Port = int.Parse(ConfigurationManager.AppSettings["port"]);
                  smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["username_email"], ConfigurationManager.AppSettings["password"]); 
                  smtp.Send(mail); 
            }
            catch (Exception ex)
            { 
                result = ex.Message;
            }
            finally
            { 
            }
            return result;
        }

        public static string GenerateRandom()
        {
            string result = "";
            string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var stringChars = new char[5];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            result = new String(stringChars);
            return result;
        }
        public static IConfiguration Configuration { get; set; }
        public static string getConnectionString() 
        { 
            if (Configuration == null) 
            { 
                loadConfig(); 
            } 
            return Configuration["cn"]; 
        }             
        public static void loadConfig() 
        { 
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json"); 
            Configuration = builder.Build(); 
        }   
    }
}
