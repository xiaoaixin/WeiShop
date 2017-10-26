using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeiShopModel;

namespace WeiShop.Web.Models
{
    public class HomeViewModel
    {
        public int NoticeNum { get; set; }
        public IEnumerable<Banner> Banners { get; set; }
        public IEnumerable<Notice> Notices { get; set; }
        public IEnumerable<Product> Products { get; set; }

        public Product Product { get; set; }
      
        public IEnumerable<Sort> Sorts { get; set; }

        public IEnumerable<ShoppingCart> ShopCars { get; set; }
        public ShoppingCart Shopcar { get; set; }
    }
}