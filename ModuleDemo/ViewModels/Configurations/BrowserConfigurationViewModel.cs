using Lumed.Infrastructure;
using Lumed.Infrastructure.Interfaces;
using Lumed.Utilities;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModuleDemo.ViewModels.Configurations
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class BrowserConfigurationViewModel : ViewModelBase
    {
        private readonly ConfigHelper configHelper = null;
        private readonly string path = null;

        [Import]
        private INotificationService notificationService = null;


        public ICommand SaveCommand { get; set; }

        private string defaultPage;
        public string DefaultPage
        {
            get
            {
                return defaultPage;
            }
            set
            {
                if (defaultPage == value)
                {
                    return;
                }
                defaultPage = value;
                OnPropertyChanged();
            }
        }

             

        public BrowserConfigurationViewModel()
        {
            SaveCommand = new DelegateCommand(SaveCommandExecute);

            if (Assembly.GetEntryAssembly()?.GetName().Name != null)
            {
                path = Path.Combine(Environment.CurrentDirectory, Assembly.GetEntryAssembly().GetName().Name + ".exe");
            }

            configHelper = new ConfigHelper(path);
            LoadStoredValues();
        }

        private void SaveCommandExecute()
        {

            configHelper.StoreValue(nameof(DefaultPage), DefaultPage);

            notificationService.ShowNotification("Se ha gaurdado la pagina por defecto", NotificationType.Information, 5);
        }

        private void LoadStoredValues()
        {
            DefaultPage = configHelper.GetValue(nameof(DefaultPage));
        }

    }
}
