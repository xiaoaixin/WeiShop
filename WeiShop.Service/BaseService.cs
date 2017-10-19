using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiShopModel;
using WeiShop.IRepository;
using WeiShop.IService;
using System.Linq.Expressions;

namespace WeiShop.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        private IBaseRepository<TEntity> _baseRepository;
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public bool Add(TEntity tEntity)
        {
            _baseRepository.Insert(tEntity);
            return _baseRepository.SaveChanges();
        }
        public bool Remove(TEntity tEntity)
        {
            _baseRepository.Delete(tEntity);
            return _baseRepository.SaveChanges();
        }
        public bool Modity(TEntity tEntity)
        {
            _baseRepository.Update(tEntity);
            return _baseRepository.SaveChanges();
        }
        public int GetCount(Func<TEntity, bool> whereLambda)
        {
            return _baseRepository.QueryCount(whereLambda);
        }
        public TEntity GetEntity(Func<TEntity, bool> whereLambda)
        {
            return _baseRepository.QueryEntity(whereLambda);
        }
        public IEnumerable<TEntity> GetEntities(Func<TEntity, bool> whereLambda)
        {
            return _baseRepository.QueryEntities(whereLambda);
        }

        public IEnumerable<TEntity> GetEntitiesByPage<TType>(int pageSize, int pageIndex, bool isAsc, Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, TType>> orderByLambda)
        {
            return _baseRepository.QueryEntitiesByPage(pageSize, pageIndex, isAsc, whereLambda, orderByLambda);
        }

        
    }
}
