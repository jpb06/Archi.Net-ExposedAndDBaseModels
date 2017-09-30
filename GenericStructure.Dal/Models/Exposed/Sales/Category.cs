using GenericStructure.Dal.Models.DBase.Base;
using GenericStructure.Dal.Models.Exposed.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStructure.Dal.Models.DBase.Exposed.Sales
{
    public class Category : ISalesModel
    {
        public int idCategory { get; set; }
        public string Title { get; set; }

        public byte[] RowVersion { get; set; }

        public List<Article> Articles { get; set; }

        public Category() 
        {
            this.idCategory = -1;
            this.Title = string.Empty;

            this.Articles = new List<Article>();

            this.RowVersion = null;
        }

        public DalModel ToDBaseModel()
        {
            return new DalCategory 
            {
                Id = this.idCategory, 
                Title = this.Title, 
                RowVersion = this.RowVersion
            };
        }
    }
}
