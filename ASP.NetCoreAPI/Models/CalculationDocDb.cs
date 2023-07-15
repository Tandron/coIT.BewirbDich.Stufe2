using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace ASP.NetCoreAPI.Models
{
    public class CalculationDocDb : IdentityDbContext
    {
        public CalculationDocDb(DbContextOptions<CalculationDocDb> options) : base(options)
        {
            
        }

        public DbSet<CalculationDoc> CalculationDocs { get; set; }
    }
}
