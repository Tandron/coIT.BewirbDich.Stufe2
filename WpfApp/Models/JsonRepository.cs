using ASP.NetCoreAPI.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace WpfApp.Models
{
    public class JsonRepository
    {
        static public List<CalculationDoc> JsonDeserializeRepository(string strJson)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<List<CalculationDoc>>(strJson, options) ?? new List<CalculationDoc>();
        }
    }
}
