using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;

namespace ASPNET_MVC.Models
{
    //public class ASPNET_MVCContext : DbContext
    public class ASPNET_MVCContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        /*public ASPNET_MVCContext() : base("name=ASPNET_MVCContext")
        {
        }*/
        
        private static ASPNET_MVCContext instance;
        public static ASPNET_MVCContext Instance
        {
            get { return instance ?? (instance = new ASPNET_MVCContext()); }
        }
        protected ASPNET_MVCContext() { TODOListItems = new ConcurrentDictionary<int, TODOListItem>();  id = 1; }

        //public System.Data.Entity.DbSet<ASPNET_MVC.Models.TODOListItem> TODOListItems { get; set; }
        public ConcurrentDictionary<int, ASPNET_MVC.Models.TODOListItem> TODOListItems { get; set; }
        public int id;
    }
}
