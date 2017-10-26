using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeiShop.IService;
using WeiShop.Web.Models;

namespace WeiShop.Web.Controllers
{
    public class SortController : Controller
    {
        public ISortService SortService { get; set; }
        public IProductService ProductService { get; set; }
        public ActionResult Index()
        {
            HomeViewModel homeViewModel=new HomeViewModel();
            homeViewModel.Sorts = SortService.GetEntities(s =>true);
            return View(homeViewModel);
        }

        public ActionResult ProductList()
        {
            HomeViewModel homeViewModel=new HomeViewModel();
            homeViewModel.Products = ProductService.GetEntities(p => true);
            return View(homeViewModel);
        }

        public ActionResult ProductDetail(string proCode)
        {
            HomeViewModel homeViewModel=new HomeViewModel();
            homeViewModel.Product = ProductService.GetEntity(p =>p.Code==proCode);
            return View(homeViewModel);
        }
    }
}