using GenericStructure.Dal.Context.Contracts;
using GenericStructure.Dal.Manipulation.Repositories.Contracts;
using GenericStructure.Dal.Manipulation.Repositories.Implementation.Base;
using GenericStructure.Dal.Manipulation.Repositories.Implementation.Specific;
using GenericStructure.Dal.Models.DBase;
using GenericStructure.Dal.Models.DBase.Base;
using GenericStructure.Dal.Models.DBase.Exposed.Sales;
using GenericStructure.Dal.Models.Exposed.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStructure.Dal.Manipulation.Repositories
{
    internal class RepositoriesMapping
    {
        public readonly Dictionary<Type, Type> modelTypesSpecificTypesMapping;

        public readonly Dictionary<Type, Func<object>> genericFactories;
        public readonly Dictionary<Type, Func<object>> specificFactories;

        #region Mapping Definition
        public RepositoriesMapping(IDBContext context)
        {
            this.modelTypesSpecificTypesMapping = new Dictionary<Type, Type>
            {
                { typeof(DalArticle), typeof(IArticlesRepository) },
                { typeof(DalCategory), typeof(ICategoriesRepository) },
                { typeof(DalCustomer), typeof(ICustomersRepository) },
                { typeof(DalOrder), typeof(IOrderDetailsRepository) },
                { typeof(DalOrderDetails), typeof(IOrdersRepository) }
            };

            this.genericFactories = new Dictionary<Type, Func<object>>
            {
                { typeof(IGenericRepository<DalArticle>), () => new GenericRepository<DalArticle>(context) },
                { typeof(IGenericRepository<DalCategory>), () => new GenericRepository<DalCategory>(context) },
                { typeof(IGenericRepository<DalCustomer>), () => new GenericRepository<DalCustomer>(context) },
                { typeof(IGenericRepository<DalOrder>), () => new GenericRepository<DalOrder>(context) },
                { typeof(IGenericRepository<DalOrderDetails>), () => new GenericRepository<DalOrderDetails>(context) },
            };

            this.specificFactories = new Dictionary<Type, Func<object>>
            {
                { typeof(IArticlesRepository), () => new ArticlesRepository(context) },
                { typeof(ICategoriesRepository), () => new CategoriesRepository(context) },
            };
        }
        #endregion

        #region Accessors
        internal Type GetRepositoryType(Type type)
        {
            Type repoType;
            this.modelTypesSpecificTypesMapping.TryGetValue(type, out repoType);
            return repoType;
        }

        internal Func<object> GetGenericFactory<TEntity>() 
            where TEntity : DalModel
        {
            Func<object> factory;
            this.genericFactories.TryGetValue(typeof(GenericRepository<TEntity>), out factory);
            return factory;
        }

        internal Func<object> GetSpecificFactory(Type factoryType)
        {
            if (factoryType == null) return null;
            Func<object> factory;
            this.specificFactories.TryGetValue(factoryType, out factory);
            return factory;
        }
        #endregion
    }
}
