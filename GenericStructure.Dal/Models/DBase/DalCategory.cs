using GenericStructure.Dal.Models.DBase.Base;
using GenericStructure.Dal.Models.DBase.Exposed.Sales;
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
    [Table("Categories")]
    internal class DalCategory : DalModel
    {
        /* ----------------------------------------------------------*/

        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        /* ----------------------------------------------------------*/
        public virtual ICollection<DalArticle> Articles { get; set; }
        /* ----------------------------------------------------------*/

        public DalCategory() : base()
        {
            this.Articles = new HashSet<DalArticle>();
        }

        public override IExposedModel ToExposedModel()
        {
            return new Category
            {
                idCategory = this.Id, 
                Title = this.Title, 
                RowVersion = this.RowVersion,
                Articles = this.Articles.Select(_ => _.ToExposedModel()).Cast<Article>().ToList()
            };
        }

        internal override void PopulateFrom(DalModel model)
        {
            if (model is DalCategory)
            {
                var derived = (DalCategory)model;

                this.Title = derived.Title;
                this.RowVersion = derived.RowVersion;
            }
        }
    }
}
