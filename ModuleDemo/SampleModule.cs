using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using System.Windows.Controls;
using Lumed.Extensibility;
using Lumed.Infrastructure;
using Lumed.Infrastructure.ServiceInterfaces;
using ModuleDemo.Views;

namespace ModuleDemo
{
    [Export(typeof(IModule))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SampleModule : TabItem, IModule, IPartImportsSatisfiedNotification
    {   
        [Import]
        private TitleClockModuleView view = null;

        public string Title => "Browser";

        public object View => view;

        public int Order { get; } = 1000;

        public SampleModule()
        {
            Header = Title;
        }

        public Task<bool> AssertAuthorization()
        {
            return Task.FromResult(true);
        }

        public void OnImportsSatisfied()
        {
            Content = view;
        }
    }
}
