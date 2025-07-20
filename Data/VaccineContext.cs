using Microsoft.EntityFrameworkCore;
using VaccineManagement.Models;

namespace VaccineManagement.Data
{
    public class VaccineContext : DbContext
    {
        public VaccineContext(DbContextOptions<VaccineContext> options)
            : base(options)
        {
        }

        public DbSet<Vaccine> Vaccines { get; set; }
    }
}
