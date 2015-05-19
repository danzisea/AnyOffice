using System.IO;
using System.Web.Mvc;

namespace Quaider.Component.UI.DataGrid
{
    public interface IGridRenderer
    {
        /// <summary>
        /// 将Grid写入TextWriter
        /// </summary>
        /// <param name="gridModel">存放了Grid的配置数据</param>
        /// <param name="output"></param>
        /// <param name="viewContext">View context</param>
        void Render(IGridModel gridModel, TextWriter output, ViewContext viewContext); 
    }
}