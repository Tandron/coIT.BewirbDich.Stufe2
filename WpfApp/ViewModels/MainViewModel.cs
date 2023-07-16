using ASP.NetCoreAPI.Models;
using Prism.Commands;
using Prism.Mvvm;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WpfApp.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly RestClient _client = new (@"https://localhost:7243/CalculationDoc/");
        public event Action<EditCalculationDocViewModel, Action> OpenNewCalcDialog = delegate { };
        public event Action OpenSaveCalcDialog = delegate { };
        public event Action OpenIssueCalcDialog = delegate { };
        public DelegateCommand NewCalcCommand { get; }
        public DelegateCommand AcceptOfferCommand { get; }
        public DelegateCommand IssueCommand { get; }
        public DelegateCommand SaveCommand { get; }

        // Die ObservableCollection könnte man auch in eigenen ViewModel CalculationDocMainViewModel auslagern
        public ObservableCollection<CalculationDocViewModel> CalculationDocItemsVm { get; }
        private CalculationDocViewModel _selectedCalculationDocItemVm = new();

        public MainViewModel()
        {
            NewCalcCommand = new DelegateCommand(NewCalcFunc);
            AcceptOfferCommand = new DelegateCommand(AcceptOfferFunc, CanExeAcceptOfferFunc);
            IssueCommand = new DelegateCommand(IssueFunc, CanExeIssueFunc);
            SaveCommand = new DelegateCommand(SaveFunc, CanExeSaveFunc);
            CalculationDocItemsVm = new ObservableCollection<CalculationDocViewModel>();
            LoadFromDatabase();
        }

        private bool CanExeSaveFunc() => false;

        private void SaveFunc()
        {
            //_repo.Save();  Unnötig wird eh alles in der Datenbank gespeichert
            OpenSaveCalcDialog?.Invoke();
        }

        private bool CanExeIssueFunc() => _selectedCalculationDocItemVm.Typ == (byte)CalculationDocViewModel.DocumentTypeEn.InsurancePolicy &&
                !_selectedCalculationDocItemVm.VersicherungsscheinAusgestellt;

        private void IssueFunc()
        {
            if (_selectedCalculationDocItemVm is not null)
            {
                _selectedCalculationDocItemVm.VersicherungsscheinAusgestellt = true;
                OpenIssueCalcDialog?.Invoke();
            }
        }

        private bool CanExeAcceptOfferFunc() => _selectedCalculationDocItemVm.Typ == (byte)CalculationDocViewModel.DocumentTypeEn.Offer;

        private void AcceptOfferFunc()
        {
            if (_selectedCalculationDocItemVm is not null)
                _selectedCalculationDocItemVm.Typ = (byte)CalculationDocViewModel.DocumentTypeEn.InsurancePolicy;
        }

        private void LoadFromDatabase()
        {
            RestRequest request = new("", Method.Get);
            var response = _client.Execute<List<CalculationDoc>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK && response.Data is List<CalculationDoc> liCalculationDocs)
            {
                foreach (var liDoc in liCalculationDocs)
                    CalculationDocItemsVm.Add(new(liDoc));
            }
         }

        public CalculationDocViewModel SelectedCalculationDocItemVm
        {
            get => _selectedCalculationDocItemVm;
            set
            {
                _selectedCalculationDocItemVm = value;
                AcceptOfferCommand.RaiseCanExecuteChanged();
                IssueCommand.RaiseCanExecuteChanged();
            }
        }

        private void NewCalcFunc()
        {
            EditCalculationDocViewModel editCalculationDocVm = new();

            //string typ, string calculationType, string berechnungbasis, string inkludiereZusatzschutz,
            //string zusatzschutzAufschlag, string hatWebshop, string risk, string beitrag,
            //string versicherungsscheinAusgestellt, string versicherungssumme)

            OpenNewCalcDialog?.Invoke(editCalculationDocVm, () =>
            {
                editCalculationDocVm.SaveCalculationDoc();
                var request = new RestRequest("additem", Method.Post);

                request.AddJsonBody(editCalculationDocVm.CalculationDoc);
                _client.Execute(request);






                //var json = client.MakeRequest();

                //if (!string.IsNullOrEmpty(json) && int.TryParse(json, out int idOk) && idOk > 0)
                //{
                //    editCalculationDocVm.Id = idOk;
                //    CalculationDocItemsVm.Add(editCalculationDocVm);
                //}
            });
        }
    }
}
