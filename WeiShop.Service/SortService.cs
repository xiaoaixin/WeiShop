﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiShop.IRepository;
using WeiShop.IService;
using WeiShopModel;

namespace WeiShop.Service
{
   public class SortService:BaseService<Sort>,ISortService
    {
        public SortService(IBaseRepository<Sort> baseRepository) : base(baseRepository)
        {
        }
    }
}
