using System.Collections.Generic;

namespace Quaider.Component.UI.DataGrid
{
    public class GridModel : IGridModel
    {
        public IList<GridColumn> Columns
        {
            get { throw new System.NotImplementedException(); }
        }

        public IDictionary<string, object> Attributes
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public GridSortOptions Sort
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
    }
}