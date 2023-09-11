using Microsoft.EntityFrameworkCore;

namespace Projet.Api.Rest.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        //Déclarations des datatables...
        public DbSet<ItemModel> ItemModels { get; set; } = null!;
    }
}
