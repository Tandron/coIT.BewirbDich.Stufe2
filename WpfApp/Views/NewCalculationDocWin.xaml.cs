using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WpfApp.ViewModels;

namespace WpfApp.Views
{
    /// <summary>
    /// Interaktionslogik für NewCalculationDocWin.xaml
    /// </summary>
    public partial class NewCalculationDocWin : Window
    {
        public NewCalculationDocWin(CalculationDocViewModel calculationDocVm)
        {
            DataContext = calculationDocVm;
            InitializeComponent();
        }
    }
}
