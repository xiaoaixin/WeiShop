using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeiShop.Web.Controllers
{
    public class UserCenterController : Controller
    {
        // GET: User
        public ActionResult Index()//个人中心
        {
            return View();
        }

        public ActionResult MyOrder()//全部订单
        {
            return View();
        }

        public ActionResult NoPay()//待付款
        {
            return View();
        }
    }
}