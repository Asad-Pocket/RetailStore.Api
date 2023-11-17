using Microsoft.EntityFrameworkCore;
using RetailStore.Api.Models;

namespace RetailStore.Api.Models.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Company> CompanyList { get; set; }
        public DbSet<Item> ItemList { get; set; }
        public DbSet<UserDetails> UserDetailsList { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Company>().
                HasMany(i => i.items).
                WithOne(m => m.Company).
                HasForeignKey(e => e.CompanyId).
                IsRequired();

          
            builder.Entity<Item>()
            .ToTable("ItemList")  // Ensure this matches your actual table name in the database
            .HasIndex(e => e.Name)
            .IsUnique();


            builder.Entity<Company>()
             .HasIndex(e => e.Name)
          .IsUnique();

            builder.Entity<UserDetails>()
                 .HasKey(u => u.Email); 

        }
    }
}
