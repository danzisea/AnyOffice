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

        /// <summary>
        /// 设置宽度
        /// </summary>
        /// <param name="width">宽度</param>
        /// <returns></returns>
        IGridColumn Width(int width);

        /// <summary>
        /// 设置宽度(百分比)
        /// </summary>
        /// <param name="width">百分比</param>
        /// <returns></returns>
        IGridColumn Width(string width);

        /// <summary>
        /// 是否可排序
        /// </summary>
        /// <param name="isSortable"></param>
        /// <returns></returns>
        IGridColumn Sortable(bool isSortable = true);

        /// <summary>
        /// 是否可见
        /// </summary>
        /// <param name="visible"></param>
        /// <returns></returns>
        IGridColumn Visible(bool visible = true);

        /// <summary>
        /// 如果为true，则显示复选框。该复选框列固定宽度。
        /// </summary>
        /// <param name="showCheckbox"></param>
        /// <returns></returns>
        IGridColumn Checkbox(bool showCheckbox = true);

        /// <summary>
        /// 为列指定额外属性
        /// </summary>
        /// <param name="attributes">属性对象</param>
        /// <returns></returns>
        IGridColumn Extends(object attributes);
    }
}