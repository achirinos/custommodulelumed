using Lumed.Infrastructure;
using Lumed.Infrastructure.Interfaces;
using ModuleDemo.Views;
using Prism.Commands;
using Prism.Logging;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModuleDemo.ViewModels{

    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class SampleModuleViewModel: ViewModelBase
    {
        private bool canNavigate;

        public string View { get; }

        public ICommand LoadCommand { get; }

        public SampleModuleViewModel()
        {
            Title = "Browser";
            View = nameof(BrowserView);
            LoadCommand = new DelegateCommand(LoadCommandExecute);
        }        

        private void LoadCommandExecute()
        {

            transitionService.SetTransitionToRegion(RegionNames.MainRegion, TransitionNames.FadeAndGrow);
            regionManager.RequestNavigate(RegionNames.MainRegion, View);
        }

    }
}
