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
    [Table("Orders")]
    internal class DalOrder : DalModel
    {
        /* ----------------------------------------------------------*/
        [ForeignKey("Customer")]
        public int IdCustomer { get; set; }
        /* ----------------------------------------------------------*/

        [Required]
        [StringLength(256)]
        public string Reference { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public DateTime ShipDate { get; set; }

        [Required]
        [StringLength(20)]
        public string PaymentCardMember { get; set; }

        [Required]
        public DateTime PaymentCardExpiration { get; set; }

        /* ----------------------------------------------------------*/
        public DalCustomer Customer { get; set; }
        public virtual ICollection<DalOrderDetails> OrderDetails { get; set; }
        /* ----------------------------------------------------------*/

        public DalOrder() : base()
        {
            this.OrderDetails = new HashSet<DalOrderDetails>();
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
