using Lumed.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ModuleDemo.ViewModels
{
    [Export]
    public class ClockViewModel : ViewModelBase
    {
        DateTime dateTime;
        
        public ClockViewModel()
        {
            this.DateTime = DateTime.Now;          

            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.IsEnabled = true;
            timer.Tick += (s, e) =>
            {
                UpdateTime();
            };

        }

        private void UpdateTime() {
            this.DateTime = DateTime.Now;
        }

        

        public DateTime DateTime
        {
            set
            {
                if (dateTime != value)
                {
                    dateTime = value;

                    OnPropertyChanged();
                }
            }
            get
            {
                return dateTime;
            }
        }
    }
}
