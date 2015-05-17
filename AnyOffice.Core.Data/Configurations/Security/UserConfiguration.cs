using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using AnyOffice.Core.Models.Security;
using Quaider.Component;
using Quaider.Component.Data;

namespace AnyOffice.Core.Data.Configurations.Security
{
    public class UserConfiguration : QuaiderEntityTypeConfiguration<User, Guid>, IEntityMapper
    {
        public UserConfiguration()
        {

        }

        public void RegisterTo(ConfigurationRegistrar config)
        {
            config.Add(this);
        }
    }
}