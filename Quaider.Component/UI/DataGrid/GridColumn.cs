using System.Collections.Generic;
using System.Web.Mvc;

namespace Quaider.Component.UI.DataGrid
{
    public class GridColumn : IGridColumn
    {
        private readonly IDictionary<string, object> _attributes;

        public GridColumn(string field)
        {
            _attributes = new Dictionary<string, object>();
            SetKeyValue("field", field);
        }

        public string Title { get; set; }

        #region IGridColumn

        IGridColumn IGridColumn.Title(string title)
        {
            Title = title;
            return this;
        }

        IGridColumn IGridColumn.Extends(object attributes)
        {
            if (attributes == null) return this;
            IDictionary<string, object> attrs = HtmlHelper.AnonymousObjectToHtmlAttributes(attributes);
            foreach (var attr in attrs)
            {
                SetKeyValue(attr.Key, attr.Value);
            }
            return this;
        }

        IGridColumn IGridColumn.Width(int width)
        {
            SetKeyValue("width", width);
            return this;
        }

        IGridColumn IGridColumn.Width(string width)
        {
            SetKeyValue("width", width);
            return this;
        }

        IGridColumn IGridColumn.Sortable(bool isSortable)
        {
            SetKeyValue("sortable", isSortable);
            return this;
        }

        IGridColumn IGridColumn.Visible(bool visible)
        {
            SetKeyValue("hidden", visible);
            return this;
        }

        IGridColumn IGridColumn.Checkbox(bool showCheckbox)
        {
            SetKeyValue("checkbox", showCheckbox);
            return this;
        }

        #endregion

        /// <summary>
        /// 获取列的data-options="..."
        /// </summary>
        /// <returns></returns>
        public string GetColumnOptions()
        {
            return EasyUiHelper.BuildOptions(_attributes);
        }

        void SetKeyValue(string key, object value)
        {
            if (_attributes.ContainsKey(key))
                _attributes[key] = value;
            else
                _attributes.Add(key, value);
        }
    }
}