﻿using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using Lab5.Data;
using Lab5.Repositories;
using Lab5.Services;

namespace Lab5.App_Start
{
    public static class DependencyInjectionConfig
    {
        public static void Register()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            container.Register<iRepository, Repository>(Lifestyle.Scoped);

            container.Register<AppDbContext, AppDbContext>(Lifestyle.Scoped);
             
            container.Register<iService, Service>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
  }