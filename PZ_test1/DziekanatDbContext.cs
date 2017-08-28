using PZ_test1.Models;

namespace PZ_test1
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DziekanatDbContext : DbContext
    {
        // Your context has been configured to use a 'DziekanatDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PZ_test1.DziekanatDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DziekanatDbContext' 
        // connection string in the application configuration file.
        public DziekanatDbContext()
            : base("name=DziekanatDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

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