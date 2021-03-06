﻿using GenericStructure.Dal.Manipulation.Repositories.Implementation.Base;
using GenericStructure.Dal.Models.DBase;
using GenericStructure.Dal.Tests.Data.Mocked;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericStructure.Dal.Tests.Testing.Manipulation.Repositories
{
    [TestFixture]
    public class ArticleRepositoryTest
    {
        private GenericRepository<DalArticle> articleRepository;

        public ArticleRepositoryTest() { }

        [Test]
        public void AddArticle()
        {
            VolatileDataset store = new VolatileDataset();
            Mock<GenericRepository<DalArticle>> mockArticleRepository = new Mock<GenericRepository<DalArticle>>();

            mockArticleRepository.Setup(r => r.Insert(It.IsAny<DalArticle>()))
                                 .Callback((DalArticle a) =>
                                 {
                                     a.Id = 8;
                                     a.Category = new DalCategory
                                     {
                                         Id = 4,
                                         Title = "Category 4",
                                         RowVersion = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 }
                                     };
                                     a.RowVersion = new byte[] { 0, 0, 0, 0, 0, 0, 0, 1 };
                                     store.Articles.Add(a);
                                 }).Verifiable();
            this.articleRepository = mockArticleRepository.Object;

            DalArticle article = new DalArticle
            {
                IdCategory = 4,
                Title = "Article 8",
                Description = "Description 8",
                ImagesPath = Guid.NewGuid(),
                Price = 100m
            };

            this.articleRepository.Insert(article);

            mockArticleRepository.Verify(r => r.Insert(It.IsAny<DalArticle>()), Times.Once());
            Assert.AreEqual(8, store.Articles.Count);
            Assert.AreEqual(8, store.Articles.Last().Id);
        }

        [Test]
        public void UpdateArticle()
        {
            VolatileDataset store = new VolatileDataset();
            Mock<GenericRepository<DalArticle>> mockArticleRepository = new Mock<GenericRepository<DalArticle>>();

            mockArticleRepository.Setup(r => r.Update(It.IsAny<DalArticle>()))
                                 .Callback((DalArticle a) =>
                                 {
                                     var index = store.Articles.FindIndex(el => el.Id == a.Id);
                                     store.Articles[index] = a;
                                 }).Verifiable();
            this.articleRepository = mockArticleRepository.Object;

            DalArticle article = store.Articles.ElementAt(4);
            string newTitle = article.Title = "a5";
            string newDescription = article.Description = "a5d";

            this.articleRepository.Update(article);

            mockArticleRepository.Verify(r => r.Update(It.IsAny<DalArticle>()), Times.Once());
            Assert.AreEqual(newTitle, store.Articles.ElementAt(4).Title);
            Assert.AreEqual(newDescription, store.Articles.ElementAt(4).Description);

        }

        [Test]
        public void DeleteArticle()
        {
            VolatileDataset store = new VolatileDataset();
            Mock<GenericRepository<DalArticle>> mockArticleRepository = new Mock<GenericRepository<DalArticle>>();

            mockArticleRepository.Setup(r => r.Delete(It.IsAny<DalArticle>()))
                                 .Callback((DalArticle a) =>
                                 {
                                     store.Articles.Remove(a);
                                 }).Verifiable();
            this.articleRepository = mockArticleRepository.Object;

            DalArticle article = store.Articles.ElementAt(5);

            this.articleRepository.Delete(article);

            mockArticleRepository.Verify(r => r.Delete(It.IsAny<DalArticle>()), Times.Once());
            Assert.AreEqual(6, store.Articles.Count);
        }

        [Test]
        public void DeleteArticleById()
        {
            VolatileDataset store = new VolatileDataset();
            Mock<GenericRepository<DalArticle>> mockArticleRepository = new Mock<GenericRepository<DalArticle>>();

            mockArticleRepository.Setup(r => r.Delete(It.IsAny<int>()))
                                 .Callback((object a) =>
                                 {
                                     var index = store.Articles.FindIndex(el => el.Id == (int)a);
                                     store.Articles.RemoveAt(index);
                                 }).Verifiable();
            this.articleRepository = mockArticleRepository.Object;

            this.articleRepository.Delete(1);

            mockArticleRepository.Verify(r => r.Delete(It.IsAny<int>()), Times.Once());
            Assert.AreEqual(6, store.Articles.Count);
        }

        [Test]
        public void GetArticleById()
        {
            VolatileDataset store = new VolatileDataset();
            Mock<GenericRepository<DalArticle>> mockArticleRepository = new Mock<GenericRepository<DalArticle>>();

            mockArticleRepository.Setup(r => r.GetByID(It.IsInRange<int>(1, 6, Range.Inclusive)))
                                 .Returns<int>(id => store.Articles.Find(el => el.Id == id));
            this.articleRepository = mockArticleRepository.Object;

            DalArticle article = this.articleRepository.GetByID(1);
            DalArticle storedArticle = store.Articles.Single(el => el.Id == 1);

            Assert.AreEqual(article.Title, storedArticle.Title);
            Assert.AreEqual(article.Description, storedArticle.Description);
            Assert.AreEqual(article.IdCategory, storedArticle.IdCategory);
        }

        [Test]
        public void GetArticleById_DoesntExist()
        {
            VolatileDataset store = new VolatileDataset();
            Mock<GenericRepository<DalArticle>> mockArticleRepository = new Mock<GenericRepository<DalArticle>>();

            mockArticleRepository.Setup(r => r.GetByID(It.IsNotIn<int>(1, 2, 3, 4, 5, 6)))
                                 .Returns<DalArticle>(null);
            this.articleRepository = mockArticleRepository.Object;

            DalArticle article = this.articleRepository.GetByID(10);

            Assert.AreEqual(null, article);
        }

        [Test]
        public void GetArticles_IdCategoryFiltered()
        {
            VolatileDataset store = new VolatileDataset();
            Mock<GenericRepository<DalArticle>> mockArticleRepository = new Mock<GenericRepository<DalArticle>>();

            mockArticleRepository.Setup(r => r.Get(It.IsAny<Expression<Func<DalArticle, bool>>>(), null, null))
                                 .Returns((Expression<Func<DalArticle, bool>> filter,
                                           Func<IQueryable<DalArticle>, IOrderedQueryable<DalArticle>> orderBy,
                                           string includeProperties) => store.Articles.Where(filter.Compile()));
            this.articleRepository = mockArticleRepository.Object;

            var result = this.articleRepository.Get(a => a.IdCategory == 1);

            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public void GetArticles_MinimumPriceFiltered()
        {
            VolatileDataset store = new VolatileDataset();
            Mock<GenericRepository<DalArticle>> mockArticleRepository = new Mock<GenericRepository<DalArticle>>();

            mockArticleRepository.Setup(r => r.Get(It.IsAny<Expression<Func<DalArticle, bool>>>(), null, null))
                                 .Returns((Expression<Func<DalArticle, bool>> filter,
                                           Func<IQueryable<DalArticle>, IOrderedQueryable<DalArticle>> orderBy,
                                           string includeProperties) => store.Articles.Where(filter.Compile()));
            this.articleRepository = mockArticleRepository.Object;

            var result = this.articleRepository.Get(filter: a => a.Price > 100m);

            Assert.AreEqual(4, result.Count());
        }

        [Test]
        public void GetArticles_Ordered()
        {
            VolatileDataset store = new VolatileDataset();
            Mock<GenericRepository<DalArticle>> mockArticleRepository = new Mock<GenericRepository<DalArticle>>();

            mockArticleRepository.Setup(r => r.Get(null, It.IsAny<Func<IQueryable<DalArticle>, IOrderedQueryable<DalArticle>>>(), null))
                                 .Returns((Expression<Func<DalArticle, bool>> filter,
                                           Func<IQueryable<DalArticle>, IOrderedQueryable<DalArticle>> orderBy,
                                           string includeProperties) => orderBy.Invoke(store.Articles.AsQueryable()));
            this.articleRepository = mockArticleRepository.Object;

            var result = this.articleRepository.Get(orderBy: q => q.OrderByDescending(a => a.Id));

            Assert.AreEqual(7, result.Count());
            Assert.AreEqual(1, result.Last().Id);
            Assert.AreEqual(7, result.First().Id);
        }

        [Test]
        public void GetArticles_PriceFilteredAndOrdered()
        {
            VolatileDataset store = new VolatileDataset();
            Mock<GenericRepository<DalArticle>> mockArticleRepository = new Mock<GenericRepository<DalArticle>>();

            mockArticleRepository.Setup(r => r.Get(It.IsAny<Expression<Func<DalArticle, bool>>>(),
                                                   It.IsAny<Func<IQueryable<DalArticle>, IOrderedQueryable<DalArticle>>>(),
                                                   null))
                                 .Returns((Expression<Func<DalArticle, bool>> filter,
                                           Func<IQueryable<DalArticle>, IOrderedQueryable<DalArticle>> orderBy,
                                           string includeProperties) => orderBy.Invoke(store.Articles.Where(filter.Compile()).AsQueryable()));
            this.articleRepository = mockArticleRepository.Object;

            var result = this.articleRepository.Get(filter: a => a.Price > 100m,
                                                    orderBy: q => q.OrderByDescending(a => a.Price));

            Assert.AreEqual(4, result.Count());
            Assert.AreEqual(150m, result.Last().Price);
            Assert.AreEqual(1000.0m, result.First().Price);
        }
    }
}
