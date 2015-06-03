using System.Collections.Generic;

namespace Quaider.Component.UI.DataGrid
{
    public class GridModel : ComponentModel<object>, IGridModel
    {
        private readonly ColumnBuilder _columnBuilder;

        public GridModel()
        {
            _columnBuilder = new ColumnBuilder();
            Renderer = new HtmlTableGridRenderer();
        }

        public IList<GridColumn> Columns
        {
            get { return _columnBuilder; }
        }
    }
}