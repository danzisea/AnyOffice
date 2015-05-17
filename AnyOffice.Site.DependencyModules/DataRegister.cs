using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using AnyOffice.Core.Data.Migrations;
using Autofac;
using Quaider.Component.Data;

namespace AnyOffice.Site.DependencyModules
{
    public class DataRegister
    {
        public static void Register(ContainerBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException("builder", "Autofac ContainerBuilder不能为空!");

            //注册Entity Mappers
            RegisterEntityMappers(builder);

            builder.Register(c => new QuaiderDbContext() { EntityMappers = c.Resolve<IEnumerable<IEntityMapper>>() });

            builder.RegisterGeneric(typeof(BaseRepository<,>)).As(typeof(IRepository<,>)).InstancePerLifetimeScope();

            DatabaseInitializer.Initialize();
        }

        private static void RegisterEntityMappers(ContainerBuilder builder)
        {
            var ass = BuildManager
                .GetReferencedAssemblies().Cast<Assembly>()
                .Where(f => !f.FullName.StartsWith("System."))
                .FirstOrDefault(f => f.FullName.StartsWith("AnyOffice.Core.Data"));

            if (ass == null) return;

            //获取需要映射的类型
            builder.RegisterAssemblyTypes(ass)
                .Where(type => !String.IsNullOrEmpty(type.Namespace) && type.IsPublic)
                .Where(t => t.IsClass && t.GetInterfaces().Count(f => f == typeof(IEntityMapper)) > 0)
                .Where(t => t.BaseType != null && t.BaseType.IsGenericType)
                .AsImplementedInterfaces();
        }
    }
}