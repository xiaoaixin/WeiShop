﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeiShop.IRepository;
using WeiShopModel;

namespace WeiShop.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private WeiShopDb _dbContext=DbContextFactory.GetIntance();
        private DbSet<TEntity> _dbSet;
        public BaseRepository()
        {
            _dbSet = _dbContext.Set<TEntity>();
        }

        public void Insert(TEntity tEntity)
        {
            _dbSet.Add(tEntity);
        }

        public void Delete(TEntity tEntity)
        {
            //先附加再删除
            _dbSet.Attach(tEntity);
            _dbSet.Remove(tEntity);
        }

        public void Update(TEntity tEntity)
        {
            _dbSet.Attach(tEntity);
            //更改实体的状态为 已更改
            _dbContext.Entry(tEntity).State = EntityState.Modified;
        }

        public int QueryCount(Func<TEntity, bool> whereLambda)
        {
            return _dbSet.Count(whereLambda);
        }
        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public TEntity QueryEntity(Func<TEntity, bool> whereLambda)
        {
            return _dbSet.FirstOrDefault(whereLambda);
        }

        public IEnumerable<TEntity> QueryEntities(Func<TEntity, bool> whereLambda)
        {
            return _dbSet.Where(whereLambda);
        }

        public IEnumerable<TEntity> QueryEntitiesByPage<TType>(int pageSize, int pageIndex, bool isAsc, Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, TType>> orderByLambda)
        {
            //生成查询语句          
            var result = _dbSet.Where(whereLambda);
            //附加数据库
            result = isAsc ? result.OrderBy(orderByLambda) : result.OrderByDescending(orderByLambda);
            //附加分页
            var offset = (pageIndex - 1) * pageSize;
            result = result.Skip(offset).Take(pageSize);
            return result;

        }

    }
}
