using System.IO;
using Quaider.Component.Extensions;

namespace Quaider.Component.UI.DataGrid
{
    public class GridColumn : ComponentBase<object>, IGridColumn
    {
        public GridColumn(string fieldName)
            : base(new ComponentModel<object>())
        {
            ComponentModel.Renderer = new GridColumnRender();
            ComponentModel.DataOptions.SetKeyValue("field", fieldName);
        }

        public bool IsFrozen { get; set; }

        #region IGridColumn

        IGridColumn IGridColumn.Title(string title)
        {
            var render = ComponentModel.Renderer as GridColumnRender;
            render.Title = title;
            return this;
        }

        IGridColumn IGridColumn.Width(int width)
        {
            ComponentModel.DataOptions.SetKeyValue("width", width);
            return this;
        }

        IGridColumn IGridColumn.Width(string width)
        {
            ComponentModel.DataOptions.SetKeyValue("width", width);
            return this;
        }

        IGridColumn IGridColumn.Sortable(bool isSortable)
        {
            ComponentModel.DataOptions.SetKeyValue("sortable", isSortable);
            return this;
        }

        IGridColumn IGridColumn.Visible(bool visible)
        {
            ComponentModel.DataOptions.SetKeyValue("hidden", visible);
            return this;
        }

        IGridColumn IGridColumn.Checkbox(bool showCheckbox)
        {
            ComponentModel.DataOptions.SetKeyValue("checkbox", showCheckbox);
            return this;
        }

        IGridColumn IGridColumn.Frozen(bool isFrozen)
        {
            IsFrozen = isFrozen;
            return this;
        }

        IGridColumn IGridColumn.ExtraOptions(object attributes)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        public override string ToHtmlString()
        {
            var writer = new StringWriter();
            ComponentModel.Renderer.Render(ComponentModel, writer, null);

            return writer.ToString();
        }
    }
}