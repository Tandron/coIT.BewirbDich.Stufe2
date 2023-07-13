using System;

namespace ASP.NetCoreAPI.Models
{
    public class CalculationDoc
    {
        public Guid Id { get; }

        public DocumentType Typ { get; set; }
        public CalculationType CalculationType { get; set; }
        /// <summary>
        /// Berechnungsart Umsatz => Jahresumsatz in Euro,
        /// Berechnungsart Haushaltssumme => Haushaltssumme in Euro,
        /// Berechnungsart AnzahlMitarbeiter => Ganzzahl
        /// </summary>
        public decimal Berechnungbasis { get; set; }

        public bool InkludiereZusatzschutz { get; set; }
        public float ZusatzschutzAufschlag { get; set; }

        //Gibt es nur bei Unternehmen, die nach Umsatz abgerechnet werden
        public bool HatWebshop { get; set; }

        public Risk Risk { get; set; }

        public decimal Beitrag { get; set; }

        public bool VersicherungsscheinAusgestellt { get; set; }
        public decimal Versicherungssumme { get; set; }

        public CalculationDoc()
        {
            Id = Guid.NewGuid();
        }
    }
}
