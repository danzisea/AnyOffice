using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Quaider.Component.UI.DataGrid
{
    public class DataGrid : IGrid
    {
        private readonly IGridModel _gridModel = new GridModel();

        public DataGrid()
        {
            InitDefault();
        }

        public override string ToString()
        {
            return ToHtmlString();
        }

        public string ToHtmlString()
        {
            var writer = new StringWriter();
            _gridModel.Renderer.Render(_gridModel, writer, null);
            return writer.ToString();
        }

        #region IGrid

        public IGrid Sort(string field)
        {
            SetKeyValue("sortName", field);
            return this;
        }

        public IGrid Toolbar(string toolbar)
        {
            SetKeyValue("toolbar", toolbar);
            return this;
        }

        public IGrid Url(string uri)
        {
            SetKeyValue("url", uri);
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
            EnsureSortNameRequired();
            SetKeyValue("sortOrder", "asc");
            return this;
        }

        public IGrid OrderByDesc()
        {
            EnsureSortNameRequired();
            SetKeyValue("sortOrder", "desc");
            return this;
        }

        public IGrid Width(int width)
        {
            SetKeyValue("width", width);
            return this;
        }

        public IGrid Height(int height)
        {
            SetKeyValue("height", height);
            return this;
        }

        public IGrid Width(string width)
        {
            SetKeyValue("width", width);
            return this;
        }

        public IGrid Height(string height)
        {
            SetKeyValue("height", height);
            return this;
        }

        public IGrid Paged(bool isPaged = true)
        {
            SetKeyValue("pagination", true);
            return this;
        }

        public IGrid Extends(object attributes)
        {
            if (attributes == null) return this;
            IDictionary<string, object> attrs = HtmlHelper.AnonymousObjectToHtmlAttributes(attributes);
            foreach (var attr in attrs)
            {
                SetKeyValue(attr.Key, attr.Value);
            }
            return this;
        }
        
        #endregion

        void EnsureSortNameRequired()
        {
            if (!_gridModel.Attributes.ContainsKey("sortName"))
                throw new InvalidOperationException("必须先指定排序字段.");
        }

        void SetKeyValue(string key, object value)
        {
            if (_gridModel.Attributes.ContainsKey(key))
                _gridModel.Attributes[key] = value;
            else
                _gridModel.Attributes.Add(key, value);
        }

        /// <summary>
        /// 设置默认的data-options
        /// </summary>
        private void InitDefault()
        {
            SetKeyValue("striped", true);
            SetKeyValue("pagination", true);
            SetKeyValue("rownumbers", true);
            SetKeyValue("singleSelect", true);
        }
    }
}