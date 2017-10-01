using GenericStructure.Dal.Manipulation.Repositories;
using GenericStructure.Dal.Manipulation.Services.Base;
using GenericStructure.Dal.Manipulation.Services.Configuration;
using GenericStructure.Dal.Manipulation.Services.Contracts;
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
    public class SalesService : BaseService, ISalesService
    {
        public SalesService() : base() { }
        public SalesService(DataConflictPolicy policy) : base(policy) { }

        #region Alteration
        public int Create<TExposedModel>(TExposedModel model) where TExposedModel : ISalesModel 
        {
            SaveResult result = null;

            var type = typeof(TExposedModel);

            if (type == typeof(Article))
                result = base.CreateFor<DalArticle, TExposedModel>(model);
            else if (type == typeof(Category))
                result = base.CreateFor<DalCategory, TExposedModel>(model);

            result.Validate(1);

            return result.AlteredIds[0];
        }

        public void Modify<TExposedModel>(TExposedModel model) where TExposedModel : ISalesModel 
        {
            SaveResult result = null;

            var type = typeof(TExposedModel);

            if (type == typeof(Article))
                result = base.ModifyFor<DalArticle, TExposedModel>(model);
            else if (type == typeof(Category))
                result = base.ModifyFor<DalCategory, TExposedModel>(model);

            result.Validate(1);
        }

        public void Delete<TExposedModel>(TExposedModel model) where TExposedModel : ISalesModel 
        {
            SaveResult result = null;

            var type = typeof(TExposedModel);

            if (type == typeof(Article))
                result = base.DeleteFor<DalArticle, TExposedModel>(model);
            else if (type == typeof(Category))
                result = base.DeleteFor<DalCategory, TExposedModel>(model);

            result.Validate(1);
        }
        #endregion

        #region Data
        public TExposedModel GetById<TExposedModel>(int id) where TExposedModel : ISalesModel 
        {
            var type = typeof(TExposedModel);

            if (type == typeof(Article))
                return (TExposedModel)base.GetByIdFor<DalArticle, TExposedModel>(id);
            else if (type == typeof(Category))
                return (TExposedModel)base.GetByIdFor<DalCategory, TExposedModel>(id);

            return default(TExposedModel);
        }
        #endregion
    }
}
