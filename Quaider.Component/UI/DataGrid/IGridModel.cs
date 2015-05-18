using System.Collections.Generic;

namespace Quaider.Component.UI.DataGrid
{
    public interface IGridModel
    {
        IList<GridColumn> Columns { get; }
        IDictionary<string, object> Attributes { get; set; }

        GridSortOptions Sort { get; set; }
    }
}