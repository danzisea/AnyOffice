using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Mvc;

namespace Quaider.Component.UI.DataGrid
{
    public class HtmlTableGridRenderer : IGridRenderer
    {
        protected IGridModel GridModel { get; private set; }
        protected ViewContext Context { get; private set; }
        private TextWriter _writer;

        public void Render(IGridModel gridModel, TextWriter output, ViewContext viewContext)
        {
            GridModel = gridModel;
            _writer = output;
            Context = viewContext;

            RenderTable();
        }

        protected virtual void RenderTable()
        {
            RenderGridStart();
            RenderHead();
            //There is no body here
            RenderGridEnd();
        }

        #region Helpers 待优化的实现

        /// <summary>
        /// 将Html写入流
        /// </summary>
        /// <param name="html"></param>
        void RenderText(string html)
        {
            _writer.Write(html);
        }

        /// <summary>
        /// 换行
        /// </summary>
        void RenderWrap()
        {
            RenderText("\r\n");
        }

        /// <summary>
        /// 写入流后换行
        /// </summary>
        void RenderTextLine(string html)
        {
            RenderText(html);
            RenderWrap();
        }

        void RenderGridStart()
        {
            string attrs = EasyUiHelper.BuildOptions(GridModel.Attributes);

            if (attrs.Length > 0)
                attrs = " " + attrs;

            RenderTextLine(string.Format("<table class=\"easyui-datagrid\"{0}>", attrs));
        }

        void RenderGridEnd()
        {
            RenderText("</table>");
        }

        /// <summary>
        /// 列头
        /// </summary>
        void RenderHead()
        {
            RenderTextLine("\t<thead>");
            RenderTextLine("\t\t<tr>");
            RenderColumns();
            RenderTextLine("\t\t</tr>");
            RenderTextLine("\t</thead>");
        }

        void RenderColumns()
        {
            foreach (var column in GridModel.Columns)
            {
                var th = "\t\t\t<th{0}>";
                string attrs = column.GetColumnOptions();
                if (attrs.Length > 0)
                    attrs = " " + attrs;
                RenderText(string.Format(th, attrs));
                RenderText(column.Title);

                RenderTextLine("</th>");
            }
        }

        #endregion
    }
}