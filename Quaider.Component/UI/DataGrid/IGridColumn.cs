namespace Quaider.Component.UI.DataGrid
{
    /// <summary>
    /// DataGrid 链式接口
    /// </summary>
    public interface IGridColumn
    {
        /// <summary>
        /// 列标题文本
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        IGridColumn Title(string title);
    }
}