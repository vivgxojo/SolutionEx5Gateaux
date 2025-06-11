using Microsoft.EntityFrameworkCore;

namespace SolutionEx5Gateaux.Models
{
    public class CatalogueGateaux : DbContext
    {
        public CatalogueGateaux(DbContextOptions<CatalogueGateaux> options) : base(options) { }

        public DbSet<Gateau> Gateau { get; set; } //Table Gateau

        public DbSet<Ingredient> Ingredient { get; set; } //Table Ingredient
    }
}
