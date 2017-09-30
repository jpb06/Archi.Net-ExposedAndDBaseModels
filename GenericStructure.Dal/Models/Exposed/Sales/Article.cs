using GenericStructure.Dal.Models.DBase.Base;
using GenericStructure.Dal.Models.Exposed.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStructure.Dal.Models.DBase.Exposed.Sales
{
    public class Article : ISalesModel
    {
        public int idArticle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ImagesPath { get; set; }
        public decimal Price { get; set; }

        public Category Category { get; set; }

        public byte[] RowVersion { get; set; }

        public Article() 
        {
            this.idArticle = -1;
            this.Title = string.Empty;
            this.Description = string.Empty;
            this.ImagesPath = Guid.Empty;
            this.Price = 0m;

            this.Category = null;

            this.RowVersion = null;
        }

        public DalModel ToDBaseModel()
        {
            return new DalArticle
            {
                Id = this.idArticle, 
                IdCategory = this.Category.idCategory, 
                Title = this.Title, 
                Description = this.Description, 
                ImagesPath = this.ImagesPath, 
                Price = this.Price, 
                RowVersion = this.RowVersion
            };
        }
    }
}
