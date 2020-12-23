using NPoco;
using Rs_71.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
 
namespace Rs_71.Models 
{ 
    public class authenticate_user 
    { 
        public string add_authenticate_user(Rs_71authenticate_user new_authenticate_user, bool returnID = false ) 
         {
             string result = "";
             if(returnID){
                result = "0";
             }
             try
             {
                 var context = Rs_71.Data.Models.Rs_71.GetInstance();
                 var x = context.Insert<Rs_71authenticate_user>(new_authenticate_user);
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
         public string update_authenticate_user(Rs_71authenticate_user new_authenticate_user)
         {
             string result = "";
             try
             {
                 var context = Rs_71.Data.Models.Rs_71.GetInstance();
                 var x = context.Update(new_authenticate_user);
             }
             catch (Exception dd)
             {
                 result = dd.Message;
             }
             return result;
         }
         public List<Rs_71authenticate_user> get_authenticate_user(string sql)
         {
             var context = Rs_71.Data.Models.Rs_71.GetInstance();
             var actual = context.Fetch<Rs_71authenticate_user>( sql);
             return actual;
         }  
     }
 
 }
