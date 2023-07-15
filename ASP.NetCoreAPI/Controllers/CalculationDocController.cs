using ASP.NetCoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Metadata;

namespace ASP.NetCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationDocController : ControllerBase
    {
        private static readonly double[] Summaries = new[]
        {
            21.54, 434.43, 21.32, 21.32, 3121.554, 2121.32
        };

        private readonly ILogger<CalculationDocController> _logger;
        private readonly CalculationDocDb _context;

        public CalculationDocController(ILogger<CalculationDocController> logger, CalculationDocDb context)
        {
            _context = context;
            _logger = logger;
        }
 
        [HttpGet(Name = "GetCalculationDoc")]
        public IEnumerable<CalculationDoc> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new CalculationDoc
            {
                Beitrag = (decimal)Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 409)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpPost("additem", Name = "PostAddItem")]
        public IActionResult PostAddItem([FromBody] CalculationDoc calculationDoc)
        {
            return Ok();
        }

        // Ja nicht so schön, viel zuviele Parameter
        private CalculationDoc CheckCalculationDoc(string typ, string calculationType, string berechnungbasis, string inkludiereZusatzschutz,
            string zusatzschutzAufschlag, string hatWebshop, string risk, string beitrag,
            string versicherungsscheinAusgestellt, string versicherungssumme, out bool isOk)
        {
            CalculationDoc calculationDoc = new();
            bool typeOk = byte.TryParse(typ, out byte typeB);
            bool calculationTypeOk = byte.TryParse(calculationType, out byte calculationTypeB);
            bool berechnungbasisOk = decimal.TryParse(berechnungbasis, out decimal berechnungbasisDec);
            bool inkludiereZusatzschutzOk = bool.TryParse(inkludiereZusatzschutz, out bool inkludiereZusatzschutzB);
            bool zusatzschutzAufschlagOk = float.TryParse(zusatzschutzAufschlag, out float zusatzschutzAufschlagFloat);
            bool hatWebshopOk = bool.TryParse(hatWebshop, out bool hatWebshopBool);
            bool riskOk = byte.TryParse(risk, out byte riskB);
            bool beitragOk = decimal.TryParse(beitrag, out decimal beitragDec);
            bool versicherungsscheinAusgestelltOk = bool.TryParse(versicherungsscheinAusgestellt, out bool versicherungsscheinAusgestelltBool);
            bool versicherungssummeOk = decimal.TryParse(versicherungssumme, out decimal versicherungssummeDec);

            if (typeOk) { calculationDoc.Typ = typeB; }
            if (calculationTypeOk) { calculationDoc.CalculationType = calculationTypeB; }
            if (berechnungbasisOk) { calculationDoc.Berechnungbasis = berechnungbasisDec; }
            if (inkludiereZusatzschutzOk) { calculationDoc.InkludiereZusatzschutz = inkludiereZusatzschutzB; }
            if (zusatzschutzAufschlagOk) { calculationDoc.ZusatzschutzAufschlag = zusatzschutzAufschlagFloat; }
            if (hatWebshopOk) { calculationDoc.HatWebshop = hatWebshopBool; }
            if (riskOk) { calculationDoc.Risk = riskB; }
            if (beitragOk) { calculationDoc.Beitrag = beitragDec; }
            if (versicherungsscheinAusgestelltOk) { calculationDoc.VersicherungsscheinAusgestellt = versicherungsscheinAusgestelltBool; }
            if (versicherungssummeOk) { calculationDoc.Versicherungssumme = versicherungssummeDec; }

            isOk = typeOk && calculationTypeOk && berechnungbasisOk && inkludiereZusatzschutzOk && zusatzschutzAufschlagOk && hatWebshopOk &&
                riskOk && beitragOk && versicherungsscheinAusgestelltOk && versicherungssummeOk;
            return calculationDoc;
        }

        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 409)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpPost("additem/{typ}/{calculationType}/{berechnungbasis}/{inkludiereZusatzschutz}/{zusatzschutzAufschlag}/{hatWebshop}/{risk}/{beitrag}/{versicherungsscheinAusgestellt}/{versicherungssumme}", Name = "PostAddItemUrl")]
        public IActionResult PostAddItemUrl(string typ, string calculationType, string berechnungbasis, string inkludiereZusatzschutz,
            string zusatzschutzAufschlag, string hatWebshop, string risk, string beitrag,
            string versicherungsscheinAusgestellt, string versicherungssumme)
        {
            CalculationDoc calculationDoc = CheckCalculationDoc(typ, calculationType, berechnungbasis, inkludiereZusatzschutz,
                zusatzschutzAufschlag, hatWebshop, risk, beitrag, versicherungsscheinAusgestellt, versicherungssumme, out bool isOk);

            if (!isOk)
            {
                _context.CalculationDocs.Add(calculationDoc);
                _context.SaveChanges();
            }
            return Ok();
        }
    }
}