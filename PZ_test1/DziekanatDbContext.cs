using PZ_test1.Models;

namespace PZ_test1
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DziekanatDbContext : DbContext
    {

        public DziekanatDbContext()
            : base("name=DziekanatDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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