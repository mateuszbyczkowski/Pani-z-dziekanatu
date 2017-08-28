using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PZ_test1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        /*public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }*/
        //to napisałem sam
        public virtual Employees Employees { get; set; }
        public virtual Students Students { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in
            // CookieAuthenticationOptions.AuthenticationType 
            var userIdentity = await manager.CreateIdentityAsync(
                this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here 
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
            return new ApplicationDbContext();
        }

        //moj kod
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
            // one-to-zero or one relationship between ApplicationUser and Customer
            // UserId column in Customers table will be foreign key
//            modelBuilder.Entity<ApplicationUser>()
//                .HasOptional(m => m.Employees)
//                .WithRequired(m => m.ApplicationUser);
////                .Map(p => p.MapKey("UserId"));
////
//            modelBuilder.Entity<ApplicationUser>()
//                .HasOptional(m => m.Students)
//                .WithRequired(m => m.ApplicationUser);
////                .Map(p => p.MapKey("UserId"));

//            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Students>()
            //    .HasMany(m => m.StudentCourses)
            //    .WithRequired(m=> m.Students)
            //    .Map(x =>
            //        {
            //            x.MapKey("StudentId");
            //            x.ToTable("ModelStudentCourses");
            //        }
            //    );
            //temat obrad
            //modelBuilder.Entity<Students>()
            //    .HasMany(u => u.StudentCourses)
            //    .WithMany()
            //    .Map(x =>
            //    {
            //        x.MapLeftKey("Id");
            //        x.MapRightKey("TheirFriends");
            //        x.ToTable("ModelStudentCourses");
            //    });

            //modelBuilder.Entity<Students>().HasMany<StudentCourses>(s => s.StudentCourses).WithRequired(c => c.Students).Map(c =>
            //{
            //    c.MapKey("Id");
            //    c.ToTable("ModelStudentCourses");
            //});

            base.OnModelCreating(modelBuilder);
            //koniec tematu obrad
        }

      /*  public virtual DbSet<CoursesOfStudy> CoursesOfStudy { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Fields> Fields { get; set; }
        public virtual DbSet<FilledFields> FilledFields { get; set; }
        public virtual DbSet<Forms> Forms { get; set; }
        public virtual DbSet<RepetedSubject> RepetedSubject { get; set; }
        public virtual DbSet<StudentCourses> StudentCourses { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Timetable> Timetable { get; set; }*/
    }
}


////moj kod
//protected override void OnModelCreating(DbModelBuilder modelBuilder)
//{
//    base.OnModelCreating(modelBuilder);

//    // one-to-zero or one relationship between ApplicationUser and Customer
//    // UserId column in Customers table will be foreign key
//    modelBuilder.Entity<ApplicationUser>()
//        .HasOptional(m => m.Employees)
//        .WithRequired(m => m.ApplicationUser)
//        .Map(p => p.MapKey("UserId"));

//    modelBuilder.Entity<ApplicationUser>()
//        .HasOptional(m => m.Students)
//        .WithRequired(m => m.ApplicationUser)
//        .Map(p => p.MapKey("UserId"));
//}