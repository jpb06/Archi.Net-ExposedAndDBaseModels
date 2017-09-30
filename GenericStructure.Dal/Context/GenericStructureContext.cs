using GenericStructure.Dal.Context.Contracts;
using GenericStructure.Dal.Models.DBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStructure.Dal.Context
{
    // https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell
    // Get-Help EntityFramework

    // Enable-Migrations
    // Add-Migration <name>
    // Update-Database

    internal class GenericStructureContext : DbContext, IDBContext
    {
        public GenericStructureContext() : base("name=GenericStructureContextConnectionString") { }

        public virtual IDbSet<DalCustomer> Customers { get; set; }
        public virtual IDbSet<DalArticle> Articles { get; set; }
        public virtual IDbSet<DalCategory> Categories { get; set; }
        public virtual IDbSet<DalOrder> Orders { get; set; }
        public virtual IDbSet<DalOrderDetails> OrderDetails { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var articleModel = modelBuilder.Entity<DalArticle>();
            articleModel.HasKey(t => t.Id);
            articleModel.Property(t => t.RowVersion).IsFixedLength();
            //articleModel.Property(t => t.Price).HasPrecision(19, 4);

            var categoryModel = modelBuilder.Entity<DalCategory>();
            categoryModel.HasKey(t => t.Id);
            categoryModel.Property(t => t.RowVersion).IsFixedLength();

            var orderModel = modelBuilder.Entity<DalOrder>();
            orderModel.HasKey(t => t.Id);
            orderModel.Property(t => t.RowVersion).IsFixedLength();

            var customersModel = modelBuilder.Entity<DalCustomer>();
            customersModel.HasKey(t => t.Id);
            customersModel.Property(t => t.RowVersion).IsFixedLength();

            var orderDetailsModel = modelBuilder.Entity<DalOrderDetails>();
            orderDetailsModel.HasKey(t => t.Id);
            orderDetailsModel.Property(t => t.RowVersion).IsFixedLength();
        }
    }
}
