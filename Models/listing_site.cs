using NPoco;
using Rs_71.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
 
namespace Rs_71.Models 
{ 
    public class listing_site 
    { 
        public string add_listing_site(Rs_71listing_site new_listing_site, bool returnID = false ) 
         {
             string result = "";
             if(returnID){
                result = "0";
             }
             try
             {
                 var context = Rs_71.Data.Models.Rs_71.GetInstance();
                 var x = context.Insert<Rs_71listing_site>(new_listing_site);
                if(returnID){
                    result =x.ToString().Trim();
                }
            } 
            catch (Exception dd) 
            { 
                 result = dd.Message;
             }
             return result;
         }
         public string update_listing_site(Rs_71listing_site new_listing_site)
         {
             string result = "";
             try
             {
                 var context = Rs_71.Data.Models.Rs_71.GetInstance();
                 var x = context.Update(new_listing_site);
             }
             catch (Exception dd)
             {
                 result = dd.Message;
             }
             return result;
         }
         public List<Rs_71listing_site> get_listing_site(string sql)
         {
             var context = Rs_71.Data.Models.Rs_71.GetInstance();
             var actual = context.Fetch<Rs_71listing_site>( sql);
             return actual;
         }  
     }
 
 }
