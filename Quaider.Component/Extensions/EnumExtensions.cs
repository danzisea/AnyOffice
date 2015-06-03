using System;

namespace Quaider.Component.Extensions
{
    public static partial class Extensions
    {
        /// <summary>
        /// 获取描述,使用System.ComponentModel.Description特性设置描述
        /// </summary>
        /// <param name="instance">枚举实例</param>
        public static string Description(this Enum instance)
        {
            return "";
        }
    }
}