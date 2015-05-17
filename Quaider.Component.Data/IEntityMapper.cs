using System.Data.Entity.ModelConfiguration.Configuration;

namespace Quaider.Component.Data
{
    /// <summary>
    /// 实体到数据库的映射接口
    /// </summary>
    public interface IEntityMapper
    {
        /// <summary>
        /// 将当前实体映射对象注册到当前数据访问上下文实体映射配置注册器中
        /// </summary>
        /// <param name="config">实体映射配置注册器</param>
        void RegisterTo(ConfigurationRegistrar config);
    }
}