using GenericStructure.Dal.Models.Exposed.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStructure.Dal.Manipulation.Services.Contracts
{
    public interface ISalesService
    {
        int Create<TExposedModel>(TExposedModel model) where TExposedModel : ISalesModel;

        void Modify<TExposedModel>(TExposedModel model) where TExposedModel : ISalesModel;

        void Delete<TExposedModel>(TExposedModel model) where TExposedModel : ISalesModel;

        TExposedModel GetById<TExposedModel>(int id) where TExposedModel : ISalesModel;
    }
}
