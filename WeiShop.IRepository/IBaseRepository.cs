﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WeiShop.IRepository
{
   public interface IBaseRepository<TEntity> where TEntity : class, new()
    {
        void Insert(TEntity tEntity);
        void Delete(TEntity tEntity);
        void Update(TEntity tEntity);
        bool SaveChanges();
        int QueryCount(Func<TEntity, bool> whereLambda);
        TEntity QueryEntity(Func<TEntity, bool> whereLambda);
        IEnumerable<TEntity> QueryEntities(Func<TEntity, bool> whereLambda);
        IEnumerable<TEntity> QueryEntitiesByPage<TType>(int pageSize, int pageIndex, bool isAsc, Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, TType>> orderByLambda);
    }
}
