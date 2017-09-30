using GenericStructure.Dal.Models.DBase;
using GenericStructure.Dal.Models.DBase.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStructure.Dal.Models
{
    internal static class ModelsExtensions
    {
        //public static void PopulateFrom(this DBaseModel model, DBaseModel source)
        //{
        //    if (model is DBaseArticle && source is DBaseArticle)
        //        ((DBaseArticle)model).PopulateFrom((DBaseArticle)source);
        //    else if (model is DBaseCategory && source is DBaseCategory)
        //        ((DBaseCategory)model).PopulateFrom((DBaseCategory)source);
        //    else if (model is DBaseCustomer && source is DBaseCustomer)
        //        ((DBaseCustomer)model).PopulateFrom((DBaseCustomer)source);
        //    else if (model is DBaseOrder && source is DBaseOrder)
        //        ((DBaseOrder)model).PopulateFrom((DBaseOrder)source);
        //    else if (model is DBaseOrderDetails && source is DBaseOrderDetails)
        //        ((DBaseOrderDetails)model).PopulateFrom((DBaseOrderDetails)source);
        //}

        //public static void PopulateFrom(this DBaseArticle article, DBaseArticle source) 
        //{
        //    article.IdCategory = source.IdCategory;
        //    article.Title = source.Title;
        //    article.Description = source.Description;
        //    article.ImagesPath = source.ImagesPath;
        //    article.Price = source.Price;
        //    article.RowVersion = source.RowVersion;
        //}

        //public static void PopulateFrom(this DBaseCategory category, DBaseCategory source)
        //{
        //    category.Title = source.Title;
        //    category.RowVersion = source.RowVersion;
        //}

        //public static void PopulateFrom(this DBaseCustomer customer, DBaseCustomer source)
        //{
        //    customer.FirstName = source.FirstName;
        //    customer.LastName = source.LastName;
        //    customer.EmailAddress = source.EmailAddress;
        //    customer.Password = source.Password;
        //    customer.RowVersion = source.RowVersion;
        //}

        //public static void PopulateFrom(this DBaseOrder order, DBaseOrder source)
        //{
        //    order.IdCustomer = source.IdCustomer;
        //    order.Reference = source.Reference;
        //    order.OrderDate = source.OrderDate;
        //    order.ShipDate = source.ShipDate;
        //    order.PaymentCardMember = source.PaymentCardMember;
        //    order.PaymentCardExpiration = source.PaymentCardExpiration;
        //    order.RowVersion = source.RowVersion;
        //}

        //public static void PopulateFrom(this DBaseOrderDetails orderDetails, DBaseOrderDetails source)
        //{
        //    orderDetails.IdOrder = source.IdOrder;
        //    orderDetails.IdArticle = source.IdArticle;
        //    orderDetails.Quantity = source.Quantity;
        //    orderDetails.UnitCost = source.UnitCost;
        //    orderDetails.LineItemTotal = source.LineItemTotal;
        //    orderDetails.RowVersion = source.RowVersion;
        //}
    }
}
