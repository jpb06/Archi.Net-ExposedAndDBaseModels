﻿using GenericStructure.Dal.Context.Contracts;
using GenericStructure.Dal.Manipulation.Repositories.Contracts;
using GenericStructure.Dal.Manipulation.Repositories.Implementation.Base;
using GenericStructure.Dal.Models.DBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStructure.Dal.Manipulation.Repositories.Implementation.Specific
{
    internal class OrdersRepository : GenericRepository<DalOrder>, IOrdersRepository
    {
        public OrdersRepository() { }
        public OrdersRepository(IDBContext context) : base(context) { }
    }
}