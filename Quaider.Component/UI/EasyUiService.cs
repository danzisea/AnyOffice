using System.Web.Mvc;

namespace Quaider.Component.UI
{
    public class EasyUiService<TEntity> : IEasyUiService<TEntity>
    {
        private readonly HtmlHelper<TEntity> _helper;

        public EasyUiService(HtmlHelper<TEntity> helper)
        {
            _helper = helper;
        }

        public DataGrid.IGrid Grid(string id)
        {
            return new DataGrid.DataGrid(id);
        }
    }
}