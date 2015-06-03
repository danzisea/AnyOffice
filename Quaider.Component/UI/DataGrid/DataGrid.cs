using System.IO;
using Quaider.Component.Extensions;

namespace Quaider.Component.UI.DataGrid
{
    public class DataGrid : ComponentBase<object>, IGrid
    {
        private readonly IGridModel _gridModel;

        public DataGrid(string id)
            : base(new GridModel())
        {
            ComponentModel.Id = id;
            _gridModel = ComponentModel as IGridModel;
            InitDefault();
        }

        #region IGrid

        IGrid IGrid.AddClass(params string[] classes)
        {
            base.AddClass(classes);
            return this;
        }

        IGrid IGrid.AddClass(string classes)
        {
            base.AddClass(classes);
            return this;
        }

        IGrid IGrid.Sort(string field)
        {
            _gridModel.DataOptions.SetKeyValue("sortName", field);
            return this;
        }

        IGrid IGrid.OrderBy()
        {
            _gridModel.DataOptions.SetKeyValue("sortOrder", "asc");
            return this;
        }

        IGrid IGrid.OrderByDesc()
        {
            _gridModel.DataOptions.SetKeyValue("sortOrder", "desc");
            return this;
        }

        IGrid IGrid.Toolbar(string toolbar)
        {
            _gridModel.DataOptions.SetKeyValue("toolbar", toolbar);
            return this;
        }

        IGrid IGrid.Url(string uri)
        {
            _gridModel.DataOptions.SetKeyValue("url", uri);
            return this;
        }

        IGrid IGrid.Columns(System.Action<ColumnBuilder> columnBuilder)
        {
            var builder = new ColumnBuilder();
            columnBuilder(builder);

            foreach (var column in builder)
            {
                _gridModel.Columns.Add(column);
            }

            return this;
        }

        IGrid IGrid.Width(int width)
        {
            _gridModel.DataOptions.SetKeyValue("width", width);
            return this;
        }

        IGrid IGrid.Height(int height)
        {
            _gridModel.DataOptions.SetKeyValue("height", height);
            return this;
        }

        IGrid IGrid.Width(string width)
        {
            _gridModel.DataOptions.SetKeyValue("height", width);
            return this;
        }

        IGrid IGrid.Height(string height)
        {
            _gridModel.DataOptions.SetKeyValue("height", height);
            return this;
        }

        IGrid IGrid.Paged(bool isPaged)
        {
            _gridModel.DataOptions.SetKeyValue("pagination", isPaged);
            return this;
        }

        IGrid IGrid.Extends(object attributes)
        {
            return this;
        }

        #endregion

        public override string ToHtmlString()
        {
            var writer = new StringWriter();
            _gridModel.Renderer.Render(_gridModel, writer, null);
            return writer.ToString();
        }

        private void InitDefault()
        {
            AddClass("easyui-datagrid");

            _gridModel.DataOptions
                .SetKeyValue("striped", true)
                .SetKeyValue("pagination", true)
                .SetKeyValue("singleSelect", true);
        }
    }
}