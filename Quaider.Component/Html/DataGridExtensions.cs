using System.Collections.Generic;
using System.Web.Mvc;
using Quaider.Component.UI.DataGrid;

namespace Quaider.Component.Html
{
    public static class DataGridExtensions
    {
        public static IGrid Grid(this HtmlHelper helper, string gridName)
        {
            return new DataGrid();
        }
    }
}