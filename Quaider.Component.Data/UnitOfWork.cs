namespace Quaider.Component.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuaiderDbContext _context;

        public UnitOfWork(QuaiderDbContext context)
        {
            _context = context;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}