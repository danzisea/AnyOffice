
namespace Quaider.Component.Logs.Formats
{
    /// <summary>
    /// Sql参数格式器
    /// </summary>
    internal class SqlParamsFormatter : FormatterBase
    {
        /// <summary>
        /// 初始化Sql参数格式器
        /// </summary>
        /// <param name="message">日志消息</param>
        public SqlParamsFormatter(LogMessage message)
            : base(message)
        {
        }

        /// <summary>
        /// 格式化
        /// </summary>
        public override string Format()
        {
            if (string.IsNullOrWhiteSpace(Message.SqlParams))
                return string.Empty;
            Result.Append("Sql参数:").AppendLine();
            Result.Append(Message.SqlParams);
            return Result.ToString();
        }
    }
}
