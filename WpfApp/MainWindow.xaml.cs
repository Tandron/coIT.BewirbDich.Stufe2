using System;
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
                mainVm.OpenSaveCalcDialog += MainVm_OpenSaveCalcDialog;
            }
        }

        private void MainVm_OpenSaveCalcDialog()
        {
            MessageBox.Show("Daten gespeichert. (Welche Daten, sind doch in der Datenbank...)", "Vorgang", MessageBoxButton.OK);
        }

        private void MainVm_OpenNewCalcDialog(EditCalculationDocViewModel editCalculationDocVm, Action action)
        {
            NewCalculationDocWin newCalculationDocWin = new(editCalculationDocVm);

            if (newCalculationDocWin.ShowDialog() == true)
                action();
        }
    }
}
