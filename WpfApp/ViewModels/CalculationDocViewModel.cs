using ASP.NetCoreAPI.Models;
using Prism.Mvvm;

namespace WpfApp.ViewModels
{
    public class CalculationDocViewModel : BindableBase
    {
        private readonly CalculationDoc _calculationDoc;

        public CalculationDocViewModel()
        {
            _calculationDoc =  new CalculationDoc();
        }

        public CalculationDocViewModel(CalculationDoc calculationDoc)
        {
            _calculationDoc = calculationDoc ?? new();
        }

        public DocumentType Typ
        { 
            get => _calculationDoc.Typ;
            set
            {
                _calculationDoc.Typ = value;
                RaisePropertyChanged();
            }
        }
        public CalculationType CalculationType
        { 
            get => _calculationDoc.CalculationType;
            set
            {
                _calculationDoc.CalculationType = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Berechnungsart Umsatz => Jahresumsatz in Euro,
        /// Berechnungsart Haushaltssumme => Haushaltssumme in Euro,
        /// Berechnungsart AnzahlMitarbeiter => Ganzzahl
        /// </summary>
        public decimal Berechnungbasis 
        { 
            get => _calculationDoc.Berechnungbasis;
            set
            {
                _calculationDoc.Berechnungbasis = value;
                RaisePropertyChanged();
            }
        }

        public bool InkludiereZusatzschutz
        { 
            get => _calculationDoc.InkludiereZusatzschutz;
            set
            {
                _calculationDoc.InkludiereZusatzschutz = value;
                RaisePropertyChanged();
            }
        }

        public float ZusatzschutzAufschlag
        { 
            get => _calculationDoc.ZusatzschutzAufschlag;
            set
            {
                _calculationDoc.ZusatzschutzAufschlag = value;
                RaisePropertyChanged();
            }
        }

        //Gibt es nur bei Unternehmen, die nach Umsatz abgerechnet werden
        public bool HatWebshop
        { 
            get => _calculationDoc.HatWebshop;
            set
            {
                _calculationDoc.HatWebshop = value;
                RaisePropertyChanged();
            }
        }

        public Risk Risk
        { 
            get => _calculationDoc.Risk;
            set
            {
                _calculationDoc.Risk = value;
                RaisePropertyChanged();
            }
        }

        public decimal Beitrag
        { 
            get => _calculationDoc.Beitrag;
            set
            {
                _calculationDoc.Beitrag = value;
                RaisePropertyChanged();
            }
        }

        public bool VersicherungsscheinAusgestellt
        {
            get => _calculationDoc.VersicherungsscheinAusgestellt;
            set
            {
                _calculationDoc.VersicherungsscheinAusgestellt = value;
                RaisePropertyChanged();
            }
        
        }
        public decimal Versicherungssumme
        { 
            get => _calculationDoc.Versicherungssumme;
            set
            {
                _calculationDoc.Versicherungssumme = value;
                RaisePropertyChanged();
            }
        }
    }
}
