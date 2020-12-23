using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using Rs_71.Data;
using Rs_71.Data.Models;
using Rs_71.Models;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace Rs_71.BusinessLogic
{
    public class centralCalls
    {
        public static ISession _Session;
        private static long getVal()
        {
            if (getSessionString("userID") == null)
            {
                return 0;
            }
            else
            {
                return long.Parse(getSessionString("userID"));
            }
        }

        public static string getSessionString(string strVal)
        {
            return _Session.GetString(strVal);
        }
        public static void setSessionString(string strKey, string strVal)
        {
            _Session.SetString(strKey, strVal);
        }
        public static void clearSession()
        {
            _Session.Clear();
        }
        public static string add_new_authenticate_user(string Email, string First_name, string Last_name, string Password, string Password2, bool returnID = false)
        {
            string response = "";
            authenticate_user c = new authenticate_user();
            string data = "";
            try
            {

                Rs_71authenticate_user cust = new Rs_71authenticate_user();
                cust.Email = Email;
                data += ",Email : " + Email;
                cust.First_name = First_name;
                data += ",First_name : " + First_name;
                cust.Last_name = Last_name;
                data += ",Last_name : " + Last_name;
                cust.Password = Encoding.ASCII.GetBytes(Password);
                cust.Password2 = Encoding.ASCII.GetBytes(Password2);
                response = c.add_authenticate_user(cust, returnID);
                if (returnID)
                {
                    Audit.InsertAudit((int)eventzz.SUCCESSFUL_AUTHENTICATE_USER_ADD, data, getVal(), true);
                    return response;
                }
                if (response.Trim().Length > 0)
                {
                    Audit.InsertAudit((int)eventzz.FAILED_AUTHENTICATE_USER_ADD, response + " (" + data + ")", getVal(), true);
                    response = "failed create attempt";
                }
                else
                {
                    response = "Creation successful";
                    Audit.InsertAudit((int)eventzz.SUCCESSFUL_AUTHENTICATE_USER_ADD, data, getVal(), true);
                }
            }
            catch (Exception d)
            {
                response = "Error adding authenticate_user";
                Audit.InsertAudit((int)eventzz.ERROR_AUTHENTICATE_USER_ADD, d.Message + "  " + (d.InnerException != null ? d.InnerException.Message : "") + " (  " + data + " ) ", getVal(), true);
            }
            return response;
        }
        public static List<Rs_71authenticate_user> get_authenticate_user(string sql)
        {
            List<Rs_71authenticate_user> response = null;
            try
            {
                authenticate_user c = new authenticate_user();
                response = c.get_authenticate_user(sql);
            }
            catch (Exception d)
            {
                Audit.InsertAudit((int)eventzz.ERROR_AUTHENTICATE_USER_GET, d.Message + "  " + (d.InnerException != null ? d.InnerException.Message : ""), getVal(), true);
            }
            return response;
        }
        public static string update_authenticate_user(string id, string oEmail, string oFirst_name, string oLast_name, string oPassword, string oPassword2, string Email, string First_name, string Last_name, string Password, string Password2, bool andPassword = true)
        {
            string response = "";
            authenticate_user c = new authenticate_user();
            string data = "";
            try
            {
                Rs_71authenticate_user cust = c.get_authenticate_user(" where id = " + id)[0];
                cust.Email = Email;
                data += ",Email : " + oEmail + " -> " + Email;
                cust.First_name = First_name;
                data += ",First_name : " + oFirst_name + " -> " + First_name;
                cust.Last_name = Last_name;
                data += ",Last_name : " + oLast_name + " -> " + Last_name;
                if (andPassword)
                {
                    cust.Password = Encoding.ASCII.GetBytes(Password);
                    cust.Password2 = Encoding.ASCII.GetBytes(Password2);
                }
                response = c.update_authenticate_user(cust);
                if (response.Trim().Length > 0)
                {
                    Audit.InsertAudit((int)eventzz.FAILED_AUTHENTICATE_USER_UPDATE, data, getVal(), true);
                    response = "Error saving data";
                }
                else
                {
                    response = "update successful";
                    Audit.InsertAudit((int)eventzz.SUCCESSFUL_AUTHENTICATE_USER_UPDATE, data, getVal(), true);
                }
            }
            catch (Exception d)
            {
                response = "Error updating data";
                Audit.InsertAudit((int)eventzz.ERROR_AUTHENTICATE_USER_UPDATE, d.Message + "  " + (d.InnerException != null ? d.InnerException.Message : "") + " ( " + data + " ) ", getVal(), true);
            }
            return response;
        }
        public static string add_new_listing_site(string Site_name, bool returnID = false)
        {
            string response = "";
            listing_site c = new listing_site();
            string data = "";
            try
            {

                Rs_71listing_site cust = new Rs_71listing_site();
                cust.Site_name = Site_name;
                data += ",Site_name : " + Site_name;
                response = c.add_listing_site(cust, returnID);
                if (returnID)
                {
                    Audit.InsertAudit((int)eventzz.SUCCESSFUL_LISTING_SITE_ADD, data, getVal(), true);
                    return response;
                }
                if (response.Trim().Length > 0)
                {
                    Audit.InsertAudit((int)eventzz.FAILED_LISTING_SITE_ADD, response + " (" + data + ")", getVal(), true);
                    response = "failed create attempt";
                }
                else
                {
                    response = "Creation successful";
                    Audit.InsertAudit((int)eventzz.SUCCESSFUL_LISTING_SITE_ADD, data, getVal(), true);
                }
            }
            catch (Exception d)
            {
                response = "Error adding listing_site";
                Audit.InsertAudit((int)eventzz.ERROR_LISTING_SITE_ADD, d.Message + "  " + (d.InnerException != null ? d.InnerException.Message : "") + " (  " + data + " ) ", getVal(), true);
            }
            return response;
        }
        public static List<Rs_71listing_site> get_listing_site(string sql)
        {
            List<Rs_71listing_site> response = null;
            try
            {
                listing_site c = new listing_site();
                response = c.get_listing_site(sql);
            }
            catch (Exception d)
            {
                Audit.InsertAudit((int)eventzz.ERROR_LISTING_SITE_GET, d.Message + "  " + (d.InnerException != null ? d.InnerException.Message : ""), getVal(), true);
            }
            return response;
        }
        public static string update_listing_site(string id, string oSite_name, string Site_name, bool andPassword = true)
        {
            string response = "";
            listing_site c = new listing_site();
            string data = "";
            try
            {
                Rs_71listing_site cust = c.get_listing_site(" where id = " + id)[0];
                cust.Site_name = Site_name;
                data += ",Site_name : " + oSite_name + " -> " + Site_name;
                response = c.update_listing_site(cust);
                if (response.Trim().Length > 0)
                {
                    Audit.InsertAudit((int)eventzz.FAILED_LISTING_SITE_UPDATE, data, getVal(), true);
                    response = "Error saving data";
                }
                else
                {
                    response = "update successful";
                    Audit.InsertAudit((int)eventzz.SUCCESSFUL_LISTING_SITE_UPDATE, data, getVal(), true);
                }
            }
            catch (Exception d)
            {
                response = "Error updating data";
                Audit.InsertAudit((int)eventzz.ERROR_LISTING_SITE_UPDATE, d.Message + "  " + (d.InnerException != null ? d.InnerException.Message : "") + " ( " + data + " ) ", getVal(), true);
            }
            return response;
        }
        public static string add_new_skill(string Date, string Site, string Skill, bool returnID = false)
        {
            string response = "";
            skill c = new skill();
            string data = "";
            try
            {

                Rs_71skill cust = new Rs_71skill();
                cust.Date = DateTime.Parse(Date);// System.DateTime.Now;
                cust.Site = long.Parse(Site == null ? "1" : Site);
                data += ",Site : " + Site;
                data += ",Skill : " + Skill;
                // if (returnID)
                // {
                //     return response;
                // }
                string[] Skill_list = Skill.Split(new string[] { "*sphinxrow*" }, StringSplitOptions.RemoveEmptyEntries);
                int i = 0;
                while (Skill_list.Length > i && response.Trim().Length == 0)
                {
                    cust.Skill = Skill_list[i];
                    response = c.add_skill(cust, returnID);
                    i++;
                }
                if (response.Trim().Length > 0)
                {
                    Audit.InsertAudit((int)eventzz.FAILED_SKILL_ADD, response + " (" + data + ")", getVal(), true);
                    response = "failed create attempt";
                }
                else
                {
                    response = " creation successful";
                    Audit.InsertAudit((int)eventzz.SUCCESSFUL_SKILL_ADD, data, getVal(), true);
                }
            }
            catch (Exception d)
            {
                response = "Error adding skill";
                Audit.InsertAudit((int)eventzz.ERROR_SKILL_ADD, d.Message + "  " + (d.InnerException != null ? d.InnerException.Message : "") + " (  " + data + " ) ", getVal(), true);
            }
            return response;
        }
        public static List<Rs_71skill_data> get_skill(string sql)
        {
            List<Rs_71skill_data> response = null;
            try
            {
                skill c = new skill();
                response = c.get_skill_linked(sql);
            }
            catch (Exception d)
            {
                Audit.InsertAudit((int)eventzz.ERROR_SKILL_GET, d.Message + "  " + (d.InnerException != null ? d.InnerException.Message : ""), getVal(), true);
            }
            return response;
        }
        public static List<Rs_71skill_count> get_skill_Count(string sql)
        {
            List<Rs_71skill_count> response = null;
            try
            {
                skill c = new skill();
                response = c.get_skill_Count_All(sql);
            }
            catch (Exception d)
            {
                Audit.InsertAudit((int)eventzz.ERROR_SKILL_GET, d.Message + " count " + (d.InnerException != null ? d.InnerException.Message : ""), getVal(), true);
            }
            return response;
        }
        public static string update_skill(string id, string oDate, string oSite, string oSkill, string Date, string Site, string Skill, bool andPassword = true)
        {
            string response = "";
            skill c = new skill();
            string data = "";
            try
            {
                Rs_71skill cust = c.get_skill(" where id = " + id)[0];
                cust.Site = long.Parse(Site == null ? "1" : Site);
                data += ",Site : " + oSite + " -> " + Site;
                cust.Skill = Skill;
                data += ",Skill : " + oSkill + " -> " + Skill;
                cust.Date = DateTime.Parse(Date);
                data += ",Date : " + oDate + " -> " + Date;
                response = c.update_skill(cust);
                if (response.Trim().Length > 0)
                {
                    Audit.InsertAudit((int)eventzz.FAILED_SKILL_UPDATE, data, getVal(), true);
                    response = "Error saving data";
                }
                else
                {
                    response = "SKILL update successful";
                    Audit.InsertAudit((int)eventzz.SUCCESSFUL_SKILL_UPDATE, data, getVal(), true);
                }
            }
            catch (Exception d)
            {
                response = "Error updating data";
                Audit.InsertAudit((int)eventzz.ERROR_SKILL_UPDATE, d.Message + "  " + (d.InnerException != null ? d.InnerException.Message : "") + " ( " + data + " ) ", getVal(), true);
            }
            return response;
        }
    }
}
