using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Quaider.Component.Data
{
    public class QuaiderDbContext : SqlDbContext
    {
        #region ctor

        public QuaiderDbContext()
            : base("Default") { }

        public QuaiderDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString) { }

        public QuaiderDbContext(DbConnection existingConnection)
            : base(existingConnection, true) { }

        #endregion

        //todo:解决Autofac属性注入IEnumerable
        public IEnumerable<IEntityMapper> EntityMappers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除（禁用）表名为实体类型复数的契约,（禁用）如User实体生成Users表
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            if (EntityMappers == null)
            {
                return;
            }

            foreach (var mapper in EntityMappers)
            {
                mapper.RegisterTo(modelBuilder.Configurations);
            }
        }
    }
}