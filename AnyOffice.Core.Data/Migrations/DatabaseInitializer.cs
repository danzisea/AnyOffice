using System.Data.Entity;
using Quaider.Component.Data;

namespace AnyOffice.Core.Data.Migrations
{
    /// <summary>
    /// 数据库初始化
    /// </summary>
    public class DatabaseInitializer
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<QuaiderDbContext, MigrateConfiguration>());
        }
    }
}