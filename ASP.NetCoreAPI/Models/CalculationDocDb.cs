using Microsoft.EntityFrameworkCore;
using System;

namespace ASP.NetCoreAPI.Models
{
    public class CalculationDocDb : DbContext
    {
        public CalculationDocDb(DbContextOptions<CalculationDocDb> options) : base(options)
        {
            
        }

        public DbSet<CalculationDoc> CalculationDocs { get; set; }
    }
}
