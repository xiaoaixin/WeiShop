using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeiShopModel;
using WeiShop.IService;
using WeiShop.Web.Models;

namespace WeiShop.Web.Controllers
{
    public class HomeController : Controller
    {
        public IBannerService BannerService { get; set; }
        public INoticeService NoticeService { get; set; }
        public IProductService ProductService { get; set; }
        public ActionResult Index()
        {
            HomeViewModel homeViewModel=new HomeViewModel();
            homeViewModel.NoticeNum = NoticeService.GetCount(n => true);
            homeViewModel.Notices = NoticeService.GetEntitiesByPage(3, 1, false, n => true, n => n.ModiTime);
            homeViewModel.Banners = BannerService.GetEntities(b => true);
            homeViewModel.Products = ProductService.GetEntitiesByPage(3, 1, false, p => p.Type == 1, p => p.ModiTime);

            return View(homeViewModel);
        }

        public ActionResult Ggxiang()
        {
            return View();
        }

        public ActionResult Gonggao()
        {
            return View();
        }
    }
}