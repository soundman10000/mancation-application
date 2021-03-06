﻿// Mancation 
// (c) Smokey Inc.
// For the full copyright and license information, please view the LICENSE
// file that was distributed with this source code.

using Host.Infastructure;
using Mancation.Domain;
using Microsoft.Practices.Unity;
using MongoDB.Driver;
using ServiceStack.Caching;

namespace Host
{
    /// <summary>
    /// Set up dependency injection
    /// </summary>
    public class HostContainer
    {
        public const string USER_DATABASE = "users";

        public static IUnityContainer Create()
        {
            var container = new UnityContainer();
            var connectionManager = new ConnectionManager();

            container.RegisterInstance<ICacheClient>(new MemoryCacheClient(), new ContainerControlledLifetimeManager());

            container.RegisterType<IMongoClient, MongoClient>(new ContainerControlledLifetimeManager(),
                new InjectionConstructor(connectionManager.ConnectionString));

            container.RegisterType<IAddressDocumentStore, AddressDocumentStore>(new ContainerControlledLifetimeManager());
            container.RegisterType<IPersonDocumentStore, PersonDocumentStore>(new ContainerControlledLifetimeManager());
            container.RegisterType<IUserDocumentStore, UserDocumentStore>(new ContainerControlledLifetimeManager());

            return container;
        }
    }
}