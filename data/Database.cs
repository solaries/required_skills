using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;

namespace Rs_71.Data.Models
{
    public partial class Rs_71 : Database
    {
        public Rs_71() : base(BusinessLogic.Audit.getConnectionString(), DatabaseType.MySQL, MySql.Data.MySqlClient.MySqlClientFactory.Instance)
        {
            CommonConstruct();
        }
        public virtual void CommonConstruct()
        {
            Factory = new DefaultFactory();
        }
        public interface IFactory
        {
            Rs_71 GetInstance();
            void BeginTransaction(Rs_71 database);
            void CompleteTransaction(Rs_71 database);
        }


        public class DefaultFactory : IFactory
        {
            [ThreadStatic]
            static Stack<Rs_71> _stack = new Stack<Rs_71>();

            public Rs_71 GetInstance()
            {

                if (_stack == null)
                { return new Rs_71(); }
                else
                {
                    return _stack.Count > 0 ? _stack.Peek() : new Rs_71();
                }


            }

            public void BeginTransaction(Rs_71 database)
            {

                if (_stack == null)
                {
                    _stack = new Stack<Rs_71>();
                }
                _stack.Push(database);
            }

            public void CompleteTransaction(Rs_71 database)
            {
                if (_stack == null)
                {
                    _stack = new Stack<Rs_71>();
                }
                _stack.Pop();
            }
        }

        public static IFactory Factory { get; set; }

        public static Rs_71 GetInstance()
        {
            if (Factory == null)
                return new Rs_71();
            return Factory.GetInstance();
        }

        protected override void OnBeginTransaction()
        {
            Factory.BeginTransaction(this);
        }

        protected override void OnCompleteTransaction()
        {
            Factory.CompleteTransaction(this);
        }

        public class Record<T> where T : new()
        {
            public bool IsNew(Database db) { return db.IsNew(this); }
            public object Insert(Database db) { return db.Insert(this); }

            public int Update(Database db, IEnumerable<string> columns) { return db.Update(this, columns); }
            public static int Update(Database db, string sql, params object[] args) { return db.Update<T>(sql, args); }
            public static int Update(Database db, Sql sql) { return db.Update<T>(sql); }
            public int Delete(Database db) { return db.Delete(this); }
            public static int Delete(Database db, string sql, params object[] args) { return db.Delete<T>(sql, args); }
            public static int Delete(Database db, Sql sql) { return db.Delete<T>(sql); }
            public static int Delete(Database db, object primaryKey) { return db.Delete<T>(primaryKey); }
            public static bool Exists(Database db, object primaryKey) { return db.Exists<T>(primaryKey); }
            public static T SingleOrDefault(Database db, string sql, params object[] args) { return db.SingleOrDefault<T>(sql, args); }
            public static T SingleOrDefault(Database db, Sql sql) { return db.SingleOrDefault<T>(sql); }
            public static T FirstOrDefault(Database db, string sql, params object[] args) { return db.FirstOrDefault<T>(sql, args); }
            public static T FirstOrDefault(Database db, Sql sql) { return db.FirstOrDefault<T>(sql); }
            public static T Single(Database db, string sql, params object[] args) { return db.Single<T>(sql, args); }
            public static T Single(Database db, Sql sql) { return db.Single<T>(sql); }
            public static T First(Database db, string sql, params object[] args) { return db.First<T>(sql, args); }
            public static T First(Database db, Sql sql) { return db.First<T>(sql); }
            public static List<T> Fetch(Database db, string sql, params object[] args) { return db.Fetch<T>(sql, args); }
            public static List<T> Fetch(Database db, Sql sql) { return db.Fetch<T>(sql); }
            public static List<T> Fetch(Database db, long page, long itemsPerPage, string sql, params object[] args) { return db.Fetch<T>(page, itemsPerPage, sql, args); }
            public static List<T> Fetch(Database db, long page, long itemsPerPage, Sql sql) { return db.Fetch<T>(page, itemsPerPage, sql); }
            public static List<T> SkipTake(Database db, long skip, long take, string sql, params object[] args) { return db.SkipTake<T>(skip, take, sql, args); }
            public static List<T> SkipTake(Database db, long skip, long take, Sql sql) { return db.SkipTake<T>(skip, take, sql); }
            public static Page<T> Page(Database db, long page, long itemsPerPage, string sql, params object[] args) { return db.Page<T>(page, itemsPerPage, sql, args); }
            public static Page<T> Page(Database db, long page, long itemsPerPage, Sql sql) { return db.Page<T>(page, itemsPerPage, sql); }
            public static IEnumerable<T> Query(Database db, string sql, params object[] args) { return db.Query<T>(sql, args); }
            public static IEnumerable<T> Query(Database db, Sql sql) { return db.Query<T>(sql); }

            protected HashSet<string> Tracker = new HashSet<string>();
            private void OnLoaded() { Tracker.Clear(); }
            protected void Track(string c) { if (!Tracker.Contains(c)) Tracker.Add(c); }

            public int Update(Database db)
            {
                if (Tracker.Count == 0)
                    return db.Update(this);

                var retv = db.Update(this, Tracker.ToArray());
                Tracker.Clear();
                return retv;
            }
            public void Save(Database db)
            {
                if (this.IsNew(db))
                    Insert(db);
                else
                    Update(db);
            }
        }
    }
    [TableName("rs_71event")]
    [PrimaryKey("id")]
    [ExplicitColumns]
    public partial class @Event : Rs_71.Record<@Event>

    {
        [Column("id")]
        public long Id
        {
            get { return _Id; }
            set { _Id = value; Track("id"); }
        }
        long _Id;
        [Column("eventName")]
        public string Eventname
        {
            get { return _Eventname; }
            set { _Eventname = value; Track("eventName"); }
        }
        string _Eventname;

        public static IEnumerable<@Event> Query(Database db, string[] columns = null, long[] Id = null)
        {
            var sql = new Sql();

            if (columns != null)
                sql.Select(columns);

            sql.From("rs_71event (NOLOCK)");


            if (Id != null)
                sql.Where("id IN (@0)", Id);


            return db.Query<@Event>(sql);
        }

    }
    [TableName("rs_71eventLog")]
    [PrimaryKey("id")]
    [ExplicitColumns]
    public partial class EventLog : Rs_71.Record<EventLog>

    {
        [Column("id")]
        public long Id
        {
            get { return _Id; }
            set { _Id = value; Track("id"); }
        }
        long _Id;
        [Column("eventid")]
        public long Eventid
        {
            get { return _Eventid; }
            set { _Eventid = value; Track("eventid"); }
        }
        long _Eventid;
        [Column("description")]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; Track("description"); }
        }
        string _Description;
        [Column("userEvent")]
        public bool Userevent
        {
            get { return _Userevent; }
            set { _Userevent = value; Track("userEvent"); }
        }
        bool _Userevent;
        [Column("userid")]
        public long Userid
        {
            get { return _Userid; }
            set { _Userid = value; Track("userid"); }
        }
        long _Userid;
        [Column("eventDate")]
        public DateTime Eventdate
        {
            get { return _Eventdate; }
            set { _Eventdate = value; Track("eventDate"); }
        }
        DateTime _Eventdate;

        public static IEnumerable<EventLog> Query(Database db, string[] columns = null, long[] Id = null)
        {
            var sql = new Sql();

            if (columns != null)
                sql.Select(columns);

            sql.From("rs_71eventLog (NOLOCK)");


            if (Id != null)
                sql.Where("id IN (@0)", Id);


            return db.Query<EventLog>(sql);
        }

    }
    [TableName("rs_71authenticate_user")]
    [PrimaryKey("id")]
    [ExplicitColumns]
    public partial class Rs_71authenticate_user : Rs_71.Record<Rs_71authenticate_user>
    {
        [Column("id")]
        public long Id
        {
            get { return _Id; }
            set { _Id = value; Track("id"); }
        }
        long _Id;

        [Column("email")]
        public string Email
        {
            get { return _Email; }
            set { _Email = value; Track("email"); }
        }
        string _Email;

        [Column("first_name")]
        public string First_name
        {
            get { return _First_name; }
            set { _First_name = value; Track("first_name"); }
        }
        string _First_name;

        [Column("last_name")]
        public string Last_name
        {
            get { return _Last_name; }
            set { _Last_name = value; Track("last_name"); }
        }
        string _Last_name;

        [Column("password")]
        public byte[] Password
        {
            get { return _Password; }
            set { _Password = value; Track("password"); }
        }
        byte[] _Password;

        [Column("password2")]
        public byte[] Password2
        {
            get { return _Password2; }
            set { _Password2 = value; Track("password2"); }
        }
        byte[] _Password2;

        public static IEnumerable<Rs_71authenticate_user> Query(Database db, string[] columns = null, long[] Id = null)
        {

            var sql = new Sql();
            if (columns != null) sql.Select(columns);
            sql.From("rs_71authenticate_user (NOLOCK)");
            if (Id != null)
                sql.Where("id IN (@0)", Id);

            return db.Query<Rs_71authenticate_user>(sql);
        }
    }


    [TableName("rs_71listing_site")]
    [PrimaryKey("id")]
    [ExplicitColumns]
    public partial class Rs_71listing_site : Rs_71.Record<Rs_71listing_site>
    {
        [Column("id")]
        public long Id
        {
            get { return _Id; }
            set { _Id = value; Track("id"); }
        }
        long _Id;

        [Column("site_name")]
        public string Site_name
        {
            get { return _Site_name; }
            set { _Site_name = value; Track("site_name"); }
        }
        string _Site_name;

        public static IEnumerable<Rs_71listing_site> Query(Database db, string[] columns = null, long[] Id = null)
        {

            var sql = new Sql();
            if (columns != null) sql.Select(columns);
            sql.From("rs_71listing_site (NOLOCK)");
            if (Id != null)
                sql.Where("id IN (@0)", Id);

            return db.Query<Rs_71listing_site>(sql);
        }
    }


    [TableName("rs_71skill")]
    [PrimaryKey("id")]
    [ExplicitColumns]
    public partial class Rs_71skill : Rs_71.Record<Rs_71skill>
    {
        [Column("id")]
        public long Id
        {
            get { return _Id; }
            set { _Id = value; Track("id"); }
        }
        long _Id;

        [Column("date")]
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; Track("date"); }
        }
        DateTime _Date;

        [Column("site")]
        public long Site
        {
            get { return _Site; }
            set { _Site = value; Track("site"); }
        }
        long _Site;

        [Column("skill")]
        public string Skill
        {
            get { return _Skill; }
            set { _Skill = value; Track("skill"); }
        }
        string _Skill;

        public static IEnumerable<Rs_71skill> Query(Database db, string[] columns = null, long[] Id = null)
        {

            var sql = new Sql();
            if (columns != null) sql.Select(columns);
            sql.From("rs_71skill (NOLOCK)");
            if (Id != null)
                sql.Where("id IN (@0)", Id);

            return db.Query<Rs_71skill>(sql);
        }
    }

}
