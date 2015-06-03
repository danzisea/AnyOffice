using System.Linq;

namespace Quaider.Component.UI.DataGrid
{
    public class HtmlTableGridRenderer : DefaultComponentRender<object>
    {
        protected IGridModel GridModel
        {
            get { return ComponentModel as IGridModel; }
        }

        protected override string BeginTag
        {
            get
            {
                return "<table{0}>";
            }
        }

        protected override string EndTag
        {
            get
            {
                return "</table>";
            }
        }

        protected override void RenderStart()
        {
            base.RenderStart();
            RenderHead();
        }

        protected virtual void RenderHead()
        {
            RenderColumns();
        }

        protected virtual void RenderColumns()
        {
            BuildHeadColumns(true);
            BuildHeadColumns(false);
        }

        private void BuildHeadColumns(bool isFrozen)
        {
            if (isFrozen && !GridModel.Columns.Any(t => t.IsFrozen))
                return;

            RenderWrapIndent(1);
            RenderText(string.Format("<thead{0}>", isFrozen ? " data-options=\"frozen:true\">" : ""));
            RenderWrapIndent(2);
            RenderText("<tr>");

            if (isFrozen)
            {
                foreach (var column in GridModel.Columns.Where(t => t.IsFrozen))
                {
                    RenderWrapIndent(3);
                    RenderText(column.ToString());
                }
            }
            else
            {
                foreach (var column in GridModel.Columns.Where(t => !t.IsFrozen))
                {
                    RenderWrapIndent(3);
                    RenderText(column.ToString());
                }
            }

            RenderWrapIndent(2);
            RenderText("</tr>");
            RenderWrapIndent(1);
            RenderText("</thead>");
        }
    }
}