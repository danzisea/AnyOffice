using System.Collections.Generic;

namespace Quaider.Component.UI.DataGrid
{
    public interface IGridModel
    {
        IGridRenderer Renderer { get; set; }
        IList<GridColumn> Columns { get; }
        IDictionary<string, object> Attributes { get; set; }
    }
}