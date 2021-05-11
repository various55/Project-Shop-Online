﻿using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.imp
{
    public interface IDiscountCodeRepository : IRepository<DiscountCode>
    {

    }
    public class DiscountCodeRepository : RepositoryBase<DiscountCode>, IDiscountCodeRepository
    {
        public DiscountCodeRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

    }
   
}
