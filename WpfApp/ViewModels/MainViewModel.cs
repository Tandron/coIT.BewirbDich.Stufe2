using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.ViewModels
{
    public class MainViewModel :  BindableBase
    {
        public DelegateCommand ConnectingCommand { get; }

        public MainViewModel()
        {

            ConnectingCommand = new DelegateCommand(ConnectingFunc);
        }

        private void ConnectingFunc()
        {
        }
    }
}
