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

        public NewCalculationDocWin(EditCalculationDocViewModel editCalculationDocVm)
        {
            DataContext = editCalculationDocVm;
            InitializeComponent();
        }

        private void TextBoxNumber_PreviewTextInput(object sender, TextCompositionEventArgs args)
        {
            args.Handled = new Regex(numberPattern).IsMatch(args.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs args)
        {
            DialogResult = true;
            Close();
        }
    }
}
