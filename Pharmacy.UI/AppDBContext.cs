using System.Data.Entity;

namespace Pharmacy.UI
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() : base("DefaultConnection") { }
        public DbSet<User> Users { get; set; }
    }
}
