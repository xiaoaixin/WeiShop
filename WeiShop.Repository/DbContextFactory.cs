using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiShopModel;
using System.Runtime.Remoting.Messaging;

namespace WeiShop.Repository
{
   public class DbContextFactory
    {
        public static WeiShopDb GetIntance()
        {
            var _dbContext = CallContext.GetData("dbContext") as WeiShopDb;
            if(_dbContext==null)
            {
                _dbContext = new WeiShopDb();
                CallContext.SetData("dbContext", _dbContext);
            }
            return _dbContext;
        }
    }
}
