using ASP.NetCoreAPI.Models;
using System;

namespace WpfApp.ViewModels
{
    public class EditCalculationDocViewModel : CalculationDocViewModel
    {
        public CalculationDoc CalculationDoc { get => _calculationDoc; }

        public EditCalculationDocViewModel() : base()
        {

        }

        public void SaveCalculationDoc()
        {
            switch (_calculationDoc.CalculationType)
            {
                case (int)CalculationTypeEn.TurnOver:
                    //Versicherungsnehmer, die nach Umsatz abgerechnet werden, mehr als 100.000€ ausweisen und Lösegeld versichern, haben immer mittleres Risiko
                    if (_calculationDoc.Versicherungssumme > 100000m && _calculationDoc.InkludiereZusatzschutz)
                        _calculationDoc.Risk = (byte)RiskEn.Mittel;
                    _calculationDoc.Berechnungbasis = (decimal)Math.Pow((double)_calculationDoc.Versicherungssumme, 0.25d);
                    _calculationDoc.Beitrag = 1.1m * _calculationDoc.Berechnungbasis;
                    if (_calculationDoc.HatWebshop) //Webshop gibt es nur bei Unternehmen, die nach Umsatz abgerechnet werden
                        _calculationDoc.Beitrag *= 2;
                    break;

                case (int)CalculationTypeEn.BudgetarySum:
                    //Versicherungsnehmer, die nach Haushaltssumme versichert werden (primär Vereine) stellen immer ein mittleres Risiko da
                    _calculationDoc.Risk = (byte)RiskEn.Mittel;
                    _calculationDoc.Berechnungbasis = (decimal)Math.Log10((double)_calculationDoc.Versicherungssumme);
                    _calculationDoc.Beitrag = 1.0m * _calculationDoc.Berechnungbasis + 100m;
                    break;

                case (int)CalculationTypeEn.CountEmployees:
                    //Versicherungsnehmer, die nach Anzahl Mitarbeiter abgerechnet werden und mehr als 5 Mitarbeiter haben, können kein Lösegeld absichern
                    if (_calculationDoc.Berechnungbasis > 5)
                    {
                        _calculationDoc.InkludiereZusatzschutz = false;
                        _calculationDoc.ZusatzschutzAufschlag = 0;
                    }
                    _calculationDoc.Berechnungbasis = _calculationDoc.Versicherungssumme / 1000;
                    _calculationDoc.Beitrag = (_calculationDoc.Berechnungbasis < 4) ? _calculationDoc.Berechnungbasis * 250m :
                        _calculationDoc.Berechnungbasis * 200m;
                    break;
                default:
                    throw new Exception();
            }

            if (_calculationDoc.InkludiereZusatzschutz)
                _calculationDoc.Beitrag *= 1.0m + (decimal)_calculationDoc.ZusatzschutzAufschlag / 100.0m;

            if (_calculationDoc.Risk == (byte)RiskEn.Mittel)
            {
                _calculationDoc.Beitrag = (_calculationDoc.CalculationType is (byte)CalculationTypeEn.BudgetarySum or 
                    (byte)CalculationTypeEn.BudgetarySum) ? _calculationDoc.Beitrag *= 1.2m : _calculationDoc.Beitrag *= 1.3m;
            }
            _calculationDoc.Berechnungbasis = Math.Round(_calculationDoc.Berechnungbasis, 2);
            _calculationDoc.Beitrag = Math.Round(_calculationDoc.Beitrag, 2);
        }
    }
}
