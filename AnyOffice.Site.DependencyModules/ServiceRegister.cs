using System;
using Autofac;

namespace AnyOffice.Site.DependencyModules
{
    public class ServiceRegister
    {
        public static void Register(ContainerBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException("builder", "Autofac ContainerBuilder不能为空!");
            
            //todo:Register By Reflection
            //builder.RegisterType<UserService>().As<IUserService>();
        }
    }
}