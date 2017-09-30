using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericStructure.Dal.Manipulation;
using GenericStructure.Dal.Context.Contracts;
using GenericStructure.Dal.Context;
using GenericStructure.Dal.Manipulation.Services.Configuration;
using GenericStructure.Dal.Models.Exposed.Contracts;
using GenericStructure.Dal.Models.DBase.Base;
using GenericStructure.Dal.Manipulation.Repositories;
using GenericStructure.Dal.Manipulation.Repositories.Contracts;
using GenericStructure.Dal.Manipulation.Repositories.Implementation.Base;
using GenericStructure.Dal.Models.DBase;
using GenericStructure.Dal.Manipulation.Repositories.Implementation.Specific;
using GenericStructure.Dal.Exceptions.Custom;

namespace GenericStructure.Dal.Manipulation.Services.Base
{
    public abstract class BaseService : IDisposable
    {
        internal IDBContext context;
        private RepositoriesMapping repositoriesMapping;
        public DataConflictPolicy policy;

        public BaseService()
        {
            this.context = new GenericStructureContext();
            this.repositoriesMapping = new RepositoriesMapping(this.context);
            this.policy = DataConflictPolicy.ClientWins;
        }

        public BaseService(DataConflictPolicy policy)
        {
            this.context = new GenericStructureContext();
            this.repositoriesMapping = new RepositoriesMapping(this.context);
            this.policy = policy;
        }

        #region Generic alteration
        protected SaveResult CreateFor<TDBaseModel, TExposedModel>(TExposedModel exposedModel)
            where TDBaseModel : DalModel
            where TExposedModel : IExposedModel
        {
            TDBaseModel model = (TDBaseModel)exposedModel.ToDBaseModel();

            var repository = this.repositoriesMapping.FindGenericRepository<TDBaseModel>();
            repository.Insert(model);

            SaveResult result = this.Save(policy);
            result.AlteredIds = new int[] { model.Id };

            return result;
        }

        protected SaveResult ModifyFor<TDBaseModel, TExposedModel>(TExposedModel exposedModel)
            where TDBaseModel : DalModel
            where TExposedModel : IExposedModel
        {
            TDBaseModel model = (TDBaseModel)exposedModel.ToDBaseModel();

            var repository = this.repositoriesMapping.FindGenericRepository<TDBaseModel>();
            repository.Update(model);

            SaveResult result = this.Save(policy);
            result.AlteredIds = new int[] { model.Id };

            return result;
        }

        protected SaveResult DeleteFor<TDBaseModel, TExposedModel>(TExposedModel exposedModel)
            where TDBaseModel : DalModel
            where TExposedModel : IExposedModel
        {
            TDBaseModel model = (TDBaseModel)exposedModel.ToDBaseModel();

            var repository = this.repositoriesMapping.FindGenericRepository<TDBaseModel>();
            repository.Delete(model);

            SaveResult result = this.Save(policy);
            result.AlteredIds = new int[] { model.Id };

            return result;
        }
        #endregion

        #region Data retrieval
        protected IExposedModel GetByIdFor<TDBaseModel, TExposedModel>(int id)
            where TDBaseModel : DalModel
            where TExposedModel : IExposedModel
        {
            var repository = this.repositoriesMapping.FindGenericRepository<TDBaseModel>();

            DalModel internalModel = repository.GetByID(id);
            IExposedModel exposedModel = internalModel.ToExposedModel();

            return exposedModel;
        }
        #endregion

        protected SaveResult Save(DataConflictPolicy policy)
        {
            bool saveFailed;
            do
            {
                saveFailed = false;

                try
                {
                    int result = this.context.SaveChanges();

                    return new SaveResult { AlteredObjectsCount = result };
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    // TODO : Throw proper DalException
                    if (policy == DataConflictPolicy.NoPolicy) throw;

                    saveFailed = true;

                    DataConflictInfo info = OptimisticConcurrency.ApplyPolicy(policy, ex);
                    if (info != null) throw new DataConflictException(info);  
                }

            } while (saveFailed);

            return null;
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
