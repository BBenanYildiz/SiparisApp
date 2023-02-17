using Autofac;
using SiparisApp.Core.Repositories;
using SiparisApp.Core.Services;
using SiparisApp.Core.UnitOfWorks;
using SiparisApp.Repository;
using SiparisApp.Repository.Repositories;
using SiparisApp.Repository.UnitOfWorks;
using SiparisApp.Service.MapProfile;
using SiparisApp.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace SiparisApp.API.Modules
{
    public class RepositoryServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IGenericService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(
                 apiAssembly,
                 repoAssembly,
                 serviceAssembly).
                 Where(x => x.Name.EndsWith("Repository")).
                 AsImplementedInterfaces().
                 InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(
             apiAssembly,
             repoAssembly,
             serviceAssembly).
             Where(x => x.Name.EndsWith("Service")).
             AsImplementedInterfaces().
             InstancePerLifetimeScope();

        }
    }
}
