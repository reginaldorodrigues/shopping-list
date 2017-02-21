using Microsoft.Practices.Unity;
using System.Web.Http;
using ShoppingList.ApiServices.ShoppingList;
using ShoppingList.Data.ShoppingList;
using Unity.WebApi;
using AutoMapper;
using ShoppingList.ApiServices;

namespace ShoppingList.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IShoppingListRepository, ShoppingListRepository>();
            container.RegisterType<IShoppingListService, ShoppingListService>();

            RegisterAutomapper(container);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        public static void RegisterAutomapper(IUnityContainer container)
        {
            IMapperConfiguration mapConfig = new MapperConfiguration(cfg => { });
            ShoppingListMapper.Configure(mapConfig);

            container.RegisterInstance(((MapperConfiguration)mapConfig).CreateMapper(),
                new ContainerControlledLifetimeManager());
        }
    }
}