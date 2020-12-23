using NPoco;
using Rs_71.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rs_71.Models
{
    public class skill
    {
        public string add_skill(Rs_71skill new_skill, bool returnID = false)
        {
            string result = "";
            if (returnID)
            {
                result = "0";
            }
            try
            {
                var context = Rs_71.Data.Models.Rs_71.GetInstance();
                var x = context.Insert<Rs_71skill>(new_skill);
                if (returnID)
                {
                    result = x.ToString().Trim();
                }
            }
            catch (Exception dd)
            {
                result = dd.Message;
            }
            return result;
        }
        public string update_skill(Rs_71skill new_skill)
        {
            string result = "";
            try
            {
                var context = Rs_71.Data.Models.Rs_71.GetInstance();
                var x = context.Update(new_skill);
            }
            catch (Exception dd)
            {
                result = dd.Message;
            }
            return result;
        }
        public List<Rs_71skill_data> get_skill_linked(string sql)
        {
            var context = Rs_71.Data.Models.Rs_71.GetInstance();
            var actual = context.Fetch<Rs_71skill_data>("select a.id , a.date , a.site , a1.site_name  site_data  , a.skill   from rs_71skill a  inner join  rs_71listing_site a1 on a.site = a1.id " + sql);
            return actual;
        }

        public List<Rs_71skill_count> get_skill_Count_All(string sql)
        {
            var context = Rs_71.Data.Models.Rs_71.GetInstance();
            var actual = context.Fetch<Rs_71skill_count>("select count(*) coun, skill, b.site_name  from  rs_71skill a inner join rs_71listing_site b on a.site = b.id " + sql + " group by skill, b.site_name order by b.site_name , coun desc ");
            return actual;
        }



        public List<Rs_71skill> get_skill(string sql)
        {
            var context = Rs_71.Data.Models.Rs_71.GetInstance();
            var actual = context.Fetch<Rs_71skill>(sql);
            return actual;
        }
    }
    public partial class Rs_71skill_data
    {
        [Column("id")]
        public long Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        long _Id;
        [Column("date")]
        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        string _Date;
        [Column("site")]
        public string Site
        {
            get { return _Site; }
            set { _Site = value; }
        }
        string _Site;
        [Column("site_data")]
        public string Site_data
        {
            get { return _Site_data; }
            set { _Site_data = value; }
        }
        string _Site_data;
        [Column("skill")]
        public string Skill
        {
            get { return _Skill; }
            set { _Skill = value; }
        }
        string _Skill;
    }
    public partial class Rs_71skill_count
    {

        [Column("coun")]
        public string Coun
        {
            get { return _Coun; }
            set { _Coun = value; }
        }
        string _Coun;

        [Column("skill")]
        public string Skill
        {
            get { return _Skill; }
            set { _Skill = value; }
        }
        string _Skill;

        [Column("site_name")]
        public string Site_name
        {
            get { return _Site_name; }
            set { _Site_name = value; }
        }
        string _Site_name;
    }

}
