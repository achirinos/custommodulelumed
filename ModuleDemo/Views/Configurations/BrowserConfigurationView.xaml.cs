using ModuleDemo.ViewModels.Configurations;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace ModuleDemo.Views.Configurations
{
    [Export(nameof(BrowserConfigurationView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class BrowserConfigurationView : UserControl
    {
        [ImportingConstructor]
        public BrowserConfigurationView(BrowserConfigurationViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
