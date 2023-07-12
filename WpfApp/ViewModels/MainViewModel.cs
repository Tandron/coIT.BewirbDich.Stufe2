using Prism.Commands;
using Prism.Mvvm;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

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
            string serverBaseUrl = "https://localhost:7243";

            var client = new RestClient(serverBaseUrl);

            //var request = new RestRequest(path, Method.Post);
            //request.AddHeader("Content-Type", "application/json");

            //var body = JsonConvert.SerializeObject(requestModel);
            //request.AddParameter("application/json", body, ParameterType.RequestBody);
            //var response = await client.ExecuteAsync(request);

            //OnConnectionStatusChanged?.Invoke(ConnectingStatus.Complete);

            //if (response.ErrorException != null)
            //{
            //    OnConnectionStatusChanged?.Invoke(ConnectingStatus.Error);
            //    throw new ServerException($"Server error: {response.ErrorMessage}", response.ErrorException);
            //}

            //var responseObject = JsonConvert.DeserializeObject<ReponseType>(response.Content);


            var httpClient = new HttpClient(new HttpClientHandler()
            {
                UseDefaultCredentials = true
            });
            httpClient.GetStringAsync("https://localhost:7243/");
        }
    }
}
