using System;
using XGames.Infra.Persistence;

namespace XGames.Infra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly XGamesContext _context;

        public UnitOfWork(XGamesContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
