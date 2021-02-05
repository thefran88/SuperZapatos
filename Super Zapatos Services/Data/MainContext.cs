using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace Super_Zapatos.Data
{
    public class MainContext : DbContext
    {
        //SuperZapatosDB
        //static string ConnectionString = string.Format(@"Data Source={0}", Path.Combine(HttpContext.Current.Server.MapPath("../App_Data/SuperZapatosDB.mdf")));
        //static string ConnectionString = string.Format(@"Database=SuperZapatosDB; Data Source={0}/SuperZapatosDB.mdf", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
        static string ConnectionString = string.Format("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"{0}\\SuperZapatosDB.mdf\";", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));

        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public MainContext() : base(ConnectionString)
        {
        }

        public System.Data.Entity.DbSet<Super_Zapatos.Models.Store> Stores { get; set; }

        public System.Data.Entity.DbSet<Super_Zapatos.Models.Article> Articles { get; set; }
    }
}
