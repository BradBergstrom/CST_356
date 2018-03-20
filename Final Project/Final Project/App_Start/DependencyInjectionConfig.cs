
using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using Final_Project.Models;
using Final_Project.Repositories;
using Final_Project.Services;
using Final_Project.Data;

namespace Final_Project.App_Start
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
            container.Register<iService, Service>(Lifestyle.Scoped);
            container.Register<AppDbContext, AppDbContext>(Lifestyle.Scoped);

            //            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>());

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}