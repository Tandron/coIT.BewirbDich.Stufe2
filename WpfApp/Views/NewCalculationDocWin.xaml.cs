using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using WpfApp.ViewModels;

namespace WpfApp.Views
{
    /// <summary>
    /// Interaktionslogik für NewCalculationDocWin.xaml
    /// </summary>
    public partial class NewCalculationDocWin : Window
    {
        private const string numberPattern = "[^0-9.]+";

        public NewCalculationDocWin(CalculationDocViewModel calculationDocVm)
        {
            DataContext = calculationDocVm;
            InitializeComponent();
        }

        private void TextBoxNumber_PreviewTextInput(object sender, TextCompositionEventArgs args)
        {
            args.Handled = new Regex(numberPattern).IsMatch(args.Text);
        }
    }
}
