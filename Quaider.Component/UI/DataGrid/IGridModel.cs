using System.Collections.Generic;

namespace Quaider.Component.UI.DataGrid
{
    public interface IGridModel : IComponentModel<object>
    {
        IList<GridColumn> Columns { get; }
    }
}