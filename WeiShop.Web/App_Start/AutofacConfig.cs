using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace WeiShop.Web.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterDenpendency()
        {
            //1 创建一个容器配置对象
            var builder = new ContainerBuilder();
            //2 注册当前MVC应用里的所有控制器（自动注册，只需要给他提供，要注册的程序集）
            //Assembly.GetExecutingAssembly() 获取当前运行程序中的所有类
            //PropertiesAutowired表示使用属性的方式进行.依赖注入
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

            //3 加载其他程序集的代码
            var service = Assembly.Load("WeiShop.Service");
            var repository = Assembly.Load("WeiShop.Repository");

            var iservice = Assembly.Load("WeiShop.IService");
            var irepository = Assembly.Load("WeiShop.IRepository");
            //4 注册接口的实现方（都来自于其他的程序集的类）
            builder.RegisterAssemblyTypes(service,iservice).Where(t=>t.Name.EndsWith("Service")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(repository,irepository).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces();

            //5 创建IOC容器对象
            var conteiner = builder.Build();

            //6 替换MVC内置的控制器实例化对象（专移权限）
            DependencyResolver.SetResolver(new AutofacDependencyResolver(conteiner));
        }
    }
}