using System.Collections.Generic;

namespace Quaider.Component.UI.DataGrid
{
    public class ColumnBuilder : List<GridColumn>
    {
        /// <summary>
        /// 列字段名称
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public IGridColumn Field(string fieldName)
        {
            return new GridColumn();
        }
    }
}