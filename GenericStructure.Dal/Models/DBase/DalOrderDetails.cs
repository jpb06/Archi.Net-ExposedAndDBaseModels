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
    [Table("OrderDetails")]
    internal class DalOrderDetails : DalModel
    {
        /* ----------------------------------------------------------*/
        [ForeignKey("Order")]
        public int IdOrder { get; set; }

        [ForeignKey("Article")]
        public int IdArticle { get; set; }
        /* ----------------------------------------------------------*/

        [Required]
        public int Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitCost { get; set; }

        [Column(TypeName = "money")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? LineItemTotal { get; set; }

        /* ----------------------------------------------------------*/
        public virtual DalOrder Order { get; set; }
        public virtual DalArticle Article { get; set; }
        /* ----------------------------------------------------------*/

        public DalOrderDetails() : base()
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
