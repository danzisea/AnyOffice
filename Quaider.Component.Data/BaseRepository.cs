using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Quaider.Component.Data
{
    public class BaseRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : EntityBase<TKey>
    {
        private readonly QuaiderDbContext _context;

        private readonly DbSet<TEntity> _entities;

        public BaseRepository(QuaiderDbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity, TKey>();
        }

        public IQueryable<TEntity> Entities
        {
            get { return _entities; }
        }

        /// <summary>
        /// 根据主键获取单个实体
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns>实体</returns>
        public TEntity GetByKey(TKey key)
        {
            return _context.Set<TEntity, TKey>().Find(key);
        }

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        public void Insert(TEntity entity)
        {
            _entities.Add(entity);
        }

        /// <summary>
        /// 批量插入实体
        /// </summary>
        /// <param name="entities">实体集合</param>
        public void Insert(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                _entities.Add(entity);
        }

        /// <summary>
        /// 删除指定主键的记录
        /// </summary>
        /// <param name="key">主键值</param>
        public void Delete(TKey key)
        {
            TEntity entity = GetByKey(key);
            Delete(entity);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        /// <summary>
        /// 删除实体记录集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        public void Delete(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                _entities.Remove(entity);
        }

        /// <summary>
        /// 删除所有符合特定表达式的数据
        /// </summary>
        /// <param name="predicate">查询条件谓语表达式</param>
        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            List<TEntity> entities = _entities.Where(predicate).ToList();
            Delete(entities);
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        public void Update(TEntity entity)
        {
            _entities.Attach(entity);
            _context.Entry(entity).State = System.Data.EntityState.Modified;
        }

        /// <summary>
        /// 使用附带新值的实体信息更新指定实体属性的值
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        /// <param name="entity">附带新值的实体信息，必须包含主键</param>
        public void Update(Expression<Func<TEntity, object>> propertyExpression, TEntity entity)
        {
            throw new NotSupportedException("不支持按需更新功能。");
        }

        #region ISql

        /// <summary>
        /// 执行存储过程，且返回实体列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="commandText">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <returns>实体列表</returns>
        public IList<TEntity> ExecuteStoredProcedureList<TEntity, TKey>(string commandText, params object[] parameters) where TEntity : EntityBase<TKey>
        {
            return _context.ExecuteStoredProcedureList<TEntity, TKey>(commandText, parameters);
        }

        /// <summary>
        /// 执行一段查询命令
        /// </summary>
        /// <typeparam name="TElement">返回的类型</typeparam>
        /// <param name="sql">查询命令</param>
        /// <example>
        /// SELECT idCustomer,Name FROM dbo.[Customers] WHERE idCustomer > {0}
        /// </example>
        /// <param name="parameters">参数</param>
        /// <returns>查询结果</returns>
        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return _context.SqlQuery<TElement>(sql, parameters);
        }

        /// <summary>
        /// 执行一段查询命令
        /// </summary>
        /// <param name="commandText">
        /// 查询命令
        /// <example>
        /// Update dbo.[Customers] Set Name = {1} WHERE idCustomer = {0}
        /// </example>
        /// </param>
        /// <param name="parameters">参数</param>
        /// <returns>返回受影响的行数</returns>
        public int ExecuteSqlCommand(string commandText, params object[] parameters)
        {
            return _context.ExecuteSqlCommand(commandText, parameters);
        }

        #endregion
    }
}