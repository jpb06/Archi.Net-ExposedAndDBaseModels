using GenericStructure.Dal.Models.DBase.Base;
using GenericStructure.Dal.Models.Exposed.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStructure.Dal.Models.DBase
{
    [Table("Customers")]
    internal class DalCustomer : DalModel
    {
        /* ----------------------------------------------------------*/

        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(128)]
        public string LastName { get; set; }

        [Required]
        [StringLength(128)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(128)]
        public string Password { get; set; }

        /* ----------------------------------------------------------*/

        public DalCustomer() : base()
        {

        }

        public override IExposedModel ToExposedModel()
        {
            throw new NotImplementedException();
        }

        internal override void PopulateFrom(DalModel model)
        {
            throw new NotImplementedException();
        }
    }
}
