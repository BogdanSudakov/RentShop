using API.Entities;
using API.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>,
        AppUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories  { get; set; }
        public DbSet<Order> Orders  { get; set; }

        public DbSet<RealResearch> RealResearches { get; set; }
        public DbSet<RealResearchIndicator> RealResearchIndicators { get; set; }

        public DbSet<Research> Rearches { get; set; }
        public DbSet<ResearchIndicator> ResearchIndicators { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<AppUser>()
                .HasMany(ur => ur.Orders)
                .WithOne(u => u.Customer)
                .HasForeignKey(ur => ur.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<AppUser>()
                .HasMany(ur => ur.CompletedOrders)
                .WithOne(u => u.LaboratoryAssistant)
                .HasForeignKey(ur => ur.LaboratoryAssistantId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            builder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.ChildCategories)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Order>()
                .HasMany(ur => ur.OrderResearches)
                .WithOne(u => u.Order)
                .HasForeignKey(u => u.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<RealResearch>()
                .HasMany(p => p.RealResearchIndicators)
                .WithOne(s => s.RealResearch)
                .HasForeignKey(s => s.RealResearchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Research>()
                .HasMany(p => p.RealResearches)
                .WithOne(s => s.Research)
                .HasForeignKey(s => s.ResearchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Category>()
                .HasMany(p => p.Researches)
                .WithOne(s => s.Category)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Research>()
                .HasMany(p => p.Indicators)
                .WithMany(s => s.Researches);
            
            builder.ApplyUtcDateTimeConverter();
        }
    }
}