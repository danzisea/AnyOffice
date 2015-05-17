using System;
using System.Linq;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace AnyOffice.Site.DependencyModules
{
    /// <summary>
    /// 依赖注册类
    /// </summary>
    public class Startup 
    {
        public static void RegisterDependency()
        {
            var builder = new ContainerBuilder();

            //控制器注入RegisterControllers() 参数必须是包含了控制器所在的程序集
            var controllerAss = AppDomain.CurrentDomain.GetAssemblies()
                .Where(f => f.FullName.StartsWith("AnyOffice"))
                .Where(f => f.ExportedTypes.Any(c => typeof (Controller).IsAssignableFrom(c) && c.IsClass))
                .ToArray();

            //特别注意：RegisterControllers（）方法必须在 builder.Build() 方法之前调用，否则经测试无效...
            builder.RegisterControllers(controllerAss).InstancePerLifetimeScope();

            //builder.Build()之前调用builder.RegisterControllers();
            var container = builder.Build();

            //we create new instance of ContainerBuilder
            //because Build() or Update() method can only be called once on a ContainerBuilder.
            builder = new ContainerBuilder();
            DataRegister.Register(builder);
            ServiceRegister.Register(builder);
            builder.Update(container);

            //set dependency resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}