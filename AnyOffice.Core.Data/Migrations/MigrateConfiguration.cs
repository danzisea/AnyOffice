using System.Data.Entity.Migrations;
using Quaider.Component.Data;

namespace AnyOffice.Core.Data.Migrations
{
    internal sealed class MigrateConfiguration : DbMigrationsConfiguration<QuaiderDbContext>
    {
        public MigrateConfiguration()
        {
            //任何实体的修改会直接更新DB
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        /// <summary>
        /// 数据迁移（数据初始化）
        /// </summary>
        protected override void Seed(QuaiderDbContext context)
        {
            int a = 1;
            base.Seed(context);
        }
    }
}