using GenericStructure.Dal.Context.Contracts;
using GenericStructure.Dal.Manipulation.Repositories.Contracts;
using GenericStructure.Dal.Manipulation.Repositories.Implementation.Base;
using GenericStructure.Dal.Models.DBase;
using GenericStructure.Dal.Models.DBase.Base;
using GenericStructure.Dal.Models.Exposed.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStructure.Dal.Manipulation.Repositories
{
    public static class RepositoryLocator
    {   
        internal static IGenericRepository<TEntity> FindGenericRepository<TEntity>(this RepositoriesMapping mapping) 
            where TEntity : DalModel
        {
            var type = mapping.GetRepositoryType(typeof(TEntity));
            var f = mapping.GetSpecificFactory(type) ?? mapping.GetGenericFactory<TEntity>();

            if (f == null)
            {
                // TODO : Throw proper DalException
                string message = string.Format("Mapping is missing for {0}",
                        typeof(TEntity).FullName);
                throw new Exception(message);
            }

            var repo = f();
            return (IGenericRepository<TEntity>)repo;
        }

        internal static TRepo FindRepository<TRepo, TEntity>(this RepositoriesMapping mapping)
            where TRepo : class, IGenericRepository<TEntity>
            where TEntity : DalModel
        {
            var repo = FindGenericRepository<TEntity>(mapping);
            try
            {
                return (TRepo)repo;
            }
            catch (InvalidCastException)
            {
                // TODO : Throw proper DalException
                string message = string.Format("Registered repository for entity {0} does not implement {1}",
                    typeof(TEntity).FullName,
                    typeof(TRepo).FullName);
                throw new Exception(message);
            }
        }
    }
}
