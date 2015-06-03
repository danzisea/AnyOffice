using System;
using System.Web;

namespace Quaider.Component.UI.DataGrid
{
    /// <summary>
    /// EasyUi DataGrid组件接口
    /// </summary>
    public interface IGrid : IHtmlString
    {
        /// <summary>
        /// 添加CSS类
        /// </summary>
        /// <param name="classes"></param>
        /// <returns></returns>
        IGrid AddClass(params string[] classes);

        /// <summary>
        /// 添加CSS类
        /// </summary>
        /// <param name="classes">空格分开的类名字符串</param>
        /// <returns></returns>
        IGrid AddClass(string classes);

        /// <summary>
        /// 定义列可以进行排序。
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        IGrid Sort(string field);

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
        /// 指定DataGrid额外属性
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns></returns>
        IGrid Extends(object attributes);

        /// <summary>
        /// 定义DataGrid列属性
        /// </summary>
        /// <returns></returns>
        IGrid Columns(Action<ColumnBuilder> columnBuilder);

        /// <summary>
        /// 设置宽度
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        IGrid Width(int width);

        /// <summary>
        /// 设置高度
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        IGrid Height(int height);

        /// <summary>
        /// 设置宽度(百分比)
        /// </summary>
        /// <param name="width">百分比</param>
        /// <returns></returns>
        IGrid Width(string width);

        /// <summary>
        /// 设置高度(百分比)
        /// </summary>
        /// <param name="height">百分比</param>
        /// <returns></returns>
        IGrid Height(string height);

        /// <summary>
        /// 是否排序
        /// </summary>
        /// <param name="isPaged"></param>
        /// <returns></returns>
        IGrid Paged(bool isPaged = true);
    }
}