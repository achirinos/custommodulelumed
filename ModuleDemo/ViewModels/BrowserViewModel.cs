using Lumed.Infrastructure;
using Lumed.Utilities;
using Prism.Commands;
using Prism.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModuleDemo.ViewModels
{
    [Export]
    public class BrowserViewModel: ViewModelBase
    {
        private readonly ConfigHelper configHelper = null;
        private readonly string path = null;


        private string setPage;

        public string SetPage
        {
            get { return setPage; }
            set {
                if(setPage!=value)
                {
                    setPage = value;
                    OnPropertyChanged();
                }
                
            }
        }

        private string goPage;

        public string GoPage
        {
            get { return goPage; }
            set {
                if(goPage!=value)
                {
                    goPage = value;
                    OnPropertyChanged();
                    logger?.Log("nuevo GoPage" + value, Category.Info, Priority.None);
                }
            }
        }

        public ICommand GoCommand { get; }

        public BrowserViewModel()
        {
            GoCommand = new DelegateCommand(GoCommandExecute);
            
            if (Assembly.GetEntryAssembly()?.GetName().Name != null)
            {
                path = Path.Combine(Environment.CurrentDirectory, Assembly.GetEntryAssembly().GetName().Name + ".exe");
            }

            configHelper = new ConfigHelper(path);
            LoadStoredValues();
        }

        private void GoCommandExecute()
        {
            GoPage = setPage;
        }

        private void LoadStoredValues()
        {
            SetPage = configHelper.GetValue("DefaultPage");
            GoPage = SetPage;
        }

    }
}
