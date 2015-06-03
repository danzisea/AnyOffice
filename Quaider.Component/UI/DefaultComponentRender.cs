using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Quaider.Component.UI
{
    public class DefaultComponentRender<T> : IComponentRender<T>
    {
        private TextWriter _writer;

        protected TextWriter Writer
        {
            get { return _writer; }
        }

        protected ViewContext Context { get; private set; }

        protected IComponentModel<T> ComponentModel { get; private set; }

        public void Render(IComponentModel<T> componentModel, TextWriter output, ViewContext viewContext)
        {
            _writer = output;
            Context = viewContext;
            ComponentModel = componentModel;

            RenderStart();
            RenderBody();
            RenderEnd();
        }

        protected virtual string BeginTag
        {
            get { return "<div{0}>"; }
        }

        protected virtual string EndTag
        {
            get { return "</div>"; }
        }

        protected virtual StringBuilder GetDataOptions()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var option in ComponentModel.DataOptions)
            {
                if (option.Value is string)
                {
                    builder.AppendFormat("{0}:'{1}'", option.Key, option.Value);
                }
                else if (option.Value is bool)
                {
                    builder.AppendFormat("{0}:{1}", option.Key, option.Value.ToString().ToLower());
                }
                else
                {
                    builder.AppendFormat("{0}:{1}", option.Key, option.Value);
                }

                if (option.Key != ComponentModel.DataOptions.Keys.Last())
                    builder.Append(",");
            }

            return builder;
        }

        protected virtual StringBuilder GetAttributes()
        {
            StringBuilder builder = new StringBuilder();
            if (ComponentModel.Attributes == null || !ComponentModel.Attributes.Keys.Any())
                return builder;

            builder.Append(" ");

            foreach (var attr in ComponentModel.Attributes)
            {
                if (!(attr.Value is IDictionary<string, object>))
                {
                    builder.AppendFormat("{0}=\"{1}\"", attr.Key, attr.Value);
                }
                else
                    builder.AppendFormat("{0}=\"{1}\"", attr.Key, GetDataOptions());

                if (attr.Key != ComponentModel.Attributes.Keys.Last())
                    builder.Append(" ");
            }

            return builder;
        }

        protected virtual void RenderStart()
        {
            RenderText(string.Format(BeginTag, GetAttributes()));
        }

        protected virtual void RenderBody()
        {
        }

        protected virtual void RenderEnd()
        {
            RenderWrapIndent(0);
            RenderText(EndTag);
        }

        #region Helpers

        /// <summary>
        /// 将Html写入流
        /// </summary>
        /// <param name="html"></param>
        protected void RenderText(string html)
        {
            _writer.Write(html);
        }

        /// <summary>
        /// 先换行再缩进
        /// </summary>
        protected void RenderWrapIndent(int indent = 1)
        {
            var indentStr = "\r\n";
            for (var i = 0; i < indent; i++)
            {
                indentStr += "\t";
            }

            RenderText(indentStr);
        }

        /// <summary>
        /// 写入流后换行缩进
        /// </summary>
        protected void RenderTextLine(string html)
        {
            RenderText(html);
            RenderWrapIndent();
        }

        #endregion
    }
}