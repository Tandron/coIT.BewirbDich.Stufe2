using ASP.NetCoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
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

        public CalculationDocController(ILogger<CalculationDocController> logger)
        {
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
    }
}