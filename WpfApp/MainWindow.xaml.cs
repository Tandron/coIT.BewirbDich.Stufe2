using System.Windows;
using WpfApp.ViewModels;
using WpfApp.Views;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            if (args.NewValue != null && args.NewValue is MainViewModel mainVm)
            {
                mainVm.OpenNewCalcDialog += MainVm_OpenNewCalcDialog;
            }
        }

        private void MainVm_OpenNewCalcDialog(CalculationDocViewModel calculationDocVm)
        {
            NewCalculationDocWin newCalculationDocWin = new NewCalculationDocWin(calculationDocVm);

            if (newCalculationDocWin.ShowDialog() == true)
            {

            }
        }
    }
}
