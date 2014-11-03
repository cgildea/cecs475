// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using MvcMusicStore.Services;
using MvcMusicStore.Controllers;
using MvcMusicStore.Factories;
using MvcMusicStore.Filters;

namespace MvcMusicStore
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new Unity.Mvc3.UnityDependencyResolver(container));

            IDependencyResolver resolver = DependencyResolver.Current;

            IDependencyResolver newResolver = new Factories.UnityDependencyResolver(container, resolver);

            DependencyResolver.SetResolver(newResolver);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IStoreService, StoreService>();
            container.RegisterType<IController, StoreController>("Store");

            container.RegisterInstance<IMessageService>(new MessageService
            {
                Message = "You are welcome to our Web Camps Training Kit!",
                ImageUrl = "/Content/Images/webcamps.png"
            });

            container.RegisterType<IViewPageActivator, CustomViewPageActivator>(new InjectionConstructor(container));

            container.RegisterInstance<IFilterProvider>("FilterProvider", new FilterProvider(container));
            container.RegisterInstance<IActionFilter>("LogActionFilter", new TraceActionFilter());

            return container;
        }
    }
}