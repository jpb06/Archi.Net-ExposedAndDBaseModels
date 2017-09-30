using GenericStructure.Dal.Models.DBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStructure.Dal.Context.Contracts
{
    internal interface IDBContext
    {
        IDbSet<DalCustomer> Customers { get; set; }
        IDbSet<DalArticle> Articles { get; set; }
        IDbSet<DalCategory> Categories { get; set; }
        IDbSet<DalOrder> Orders { get; set; }
        IDbSet<DalOrderDetails> OrderDetails { get; set; }

        Database Database { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry Entry(object entity);
        int SaveChanges();
        void Dispose();
    }
}
