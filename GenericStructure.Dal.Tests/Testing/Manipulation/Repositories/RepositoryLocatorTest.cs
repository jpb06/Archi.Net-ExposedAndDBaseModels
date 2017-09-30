using GenericStructure.Dal.Context;
using GenericStructure.Dal.Context.Contracts;
using GenericStructure.Dal.Manipulation.Repositories;
using GenericStructure.Dal.Manipulation.Repositories.Contracts;
using GenericStructure.Dal.Manipulation.Repositories.Implementation.Base;
using GenericStructure.Dal.Manipulation.Repositories.Implementation.Specific;
using GenericStructure.Dal.Models.DBase;
using GenericStructure.Dal.Models.DBase.Base;
using GenericStructure.Dal.Models.DBase.Exposed.Sales;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStructure.Dal.Tests.Testing.Manipulation.Repositories
{
    [TestFixture]
    public class RepositoryLocatorTest
    {
        private IDBContext context;

        [OneTimeSetUp]
        public void Init()
        {
            this.context = new GenericStructureContext();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            this.context.Dispose();
        }

        //[Test]
        //public void FindGenericRepository() 
        //{
        //    var repository = RepositoryLocator.Instance.FindGenericRepository<DBaseArticle>(this.context);

        //    Assert.IsInstanceOf<GenericRepository<DBaseArticle>>(repository);
        //}

        //[Test]
        //public void FindRepository_Generic()
        //{
        //    var repository = RepositoryLocator.Instance.FindRepository<IGenericRepository<DBaseArticle>, DBaseArticle>(this.context);

        //    Assert.IsInstanceOf<GenericRepository<DBaseArticle>>(repository);
        //}

        //[Test]
        //public void FindRepository_Specific()
        //{
        //    var repository = RepositoryLocator.Instance.FindRepository<IArticlesRepository, DBaseArticle>(this.context);

        //    Assert.IsInstanceOf<ArticlesRepository>(repository);
        //}

        //[Test]
        //public void FindGenericRepository_UnmappedModel()
        //{
        //    Exception ex = Assert.Throws<Exception>(() => 
        //    { 
        //        RepositoryLocator.Instance.FindGenericRepository<DBaseModel>(this.context); 
        //    });
        //    Assert.That(ex.Message, Is.EqualTo("Mapping is missing for GenericStructure.Dal.Models.DBase.Base.DBaseModel"));
        //}

        //[Test]
        //public void FindRepository_UnmappedModel()
        //{
        //    Exception ex = Assert.Throws<Exception>(() =>
        //    {
        //        RepositoryLocator.Instance.FindRepository<IGenericRepository<DBaseModel>, DBaseModel>(this.context);
        //    });
        //    Assert.That(ex.Message, Is.EqualTo("Mapping is missing for GenericStructure.Dal.Models.DBase.Base.DBaseModel"));
        //}
    }
}
