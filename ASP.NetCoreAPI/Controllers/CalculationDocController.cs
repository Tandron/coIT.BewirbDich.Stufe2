using ASP.NetCoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NetCoreAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationDocController : ControllerBase
    {
        private readonly CalculationDocDb _context;

        public CalculationDocController(CalculationDocDb context)
        {
            _context = context;
        }
 
        [HttpGet(Name = "GetCalculationDoc")]
        public IEnumerable<CalculationDoc> Get()
        {
            return _context.CalculationDocs.ToList();
        }

        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 409)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpPost("additem", Name = "PostAddItem")]
        public IActionResult PostAddItem([FromBody] CalculationDoc calculationDoc)
        {
            bool isOk = CheckCalculationDoc(calculationDoc);

            if (isOk)
            {
                _context.CalculationDocs.Add(calculationDoc);
                _context.SaveChanges();
            }
            return Ok(isOk ? calculationDoc.Id : -1);
        }

        private bool CheckCalculationDoc(CalculationDoc calculationDoc)
            => calculationDoc.CalculationType < Enum.GetValues(typeof(CalculationDoc.CalculationTypeEn)).Length &&
               calculationDoc.Typ < Enum.GetValues(typeof(CalculationDoc.DocumentTypeEn)).Length &&
               calculationDoc.Risk < Enum.GetValues(typeof(CalculationDoc.RiskEn)).Length;
    }
}