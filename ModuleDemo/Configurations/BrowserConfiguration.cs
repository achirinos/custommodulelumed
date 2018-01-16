using Lumed.Infrastructure;
using Lumed.Infrastructure.Helpers;
using ModuleDemo.Views.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuleDemo.Configurations
{
    class BrowserConfiguration : ConfigurationBase
    {
        public override string Title { get; }
        public override object Icon { get; }
        public override bool IsAvailableFromStartup { get; }
        public override string View { get; }

        public BrowserConfiguration()
        {
            Title = "Browser Configuration";
            Icon = ResourceHelper.GetResourceFromAssembly(Assembly.GetExecutingAssembly().FullName, "IconSqlServer");
            IsAvailableFromStartup = true;
            View = nameof(BrowserConfigurationView);
        }
    }
}
