using System.Data.Entity.ModelConfiguration;

namespace Quaider.Component.Data
{
    /// <summary>
    /// 允许模型中的类型进行配置（Version字段已配置）
    /// </summary>
    /// <typeparam name="TEntity">实体模型</typeparam>
    /// <typeparam name="TKey">主键</typeparam>
    public class QuaiderEntityTypeConfiguration<TEntity, TKey> : EntityTypeConfiguration<TEntity>
        where TEntity : EntityBase<TKey>
    {
        public QuaiderEntityTypeConfiguration()
        {
            Property(f => f.Version).IsRowVersion();
        }
    }
}