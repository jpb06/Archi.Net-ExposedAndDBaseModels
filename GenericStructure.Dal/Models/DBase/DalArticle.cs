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
    [Table("Articles")]
    internal class DalArticle : DalModel
    {
        /* ----------------------------------------------------------*/
        [ForeignKey("Category")]
        public int IdCategory { get; set; }
        /* ----------------------------------------------------------*/

        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        [Required]
        [StringLength(2048)]
        public string Description { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public Guid ImagesPath { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        /* ----------------------------------------------------------*/
        public virtual DalCategory Category { get; set; }
        public virtual ICollection<DalOrderDetails> OrderDetails { get; set; }
        /* ----------------------------------------------------------*/

        public DalArticle() : base()
        {
            this.OrderDetails = new HashSet<DalOrderDetails>();
        }

        public override IExposedModel ToExposedModel() 
        {
            return new Article
            {
                idArticle = this.Id,        
                Title = this.Title, 
                Description = this.Description, 
                ImagesPath = this.ImagesPath,
                Price = this.Price,
                RowVersion = this.RowVersion,
                Category = this.Category != null ? (Category)this.Category.ToExposedModel() : new Category { idCategory = this.IdCategory }
            };
        }

        internal override void PopulateFrom(DalModel model)
        {
            if (model is DalArticle)
            {
                var derived = (DalArticle)model;

                this.IdCategory = derived.IdCategory;
                this.Title = derived.Title;
                this.Description = derived.Description;
                this.ImagesPath = derived.ImagesPath;
                this.Price = derived.Price;
                this.RowVersion = derived.RowVersion;
            }
        }
    }
}
