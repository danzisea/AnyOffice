using System;
using System.IO;

namespace Quaider.Component.UI.DataGrid
{
    public class DataGrid : IGrid
    {
        public override string ToString()
        {
            return ToHtmlString();
        }

        public string ToHtmlString()
        {
            var writer = new StringWriter();
            writer.Write("test");
            return writer.ToString();
        }

        public IGrid Sort(params string[] fields)
        {
            return this;
        }

        public IGrid Toolbar(string toolbar)
        {
            return this;
        }

        public IGrid Url(string uri)
        {
            return this;
        }

        public IGrid Columns(Action<ColumnBuilder> columnBuilder)
        {
            return this;
        }


        public IGrid OrderBy()
        {
            return this;
        }

        public IGrid OrderByDesc()
        {
            return this;
        }
    }
}