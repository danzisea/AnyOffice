using System.Collections.Generic;
using System.Web.Mvc;
using Quaider.Component.UI;
using Quaider.Component.UI.DataGrid;

namespace Quaider.Component.Html
{
    public static class EasyUiExtensions
    {
        public static IEasyUiService<T> EasyUi<T>(this HtmlHelper<T> helper)
        {
            return new EasyUiService<T>(helper);
        }
    }
}