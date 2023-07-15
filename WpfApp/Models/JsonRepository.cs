using ASP.NetCoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class JsonRepository
    {
        private readonly List<CalculationDoc> _documents = new();

        public JsonRepository(string strJson)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            _documents = JsonSerializer.Deserialize<List<CalculationDoc>>(strJson, options) ?? new List<CalculationDoc>();
        }

        public List<CalculationDoc> CalculationDocs { get { return _documents; } }
    }
}
