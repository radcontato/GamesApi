using prmToolkit.NotificationPattern;
using System.Data.Entity;
using Unity;
using Unity.Lifetime;
using XGames.Domain.Interfaces.Repositories;
using XGames.Domain.Interfaces.Services;
using XGames.Domain.Services;
using XGames.Infra.Persistence;
using XGames.Infra.Persistence.Repositories;

namespace XGame.IoC.Unity
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {

            container.RegisterType<DbContext, XGamesContext>(new HierarchicalLifetimeManager());
            //UnitOfWork
            //    container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<INotifiable, Notifiable>(new HierarchicalLifetimeManager());

            //Serviço de Domain
            //container.RegisterType(typeof(IServiceBase<,>), typeof(ServiceBase<,>));

            container.RegisterType<IPlayerService, PlayerService>(new HierarchicalLifetimeManager());
            // container.RegisterType<IPlataformService, ServiceJogo>(new HierarchicalLifetimeManager());



            //Repository
            //    container.RegisterType(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

            container.RegisterType<IPlayerRepository, PlayerRepository>(new HierarchicalLifetimeManager());
    //        container.RegisterType<IRepositoryJogo, RepositoryJogo>(new HierarchicalLifetimeManager());



        }
    }
}
