namespace Quaider.Component.UI
{
    /// <summary>
    /// data-options选项
    /// </summary>
    public interface IOptions<T>
    {
        void AddAttribute(string name, string value);

        void AddDataOption(string name, object value);
    }
}