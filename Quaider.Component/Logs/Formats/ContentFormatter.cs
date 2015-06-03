namespace Quaider.Component.Logs.Formats
{
    /// <summary>
    /// 内容格式器
    /// </summary>
    internal class ContentFormatter : FormatterBase
    {
        /// <summary>
        /// 初始化内容格式器
        /// </summary>
        /// <param name="message">日志消息</param>
        public ContentFormatter(LogMessage message)
            : base(message)
        {
        }

        /// <summary>
        /// 格式化
        /// </summary>
        public override string Format()
        {
            if (string.IsNullOrWhiteSpace(Message.Content))
                return string.Empty;
            Result.Append("内容:").AppendLine();
            Result.Append(Message.Content);
            return Result.ToString();
        }
    }
}
