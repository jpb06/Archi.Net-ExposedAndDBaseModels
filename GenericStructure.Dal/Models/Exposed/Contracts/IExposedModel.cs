using GenericStructure.Dal.Models.DBase;
using GenericStructure.Dal.Models.DBase.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStructure.Dal.Models.Exposed.Contracts
{
    public interface IExposedModel
    {
        DalModel ToDBaseModel();
    }
}
