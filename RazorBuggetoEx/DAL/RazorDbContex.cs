using Microsoft.EntityFrameworkCore;
using RazorBuggetoEx.Models;

namespace RazorBuggetoEx.DAL
{
    public class RazorDbContex : DbContext
    {
        public RazorDbContex(DbContextOptions<RazorDbContex> options):base(options)
        {
                
        }

        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
