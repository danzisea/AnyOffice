using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Quaider.Component.Data
{
    public interface IRepository<TEntity, in TKey> where TEntity : EntityBase<TKey>
    {
        #region 属性

        /// <summary>
        ///     获取 当前实体的查询数据集
        /// </summary>
        IQueryable<TEntity> Entities { get; }

        #endregion

        #region 方法

        /// <summary>
        /// 根据主键获取单个实体
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns>实体</returns>
        TEntity GetByKey(TKey key);

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        void Insert(TEntity entity);

        /// <summary>
        /// 批量插入实体
        /// </summary>
        /// <param name="entities">实体集合</param>
        void Insert(IEnumerable<TEntity> entities);

        /// <summary>
        /// 删除指定主键的记录
        /// </summary>
        /// <param name="key">主键值</param>
        void Delete(TKey key);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        void Delete(TEntity entity);

        /// <summary>
        /// 删除实体记录集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        void Delete(IEnumerable<TEntity> entities);

        /// <summary>
        /// 删除所有符合特定表达式的数据
        /// </summary>
        /// <param name="predicate">查询条件谓语表达式</param>
        void Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Update(TEntity entity);

        /// <summary>
        /// 使用附带新值的实体信息更新指定实体属性的值
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        /// <param name="entity">附带新值的实体信息，必须包含主键</param>
        void Update(Expression<Func<TEntity, object>> propertyExpression, TEntity entity);

        #endregion
    }
}