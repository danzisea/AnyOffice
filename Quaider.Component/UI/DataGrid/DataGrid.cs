using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Quaider.Component.UI.DataGrid
{
    public class DataGrid : IGrid
    {
        private readonly IGridModel _gridModel = new GridModel();

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

        public IGrid Sort(string field)
        {
            _gridModel.Sort = new GridSortOptions { Column = field, Direction = SortDirection.Ascending };
            return this;
        }

        public IGrid Toolbar(string toolbar)
        {
            if (_gridModel.Attributes.ContainsKey("toolbar"))
                _gridModel.Attributes.Remove("toolbar");
            _gridModel.Attributes.Add("toolbar", toolbar);
            return this;
        }

        public IGrid Url(string uri)
        {
            if (_gridModel.Attributes.ContainsKey("url"))
                _gridModel.Attributes.Remove("url");
            _gridModel.Attributes.Add("url", uri);
            return this;
        }

        public IGrid Columns(Action<ColumnBuilder> columnBuilder)
        {
            var builder = new ColumnBuilder();
            columnBuilder(builder);

            foreach (var column in builder)
            {
                _gridModel.Columns.Add(column);
            }

            return this;
        }

        public IGrid OrderBy()
        {
            if (_gridModel.Sort == null)
                throw new InvalidOperationException("必须先指定排序字段.");

            _gridModel.Sort.Direction = SortDirection.Ascending;

            return this;
        }

        public IGrid OrderByDesc()
        {
            if (_gridModel.Sort == null)
                throw new InvalidOperationException("必须先指定排序字段.");

            _gridModel.Sort.Direction = SortDirection.Descending;

            return this;
        }

        public IGrid Extends(object attributes)
        {
            if (attributes == null) return this;
            IDictionary<string,object> attrs = HtmlHelper.AnonymousObjectToHtmlAttributes(attributes);
            foreach (var attr in attrs)
            {
                if (_gridModel.Attributes.ContainsKey(attr.Key))
                    _gridModel.Attributes.Remove(attr.Key);
                _gridModel.Attributes.Add(attr.Key, attr.Value);
            }
            return this;
        }
    }
}