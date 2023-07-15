using ASP.NetCoreAPI.Models;
using Fluent.Infrastructure.FluentModel;
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
        private readonly ApplicationDbContext _context;

        public CalculationDocController(ILogger<CalculationDocController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }
        //public CalculationDocController(ILogger<CalculationDocController> logger)
        //{
        //    _logger = logger;
        //}

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

        private CalculationDoc CheckCalculationDoc(string typ, string calculationType, string berechnungbasis, string inkludiereZusatzschutz,
            string zusatzschutzAufschlag, string hatWebshop, string risk, string beitrag,
            string versicherungsscheinAusgestellt, string versicherungssumme, out bool isOk)
        {
            CalculationDoc calculationDoc = new();
            bool typeOk = byte.TryParse(typ, out byte typeB);
            bool calculationTypeOk = byte.TryParse(calculationType, out byte calculationTypeB);

            if (typeOk) { calculationDoc.Typ = typeB; }
            if (calculationTypeOk) { calculationDoc.CalculationType = calculationTypeB; }

            isOk = typeOk && calculationTypeOk;
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
                //context.Products.Add(product);
                //context.SaveChanges();
            }
            return Ok();
        }
    }
}