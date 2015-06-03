namespace Quaider.Component.UI.DataGrid
{
    public class GridColumnRender : DefaultComponentRender<object>
    {
        public string Title { get; set; }

        protected override string BeginTag
        {
            get
            {
                return "<th{0}>";
            }
        }

        protected override string EndTag
        {
            get
            {
                return "</th>";
            }
        }

        protected override void RenderStart()
        {
            RenderText(string.Format(BeginTag, GetAttributes()));
        }

        protected override void RenderBody()
        {
            RenderText(Title);
        }

        protected override void RenderEnd()
        {
            RenderText(EndTag);
        }
    }
}