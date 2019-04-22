using NorthWindDb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindDb
{
    public class ApplicationDbContext: DbContext
    {
        static readonly string connection = ConfigurationManager.ConnectionStrings["NorthWindDbCs"].ConnectionString;
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderDetailConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext():base(connection)
        {
            
        }

    }
}
