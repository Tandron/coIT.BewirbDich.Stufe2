using Prism.Commands;
using Prism.Mvvm;

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
            //string endPoint = @"https://localhost:7243/WeatherForecast";
            //var client = new RestClientViewModel(endPoint);
            //var json = client.MakeRequest();

            var client = new RestClientViewModel
            {
                EndPoint = @"https://localhost:7243/CalculationDoc/",
                Method = HttpVerb.GET,
                PostData = "{postData: value}"
            };
            var json = client.MakeRequest();
        }
    }
}
