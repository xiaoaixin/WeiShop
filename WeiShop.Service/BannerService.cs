using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiShopModel;
using WeiShop.IRepository;
using WeiShop.IService;

namespace WeiShop.Service
{
   public class BannerService:BaseService<Banner>,IBannerService
    {
        public BannerService(IBaseRepository<Banner> bannerRepository) : base(bannerRepository)
        {

        }
    }
}
