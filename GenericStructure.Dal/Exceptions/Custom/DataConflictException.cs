using GenericStructure.Dal.Manipulation.Services.Configuration;
using GenericStructure.Dal.Models.DBase.Base;
using GenericStructure.Dal.Models.Exposed.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStructure.Dal.Exceptions.Custom
{
    public class DataConflictException : DalException
    {
        public DataConflictException(DataConflictInfo info) : base ()
        {
            DalModel dbValues = (DalModel) info.DatabaseValues.ToObject();
            DalModel cValues = (DalModel) info.CurrentValues.ToObject();

            this.DatabaseValues = dbValues.ToExposedModel();
            this.CurrentValues = cValues.ToExposedModel();
        }

        public IExposedModel DatabaseValues { get; set; }
        public IExposedModel CurrentValues { get; set; }
    }
}
