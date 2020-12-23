using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using Rs_71.Data.Models;
using Rs_71.Models;
using Rs_71.BusinessLogic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Newtonsoft.Json;

namespace Rs_71.Controllers
{
    [Authorize]
    public class USERController : Controller
    {


        private void getStatus(bool clearStatus = true)
        {
            if (centralCalls.getSessionString("status") != null)
            {
                if (centralCalls.getSessionString("status").Trim().Length > 0)
                {
                    ViewBag.status = centralCalls.getSessionString("status");
                    if (clearStatus)
                    {
                        centralCalls.setSessionString("status", "");
                    }
                }
            }
            if (centralCalls.getSessionString("down") != null)
            {
                if (centralCalls.getSessionString("down").Trim().Length > 0)
                {
                    ViewBag.down = centralCalls.getSessionString("down");
                    centralCalls.setSessionString("down", "");
                }
            }
        }
        private string doAuthenticate(string userName, string password, string clientID)
        {
            string baseUrl = string.Format("{0}://{1}{2}", Request.Scheme, Request.Host, Request.PathBase);
            string result = "";
            string dataToSend = "&username=" + HttpUtility.UrlEncode(userName) + "&password=" + HttpUtility.UrlEncode(password) + "&clientid=" + HttpUtility.UrlEncode(clientID) + "&grant_type=password";
            string urlPath = baseUrl.ToString().Split(new string[] { Request.Path.ToString() }, StringSplitOptions.RemoveEmptyEntries)[0];
            if (Request.Path.ToString().Trim().Length == 1)
            {
                urlPath = baseUrl.ToString();
            }
            var newHttpRequest = (HttpWebRequest)WebRequest.Create(urlPath + "/token");
            var data = Encoding.ASCII.GetBytes(dataToSend);
            newHttpRequest.Method = "POST";
            newHttpRequest.ContentType = "application/x-www-form-urlencoded";
            newHttpRequest.ContentLength = data.Length;
            using (var streamProcess = newHttpRequest.GetRequestStream())
            {
                streamProcess.Write(data, 0, data.Length);
            }
            try
            {
                var newHttpResponse = (HttpWebResponse)newHttpRequest.GetResponse();
                var responseString = new StreamReader(newHttpResponse.GetResponseStream()).ReadToEnd();
                dynamic passString = JsonConvert.DeserializeObject<dynamic>(responseString);
                result = (string)passString.access_token;
            }
            catch (Exception d)
            {
            }
            return result;
        }

        [AllowAnonymous]
        public ActionResult Change_Password()
        {
            centralCalls._Session = HttpContext.Session;
            getStatus(false);
            if (centralCalls.getSessionString("userType") == null)
            {
                centralCalls.setSessionString("status", "Session Timed out");
                return RedirectToAction("Login", "user");
            }
            ViewBag.first_name = centralCalls.getSessionString("first_name");
            ViewBag.last_name = centralCalls.getSessionString("last_name");
            ViewBag.email = centralCalls.getSessionString("email");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Change_Password(string email, string password, string npassword)
        {
            centralCalls._Session = HttpContext.Session;
            ActionResult xx = updatePassword(password: password, npassword: npassword, email: email);
            centralCalls.setSessionString("status", centralCalls.getSessionString("response"));
            if (centralCalls.getSessionString("response").IndexOf("update successful") > -1)
            {
                centralCalls.setSessionString("status", "Password Changed Successfully");
                return RedirectToAction("Login", "user");
            }
            else
            {
                return RedirectToAction("Change_Password", "user");
            }
        }


        [AllowAnonymous]
        public ActionResult updatePassword(string email, string password, string npassword)
        {
            centralCalls._Session = HttpContext.Session;
            List<Rs_71authenticate_user> response = null;
            string result = "Authentication failed";
            string strRND11 = password;
            byte[] arr11 = Encoding.ASCII.GetBytes(Audit.GetEncodedHash(strRND11, "doing it well"));
            response = centralCalls.get_authenticate_user(" where replace(password, '@','#')  = '" + Encoding.ASCII.GetString(arr11).Replace("@", "#") + "' and replace(email, '@','#') = '" + email.Replace("@", "#") + "' ");
            if (response != null)
            {
                if (response.Count > 0)
                {
                    string strRND = npassword;
                    byte[] arr = Encoding.ASCII.GetBytes(Audit.GetEncodedHash(strRND, "doing it well"));
                    result = centralCalls.update_authenticate_user(id: response[0].Id.ToString(), oEmail: response[0].Email.ToString(), oFirst_name: response[0].First_name.ToString(), oLast_name: response[0].Last_name.ToString(), oPassword: Encoding.ASCII.GetString(response[0].Password), oPassword2: Encoding.ASCII.GetString(response[0].Password2), Email: response[0].Email.ToString(), First_name: response[0].First_name.ToString(), Last_name: response[0].Last_name.ToString(), Password: Encoding.ASCII.GetString(arr), Password2: Encoding.ASCII.GetString(response[0].Password2));
                }
            }
            centralCalls.setSessionString("response", JsonConvert.SerializeObject(result));
            return Content((string)result);
        }


        [AllowAnonymous]
        public ActionResult new_listing_sites()
        {
            centralCalls._Session = HttpContext.Session;
            if (centralCalls.getSessionString("userType") == null)
            {
                centralCalls.setSessionString("status", "Session Timed out");
                return RedirectToAction("Login", "user");
            }
            if (centralCalls.getSessionString("status") == "Please change your password")
            {
                return RedirectToAction("Change_Password", "user");
            }
            getStatus();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult new_listing_sites(string Site_name)
        {
            centralCalls._Session = HttpContext.Session;
            if (centralCalls.getSessionString("userType") == null)
            {
                centralCalls.setSessionString("status", "Session Timed out");
                return RedirectToAction("Login", "user");
            }
            if (centralCalls.getSessionString("status") == "Please change your password")
            {
                return RedirectToAction("Change_Password", "user");
            }

            string response = null;
            ActionResult xx = add_listing_sites(Site_name: Site_name, token: centralCalls.getSessionString("token"));
            response = centralCalls.getSessionString("response");
            centralCalls.setSessionString("status", response);
            return RedirectToAction("new_listing_sites", "user");
        }

        [AllowAnonymous]
        public ActionResult add_listing_sites(string Site_name, string token)
        {
            centralCalls._Session = HttpContext.Session;
            centralCalls.setSessionString("status", "");
            string response = null;
            response = centralCalls.add_new_listing_site(Site_name: Site_name);
            centralCalls.setSessionString("response", response);
            return Content((string)response);
        }

        [AllowAnonymous]
        public ActionResult view_listing_sites()
        {
            centralCalls._Session = HttpContext.Session;
            if (centralCalls.getSessionString("userType") == null)
            {
                centralCalls.setSessionString("status", "Session Timed out");
                return RedirectToAction("Login", "user");
            }
            if (centralCalls.getSessionString("status") == "Please change your password")
            {
                return RedirectToAction("Change_Password", "user");
            }
            getStatus();
            List<Rs_71listing_site> response = null;
            ActionResult d = view_it_listing_sites(centralCalls.getSessionString("token"));
            return View(JsonConvert.DeserializeObject<List<Rs_71listing_site>>(centralCalls.getSessionString("response")));
        }

        [AllowAnonymous]
        public ActionResult view_it_listing_sites(string token)
        {
            centralCalls._Session = HttpContext.Session;
            centralCalls.setSessionString("status", "");
            getStatus();
            centralCalls.setSessionString("response", JsonConvert.SerializeObject(centralCalls.get_listing_site("")));
            return Content(centralCalls.getSessionString("response"));
        }

        [AllowAnonymous]
        public ActionResult edit_listing_sites(string id, string Site_name)
        {
            centralCalls._Session = HttpContext.Session;
            if (centralCalls.getSessionString("userType") == null)
            {
                centralCalls.setSessionString("status", "Session Timed out");
                return RedirectToAction("Login", "user");
            }
            if (centralCalls.getSessionString("status") == "Please change your password")
            {
                return RedirectToAction("Change_Password", "user");
            }
            getStatus();
            ViewBag.id = id;
            ViewBag.Site_name = Site_name;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult edit_listing_sites(string id, string oSite_name, string Site_name)
        {
            centralCalls._Session = HttpContext.Session;
            if (centralCalls.getSessionString("userType") == null)
            {
                centralCalls.setSessionString("status", "Session Timed out");
                return RedirectToAction("Login", "user");
            }
            if (centralCalls.getSessionString("status") == "Please change your password")
            {
                return RedirectToAction("Change_Password", "user");
            }
            string response = null;
            ActionResult xx = update_listing_sites(id: id, oSite_name: oSite_name, Site_name: Site_name, token: centralCalls.getSessionString("token"));
            response = centralCalls.getSessionString("response");
            centralCalls.setSessionString("status", response);
            if (response.IndexOf("uccess") > -1)
            {
                return RedirectToAction("view_listing_sites", "user");
            }
            else
            {
                return RedirectToAction("view_listing_sites", "user");
                return View();
            }
            return RedirectToAction("new_listing_sites", "user");
        }

        [AllowAnonymous]
        public ActionResult update_listing_sites(string id, string oSite_name, string Site_name, string token)
        {
            centralCalls._Session = HttpContext.Session;
            centralCalls.setSessionString("status", "");
            string response = null;
            response = centralCalls.update_listing_site(id: id, oSite_name: oSite_name, Site_name: Site_name, andPassword: false);
            centralCalls.setSessionString("response", response);
            return Content((string)response);
        }



        [AllowAnonymous]
        public ActionResult login()
        {
            centralCalls._Session = HttpContext.Session;
            getStatus();
            centralCalls.clearSession();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult login(string Email, string First_name, string Last_name, string Password, string Password2, string forgot)
        {
            centralCalls._Session = HttpContext.Session;
            string token = doAuthenticate(userName: Email, password: Password, clientID: "user");
            List<Rs_71authenticate_user> response = null;
            if (String.IsNullOrEmpty(forgot))
            {
                ActionResult xx = authenticate(password: Password, email: Email);
                response = JsonConvert.DeserializeObject<List<Rs_71authenticate_user>>(centralCalls.getSessionString("response"));
                if (response != null)
                {
                    if (response.Count > 0)
                    {
                        if (Encoding.ASCII.GetString(response[0].Password) == Encoding.ASCII.GetString(response[0].Password2))
                        {
                            centralCalls.setSessionString("userID", response[0].Id.ToString());
                            centralCalls.setSessionString("userType", "user");
                            centralCalls.setSessionString("email", response[0].Email);
                            centralCalls.setSessionString("first_name", response[0].First_name);
                            centralCalls.setSessionString("last_name", response[0].Last_name);
                            centralCalls.setSessionString("token", token);
                            centralCalls.setSessionString("Password", Password);
                            centralCalls.setSessionString("status", "Please change your password");
                            return RedirectToAction("Change_Password", "user");
                        }
                        else
                        {
                            centralCalls.setSessionString("userID", response[0].Id.ToString());
                            centralCalls.setSessionString("userType", "user");
                            centralCalls.setSessionString("email", response[0].Email);
                            centralCalls.setSessionString("first_name", response[0].First_name);
                            centralCalls.setSessionString("last_name", response[0].Last_name);
                            centralCalls.setSessionString("status", "");
                            centralCalls.setSessionString("token", token);
                            centralCalls.setSessionString("Password", Password);
                            return RedirectToAction("Change_Password", "user");
                        }
                    }
                    else
                    {
                        centralCalls.setSessionString("status", "Authentication Not successful");
                        return RedirectToAction("Login", "user");
                    }
                }
                else
                {
                    centralCalls.setSessionString("status", "Authentication Not successful");
                    return RedirectToAction("Login", "user");
                }
            }
            else
            {
                ActionResult xx = forgotauthenticate_user(Email: Email);
                response = JsonConvert.DeserializeObject<List<Rs_71authenticate_user>>(centralCalls.getSessionString("response"));
                return RedirectToAction("Login", "user");
            }
        }

        [AllowAnonymous]
        public ActionResult authenticate(string email, string password)
        {
            centralCalls._Session = HttpContext.Session;
            List<Rs_71authenticate_user> response = null;
            password = Audit.GetEncodedHash(password, "doing it well");
            response = centralCalls.get_authenticate_user(" where replace(password, '@','#')  = '" + password.Replace("@", "#") + "' and replace(email, '@','#') = '" + email.Replace("@", "#") + "' ");
            centralCalls.setSessionString("response", JsonConvert.SerializeObject(response));
            return Content(JsonConvert.SerializeObject((List<Rs_71authenticate_user>)response));
        }

        [AllowAnonymous]
        public ActionResult forgotauthenticate_user(string Email)
        {
            centralCalls._Session = HttpContext.Session;
            List<Rs_71authenticate_user> response = null;
            response = centralCalls.get_authenticate_user(" where replace(email, '@','#') = '" + Email.Replace("@", "#") + "' ");
            if (response != null)
            {
                if (response.Count > 0)
                {
                    string strRND = Audit.GenerateRandom();
                    byte[] arr = Encoding.ASCII.GetBytes(Audit.GetEncodedHash(strRND, "doing it well"));
                    centralCalls.update_authenticate_user(id: response[0].Id.ToString(), oEmail: response[0].Email.ToString(), oFirst_name: response[0].First_name.ToString(), oLast_name: response[0].Last_name.ToString(), oPassword: Encoding.ASCII.GetString(response[0].Password), oPassword2: Encoding.ASCII.GetString(response[0].Password2), Email: response[0].Email.ToString(), First_name: response[0].First_name.ToString(), Last_name: response[0].Last_name.ToString(), Password: Encoding.ASCII.GetString(arr), Password2: Encoding.ASCII.GetString(arr));
                    string mailSubject = "Profile password reset on (code joh) required skills";
                    centralCalls.setSessionString("status", "Password reset successful, please check your email for your new password.");
                    string mailBody = "Hi <br><br>Your password has been successfully reset on the (code joh) required skills platform. Please log in with following credentials: <br><br> Email:" + response[0].Email + "<br><br>password :" + strRND + "<br><br><br>Regards<br><br>";
                    Audit.SendMail(Email, mailSubject, mailBody, " ");
                }
            }
            centralCalls.setSessionString("response", JsonConvert.SerializeObject(response));
            return Content(JsonConvert.SerializeObject((List<Rs_71authenticate_user>)response)); ;
        }


        [AllowAnonymous]
        public ActionResult new_skills()
        {
            centralCalls._Session = HttpContext.Session;
            if (centralCalls.getSessionString("userType") == null)
            {
                centralCalls.setSessionString("status", "Session Timed out");
                return RedirectToAction("Login", "user");
            }
            if (centralCalls.getSessionString("status") == "Please change your password")
            {
                return RedirectToAction("Change_Password", "user");
            }
            ViewBag.Data0 = centralCalls.get_listing_site("");
            getStatus();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult new_skills(string Date, string Site, string Skill)
        {
            centralCalls._Session = HttpContext.Session;
            if (centralCalls.getSessionString("userType") == null)
            {
                centralCalls.setSessionString("status", "Session Timed out");
                return RedirectToAction("Login", "user");
            }
            if (centralCalls.getSessionString("status") == "Please change your password")
            {
                return RedirectToAction("Change_Password", "user");
            }

            string response = null;
            ActionResult xx = add_skills(Date: Date, Site: Site, Skill: Skill, token: centralCalls.getSessionString("token"));
            response = centralCalls.getSessionString("response");
            centralCalls.setSessionString("status", response);
            return RedirectToAction("new_skills", "user");
        }

        [AllowAnonymous]
        public ActionResult add_skills(string Date, string Site, string Skill, string token)
        {
            centralCalls._Session = HttpContext.Session;
            centralCalls.setSessionString("status", "");
            string response = null;
            response = centralCalls.add_new_skill(Date: Date, Site: Site, Skill: Skill);
            centralCalls.setSessionString("response", response);
            return Content((string)response);
        }



        // [AllowAnonymous]
        // public ActionResult view_skills()
        // {
        //         centralCalls._Session = HttpContext.Session;
        //     if(centralCalls.getSessionString("userType")  == null){ 
        //        centralCalls.setSessionString( "status" , "Session Timed out");
        //        return RedirectToAction("Login", "user");
        //     }
        //     if(centralCalls.getSessionString("status") == "Please change your password")
        //     {
        //        return RedirectToAction("Change_Password", "user");
        //     }
        //     getStatus();
        //     List<Rs_71skill> response = null; 
        //    ActionResult d =  view_it_skills(centralCalls.getSessionString("token")  ); 
        //     return View( JsonConvert.DeserializeObject< List<Rs_71skill_data>>(centralCalls.getSessionString("response" )) );
        // }

        // [AllowAnonymous]
        // public ActionResult view_it_skills(string token)
        // {
        //         centralCalls._Session = HttpContext.Session;
        //         centralCalls.setSessionString("status","");
        //     getStatus();
        //     centralCalls.setSessionString("response",JsonConvert.SerializeObject(centralCalls.get_skill(""))) ;
        //     return Content( centralCalls.getSessionString("response" ))  ;
        // }







        [AllowAnonymous]
        public ActionResult view_skills()
        {
            centralCalls._Session = HttpContext.Session;
            if (centralCalls.getSessionString("userType") == null)
            {
                centralCalls.setSessionString("status", "Session Timed out");
                return RedirectToAction("Login", "user");
            }
            if (centralCalls.getSessionString("status") == "Please change your password")
            {
                return RedirectToAction("Change_Password", "user");
            }
            getStatus();
            List<Rs_71skill> response = null;
            ActionResult d = view_it_skills(centralCalls.getSessionString("token"));
            return View(JsonConvert.DeserializeObject<List<Rs_71skill_count>>(centralCalls.getSessionString("response")));
        }

        [AllowAnonymous]
        public ActionResult view_it_skills(string token)
        {
            centralCalls._Session = HttpContext.Session;
            centralCalls.setSessionString("status", "");
            getStatus();
            centralCalls.setSessionString("response", JsonConvert.SerializeObject(centralCalls.get_skill_Count("")));
            return Content(centralCalls.getSessionString("response"));
        }






        [AllowAnonymous]
        public ActionResult edit_skills(string id, string Date, string Site, string Skill)
        {
            centralCalls._Session = HttpContext.Session;
            if (centralCalls.getSessionString("userType") == null)
            {
                centralCalls.setSessionString("status", "Session Timed out");
                return RedirectToAction("Login", "user");
            }
            if (centralCalls.getSessionString("status") == "Please change your password")
            {
                return RedirectToAction("Change_Password", "user");
            }
            ViewBag.Data0 = centralCalls.get_listing_site("");
            getStatus();
            ViewBag.id = id;
            ViewBag.Date = Date;
            ViewBag.Site = Site;
            ViewBag.Skill = Skill;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult edit_skills(string id, string oDate, string oSite, string oSkill, string Date, string Site, string Skill)
        {
            centralCalls._Session = HttpContext.Session;
            if (centralCalls.getSessionString("userType") == null)
            {
                centralCalls.setSessionString("status", "Session Timed out");
                return RedirectToAction("Login", "user");
            }
            if (centralCalls.getSessionString("status") == "Please change your password")
            {
                return RedirectToAction("Change_Password", "user");
            }
            string response = null;
            ActionResult xx = update_skills(id: id, oDate: oDate, oSite: oSite, oSkill: oSkill, Date: Date, Site: Site, Skill: Skill, token: centralCalls.getSessionString("token"));
            response = centralCalls.getSessionString("response");
            centralCalls.setSessionString("status", response);
            if (response.IndexOf("uccess") > -1)
            {
                return RedirectToAction("view_skills", "user");
            }
            else
            {
                return RedirectToAction("view_skills", "user");
                return View();
            }
            return RedirectToAction("new_skills", "user");
        }

        [AllowAnonymous]
        public ActionResult update_skills(string id, string oDate, string oSite, string oSkill, string Date, string Site, string Skill, string token)
        {
            centralCalls._Session = HttpContext.Session;
            centralCalls.setSessionString("status", "");
            string response = null;
            response = centralCalls.update_skill(id: id, oDate: oDate, oSite: oSite, oSkill: oSkill, Date: Date, Site: Site, Skill: Skill, andPassword: false);
            centralCalls.setSessionString("response", response);
            return Content((string)response);
        }



    }
}
