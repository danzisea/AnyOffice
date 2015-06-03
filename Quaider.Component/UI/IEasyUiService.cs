using Quaider.Component.UI.DataGrid;

namespace Quaider.Component.UI
{
    public interface IEasyUiService<TEntity>
    {
        /// <summary>
        /// 创建DataGrid
        /// </summary>
        /// <returns></returns>
        IGrid Grid(string id);
    }
}