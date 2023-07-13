using ASP.NetCoreAPI.Models;
using Prism.Commands;
using Prism.Mvvm;
using RestSharp;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Net;
using System.Security.Policy;
using System.Text;

namespace WpfApp.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private const string _strEndPoint = @"https://localhost:7243/CalculationDoc/";
        public event Action<CalculationDocViewModel, Action> OpenNewCalcDialog = delegate { };
        public DelegateCommand ConnectingCommand { get; }
        public DelegateCommand NewCalcCommand { get; }
        // Die ObservableCollection könnte man auch in eigenen ViewModel CalculationDocMainViewModel auslagern
        public ObservableCollection<CalculationDocViewModel> CalculationDocItemsVm { get; }

        public MainViewModel()
        {
            ConnectingCommand = new DelegateCommand(ConnectingFunc);
            NewCalcCommand = new DelegateCommand(NewCalcFunc);
            CalculationDocItemsVm = new ObservableCollection<CalculationDocViewModel>();
        }

        private void NewCalcFunc()
        {
            CalculationDocViewModel calculationDocVm = new();

            OpenNewCalcDialog?.Invoke(calculationDocVm, () =>
            {
                var client = new RestClientViewModel
                {
                    EndPoint = _strEndPoint + "additem/1/32/21/212/32/21/323/212/212/3232",
                    Method = HttpVerb.POST
                };
                var json = client.MakeRequest();
            });
        }

        private void ConnectingFunc()
        {
            var client1 = new RestClientViewModel
            {
                EndPoint = _strEndPoint,
                Method = HttpVerb.GET
            };
            var json1 = client1.MakeRequest();



            var client = new RestClientViewModel
            {
                EndPoint = _strEndPoint + "additem/1/32/21/212/32/21/323/212/212/3232",
                Method = HttpVerb.POST
            };
            var json = client.MakeRequest();
            //          curl - X 'POST'
            //'https://localhost:7243/CalculationDoc/additem/1/32/21/212/32/21/323/212/212/3232' \
            //-H 'accept: text/plain' \
            //-d ''




            // https://stackoverflow.com/questions/4015324/send-http-post-request-in-net

            //"additem/{typ}/{calculationType}/{berechnungbasis}/{inkludiereZusatzschutz}/{zusatzschutzAufschlag}/{hatWebshop}/{risk}/{beitrag}" +
            //    "/{versicherungsscheinAusgestellt}/{versicherungssumme}"
            //using (var client2 = new WebClient())
            //{
            //    var values = new NameValueCollection();
            //        values["typ"] = "0";
            //    values["calculationType"] = "1";
            //    values["berechnungbasis"] = "221";
            //    values["inkludiereZusatzschutz"] = "21";
            //    values["zusatzschutzAufschlag"] = "0";
            //    values["hatWebshop"] = "21";
            //    values["risk"] = "0";
            //    values["beitrag"] = "3121";
            //    values["versicherungsscheinAusgestellt"] = "43";
            //    values["versicherungssumme"] = "2132";

            //    var response4 = client2.UploadValues(_strEndPoint + "additem", "POST", values);
            //    string responseInString = Encoding.UTF8.GetString(response4);

            //    var response3 = client2.UploadValues(_strEndPoint + "additem/", values);

            //    var responseString = Encoding.Default.GetString(response3);
            //}


            //var client = new RestClient(_strEndPoint);
            //// client.Authenticator = new HttpBasicAuthenticator(username, password);
            //var request = new RestRequest("additem/{id}");
            //request.AddParameter("typ", "0");
            //request.AddParameter("calculationType", "1");
            //request.AddParameter("berechnungbasis", "231");

            //request.AddParameter("inkludiereZusatzschutz", "true");
            //request.AddParameter("zusatzschutzAufschlag", "0");
            //request.AddParameter("hatWebshop", "true");
            //request.AddParameter("risk", "0");
            //request.AddParameter("beitrag", "210");
            //request.AddParameter("versicherungsscheinAusgestellt", "true");
            //request.AddParameter("versicherungssumme", "0");
            ////request.AddHeader("berechnungbasis", "231");
            //var response = client.Post(request);
            //var content = response.Content; // Raw content as string
            //var response2 = client.Post<CalculationDoc>(request);
            ////var name = response2.Data.Name;


            //var client = new RestClientViewModel
            //{
            //    EndPoint = _strEndPoint + "additem/",
            //    Method = HttpVerb.POST,
            //    //PostData = "{postData: value}"
            //    //PostData = "'{\"typ\": 0, \":\": 0, \"\": , \"\": , \"\": , \"\": , \"\": , \"\": , \"\": , \"\": }"

            //    //PostData = "{'typ': '0', 'calculationType': '0', 'berechnungbasis': '0'}"
            //    //PostData =
            //    //                "'{
            //    //  "typ": 0,
            //    //  "calculationType": 0,
            //    //  "berechnungbasis": 0,
            //    //  "inkludiereZusatzschutz": true,
            //    //  "zusatzschutzAufschlag": 0,
            //    //  "hatWebshop": true,
            //    //  "risk": 0,
            //    //  "beitrag": 0,
            //    //  "versicherungsscheinAusgestellt": true,
            //    //  "versicherungssumme": 0
            //    //}'"
            //};
            //var json = client.MakeRequest("?param=0");
        }
    }
}
