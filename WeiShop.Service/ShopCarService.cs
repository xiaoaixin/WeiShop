using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiShop.IRepository;
using WeiShop.IService;
using WeiShopModel;

namespace WeiShop.Service
{
   public class ShopCarService:BaseService<ShoppingCart>,IShopCarService
    {
        public ShopCarService(IBaseRepository<ShoppingCart> baseRepository) : base(baseRepository)
        {
        }
    }
}
