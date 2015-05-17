using System;
using System.ComponentModel.DataAnnotations;

namespace Quaider.Component
{
    /// <summary>
    /// 数据库实体基类
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    [Serializable]
    public abstract class EntityBase<TKey>
    {
        protected EntityBase()
        {
            CreateTime = DateTime.Now;
        }

        #region 属性

        [Key]
        public TKey Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 时间戳，防并发
        /// </summary>
        public byte[] Version { get; set; }

        #endregion
    }
}