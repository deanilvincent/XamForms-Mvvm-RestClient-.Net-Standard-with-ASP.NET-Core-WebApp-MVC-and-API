using Microsoft.EntityFrameworkCore;

namespace WebApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext (DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:sea0001.database.windows.net,1433;Initial Catalog=mydb01;Persist Security Info=False;User ID=saa;Password=Pr0xxxy321;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public DbSet<WebApp.Models.Product> Product { get; set; }
    }
}
