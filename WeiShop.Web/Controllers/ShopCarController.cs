using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeiShop.IService;
using WeiShop.Web.Models;
using WeiShopModel;

namespace WeiShop.Web.Controllers
{
    public class ShopCarController : Controller
    {
        public IShopCarService ShopCarService { get; set; }
        public ShoppingCart Shopcar { get; set; }
        // GET: ShopCar
        public ActionResult Index()
        {
            HomeViewModel homeViewModel=new HomeViewModel();
            homeViewModel.ShopCars = ShopCarService.GetEntities(s => true);
            return View(homeViewModel);
        }
        /// <summary>
        /// 加入购物车
        /// </summary>
        /// <param name="procode">商品ID</param>
        /// <param name="qty">加入商品的数量</param>
        /// <returns></returns>
        public ActionResult AddShopCar(string procode,int qty)
        {
            ShoppingCart shopCart=new ShoppingCart();
            shopCart.CusId = 1;//用户的ID
            shopCart.ProCode = procode;
            shopCart.Qty = qty;
            shopCart.CreateTime = DateTime.Now;
            try
            {
                bool zt = ShopCarService.Add(shopCart);
                var msg = zt ? 1 : 0;
                return Content("商品添加成功!" );
            }
            catch (Exception )
            {
                return Content("此商品已存在，请到购物车编辑！");
            }
           
        }
    }
}