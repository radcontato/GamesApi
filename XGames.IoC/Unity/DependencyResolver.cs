using Microsoft.Practices.Unity;
using prmToolkit.NotificationPattern;
using System.Data.Entity;
using XGames.Domain.Interfaces.Repositories;
using XGames.Domain.Interfaces.Services;
using XGames.Domain.Services;
using XGames.Infra.Persistence;
using XGames.Infra.Persistence.Repositories;
using XGames.Infra.Transactions;

namespace XGame.IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<DbContext, XGamesContext>(new HierarchicalLifetimeManager());

            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            container.RegisterType<IPlayerService, PlayerService>(new HierarchicalLifetimeManager());
            container.RegisterType<IGameService, GameService>(new HierarchicalLifetimeManager());

            container.RegisterType<IPlayerRepository, PlayerRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IGameRepository, GameRepository>(new HierarchicalLifetimeManager());
        }
    }
}
