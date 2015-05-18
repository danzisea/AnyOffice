using System;
using System.Web;

namespace Quaider.Component.UI.DataGrid
{
    /// <summary>
    /// EasyUi DataGrid属性
    /// </summary>
    public interface IGrid : IHtmlString
    {
        /// <summary>
        /// 定义哪些列可以进行排序。
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        IGrid Sort(params string[] fields);

        /// <summary>
        /// 升序排序
        /// </summary>
        /// <returns></returns>
        IGrid OrderBy();

        /// <summary>
        /// 降序排序
        /// </summary>
        /// <returns></returns>
        IGrid OrderByDesc();

        /// <summary>
        /// 工具栏
        /// </summary>
        /// <param name="toolbar">jQuery Selector</param>
        /// <returns></returns>
        IGrid Toolbar(string toolbar);

        /// <summary>
        /// 一个URL从远程站点请求数据。
        /// </summary>
        /// <param name="uri">url</param>
        /// <returns></returns>
        IGrid Url(string uri);

        /// <summary>
        /// 定义DataGrid列属性
        /// </summary>
        /// <returns></returns>
        IGrid Columns(Action<ColumnBuilder> columnBuilder);
    }

    /// <summary>
    /// EasyUi列属性
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGridWithOptions : IHtmlString
    {

    }
}