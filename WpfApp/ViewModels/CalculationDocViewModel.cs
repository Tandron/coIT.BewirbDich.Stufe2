using ASP.NetCoreAPI.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace WpfApp.ViewModels
{
    public class CalculationDocViewModel : BindableBase
    {
        public enum CalculationTypeEn
        {
            TurnOver,           // Umsatz
            BudgetarySum,       // Haushaltssumme
            CountEmployees      // Anzahl der Mitarbeiter
        }

        public enum DocumentTypeEn
        {
            Offer,            
            InsurancePolicy   
        }
        
        public enum RiskEn
        {
            Gering,
            Mittel
        }

        protected readonly CalculationDoc _calculationDoc;
        public List<string> LiCalculationType { get; }
        public List<string> LiRiskType { get; } = new();
        public List<string> LiAdditionalProtectionSurcharge { get; } = new();
        public int AdditionalProtectionSurchargeIndex { get; set; }

        public CalculationDocViewModel()
        {
            _calculationDoc =  new CalculationDoc();
            LiCalculationType = new List<string>()  // Sollte man auch mit i18n nutzen
            {
                "Umsatz",
                "Haushaltssumme",
                "Anzahl der Mitarbeiter"
            };
            LiRiskType.AddRange(Enum.GetNames(typeof(RiskEn)));
            LiAdditionalProtectionSurcharge.AddRange(new string[] { "10%", "20%", "25%" });
            Versicherungssumme = 100000m;
        }

        public CalculationDocViewModel(CalculationDoc calculationDoc) : this()
        {
            _calculationDoc = calculationDoc ?? new();
        }

        public byte Typ
        { 
            get => _calculationDoc.Typ;
            set
            {
                _calculationDoc.Typ = value;
                RaisePropertyChanged();
            }
        }

        public int CalculationType
        { 
            get => _calculationDoc.CalculationType;
            set
            {
                _calculationDoc.CalculationType = (byte)value;
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

        public int RiskType
        { 
            get => _calculationDoc.Risk;
            set
            {
                _calculationDoc.Risk = (byte)value;
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
