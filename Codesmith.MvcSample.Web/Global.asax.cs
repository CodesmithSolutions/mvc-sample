using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Codesmith.MvcSample.Services;
using Codesmith.MvcSample.Services.Contracts;
using Codesmith.MvcSample.Services.Infrastructure;
using Codesmith.MvcSample.Web.Infrastructure;
using Codesmith.MvcSample.Web.Infrastructure.Helpers;
using FluentValidation;
using FluentValidation.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace Codesmith.MvcSample.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //System.Web.Http.GlobalConfiguration.Configure((config) =>
           // {
           //     GlobalConfiguration.Configuration = config;
           //     WebApiConfig.Register(config);
           // });

            // Create the container as usual.
            var container = new Container();
            RegisterIoCContainer(container);

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            FluentValidationModelValidatorProvider.Configure();
        }

        public void RegisterIoCContainer(Container container)
        {
            container.Options.ResolveUnregisteredConcreteTypes = true;
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            // Injectable service
            container.Register<IUserService, UserService>(Lifestyle.Scoped);
            container.Register<IIssueService, IssueService>(Lifestyle.Scoped);
            container.Register<IIssueSelectListHelper, IssueSelectListHelper>(Lifestyle.Scoped);

            // Automapper
            container.RegisterSingleton(() => GetMapper(container));

            // Register Service Dependencies
            Register.RegisterServices(container);

            // Register the validators and factory
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            container.Register<IValidatorFactory, ApplicationValidatorFactory>(Lifestyle.Singleton);
            container.Register(typeof(IValidator<>), assemblies);
            
            // Register Simple Injector validation factory in FV
            FluentValidationModelValidatorProvider.Configure(provider =>
            {
                provider.ValidatorFactory = new ApplicationValidatorFactory(container);
                    provider.AddImplicitRequiredValidator = false;
                }
            );
            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();
        }

        private AutoMapper.IMapper GetMapper(Container container)
        {
            var mp = container.GetInstance<AutoMapperProvider>();
            return mp.GetMapper();
        }

    }
}
