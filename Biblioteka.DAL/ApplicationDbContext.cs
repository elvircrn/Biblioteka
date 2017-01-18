namespace Biblioteka.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Model;
    using Users;
    using Items;

    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext1")
        {
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Record> Records { get; set; }

        public DbSet<Clan> Clans { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Knjiga> Knjigas { get; set; } // Still not a typo

        public DbSet<Worker> Workers { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<ImageData> ImageDatas { get; set; } // This isn't a typo

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("EC17455");

            modelBuilder.Entity<User>()
            .HasMany(p => p.Roles)
            .WithMany(x => x.Users);

            modelBuilder.Entity<Knjiga>()
            .HasMany(p => p.SpisakAutora)
            .WithMany(x => x.Knjigas);

            modelBuilder.Entity<Knjiga>()
            .HasMany(p => p.Clans)
            .WithMany(x => x.WishList);
        }
    }
}
