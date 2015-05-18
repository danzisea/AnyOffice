using System.Collections.Generic;
using System.Web.Mvc;

namespace Quaider.Component.UI.DataGrid
{
    public class GridColumn : IGridColumn
    {
        public IGridColumn Title(string title)
        {
            return this;
        }

        private IDictionary<string, object> _extendsProperties;

        public IGridColumn Extends(object attributes)
        {
            _extendsProperties = HtmlHelper.AnonymousObjectToHtmlAttributes(attributes);

            return this;
        }
    }
}