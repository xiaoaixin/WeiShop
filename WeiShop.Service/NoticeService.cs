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
    public class NoticeService : BaseService<Notice>, INoticeService
    {
        public NoticeService(IBaseRepository<Notice> baseRepository) : base(baseRepository)
        {
        }
    }
}
