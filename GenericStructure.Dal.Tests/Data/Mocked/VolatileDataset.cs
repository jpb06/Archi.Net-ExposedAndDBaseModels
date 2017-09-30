using GenericStructure.Dal.Models.DBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStructure.Dal.Tests.Data.Mocked
{
    public class VolatileDataset
    {
        internal List<DalArticle> Articles { get; set; }
        internal List<DalCategory> Categories { get; set; }
        internal List<DalCustomer> Customers { get; set; }
        internal List<DalOrderDetails> OrderDetails { get; set; }
        internal List<DalOrder> Orders { get; set; }

        public VolatileDataset()
        {
            this.Articles = new List<DalArticle>();
            this.Categories = new List<DalCategory>();
            this.Customers = new List<DalCustomer>();
            this.OrderDetails = new List<DalOrderDetails>();
            this.Orders = new List<DalOrder>();

            this.Populate();
        }

        public void Populate()
        {
            #region Articles
            this.Articles.AddRange(new List<DalArticle>()
            { 
                new DalArticle
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 1,
                    IdCategory = 1,
                    Category = new DalCategory 
                    {
                        Id = 1, 
                        Title = "Category 1"
                    }, 
                    Title = "Article 1", 
                    Description = "Article 1 description", 
                    ImagesPath = Guid.NewGuid(), 
                    Price = 100m
                },
                new DalArticle
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 2,
                    IdCategory = 1,
                    Category = new DalCategory 
                    {
                        Id = 1, 
                        Title = "Category 1"
                    }, 
                    Title = "Article 2", 
                    Description = "Article 2 description", 
                    ImagesPath = Guid.NewGuid(), 
                    Price = 50m
                },
                new DalArticle
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 3,
                    IdCategory = 1,
                    Category = new DalCategory 
                    {
                        Id = 1, 
                        Title = "Category 1"
                    }, 
                    Title = "Article 3", 
                    Description = "Article 3 description", 
                    ImagesPath = Guid.NewGuid(), 
                    Price = 150m
                },
                new DalArticle
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 4,
                    IdCategory = 2,
                    Category = new DalCategory 
                    {
                        Id = 2, 
                        Title = "Category 2"
                    }, 
                    Title = "Article 4", 
                    Description = "Article 4 description", 
                    ImagesPath = Guid.NewGuid(), 
                    Price = 250m
                },
                new DalArticle
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 5,
                    IdCategory = 2,
                    Category = new DalCategory 
                    {
                        Id = 2, 
                        Title = "Category 2"
                    }, 
                    Title = "Article 5", 
                    Description = "Article 5 description", 
                    ImagesPath = Guid.NewGuid(), 
                    Price = 0.99m
                },
                new DalArticle
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 6,
                    IdCategory = 3,
                    Category = new DalCategory 
                    {
                        Id = 3, 
                        Title = "Category 3"
                    }, 
                    Title = "Article 6", 
                    Description = "Article 6 description", 
                    ImagesPath = Guid.NewGuid(), 
                    Price = 1000.0m
                },
                new DalArticle
                {
                    RowVersion = new byte[] {0, 0, 0, 0, 0, 0, 0, 0},
                    Id = 7,
                    IdCategory = 4,
                    Category = new DalCategory 
                    {
                        Id = 4, 
                        Title = "Category 4"
                    }, 
                    Title = "Art 7", 
                    Description = "Art 7 description", 
                    ImagesPath = Guid.NewGuid(), 
                    Price = 255.0m
                }
            });
            #endregion
        }
    }
}
