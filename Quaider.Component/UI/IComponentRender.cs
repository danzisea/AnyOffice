using System.IO;
using System.Web.Mvc;

namespace Quaider.Component.UI
{
    /// <summary>
    /// 组件渲染接口
    /// </summary>
    public interface IComponentRender<T>
    {
        /// <summary>
        /// 将组件渲染的Html写入流
        /// </summary>
        /// <param name="componentModel">组件依赖模型</param>
        /// <param name="output">要写入的流</param>
        /// <param name="viewContext">viewContext</param>
        void Render(IComponentModel<T> componentModel, TextWriter output, ViewContext viewContext);
    }
}