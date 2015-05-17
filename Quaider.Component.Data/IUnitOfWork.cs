namespace Quaider.Component.Data
{
    /// <summary>
    /// 用来做Transaction Per Action(or request)
    /// </summary>
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}