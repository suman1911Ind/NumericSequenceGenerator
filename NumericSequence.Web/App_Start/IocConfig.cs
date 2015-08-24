using System.Linq;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using NumericSequence.Web.Services;

namespace Calculator.Web
{
    public static class IocConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            var thisAssembly = typeof(IocConfig).Assembly;

            builder.RegisterControllers(thisAssembly);

            builder.RegisterAssemblyTypes(thisAssembly)
               .Where(t => t.GetInterfaces()
                            .Where(i => i.IsGenericType)
                            .Select(i => i.GetGenericTypeDefinition())
                            .Contains(typeof(ISequenceService<>)))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}