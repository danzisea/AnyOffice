using System.Collections.Generic;

namespace Quaider.Component.UI.DataGrid
{
    public class GridModel : IGridModel
    {
        private readonly ColumnBuilder _columnBuilder;

        public GridModel()
        {
            _columnBuilder = new ColumnBuilder();
            Renderer = new HtmlTableGridRenderer();
            Attributes = new Dictionary<string, object>();
        }

        public IList<GridColumn> Columns
        {
            get { return _columnBuilder; }
        }

        public IDictionary<string, object> Attributes { get; set; }

        public GridSortOptions SortOptions { get; set; }

        public IGridRenderer Renderer { get; set; }
    }
}