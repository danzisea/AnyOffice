
using System.Text;

namespace Quaider.Component.Logs.Formats
{
    /// <summary>
    /// 日志消息基格式器
    /// </summary>
    internal abstract class FormatterBase
    {
        /// <summary>
        /// 初始化日志消息格式器
        /// </summary>
        /// <param name="message">日志消息</param>
        protected FormatterBase(LogMessage message)
        {
            Message = message;
            Result = new StringBuilder();
        }

        /// <summary>
        /// 日志消息
        /// </summary>
        public LogMessage Message { get; set; }

        /// <summary>
        /// 输出结果
        /// </summary>
        public StringBuilder Result { get; set; }

        /// <summary>
        /// 格式化
        /// </summary>
        public abstract string Format();

        /// <summary>
        /// 添加消息
        /// </summary>
        protected void Add(string caption, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return;
            Result.AppendFormat("{0}: {1}   ", caption, value);
        }
    }
}
