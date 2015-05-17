using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;

namespace Quaider.Component.Data
{
    /// <summary>
    /// 提供执行Sql语句和存储过程的DbContext
    /// </summary>
    public abstract class SqlDbContext : DbContext
    {
        #region ctor

        protected SqlDbContext()
            : base("Default") { }

        protected SqlDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString) { }

        protected SqlDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection) { }

        #endregion

        #region Utilities

        /// <summary>
        /// Attach an entity to the context or return an already attached entity (if it was already attached)
        /// </summary>
        /// <typeparam name="TEntity">TEntity</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns>Attached entity</returns>
        protected virtual TEntity AttachEntityToContext<TEntity, TKey>(TEntity entity) where TEntity : EntityBase<TKey>
        {
            //little hack here until Entity Framework really supports stored procedures
            //otherwise, navigation properties of loaded entities are not loaded until an entity is attached to the context
            var alreadyAttached = Set<TEntity>().Local.FirstOrDefault(x => x.Id.Equals(entity.Id));
            if (alreadyAttached == null)
            {
                //attach new entity
                Set<TEntity>().Attach(entity);
                return entity;
            }

            //entity is already loaded
            return alreadyAttached;
        }

        #endregion

        #region Methods

        public DbSet<TEntity> Set<TEntity, TKey>() where TEntity : EntityBase<TKey>
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <typeparam name="TEntity">实体</typeparam>
        /// <typeparam name="TKey">主键</typeparam>
        /// <param name="commandText">存储过程</param>
        /// <param name="parameters">参数</param>
        /// <returns>返回实例集合</returns>
        public virtual IList<TEntity> ExecuteStoredProcedureList<TEntity, TKey>(string commandText, params object[] parameters)
            where TEntity : EntityBase<TKey>
        {
            //add parameters to command
            if (parameters != null && parameters.Length > 0)
            {
                for (int i = 0; i <= parameters.Length - 1; i++)
                {
                    var p = parameters[i] as DbParameter;
                    if (p == null)
                        throw new Exception("Not support parameter type");

                    commandText += i == 0 ? " " : ", ";

                    commandText += "@" + p.ParameterName;
                    if (p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Output)
                    {
                        //output parameter
                        commandText += " output";
                    }
                }
            }

            var result = this.Database.SqlQuery<TEntity>(commandText, parameters).ToList();

            //performance hack applied as described here - http://www.nopcommerce.com/boards/t/25483/fix-very-important-speed-improvement.aspx
            bool acd = this.Configuration.AutoDetectChangesEnabled;
            try
            {
                this.Configuration.AutoDetectChangesEnabled = false;

                for (int i = 0; i < result.Count; i++)
                    result[i] = AttachEntityToContext<TEntity, TKey>(result[i]);
            }
            finally
            {
                this.Configuration.AutoDetectChangesEnabled = acd;
            }

            return result;
        }

        /// <summary>
        /// 执行一段Sql查询
        /// </summary>
        /// <typeparam name="TElement">要返回的元素</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public virtual IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return base.Database.SqlQuery<TElement>(sql, parameters);
        }

        /// <summary>
        /// 执行一个命令
        /// </summary>
        /// <param name="commandText">命令语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>返回受影响的行数</returns>
        public virtual int ExecuteSqlCommand(string commandText, params object[] parameters)
        {
            return base.Database.ExecuteSqlCommand(commandText, parameters);
        }

        #endregion
    }
}