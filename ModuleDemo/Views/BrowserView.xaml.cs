using ModuleDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ModuleDemo.Utility;

namespace ModuleDemo.Views
{
    [Export(nameof(BrowserView))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class BrowserView : UserControl
    {
        [ImportingConstructor]
        public BrowserView(BrowserViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;            
        }
    }
}
