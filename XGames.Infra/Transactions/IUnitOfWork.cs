namespace XGames.Infra.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
