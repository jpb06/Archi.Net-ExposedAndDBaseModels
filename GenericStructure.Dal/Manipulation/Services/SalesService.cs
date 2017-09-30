using GenericStructure.Dal.Manipulation.Repositories;
using GenericStructure.Dal.Manipulation.Services.Base;
using GenericStructure.Dal.Manipulation.Services.Configuration;
using GenericStructure.Dal.Models.DBase;
using GenericStructure.Dal.Models.DBase.Exposed;
using GenericStructure.Dal.Models.DBase.Exposed.Sales;
using GenericStructure.Dal.Models.Exposed.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStructure.Dal.Manipulation.Services
{
    public class SalesService : BaseService
    {
        public SalesService() : base() { }
        public SalesService(DataConflictPolicy policy) : base(policy) { }

        #region Alteration
        public int Create<T>(T exposedModel) where T : ISalesModel 
        {
            SaveResult result = null;

            var type = typeof(T);

            if (type == typeof(Article))
                result = this.CreateFor<DalArticle, T>(exposedModel);
            else if (type == typeof(Category))
                result = this.CreateFor<DalCategory, T>(exposedModel);

            result.Validate(1);

            return result.AlteredIds[0];
        }

        public void Modify<T>(T exposedModel) where T : ISalesModel 
        {
            SaveResult result = null;

            var type = typeof(T);

            if (type == typeof(Article))
                result = this.ModifyFor<DalArticle, T>(exposedModel);
            else if (type == typeof(Category))
                result = this.ModifyFor<DalCategory, T>(exposedModel);

            result.Validate(1);
        }

        public void Delete<T>(T exposedModel) where T : ISalesModel 
        {
            SaveResult result = null;

            var type = typeof(T);

            if (type == typeof(Article))
                result = this.DeleteFor<DalArticle, T>(exposedModel);
            else if (type == typeof(Category))
                result = this.DeleteFor<DalCategory, T>(exposedModel);

            result.Validate(1);
        }
        #endregion

        #region Data
        public T GetById<T>(int id) where T : ISalesModel 
        {
            var type = typeof(T);

            if (type == typeof(Article))
                return (T) this.GetByIdFor<DalArticle, T>(id);
            else if (type == typeof(Category))
                return (T) this.GetByIdFor<DalCategory, T>(id);

            return default(T);
        }
        #endregion
    }
}
