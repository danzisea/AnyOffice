using System.Collections.Generic;
using System.Text;

namespace Quaider.Component.UI
{
    public static class EasyUiHelper
    {
        /// <summary>
        /// 生成data-options字符串
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public static string BuildOptions(IDictionary<string, object> attributes)
        {
            var builder = new StringBuilder();

            int i = 0;
            foreach (var attr in attributes)
            {
                if (attr.Value is string)
                    builder.AppendFormat("{0}:'{1}'", attr.Key, attr.Value);
                else if (attr.Value is bool)
                    builder.AppendFormat("{0}:{1}", attr.Key, attr.Value.ToString().ToLower());
                else
                    builder.AppendFormat("{0}:{1}", attr.Key, attr.Value);

                if ((attributes.Count - 1) != i)
                {
                    builder.Append(",");
                }
                i++;
            }

            return string.Format("data-options=\"{0}\"", builder);
        }
    }
}