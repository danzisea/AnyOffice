using System.Collections.Generic;

namespace Quaider.Component.Data
{
    /// <summary>
    /// 支持方言查询的约定 ，其实现依据所依赖的数据库
    /// </summary>
    public interface ISql
    {
        /// <summary>
        /// 执行存储过程，且返回实体列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="commandText">存储过程名称</param>
        /// <param name="parameters">参数</param>
        /// <returns>实体列表</returns>
        IList<TEntity> ExecuteStoredProcedureList<TEntity, TKey>(string commandText, params object[] parameters)
            where TEntity : EntityBase<TKey>;

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
        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);

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
        int ExecuteSqlCommand(string commandText, params object[] parameters);
    }
}