using Microsoft.AspNet.Identity.EntityFramework;
using PZ_test1.Models;

namespace PZ_test1
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DziekanatDbContext : IdentityDbContext<ApplicationUser>
    {

        public DziekanatDbContext()
            : base("name=DziekanatDbContext1")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser");
            //modelBuilder.Entity<ApplicationUser>().Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<ApplicationUser>().HasOptional(d => d.Students).WithRequired(p => p.ApplicationUser);
            modelBuilder.Entity<ApplicationUser>().HasOptional(e => e.Employees).WithRequired(k => k.ApplicationUser);

            base.OnModelCreating(modelBuilder);
        }

        public static DziekanatDbContext Create()
        {
            return new DziekanatDbContext();
        }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<KierunkiStudiow> KierunkiStudiow { get; set; }
        public virtual DbSet<ListaKierunkow> ListaKierunkow { get; set; }
        public virtual DbSet<PowtarzanePrzedmioty> PowtarzanePrzedmioty { get; set; }
        public virtual DbSet<PrzedluzenieSesji> PrzedluzenieSesji { get; set; }
        public virtual DbSet<Termin> Termin { get; set; }
        public virtual DbSet<Warunki> Warunki { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}